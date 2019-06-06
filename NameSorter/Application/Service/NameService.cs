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
        /// Get names from repository.
        /// </summary>
        /// <returns>The names.</returns>
        /// <param name="fileName">File name.</param>
        public IList<Name> GetNames(string fileName)
        {
            return _nameRepository.GetNames(fileName);
        }

        /// <summary>
        /// Save the list of names.
        /// </summary>
        /// <param name="names">Names.</param>
        public void SaveNames(IList<Name> names)
        {
            _nameRepository.SaveNames(names);
        }

        /// <summary>
        /// Sort the given names.
        /// </summary>
        /// <returns>The names.</returns>
        /// <param name="names">Names.</param>
        public IList<Name> SortNames(IList<Name> names)
        {
            return _nameSorter.SortNames(names);
        }
    }
}
