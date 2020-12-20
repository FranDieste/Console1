using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
   public interface IQuery<Tin,Tout>
    {
        Tout ExecuteQuery(Tin Param);
    }
}
