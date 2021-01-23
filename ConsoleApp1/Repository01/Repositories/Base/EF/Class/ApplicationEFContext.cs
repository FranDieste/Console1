using Domain.Aggregates.BookAggregate.Configuration;
using Domain.Aggregates.BookAggregate.Entities;
using Domain.Aggregates.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository01.Repositories.Base.EF.Interfaces;

namespace Repository01.Repositories.Base.EF.Class
{
    public class ApplicationEFContext :DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbContext Instance => this;

        public DbSet<SysTables> SysTables { get; set; }

        // public DbSet<User> Users { get; set; }
        private string GetConnectionString()
        {
            //Se añaden las extensiones de 
            //Microsoft.extensions.Configuration
            //Microsoft.extensions.Configuration.json

            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                       

            IConfiguration configuration = builder.Build();

            //When create a file appsettings.json we have to change the property--> copiar al directorio de salida and assigned always(siempre)
            var connectionString = configuration["Data:DefaultConnection:ConnectionString"];

            return connectionString;

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(GetConnectionString());


        }



    }
}
