using AutoMapper;
using OrdersApp.Data.DataAccess;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OrdersApp.Data.Models;
using OrdersWeb.DTOs;
using OrdersWeb.DTOs.Create;
using OrdersWeb.DTOs.Read;
using OrdersWeb.DTOs.Update;
using OrdersWeb.Repository;
using OrdersWeb.Repository.Abstract;
using OrdersWeb.Repository.RepositoryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemRepository _repository;
        private readonly IMapper _mapper;

        public MenuItemController(IMenuItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MenuItemReadDto>> GetAllMenus()
        {
            var MenuItems = _repository.FindAll();

            return Ok(_mapper.Map<IEnumerable<MenuItemReadDto>>(MenuItems));
        }

        [HttpGet("{id}", Name = "GetMenuItemById")]
        public ActionResult<MenuItemReadDto> GetMenuItemById(Guid id)
        {
            var MenuItem = _repository.FindById(id);
            if (MenuItem != null)
            {
                return Ok(_mapper.Map<MenuItemReadDto>(MenuItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<MenuItemReadDto> CreateMenuItem(MenuItemCreateDto menuItemCreateDto)
        {

            var menuItemModel = _mapper.Map<MenuItem>(menuItemCreateDto);
            _repository.Create(menuItemModel);
            _repository.SaveChanges();

            var menuItemReadDto = _mapper.Map<MenuItemReadDto>(menuItemModel);

            return CreatedAtRoute(nameof(GetMenuItemById), new { Id = menuItemReadDto.Id }, menuItemReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMenuItem(Guid id, MenuItemUpdateDto menuItemUpdateDto)
        {
            var menuItemModelFromRepo = _repository.FindById(id);
            if (menuItemModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(menuItemUpdateDto, menuItemModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialMenuItemUpdate(Guid id, JsonPatchDocument<MenuItemUpdateDto> patchDoc)
        {
            var menuItemModelFromRepo = _repository.FindById(id);
            if (menuItemModelFromRepo == null)
            {
                return NotFound();
            }

            var menuItemToPatch = _mapper.Map<MenuItemUpdateDto>(menuItemModelFromRepo);
            patchDoc.ApplyTo(menuItemToPatch, ModelState);
            if (!TryValidateModel(menuItemToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(menuItemToPatch, menuItemModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMenuItem(Guid id)
        {
            var menuItemModelFromRepo = _repository.FindById(id);
            if (menuItemModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.Delete(menuItemModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
