using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app_datumation.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsEmpty<T>(this IEnumerable<T> list)
        {
            if (list is ICollection<T>) return ((ICollection<T>)list).Count == 0;
            return !list.Any();
        }
    }
}