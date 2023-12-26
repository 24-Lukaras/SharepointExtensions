using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharepointExtensions.Filtration
{
    public enum FilterOperation
    {
        LessThan,
        LessOrEqual,
        GreaterThan,
        GreaterOrEqual,

        Equals,
        NotEqual,
        In,
        Has,

        StartsWith,
        EndsWith,
        Contains,

        IsNotNull,
        IsNull
    }
}
