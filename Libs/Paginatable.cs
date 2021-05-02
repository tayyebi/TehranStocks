using System;
using System.Collections.Generic;
using System.Linq;

namespace TehranStocks.Libs
{
    static public class Paginatable
    {
        public static List<TSource> Paginate<TSource>(this IEnumerable<TSource> source, PaginationDetails details)
        {
            return source
                .Skip(details.Size * (details.Number - 1))
                .Take(details.Size)
                .ToList();
        }
    }
    public class PaginationDetails
    {
        public int Size { get; set; } = 100;
        public int Number { get; set; } = 1;
    }
}