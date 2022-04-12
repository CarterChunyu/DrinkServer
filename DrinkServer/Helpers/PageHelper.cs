using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Helpers
{
    public static class PageHelper
    {
        public static int GetPages<T>(this IEnumerable<T> source, int page_count)
        {
            return source.Count() % page_count == 0 ? source.Count() / page_count : source.Count() / page_count + 1;
        }
        public static IEnumerable<T> GetPages<T>(this IEnumerable<T> source, int page_count, int index)
        {
            return source.Skip((index - 1) * page_count).Take(page_count);
        }
    }
}
