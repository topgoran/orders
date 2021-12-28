using OrdersApp.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using OrdersApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OrdersWeb.GraphQL.Types;

namespace OrdersWeb.Repository.RepositoryClasses
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(OrdersContext ordersContext) : base(ordersContext) { }

        public UserPageResponse FindCustom(int? pageNumber, int? pageSize, string filter)
        {
            IQueryable<User> users = ordersContext.Users;

            if(!string.IsNullOrEmpty(filter))
                users = users.Where(u => ((filter == null || u.FirstName.Contains(filter)) || (filter == null || u.LastName.Contains(filter))));
            if (pageNumber != null && pageSize != null) {
                users = users.Skip((int)((pageNumber - 1) * pageSize)).Take((int)pageSize);
            }

            return new UserPageResponse
            { 
                Users = users, 
                Count = users.Count()
            };
        }

        public User Update(User dbEntity, User entity)
        {
            dbEntity.FirstName = entity.FirstName;
            dbEntity.LastName = entity.LastName;
            dbEntity.PhoneNumber = entity.PhoneNumber;
            dbEntity.Address = entity.Address;
            dbEntity.City = entity.City;
            dbEntity.State = entity.State;

            ordersContext.Set<User>().Update(dbEntity);
            SaveChanges();
            return dbEntity;
        }
    }
}
