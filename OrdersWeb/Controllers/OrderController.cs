using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OrdersApp.Data.Models;
using OrdersWeb.DTOs.Create;
using OrdersWeb.DTOs.Read;
using OrdersWeb.DTOs.Update;
using OrdersWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderReadDto>> GetAllOrders()
        {
            var Orders = _repository.FindAll();

            return Ok(_mapper.Map<IEnumerable<OrderReadDto>>(Orders));
        }

        [HttpGet("{id}", Name = "GetOrderById")]
        public ActionResult<OrderReadDto> GetOrderById(Guid id)
        {
            var Order = _repository.FindById(id);
            if (Order != null)
            {
                return Ok(_mapper.Map<OrderReadDto>(Order));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<OrderReadDto> CreateOrder(OrderCreateDto orderCreateDto)
        {

            var orderModel = _mapper.Map<Order>(orderCreateDto);
            _repository.Create(orderModel);
            _repository.SaveChanges();

            var orderReadDto = _mapper.Map<OrderReadDto>(orderModel);

            return CreatedAtRoute(nameof(GetOrderById), new { Id = orderReadDto.Id }, orderReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOrder(Guid id, OrderUpdateDto orderUpdateDto)
        {
            var orderModelFromRepo = _repository.FindById(id);
            if (orderModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(orderUpdateDto, orderModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialOrderUpdate(Guid id, JsonPatchDocument<OrderUpdateDto> patchDoc)
        {
            var orderModelFromRepo = _repository.FindById(id);
            if (orderModelFromRepo == null)
            {
                return NotFound();
            }

            var orderToPatch = _mapper.Map<OrderUpdateDto>(orderModelFromRepo);
            patchDoc.ApplyTo(orderToPatch, ModelState);
            if (!TryValidateModel(orderToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(orderToPatch, orderModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(Guid id)
        {
            var orderModelFromRepo = _repository.FindById(id);
            if (orderModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.Delete(orderModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
    
}
