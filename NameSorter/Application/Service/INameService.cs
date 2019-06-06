using System;
using System.Collections.Generic;
using NameSorter.Application.Model.Entities;

namespace NameSorter.Application.Service
{
    public interface INameService
    {
        /// <summary>
        /// Get sorted list of names.
        /// </summary>
        /// <returns>The sorted names.</returns>
        /// <param name="fileName">File name.</param>
        IList<Name> GetSortedNames(string fileName);

        /// <summary>
        /// Saves the list of names.
        /// </summary>
        /// <param name="names">Names.</param>
        void SaveNames(IList<Name> names);
    }
}
