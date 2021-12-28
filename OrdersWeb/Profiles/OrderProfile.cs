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
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrderUpdateDto, Order>();
            CreateMap<Order, OrderUpdateDto>();
        }

    }
}
