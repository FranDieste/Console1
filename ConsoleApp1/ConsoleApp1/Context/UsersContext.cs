using ConsoleApp1.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Context
{
    /*
     * The associations of the Book table with the database is done creating the bookContext class
     * We need to instal the followins nuguets.
     *  -Microsoft.EntityFrameWorkCore
     *  -Micorosft.EntityFrameWorkCore.SqlServer
     */
   public class UsersContext:DbContext
    {
        public DbSet<User> Users { get; set; }
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

        public void AddConsole(string info)
        {

        }

    }
}
