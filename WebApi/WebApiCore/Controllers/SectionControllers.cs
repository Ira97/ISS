using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicCore.Service;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApiCore.Controllers
{
    [Route("api/section")]
    [ApiController]
    [AllowAnonymous]
    [SwaggerTag("Контроллер работы с областями")]
    public class SectionControllers: BaseApiController
    {
        private readonly ISectionService _sectionService;

        public SectionControllers(IHttpContextAccessor contextAccessor, ILogger<BaseApiController> logger,
            ISectionService sectionService) : base(contextAccessor, logger)
        {
            _sectionService = sectionService;
        }

        [ProducesResponseType(typeof(List<SectionDto>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpGet("{parentId}")]
        public async Task<MainSectionDto> GetSectionAsync([FromRoute] int parentId)
        {
            var result = await _sectionService.GetSectionsAsync(parentId);
            if (result.IsFailed)
                return result.Value;
            return result.Value;
        }
        
        [ProducesResponseType(typeof(List<SectionDto>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPost]
        public async Task<Result> AddSectionAsync([FromBody] SectionDto sectionDto)
        {
            var result = await _sectionService.CreateSectionAsync(sectionDto);
            if (result.IsFailed)
                return result;
            return result;
        }

        [ProducesResponseType(typeof(List<SectionDto>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPost("research")]
        public async Task<Result> AddResearchAsync([FromBody] ResearchDto research)
        {
            var result = await _sectionService.CreateResearchAsync(research);
            if (result.IsFailed)
                return result;
            return result;
        }

        [ProducesResponseType(typeof(List<SectionDto>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPost("object")]
        public async Task<Result> AddDataObjectAsync([FromBody] DataObjectDto objectDto)
        {
            var result = await _sectionService.CreateDataObjectAsync(objectDto);
            if (result.IsFailed)
                return result;
            return result;
        }

        [ProducesResponseType(typeof(List<SectionDto>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpGet("list")]
        public async Task<List<SectionDto>> GetSectionListAsync()
        {
            var result = await _sectionService.GetSectionListAsync();
            return result.ValueOrDefault;
        }

        [ProducesResponseType(typeof(List<DataObjectDto>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpGet("object")]
        public async Task<List<DataObjectDto>> GetDataObjectListAsync()
        {
            var result = await _sectionService.GetDataObjectListAsync();
            return result.ValueOrDefault;
        }

        [ProducesResponseType(typeof(List<MethodDto>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpGet("method")]
        public async Task<List<MethodDto>> GetMethodListAsync()
        {
            var result = await _sectionService.GetMethodListAsync();
            return result.ValueOrDefault;
        }

        [ProducesResponseType(typeof(List<PropertyDto>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpGet("property")]
        public async Task<List<PropertyDto>> GetPropertyListAsync()
        {
            var result = await _sectionService.GetPropertyListAsync();
            return result.ValueOrDefault;
        }
    }
}