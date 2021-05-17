using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicCore.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApiCore.Controllers
{
    [Route("api/sections")]
    [ApiController]
    [AllowAnonymous]
    [SwaggerTag("Контроллер работы с областями")]
    public class SectionsControllers: BaseApiController
    {
        private readonly ISectionService _sectionService;

        public SectionsControllers(IHttpContextAccessor contextAccessor, ILogger<BaseApiController> logger,
            ISectionService sectionService) : base(contextAccessor, logger)
        {
            _sectionService = sectionService;
        }

        [ProducesResponseType(typeof(List<SectionDto>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpGet("{parentId}")]
        public async Task<List<SectionDto>> GetAreaAsync([FromRoute] int parentId)
        {
            var result = await _sectionService.GetSectionsAsync(parentId);
            if (result.IsFailed)
                return result.Value;
            return result.Value;
        }
    }
}