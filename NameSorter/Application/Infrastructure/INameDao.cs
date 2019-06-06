using System;
using System.Collections.Generic;
using NameSorter.Application.Model.Entities;

namespace NameSorter.Application.Infrastructure
{
    public interface INameDao
    {
        /// <summary>
        /// Load the names.
        /// </summary>
        /// <returns>The names.</returns>
        /// <param name="fileName">File name.</param>
        IList<Name> LoadNames(string fileName);

        /// <summary>
        /// Save the names.
        /// </summary>
        /// <param name="names">Names.</param>
        void SaveNames(IList<Name> names);
    }
}
