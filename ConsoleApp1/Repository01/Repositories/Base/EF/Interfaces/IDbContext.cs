using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository01.Repositories.Base.EF.Interfaces
{
   public interface IDbContext:IDisposable
    {
        DbContext Instance { get; }
    }
}
