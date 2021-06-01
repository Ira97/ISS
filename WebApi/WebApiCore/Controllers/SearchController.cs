﻿using BusinessLogicCore.Service.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Search;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Controllers
{
    [Route("api/search")]
    [ApiController]
    [AllowAnonymous]
    [SwaggerTag("Контроллер работы с областями")]
    public class SearchController : BaseApiController
    {
        private readonly ISearchService _searchService;
        public SearchController(IHttpContextAccessor contextAccessor,
        ILogger<BaseApiController> logger, ISearchService searchService) : base(contextAccessor, logger)
        {
            _searchService = searchService;
        }

        [HttpGet("simple")]
        public async Task<SearchResult> SimpleSearchAsync([FromQuery] string value)
        {
            var result = await _searchService.GetSimpleSearchAsync(value);
            if (result.IsFailed)
                return result.Value;
            return result.Value;
        }
    }
}