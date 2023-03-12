using System.Collections.Generic;

namespace Nowy.Standard;

public static class ListExtensions
{
    public static void Swap<T>(this IList<T> list, int from, int to)
    {
        T tmp = list[from];
        list[from] = list[to];
        list[to] = tmp;
    }
}
