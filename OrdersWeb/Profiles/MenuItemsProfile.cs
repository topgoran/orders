using AutoMapper;
using OrdersApp.Data.Models;
using OrdersWeb.DTOs.Create;
using OrdersWeb.DTOs.Read;
using OrdersWeb.DTOs.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.Profiles
{
    public class MenuItemsProfile : Profile
    {
        public MenuItemsProfile()
        {
            CreateMap<MenuItem, MenuItemReadDto>();
            CreateMap<MenuItemCreateDto, MenuItem>();
            CreateMap<MenuItemUpdateDto, MenuItem>();
            CreateMap<MenuItem, MenuItemUpdateDto>();
        }
    }
}
