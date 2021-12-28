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
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemRepository _repository;
        private readonly IMapper _mapper;

        public OrderItemController(IOrderItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderItemReadDto>> GetAllOrderItems()
        {
            var OrderItems = _repository.FindAll();

            return Ok(_mapper.Map<IEnumerable<OrderItemReadDto>>(OrderItems));
        }

        [HttpGet("{id}", Name = "GetOrderItemuById")]
        public ActionResult<OrderItemReadDto> GetOrderItemuById(Guid id)
        {
            var OrderItem = _repository.FindById(id);
            if (OrderItem != null) {
                return Ok(_mapper.Map<OrderItemReadDto>(OrderItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<OrderItemReadDto> CreateOrderItem(OrderCreateDto orderItemCreateDto)
        {

            var orderItemModel = _mapper.Map<OrderItem>(orderItemCreateDto);
            _repository.Create(orderItemModel);
            _repository.SaveChanges();

            var orderItemReadDto = _mapper.Map<OrderItemReadDto>(orderItemModel);

            return CreatedAtRoute(nameof(GetOrderItemuById), new { Id = orderItemReadDto.Id }, orderItemReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOrderItem(Guid id, OrderItemUpdateDto orderItemUpdateDto)
        {
            var orderItemModelFromRepo = _repository.FindById(id);
            if (orderItemModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(orderItemUpdateDto, orderItemModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialOrderItemUpdate(Guid id, JsonPatchDocument<OrderItemUpdateDto> patchDoc)
        {
            var orderItemModelFromRepo = _repository.FindById(id);
            if (orderItemModelFromRepo == null)
            {
                return NotFound();
            }

            var orderItemToPatch = _mapper.Map<OrderItemUpdateDto>(orderItemModelFromRepo);
            patchDoc.ApplyTo(orderItemToPatch, ModelState);
            if (!TryValidateModel(orderItemToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(orderItemToPatch, orderItemModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrderItem(Guid id)
        {
            var orderItemModelFromRepo = _repository.FindById(id);
            if (orderItemModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.Delete(orderItemModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
