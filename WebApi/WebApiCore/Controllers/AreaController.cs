using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicCore.Service;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using ScientificDatabase.Models.Hierarchy;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApiCore.Controllers
{
    [Route("api/area")]
    [ApiController]
    [AllowAnonymous]
    [SwaggerTag("Контроллер работы с областями")]
    public class AreaController : BaseApiController
    {
        private readonly IAreaService _areaService;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="contextAccessor"></param>
        /// <param name="logger"></param>
        /// <param name="areaService"></param>
        public AreaController(IHttpContextAccessor contextAccessor, ILogger<BaseApiController> logger,
            IAreaService areaService) : base(contextAccessor, logger)
        {
            _areaService = areaService;
        }


        [ProducesResponseType(typeof(List<AreaDto>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpGet("list")]
        public async Task<Result<List<AreaDto>>> GetAreasAsync()
        {
           var result =  await _areaService.GetAreasAsync();
           if (result.IsFailed)
               return result;
           return Result.Ok(result.Value);
        }
        
        [ProducesResponseType(typeof(List<AreaDto>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpGet("{areaId}")]
        public async Task<AreaDto> GetAreaAsync([FromRoute] int areaId)
        {
            try
            {
                var result =  await _areaService.GetSectionsForAreaAsync(areaId);
                if (result.IsFailed)
                    return result.Value;
                return result.Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [ProducesResponseType(typeof(List<AreaDto>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPost("create")]
        public async Task<Result> CreateAreaAsync([FromBody] AreaDto areaDto)
        {
            var result =  await _areaService.CreateAreaAsync(areaDto);
            if (result.IsFailed)
                return result;
            
            return Result.Ok();
        }
    }
}