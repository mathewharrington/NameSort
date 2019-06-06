using System;
using System.Collections.Generic;
using NameSorter.Application.Model.Entities;

namespace NameSorter.Application.Model
{
    public interface ISorter
    {
        IList<Name> SortNames(IList<Name> names);
    }
}
