﻿using System.Collections.Generic;
using System.Threading.Tasks;
using FluentResults;
using Models;

namespace BusinessLogicCore.Service
{
    public interface ISectionService
    {
        Task<Result> CreateSectionAsync(SectionDto sectionDto);
        Task<Result<List<SectionDto>>> GetSectionsAsync(int parentId);
    }
}