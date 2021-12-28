using AutoMapper;
using OrdersApp.Data.DataAccess;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OrdersApp.Data.Models;
using OrdersWeb.DTOs;
using OrdersWeb.DTOs.Create;
using OrdersWeb.DTOs.Update;
using OrdersWeb.Repository;
using OrdersWeb.Repository.RepositoryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace OrdersWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Member")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _repository;
        private readonly IMapper _mapper;

        public MenuController(IMenuRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MenuReadDto>> GetAllMenus()
        {
            var Menus = _repository.FindAll();

            return Ok(_mapper.Map<IEnumerable<MenuReadDto>>(Menus));
        }

        [HttpGet("{id}", Name = "GetMenuById")]
        public ActionResult<MenuReadDto> GetMenuById(Guid id) {
            var Menu = _repository.FindById(id);
            if (Menu != null)
            {
                return Ok(_mapper.Map<MenuReadDto>(Menu));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<MenuReadDto> CreateMenu(MenuCreateDto menuCreateDto) {

            var menuModel = _mapper.Map<Menu>(menuCreateDto);
            _repository.Create(menuModel);
            _repository.SaveChanges();

            var menuReadDto = _mapper.Map<MenuReadDto>(menuModel);

            return CreatedAtRoute(nameof(GetMenuById), new { Id = menuReadDto.Id}, menuReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMenu(Guid id, MenuUpdateDto menuUpdateDto) {
            var menuModelFromRepo = _repository.FindById(id);
            if (menuModelFromRepo == null) {
                return NotFound();
            }

            _mapper.Map(menuUpdateDto, menuModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialMenuUpdate(Guid id, JsonPatchDocument<MenuUpdateDto> patchDoc) {
            var menuModelFromRepo = _repository.FindById(id);
            if (menuModelFromRepo == null)
            {
                return NotFound();
            }

            var menuToPatch = _mapper.Map<MenuUpdateDto>(menuModelFromRepo);
            patchDoc.ApplyTo(menuToPatch, ModelState);
            if (!TryValidateModel(menuToPatch)) {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(menuToPatch, menuModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMenu(Guid id) {
            var menuModelFromRepo = _repository.FindById(id);
            if (menuModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.Delete(menuModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
