using AutoMapper;
using OrdersApp.Data.Models;
using OrdersWeb.DTOs;
using OrdersWeb.DTOs.Create;
using OrdersWeb.DTOs.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.Profiles
{
    public class MenusProfile : Profile
    {
        public MenusProfile()
        {
            CreateMap<Menu, MenuReadDto>(); 
            CreateMap<MenuCreateDto, Menu>();
            CreateMap<MenuUpdateDto, Menu>();
            CreateMap<Menu, MenuUpdateDto>();
        }
    }
}
