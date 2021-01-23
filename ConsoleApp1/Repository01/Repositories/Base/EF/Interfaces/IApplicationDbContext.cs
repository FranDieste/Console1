using Domain.Aggregates.BookAggregate.Configuration;
using Domain.Aggregates.BookAggregate.Entities;
using Domain.Aggregates.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository01.Repositories.Base.EF.Interfaces
{
   public interface IApplicationDbContext: IDbContext
    {
      
       DbSet<User> Users { get; set; }
       DbSet<Book> Books { get; set; }
       DbSet<SysTables> SysTables { get; set; }


    }
}
