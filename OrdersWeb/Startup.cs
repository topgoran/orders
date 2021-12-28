using OrdersApp.Data.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrdersWeb.Repository;
using OrdersWeb.Repository.Abstract;
using OrdersWeb.Repository.RepositoryClasses;
using System;
using Newtonsoft.Json.Serialization;
using GraphQL.Server;
using GraphQL.Types;
using OrdersWeb.GraphQL;
using Microsoft.Extensions.Logging;
using GraphQL.DataLoader;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using OrdersWeb.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using OrdersApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using OrdersWeb.GraphQL.Types;
using System.Threading.Tasks;
using GraphQL.Validation;
using GraphQL.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using System.Collections.Generic;
using System.Linq;

namespace OrdersWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<OrdersContext>(
                options => options.UseSqlite(connectionString));

            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });


            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMenuItemRepository, MenuItemRepository>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddIdentity<User, IdentityRole<Guid>>(options => {
                options.SignIn.RequireConfirmedAccount = true;
                /*options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;*/
                options.Password.RequiredLength = 8;

            }).AddEntityFrameworkStores<OrdersContext>();

            services
                .AddScoped<OrdersSchema>()
                .AddScoped<Mutation>()
                .AddScoped<Query>()
                .AddGraphQL()
                .AddSystemTextJson()
                .AddDataLoader()
                .AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User })
                .AddGraphTypes(typeof(OrdersSchema), ServiceLifetime.Scoped);

            services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
            services.AddSingleton<DataLoaderDocumentListener>();

            services.AddScoped<RegistrationRepository>();

            //AUTH
            services.AddHttpContextAccessor();
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);

                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    RequireExpirationTime = false
                };
            });

            services.AddGraphQLAuth(_ =>
            {
                _.AddPolicy("Admin", p => p.RequireClaim(ClaimTypes.Role, "Admin"));
                _.AddPolicy("Member", p => p.RequireClaim(ClaimTypes.Role, "Member"));
            });

            services.AddSpaStaticFiles(configuration => {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsApiPolicy",
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                        .WithHeaders(new[] { "authorization", "content-type", "accept" })
                        .WithMethods(new[] { "GET", "POST", "PUT", "DELETE", "OPTIONS" })
                        ;
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, RoleManager<IdentityRole<Guid>> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsApiPolicy");

            CreateRoles(roleManager);


            app.UseAuthentication();
            app.UseAuthorization();

            //GraphQL
            app.UseWebSockets();
            app.UseGraphQLWebSockets<OrdersSchema>();
            app.UseGraphQL<OrdersSchema>();

            // use graphql-playground at default url /ui/playground
            app.UseGraphQLPlayground();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //CreateRoles(serviceProvider);

            app.UseStaticFiles(); 
            app.UseSpaStaticFiles();
        }

        private static void CreateRoles(RoleManager<IdentityRole<Guid>> roleManager)
        {
            List<string> roles = Enum.GetNames(typeof(Roles)).ToList();
            foreach(string roleToAdd in roles){
                var role = roleManager.RoleExistsAsync(roleToAdd);
                Task.WaitAll(role);
                bool exists = role.Result;

                if (!exists) {
                    var newRole = new IdentityRole<Guid> { Name = roleToAdd };
                    roleManager.CreateAsync(newRole).Wait();
                    roleManager.AddClaimAsync(newRole, new Claim(ClaimTypes.Role, roleToAdd)).Wait();
                }
            }
        }
    }
}
