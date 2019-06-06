using System;
using System.Collections.Generic;
using NameSorter.Application.Model.Entities;

namespace NameSorter.Application.Infrastructure
{
    public interface INameRepository
    {
        /// <summary>
        /// Get the names from given file.
        /// </summary>
        /// <returns>The names.</returns>
        /// <param name="fileName">File name.</param>
        IList<Name> GetNames(string fileName);

        /// <summary>
        /// Save the list of names.
        /// </summary>
        /// <param name="names">Names.</param>
        void SaveNames(IList<Name> names);
    }
}
