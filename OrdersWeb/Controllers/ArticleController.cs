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
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _repository;
        private readonly IMapper _mapper;

        public ArticleController(IArticleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ArticleReadDto>> GetAllArticles()
        {
            var Articles = _repository.FindAll();

            return Ok(_mapper.Map<IEnumerable<ArticleReadDto>>(Articles));
        }

        [HttpGet("{id}", Name = "GetArticleById")]
        public ActionResult<ArticleReadDto> GetArticleById(Guid id)
        {
            var Article = _repository.FindById(id);
            if (Article != null)
            {
                return Ok(_mapper.Map<ArticleReadDto>(Article));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<ArticleReadDto> CreateArticle(ArticleCreateDto articleCreateDto)
        {

            var articleModel = _mapper.Map<Article>(articleCreateDto);
            _repository.Create(articleModel);
            _repository.SaveChanges();

            var articleReadDto = _mapper.Map<ArticleReadDto>(articleModel);

            return CreatedAtRoute(nameof(GetArticleById), new { Id = articleReadDto.Id }, articleReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateArticle(Guid id, ArticleUpdateDto articleUpdateDto)
        {
            var articleModelFromRepo = _repository.FindById(id);
            if (articleModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(articleUpdateDto, articleModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialArticleUpdate(Guid id, JsonPatchDocument<ArticleUpdateDto> patchDoc)
        {
            var articleModelFromRepo = _repository.FindById(id);
            if (articleModelFromRepo == null)
            {
                return NotFound();
            }

            var articleToPatch = _mapper.Map<ArticleUpdateDto>(articleModelFromRepo);
            patchDoc.ApplyTo(articleToPatch, ModelState);
            if (!TryValidateModel(articleToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(articleToPatch, articleModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteArticle(Guid id)
        {
            var articleModelFromRepo = _repository.FindById(id);
            if (articleModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.Delete(articleModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
