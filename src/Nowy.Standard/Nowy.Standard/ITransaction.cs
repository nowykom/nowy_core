using System;
using System.Collections.Generic;
using System.Text;

namespace Nowy.Standard;

public interface ITransaction
{
    void Commit();
    void Rollback();
}
