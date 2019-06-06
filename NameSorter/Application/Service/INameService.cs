using System;
using System.Collections.Generic;
using NameSorter.Application.Model.Entities;

namespace NameSorter.Application.Service
{
    public interface INameService
    {
        /// <summary>
        /// Gets the names.
        /// </summary>
        /// <returns>The names.</returns>
        /// <param name="fileName">File name.</param>
        IList<Name> GetNames(string fileName);

        /// <summary>
        /// Sort the names.
        /// </summary>
        /// <returns>The names.</returns>
        /// <param name="names">Names.</param>
        IList<Name> SortNames(IList<Name> names);

        /// <summary>
        /// Saves the names.
        /// </summary>
        /// <param name="names">Names.</param>
        void SaveNames(IList<Name> names);
    }
}
