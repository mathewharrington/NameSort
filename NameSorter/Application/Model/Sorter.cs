using System;
using System.Collections.Generic;
using System.Linq;
using NameSorter.Application.Model.Entities;

namespace NameSorter.Application.Model
{
    public class Sorter : ISorter
    {
        /// <summary>
        /// Sort the names by surname then by given names.
        /// </summary>
        /// <returns>The names.</returns>
        /// <param name="names">Names.</param>
        public IList<Name> SortNames(IList<Name> names)
        {
            var sortedNames = names.OrderBy(x => x.Surname)
                .ThenBy(x => x.FirstGivenName)
                .ThenBy(x => x.SecondGivenName)
                .ThenBy(x => x.ThirdGivenName)
                .ToList();
            return sortedNames;
        }
    }
}
