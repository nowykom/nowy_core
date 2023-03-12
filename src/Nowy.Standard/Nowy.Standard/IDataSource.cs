using System.Collections.Generic;

namespace Nowy.Standard;

public interface IDataSource
{
    void Fetch();
}

public interface IDataSource<T> : IDataSource
{
    IEnumerable<T> Enumerable();
}
