using FluentResults;
using Models.Search;
using ScientificDatabase.Repositories;
using ScientificDatabase.Repositories.HierarchyRepository;
using ScientificDatabase.Repositories.TypeObjectRepositopy;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicCore.Service.Search
{
    public class SearchService : ISearchService
    {

        private readonly SectionRepositopy _sectionsRepository;
        private readonly AreaRepository _areaRepository;
        private readonly DataObjectRepository _dataObjectRepository;
        private readonly ResearchRepository _researchRepository;

        public SearchService(ResearchRepository researchRepository, DataObjectRepository dataObjectRepository,
                             AreaRepository areaRepository, SectionRepositopy sectionsRepository)
        {
            _researchRepository = researchRepository;
            _dataObjectRepository = dataObjectRepository;
            _areaRepository = areaRepository;
            _sectionsRepository = sectionsRepository;
        }

        public async Task<Result<SearchResult>> GetSimpleSearchAsync(string searchTerm)
        {
            var searchResult = new SearchResult();
            //var sectionList = await _sectionsRepository.GetListAsync(x => x.Name.Contains(searchTerm) || x.Description.Contains(searchTerm));
            //var dataObjectList = await _dataObjectRepository.GetListAsync(x => x.Name.Contains(searchTerm));
            var researchList = await _researchRepository.GetListAsync(x => x.Description.Contains(searchTerm) || 
            x.Title.Contains(searchTerm) || 
            x.Author.Contains(searchTerm) ||
            x.Thing.Contains(searchTerm) ||
            x.Object.Contains(searchTerm) ||
            x.Method.Contains(searchTerm));
            //if (sectionList.Any())
            //{
            //    foreach(var section in sectionList)
            //    {
            //        var entryCount = GetEntryCount(section.Description, searchTerm) + 
            //            GetEntryCount(section.Name, searchTerm);
            //        var wordCount = GetWordCount(section.Description) + GetWordCount(section.Name);
            //        searchResult.EntryList.Add(new Entry
            //        {
            //            ItemId = section.Id,
            //            Relevance = entryCount / wordCount,
            //            Type = section.GetType().Name,
            //            Name = section.Name,
            //            Description = section.Description
            //        });
            //    }
            //}
            //if (dataObjectList.Any())
            //{
            //    foreach (var dataObject in dataObjectList)
            //    {
            //        var entryCount = GetEntryCount(dataObject.Name, searchTerm);
            //        var wordCount = GetWordCount(dataObject.Name);
            //        searchResult.EntryList.Add(new Entry
            //        {
            //            ItemId = dataObject.Id,
            //            Relevance = entryCount / wordCount,
            //            Type = dataObject.GetType().Name,
            //            Name = dataObject.Name,
            //            Description = "Объект"
            //        });
            //    }
            //}
            if (researchList.Any())
            {
                foreach (var reseach in researchList)
                {
                    var entryCount = GetEntryCount(reseach.Title, searchTerm) +
                        GetEntryCount(reseach.Description, searchTerm) +
                        GetEntryCount(reseach.Author, searchTerm) +
                        GetEntryCount(reseach.Thing, searchTerm) +
                        GetEntryCount(reseach.Object, searchTerm) +
                        GetEntryCount(reseach.Method, searchTerm);
                    var wordCount = GetWordCount(reseach.Title) +
                        GetWordCount(reseach.Description) +
                        GetWordCount(reseach.Author) +
                        GetWordCount(reseach.Thing) +
                        GetWordCount(reseach.Object) +
                        GetWordCount(reseach.Method);
                    searchResult.EntryList.Add(new Entry
                    {
                        ItemId = reseach.Id,
                        Relevance = entryCount / wordCount,
                        Type = reseach.GetType().Name,
                        Name = reseach.Title,
                        Description = reseach.Description
                    });
                }
            }
            return Result.Ok(searchResult);
        }

        public int GetEntryCount(string input, string searchTerm)
        {
            if (string.IsNullOrEmpty(input)) return 1;
            var source = GetWordArray(input);
            var matchQuery = from word in source
                             where word.ToLowerInvariant().Contains(searchTerm.ToLowerInvariant())
                             select word;
            return matchQuery.Count();
        }

        public int GetWordCount(string input)
        {
            if (string.IsNullOrEmpty(input)) return 1;
            var source = GetWordArray(input);
            return source.ToList().Count();
        }

        public string[] GetWordArray(string input)
        {
            return input.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
