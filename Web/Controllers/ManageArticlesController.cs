using Articles.WriteSide.Commands;
using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers;
using ServiceReference1;
using System;
using System.Threading.Tasks;
using Utils;
using Web.Models.Articles;

namespace Web.Controllers
{
    [Route("api/v1/admin/articles")]
    public class ManageArticlesController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IArticlesService _articlesService;
        private readonly ILog _logger;

        public ManageArticlesController(IMapper mapper, IArticlesService articlesService, ILog logger)
            : base(logger)
        {
            _mapper = mapper;
            _articlesService = articlesService;
            _logger = logger;
        }

        [HttpDelete("{articleId:guid}")]
        public async Task<IActionResult> DeleteArticleAsync(Guid articleId)
        {
            try
            {
                var endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleWriteServiceQueue);
                await endPoint.Send<IDeleteArticleCommand>(new
                {
                    Id = articleId
                });

                return Accepted();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IActionResult InsertArticle(AddArticleViewModel model)
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

                //TODO: Implement some logic here.

                return Accepted();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet("{articleId:guid}")]
        public async Task<IActionResult> FindArticleAsync(Guid articleId)
        {
            try
            {
                ArticleDto dto = await _articlesService.GetArticleByIdAsync(articleId);

                if (dto == null)
                {
                    return NotFound();
                }

                var response = _mapper.Map<EditArticleViewModel>(dto);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut("{articleId:guid}")]
        public async Task<IActionResult> UpdateArticleAsync(Guid articleId, [FromBody]EditArticleViewModel model)
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
                await endPoint.Send<IUpdateArticleCommand>(new
                {
                    model.Id,
                    model.Body
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
