using Articles.WriteSide.Commands;
using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using System;
using System.Threading.Tasks;
using Utils;
using Web.Models.Articles;

namespace Server.Controllers
{
    [Route("api/v1/admin/categories")]
    public class ManageCategoriesController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IArticlesService _articlesService;
        private readonly ILog _logger;

        public ManageCategoriesController(IMapper mapper, IArticlesService articlesService, ILog logger)
            : base(logger)
        {
            _mapper = mapper;
            _articlesService = articlesService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            try
            {
                CategoryDto[] dto = await _articlesService.GetCategoriesAsync();

                var response = _mapper.Map<CategoryItemViewModel[]>(dto);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet("{categoryId:guid}/articles")]
        public async Task<IActionResult> GetArticlesAsync(Guid categoryId)
        {
            try
            {
                ArticleDto[] dto = await _articlesService.GetArticlesByCategoryIdAsync(categoryId, 1, 10);

                var response = _mapper.Map<ArticleItemViewModel[]>(dto);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete("{categoryId:guid}")]
        public async Task<IActionResult> DeleteCategoryAsync(Guid categoryId)
        {
            try
            {
                var endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleWriteServiceQueue);
                await endPoint.Send<IDeleteArticleCommand>(new
                {
                    Id = categoryId
                });

                return Accepted();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertCategoryAsync(AddCategoryViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status422UnprocessableEntity);
                }

                var endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleWriteServiceQueue);
                await endPoint.Send<IInsertCategoryCommand>(new
                {
                    model.Description,
                    model.ImageUrl,
                    model.Importance,
                    model.Title
                });

                return Accepted();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet("{categoryId:guid}")]
        public async Task<IActionResult> FindCategoryAsync(Guid categoryId)
        {
            try
            {
                CategoryDto dto = await _articlesService.GetCategoryByIdAsync(categoryId);

                if (dto == null)
                {
                    return NotFound();
                }

                var response = _mapper.Map<EditCategoryViewModel>(dto);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut("{categoryId:guid}")]
        public async Task<IActionResult> UpdateCategoryAsync(Guid categoryId, [FromBody]EditCategoryViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status422UnprocessableEntity);
                }

                var endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleWriteServiceQueue);
                await endPoint.Send<IUpdateCategoryCommand>(new
                {
                    categoryId,
                    model.Description,
                    model.ImageUrl,
                    model.Importance,
                    model.Title
                });

                return Accepted();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}