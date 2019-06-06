using System;
using System.Collections.Generic;
using NameSorter.Application.Infrastructure;
using NameSorter.Application.Model;
using NameSorter.Application.Model.Entities;

namespace NameSorter.Application.Service
{
    public class NameService : INameService
    {
        private readonly INameRepository _nameRepository;
        private readonly ISorter _nameSorter;

        public NameService(INameRepository nameRepository, ISorter nameSorter)
        {
            _nameRepository = nameRepository;
            _nameSorter = nameSorter;
        }

        public IList<Name> GetNames(string fileName, string directory)
        {
            return _nameRepository.GetNames(fileName);
        }

        public void SaveNames(IList<Name> names)
        {

        }

        public IList<Name> SortNames(IList<Name> names)
        {
            return _nameSorter.SortNames(names);
        }
    }
}
