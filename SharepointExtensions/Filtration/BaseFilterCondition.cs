using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharepointExtensions.Filtration
{
    public abstract class BaseFilterCondition<T> : IFilterString
    {
        public required string FieldName { get; init; }
        public required T Value { get; set; }

        public abstract string GetFormattedValue();

        public abstract string GetFilterString();
    }
}
