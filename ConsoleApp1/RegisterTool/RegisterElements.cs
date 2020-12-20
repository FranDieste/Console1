
using Domain.Aggregates.BookAggregate.Repositories;
using Domain.Aggregates.UserAggregate.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using RegisterTool.Interfaces;
using Repository01.Repositories.Base.EF.Class;
using Repository01.Repositories.Base.EF.Interfaces;
using Repository01.Repositories.BookRepository;
using Repository01.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RegisterTool
{
    public static class RegisterElements
    {
        private static ServiceCollection _service;

        public static ServiceProvider GetDI()
        {
            if (_service == null)
            {
                _service = new ServiceCollection();
                RegisterServices();
            }

            return _service.BuildServiceProvider();
        }
        private  static void RegisterServices()
        {
 
            RegisterHandlers();

            RegisterRepositories();

        }
      
        private static void RegisterHandlers()
        {
           
            var bDirectory = AppDomain.CurrentDomain.BaseDirectory;

            var assemblies = from file in new DirectoryInfo(bDirectory).GetFiles()
                             where file.Extension.ToLower() == ".dll"
                             select Assembly.Load(AssemblyName.GetAssemblyName(file.FullName));

            var types = new Dictionary<Type, Type>();

            foreach (var item in assemblies.ToList())
            {
                var classes = from clas in item.GetTypes().Where(c => c.FullName.Contains("Handler") && c.IsClass)
                              from inte in clas.GetInterfaces().ToList().Where(i => i.FullName.Contains("IQuery"))
                              select new { cl = clas, il = inte };



                foreach (var item2 in classes)
                {
                    var classType = Type.GetType(item2.cl.AssemblyQualifiedName);
                    var interfaceType = Type.GetType(item2.il.AssemblyQualifiedName);
                    types.Add(interfaceType, classType);

                }

            }

            foreach (var item in types)
            {
                _service.AddTransient(item.Key, item.Value);

            }
        }

        private static void RegisterRepositories()
        {
            //Register Repositories
            _service.AddTransient<IBookRepository, BookRepository>();
            _service.AddTransient<IUserRepository, UserRepository>();
            //_service.AddTransient<IApplicationDbContext, ApplicationEFContext>();
            _service.AddSingleton<IApplicationDbContext, ApplicationEFContext>();
            //_service.AddSingleton<ILogger,LoggerDI>();

        }
    }
}
