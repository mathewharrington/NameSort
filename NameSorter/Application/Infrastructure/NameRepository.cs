using System.Collections.Generic;
using NameSorter.Application.Model.Entities;

namespace NameSorter.Application.Infrastructure
{
    public class NameRepository : INameRepository
    {
        private readonly INameDao _nameDao;

        public NameRepository(INameDao nameDao)
        {
            _nameDao = nameDao;
        }

        /// <summary>
        /// Load list of names.
        /// </summary>
        /// <returns>The names.</returns>
        /// <param name="fileName">File name.</param>
        public IList<Name> GetNames(string fileName)
        {
            return _nameDao.LoadNames(fileName);
        }

        /// <summary>
        /// Save list of names.
        /// </summary>
        /// <param name="names">Names.</param>
        public void SaveNames(IList<Name> names)
        {
            _nameDao.SaveNames(names);
        }
    }
}
