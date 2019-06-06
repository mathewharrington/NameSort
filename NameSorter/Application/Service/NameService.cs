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

        /// <summary>
        /// Get sorted list of names.
        /// </summary>
        /// <returns>The sorted names.</returns>
        /// <param name="fileName">File name.</param>
        public IList<Name> GetSortedNames(string fileName)
        {
            var names = _nameRepository.GetNames(fileName);
            var sortedNames = _nameSorter.SortNames(names);
            return sortedNames; 
        }

        /// <summary>
        /// Save the list of names.
        /// </summary>
        /// <param name="names">Names.</param>
        public void SaveNames(IList<Name> names)
        {
            _nameRepository.SaveNames(names);
        }
    }
}
