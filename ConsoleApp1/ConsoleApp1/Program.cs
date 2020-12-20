using Application;
using Application.Dto.InDto.Book;
using Application.Dto.OutDto;
using Application.Interfaces;
using ConsoleApp1.Class;
using ConsoleApp1.Context;
using ConsoleApp1.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using RegisterTool;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.IO.Enumeration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ConsoleApp1
{
    class Program
    {
        //Delegates
        delegate double DoubleOp(double x);
        private readonly static Dictionary<string, string> names = new Dictionary<string, string>();
        private static object s_logLock = new object();
        private CngKey _aliceKeySignature;
        private byte[] _alicePubKeyBlob;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

          
                                

            //pag 62 libro Gia Arquitectura N-Capas 

            //1743

            //1756 pendiente aquí
            //falta la implementacion de LogginFactory
            //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa

            var register = RegisterElements.GetDI();//Devolvemos el objeto que gestiona la DI(Inyection Dependency)

            var booksDto = new BooksRequestDto();
            
            //Llamar a una funcion utilizando DI
            var controller0 = register.GetRequiredService<IQuery<BooksRequestDto, IEnumerable<BooksResultDto>>>();

            var j= controller0.ExecuteQuery(booksDto);
            

            var documentEditor = new DocumentEditor();

            Console.WriteLine(DocumentEditor.s_maxDocuments);

            documentEditor.SetAddress("Miquel Santandreu");
            Console.WriteLine(documentEditor.Address);

            documentEditor.viewParamsArray(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            //Utilización de la clase singleton
            //No nos dejará instanciar directamente ya que tiene el constructor privado.

            var singletonDescription = Singleton.MySingleton.GetDescription("Prueba de singleton description");

            Console.WriteLine(singletonDescription);

            //class car two constructors
            var myCar = new Car("Hello I'm a instance of Car");


            //var a = Car.Color.Red;

            Console.WriteLine($"Mi coche es de color {Car.Color.Green} y su índice es {(int)Car.Color.Green}");

            var indexColor = 1;

            var a = (Car.Color)indexColor;


            //Use of string extension

            var fox = "The quick brown fox jumped over the lazy dogs down";

            Console.WriteLine("Number of stringExtension " + fox.GetWordCount());

#if DEBUG
            Console.WriteLine($"TEST PRE-PROCESOR");
#endif

            //Method Generlic
            var test = new MethodOverloads();

            test.Foo(3);
            test.Foo("abc");
            test.Foo("abc", 42);
            test.Foo(33, "abc");

            //Palabras claves
            //typeof=>returns a System.Type
            //nameof=>return de name of method or property

            //Nulable Types
            //int? i3 = null;
            //DateTime? d1 = null;

            //Opertor ?? get the first operant is not null else get the second operator
            int? o = null;
            int b;

            b = o ?? 10; // b has the value 10
            o = 3;
            b = o ?? 10; // b has the value 3

            Console.WriteLine($"El valor de b es {b} ");

            //The operator ? evaluate null expresion ex person p 
            // int age1 = p?.Age ?? 0; if p is != null get p.Age else 0
            //Expresion in Arrays

            int[] arr = null;
            int x1 = arr?[0] ?? 0;
            //managed heap=> monton gestionado
            //Boxing is the term used to describe the transformation of a value type to a reference type

            //7.- Arrays
            //Simple array
            var mySimpleArray = new int[4] { 4, 7, 11, 2 };
            //Arrays of class CAR
            Car[] myCars = new Car[2];
            myCars[0] = new Car();
            myCars[1] = new Car();

            Car[] myCars2 =
            {
                new Car(),
                new Car()
            };



            //Use Span
            int[] arr1 = { 1, 4, 5, 11, 13, 18 };
            var span1 = new Span<int>(arr1);

            span1[1] = 11;

            Console.WriteLine($"arr1[1] is changed via span1[1]:{arr1[1]}");

            //8 Delegates,Lambdas, and Events pag:407

            //Delegates
            //Func<T> for method that return value
            //Action<T> for void method
            myCar.getDescription(myCar.GetColorDescription, "Blue");
            myCar.PrintColor(myCar.GetColorDescription, "Red");

            DoubleOp[] operations =
            {
                MathOperations.MultiplyByTwo,
                MathOperations.Square
            };

            for (int i = 0; i < operations.Length; i++)
            {

                Console.WriteLine($"Using operations[{i}]:");
                ProcessAndDisplayNumber(operations[i], 2.0);
                ProcessAndDisplayNumber(operations[i], 7.94);
                ProcessAndDisplayNumber(operations[i], 1.414);
            }

            //Anonymous Methods=> Is a block of code that is used as the parameter for the delegate.
            //The benefit of using anonymous methods is that it reduces the amount of code you have to write

            string mid = ", middle part,";
            Func<string, string> anonDel = delegate (string param)
            {
                param += mid;
                param += " and this was added to the string.";
                return param;
            };
            Console.WriteLine(anonDel("Start of string"));

            //Lambda expressions
            Func<string, string> lambda = param =>
            {

                param += mid;
                param += " and this was added to the string.";
                return param;
            };

            Console.WriteLine(lambda("Start of string"));

            Func<double, double, double> twoParams = (x, y) => x * y;
            Console.WriteLine(twoParams(3, 2));


            Func<double, double, double> twoParamsWithTypes = (double x, double y) => x * y;
            Console.WriteLine(twoParamsWithTypes(4, 2));

            //Events pag 434

            var dealer = new CarDealer();
            var valtteri = new Consumer("Valtteri");

            dealer.NewCarInfo += valtteri.NewCarIsHere;
            dealer.NewCar("Williams");

            var max = new Consumer("Max");
            dealer.NewCarInfo += max.NewCarIsHere;
            dealer.NewCar("Mercedes");
            dealer.NewCarInfo -= valtteri.NewCarIsHere;
            dealer.NewCar("Ferrai");

            //9 Strings an regular expresion 440

            //StringBuilder can never grow to more than 500 characters.
            var str1 = new StringBuilder("Hello from all the people at Wrox Press.");
            str1.AppendFormat("We do hope yoy enjoy this book as much as we enjoyed weiting it");

            //Fomattable String
            int x = 3, y = 4;
            FormattableString s = $"The result of {x} + {y} is {x + y}";
            Console.WriteLine($"format:{s.Format}");

            //Regular Expresions pag (465)
            const string pattern = "ion";
            const string text = "Lion is in the prision bla laasldf  jlasdfl ion dfdfdff  ion";

            var matches = Regex.Match(text, pattern, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

            //10 Collections 475
            //LinkedList get the structure [Value,Next,Previous] with pointer to next node and previous node.
            //Dictionary
            var dict = new Dictionary<int, string>()
            {
                [3] = "three",
                [7] = "seven"
            };

            dict.Add(8, "nine");

            var elementDict = dict[7];

            if (!dict.TryGetValue(5, out string emptyvalue))
            {
                Console.WriteLine("5 not found");
            }

            if (dict.TryGetValue(3, out string emptyvalue2))
            {
                Console.WriteLine($"3 found {emptyvalue2}");
            }

            //11 Special Collections pag 528
            //Observable Collection
            var data = new ObservableCollection<string>();

            data.CollectionChanged += Data_CollectionChanged;
            data.Add("One");
            data.Add("Two");
            data.Insert(1, "Three");
            data.Remove("One");
            //InmutableArray the source array is inmutable.The value is inserted in second array
            var inmutableArray1 = ImmutableArray.Create<string>();

            var inmutableArray2 = inmutableArray1.Add("Williams");

            var inmutabeArray3 = inmutableArray2.Add("Ferray").Add("Mercedes").Add("Red Bull Racing");

            //Concurrent collections
            //  -ConcurrentQueue<T>
            //  -ConcurrentStack<T>
            //  -ConcurrentBag<T>
            //  -ConcurrentDictionary<T>
            //  -BlockingCollection<T>

            //12 Language Integrated Query pag 558
            //example
            /*          
            var query = from r in Formula1.GetChampions()
                        where r.Country == "Brazil"
                        orderby r.Wins descending
                        select r;

            foreach (Racer r in query)
            {
                Console.WriteLine($"{r:A}");
            }

            var ferrariDrivers = from r in Formula1.GetChampions()
            from c in r.Cars
            where c == "Ferrari"
            orderby r.LastName
            select r.FirstName + " " + r.LastName;

            var ferrariDrivers = Formula1.GetChampions()
            .SelectMany(r => r.Cars, (r, c) => new { Racer = r, Car =
            c })
            .Where(r => r.Car == "Ferrari")
            .OrderBy(r => r.Racer.LastName)
            .Select(r => r.Racer.FirstName + " " + r.Racer.LastName);

            var racers = from r in Formula1.GetChampions()
            where r.Country == "Brazil"
            orderby r.Wins descending
            select r;

            var racers = Formula1.GetChampions()
            .Where(r => r.Country == "Brazil")
            .OrderByDescending(r => r.Wins)
            .Select(r => r);

            var countries = from r in Formula1.GetChampions()
            group r by r.Country into g
            let count = g.Count()
            orderby count descending, g.Key
            where count >= 2
            select new
            {
            Country = g.Key,
            Count = count
            };

            var countries = from r in Formula1.GetChampions()
            group r by r.Country into g
            let count = g.Count()
            orderby count descending, g.Key
            where count >= 2
            select new
            {
            Country = g.Key,
            Count = count,
            Racers = from r1 in g
            orderby r1.LastName
            select r1.FirstName + " " +
            r1.LastName
            };
            foreach (var item in countries)
            {
            Console.WriteLine($"{item.Country, -10} {item.Count}");
            foreach (var name in item.Racers)
            {
            Console.Write($"{name}; ");
            }
            Console.WriteLine();
            }

            //--------->JOIN
            var racers = from r in Formula1.GetChampions()
            from y in r.Years
            select new
            {
            Year = y,
            Name = r.FirstName + " " + r.LastName
            };
            var teams = from t in Formula1.GetContructorChampions()
            from y in t.Years
            select new
            {
            Year = y,
            Name = t.Name
            };

            var racersAndTeams = (from r in racers
            join t in teams on r.Year equals t.Year
            Download from finelybook www.finelybook.com
            585
            select new
            {
            r.Year,
            Champion = r.Name,
            Constructor = t.Name
            }).Take(10);
            Console.WriteLine("Year World Champion\t Constructor Title");
            foreach (var item in racersAndTeams)
            {
            Console.WriteLine($"{item.Year}: {item.Champion,-20}
            {item.Constructor}");
            }

                var racersAndTeams =
                (from r in
                from r1 in Formula1.GetChampions()
                from yr in r1.Years
                select new
                {
                Year = yr,
                Name = r1.FirstName + " " + r1.LastName
                }
                join t in
                from t1 in Formula1.GetContructorChampions()
                from yt in t1.Years
                select new
                {
                Year = yt,
                Name = t1.Name
                }
                on r.Year equals t.Year
                orderby t.Year
                select new
                {
                Year = r.Year,
                Racer = r.Name,
                Team = t.Name
                }).Take(10);

               // LEFT OUTER JOIN
                var racersAndTeams =
                racers.GroupJoin(
                teams,
                r => r.Year,
                t => t.Year,
                (r, ts) => new
                {
                Year = r.Year,
                Champion = r.Name,
                Constructors = ts
                })
                .SelectMany(
                rt => rt.Constructors.DefaultIfEmpty(),
                (r, t) => new
                {
                Year = r.Year,
                Champion = r.Champion,
                Constructor = t?.Name ?? "no constructor
                Download from finelybook www.finelybook.com
                589
                championship"
                });
            */

            //13 Functional Programing page 617
            /*
             * using (var r = new Resource())
                {
                r.Foo();
                }

                new Resource().Use(r => r.Foo());

                ----------------------
                public static class FunctionalExtensions
                {
                //...
                     public static Func<T1, TResult> Compose<T1, T2, TResult>(
                     Func<T1, T2> f1, Func<T2, TResult> f2) =>
                        a => f2(f1(a));
                }
                
                using System;
                using static System.Console;
                using static UsingStatic.FunctionalExtensions;
                namespace UsingStatic
                {
                     class Program
                     {
                         static void Main()
                         {
                            //...
                            Func<int, int> f1 = x => x + 1;
                            Func<int, int> f2 = x => x + 2;
                            Func<int, int> f3 = Compose(f1, f2);
                            var x1 = f3(39);
                            WriteLine(x1);
                            //...
                         }
                     }
                }

               
             */

            //Tuples:combine objects of different types
            (string s, int i, Person p) t = ("magic", 42, new Person("Stephanie", "Nagel"));
            Console.WriteLine($"s:{t.s}, i:{t.i}, p: {t.p}");

            var t2 = ("magic", 42, new Person("Matthias", "Nagel"));
            Console.WriteLine($"string: {t2.Item1}, int: {t2.Item2},person: { t2.Item3}");


            //14 Errors and Exceptions 657
            /*
            *   at ConsoleApp1.Class.Person.WriteDescription() in C:\GitFran\Console1\ConsoleApp1\ConsoleApp1\Class\Person.cs:line 24
                at ConsoleApp1.Program.TestException() in C:\GitFran\Console1\ConsoleApp1\ConsoleApp1\Program.cs:line 544
                at ConsoleApp1.Program.Main(String[] args) in C:\GitFran\Console1\ConsoleApp1\ConsoleApp1\Program.cs:line 457
            */
            try
            {
                TestException();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The error is {ex.Message}");

            }
            finally
            {
                Console.WriteLine("Finaly exception writting");
            }


            //15 Asynchronous Programming pag 697 
            //What you need to be aware of with asynchronous programming:lo que debe tener en cuenta con programacion asincrona
            //Pattern:
            //    -Asynchronous pattern 
            //    -Event-based asynchronous pattern
            //    -Task-based asynchronous pattern
            //Task: async await 

            //Example of synchronous call using WebClient 701
            SynchronizeApi();
            AsynchronousPattern();

            //Event - based Asynchronous Pattern
            EventBasedAsyncPattern();

            //Task-Based Asynchronous Pattern
            //  --Async: This pattern defines a suffix Async method that returns a Task Type
            //  --await: unblocks the thread to do others tasks

            //static async Task Main()
            PrintTaskPattern();

            //Using ValueTasks pag 714
            var resultValueTask1 = GreetingValueTaskAsync("Hola Mundo");
            var resultValueTask2 = GreetingValueTask2Async("String valueTask2");

            // 16 Reflection, Metadata, and DynamicProgramming pag 730
            //attributes can be applied(classes,structs,properties,methods, and so on)

            //Create a instance of class in dynamic formConsoleApp1.Class/Calculato
            //var myObject =  CreateDynamicallyObjectClass(@"C:\GitFran\Console1\ConsoleApp1\ConsoleApp1\Class\Calculator.cs","Calculator");
            //var myObject = CreateDynamicallyObjectClass("ConsoleApp1.Class.Calculator", "Calculator");

            //18 Visual Studio 2017 pag 845
            //Docker(pag 924):Es un contenedor donde guardamos las aplicaciones que queremos ejecutar.
            //       Si se ejecuta en una maquina Windows probablemente tengamos que instala la marquina virtual de linux.
            //Key Terms:
            //  Image:A deployment unit.An image is a package that includes all dependencies(frameworks) and configuration needed
            //        to run the application.An image can derive from other images.After an image is created, it is immutable.
            //  Registry:A store where you can find Docker images.
            //           url:https://hub.docker.com. At https://hub.docker.com/r/microsoft/dotnet
            //  Container:A running image.The container is a runtime environment for one application or service.You can scale it by
            //            creating multiple instances of a container from the same image.A container runs in a host.
            //            You can download Docker Community Edition for Windows from:
            //            https://store.docker.com/editions/community/docker-cedesktop-windows to host Docker on Windows 10.
            // Dockerfile:A text file with instructions to build a Docker image.
            //            You can use the Docker command line to process the dockerfile. 

            //PROBAR DOCKER FALTA
            //pag 925  tema 18 IDE DOCKER faltaria instalar GitFran\Tools y probar docket

            //19 Libraries,Assemblies,Packages, and NuGet pag 936
            //Assemblies:Assemblies are libraries that could be shared.In addition to normal DLLs, assemblies contain extensible
            //           metadata with information about the library and a version number.It's possible to install multiple versions
            //           side by side in the global assembly cache.
            //Ildasm.exe shows the types of the  assembly with its members
            //20 Dependency Injection pag 968

            var controller = new HomeController(new GeetingService()); //creamos la instancia en este momento.
            string result = controller.Hello("Fran");
            Console.WriteLine(result);

            //975 page Using the .Net Core DI Container Microsoft.Extensions.DependencyInjection
            using (ServiceProvider container = RegisterServices())
            {
                var controller1 = container.GetRequiredService<HomeController>();
                var result1 = controller1.Hello("Pepe");
                Console.WriteLine(result1);
            }

            //21 Tasks and Parallel Programming pag 1012
            /*
             Parallel class define static methods for a parallel for and foreach.
             Parallel.Invoke is for task
                parallelism, and Parallel.ForEach is for data parallelism
             */
            PrintParallelFor();

            PrintParallelForEach();
            //Tasks
            TasksUsingThreadPool();

            RunSynchronousTask();

            LongRunningTask();

            //Ejemplo de conversion
            var resultDbl = DoubleTest(1, 2);

            string[] names1 = new string[] { "Ava", "Emma", "Olivia" };
            string[] names2 = new string[] { "Olivia", "Sophia", "Emma" };
            UniqueNames(names1, names2);


            //Futures—Results from Tasks pag 1025
            TaskWithResultDemo();

            //ContinueWith
            ContinuationTasks();

            //WaitAll:The method blocks the calling task until all tasks are waited for are completed.
            //WhenAll:Return a task wich in turn allows you to use the async keyword to wait for the result, and it does not block the aitings task

            //ActionBlocks-->investigate
            //Semaphore-->investigate
            //Barries-->investigate

            //22 Files and Streams 1087
            //  Directory and File:Contain only static methods
            //  DirectoryInfo and FileInfo:The membre of these classes are not static.

            PrintAllDrives();
            PrintFiles();

            //Working with Streams page 1103
            //Stream
            ReadFileUsingFileStream();

            // The StreamReader Class page 1116
            WriteFileUsingWriter();
            WriteFileUsingBinaryWriter();
            ReadFileUsingBinaryReader();

            //COMPRESSING FILES page 1120
            //GZipStream uses DeflateStream behind de scenes but GZipStream adds a cyclic redundancy check to detect data corruption.
            //BrotliStream is a relative new open-source compression algorithm form Google.The speed is similar to deflate but offers a better compression
            //because it uses a dictionary for often-used word for better compression.
            CompressFile();
            DecompressFile();


            //23 Networking 1147
            //httpClient class:Derives from the HttpMessageInvoker class.
            //    GetAsync: Return an httpResponseMessage object.Including headers,status and content


            //var httpAwait = GetDataSimpleAsync().GetAwaiter(); No esta funcionando hay que mirar porqué



            var task1 = Task.Run(async () =>
           {
               var a = await GetDataSimpleAsync();

           });

            task1.Wait();


            //httpAwait.OnCompleted(waitHttpclient);

            //void waitHttpclient()
            //{
            //    Console.WriteLine("Finish request");
            //}

            //24 Security --------------------------------pag 1217------------------------------------
            //keys elements to consider:
            //First: user of application (authenticated and authorization)
            //WindowsIdentity  aqui pag 1218

            WindowsIdentity identity = ShowIdentityInformation();

            //Contains and identity and offers additional information such as roles the user belongs to
            WindowsPrincipal principal = ShowPrincipal(identity);
            ShowClaims(principal.Claims);


            //Encrypting Data pag 1231
            //Using CNG(Crypthograpthy Next Generation) only run in Windows platform

            var p = new Program();
            p.Run();

            //25 ADO.NET and Transactions.pag 1265
            p.AddUser();

            Console.WriteLine("Finish");


        }



        //Zip Files
        //public static void CreateZipFile(string directory, string zipFile)
        //{
        //    FileStream zipStream = File.OpenWrite(zipFile);
        //    using (var archive = new ZipArchive(zipStream,
        //    ZipArchiveMode.Create))
        //    {
        //        IEnumerable<string> files = Directory.EnumerateFiles(
        //        directory, "*", SearchOption.TopDirectoryOnly);
        //        foreach (var file in files)
        //        {
        //            ZipArchiveEntry entry =
        //            archive.CreateEntry(Path.GetFileName(file));
        //            using (FileStream inputStream = File.OpenRead(file))
        //            using (Stream outputStream = entry.Open())
        //            {
        //                inputStream.CopyTo(outputStream);
        //            }

        //        }
        //    }
        //}

        public void AddUser()
        {

            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            var log = new LoggerConfiguration().ReadFrom.Configuration(builder.Build())
                                                          .Enrich.FromLogContext()
                                                          .WriteTo.Console()
                                                          .CreateLogger();

            log.Information("Application Starting");

            var host = Host.CreateDefaultBuilder()
                           .ConfigureServices((context, service) =>
                           {
                               service.AddTransient<IGreetingService,GreetingService>();
                           })
                           .UseSerilog()
                           .Build();



            var svc = ActivatorUtilities.CreateInstance<GreetingService>(host.Services);
            svc.Run();


            //ExecuteNonQuery:this method is commonly used for Update,Insert or Delete statements.Return the number of records affected.

            //1756 libro Creating a .Net Client


            var booksResult = GetBooksHttp();


            var usersCount = GetUserBDExecuteScalarNumeric();
            usersCount++;
            var myUser = new User()
            {
                Code = "Usr" + usersCount,
                Name = "Usuario" + usersCount,
                PassWord = "Usr" + usersCount

            };


            GetUserBDExecuteScalarTable<User>();


            //leer la cadena de conexión de la bd e insertar.
            var testConnection = TestConnection();
            if (testConnection)
            {
                CreateCurrentUser(code: "Usr1", name: "Usuario1", passWord: "Usr1");
            }

            //Continuamos con TRANSACTIONS WITH ADO.NET 1286
            //Revisar con mas profundidad

            //Entity Framework Core 1316  example
            //AddUsersAsync("User2","User2Description","password2").GetAwaiter().GetResult();

            //run ok
            // AddUsersAsync("User2", "User2Description", "password2").Wait();
            var t = AddUsersAsync("User3", "User3Description", "password3");
            t.Wait();


            //Reading from the Database 1321 seguir revisando mas temas como las relaciones etc ******
            //We can't use intellyTrace event in this version of Visual Studio
            
           var users= GetUserList().GetAwaiter().GetResult();


            //AddLoggin revisar *******************************************
            AddLogging();

            //27  Localization pag 1409
            SetCultureInfo();

            //28 Testing 1460
            //Web Test pendiente de mirar***************************************
            //Live Unit Testing pendiente de mirar ******************************

            //Tema 29 pendiente

            //30  ASP.NET Core 1554 PENDIENTE

            //32 Web Api  1739 mirar primero
            //verbs used by Rest full
            //GET:retrive resources
            //POST:Add new resources
            //PUT:Update resources
            //DELETE:Delete resources



            Console.WriteLine("Fin asincronismo");

           
        }

        private IEnumerable<BooksResultDto> GetBooksHttp()
        {

            /*
             * 200=> ok
             * 201=> Created
             * 204=> No Content
             * 400=> Bad Request
             * 401=> Unauthorized
             * 404=> Not Found
             */

            //var url = @"http://localhost:57600/api/Books/GetBooks";
            //https://localhost:44346/

            var url = @"https://localhost:44346/api/Books";
            IEnumerable<BooksResultDto> bookingResult = null;
            try
            {
                using (var client = new HttpClient())
                {
                    var result = client.GetAsync(url).Result;

                    result.EnsureSuccessStatusCode();
                                                               
                    var resultStr = result.Content.ReadAsStringAsync().Result;
                    bookingResult = JsonConvert.DeserializeObject<IEnumerable<BooksResultDto>>(resultStr);
                       
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return bookingResult;


        }

        private void SetCultureInfo()
        {
            var ci = new CultureInfo("es-ES");
            CultureInfo.CurrentCulture = ci;
            CultureInfo.CurrentUICulture = ci;

            var d = new DateTime(2020, 10, 28);
            Console.WriteLine(d.ToLongDateString());

            Console.WriteLine(d.ToString("D",new CultureInfo("fr-FR")));



        }

        private void AddLogging()
        {

            //var loggerFactory = new LoggerFactory()
            //    .AddConsole()
            //    .AddDebuger();




        }


        private async Task<IEnumerable<User>> GetUserList()
        {

            using (var context = new UsersContext())
            {
                //This instruction map the class User with the User database's table
                var userList = await context.Users.ToListAsync<User>();
                return userList;

            }

        }

        private  async Task AddUsersAsync(string code, string name, string password)
        {
           
            using (var context = new UsersContext())
            {
                var user = new User() 
                { 
                    Code = code, 
                    Name = name, 
                    PassWord = password 
                };

                await context.Users.AddAsync(user);//Add object to the contect

                //For more instances of user we have assign several instance
                //await context.AddRangeAsync(user1,user2,user3);//Add object to the contect

                int records = await context.SaveChangesAsync(); //save object in bd
                Console.WriteLine($"{records} record added");
            }

            Console.WriteLine();

        }

        static bool TestConnection()
        {

            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UsersDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            var connection = new SqlConnection(connectionString);

            connection.Open();
            Console.WriteLine("Connection opened");
            connection.Close();
            return true;

        }

        static User CreateCurrentUser(string code, string name, string passWord)
        {
            var myUser = new User()
            {
                Code = code,
                Name = name,
                PassWord = passWord

            };

            // GetConnectionString(Usarla al insertar los datos en la bd);
            AddUserBDExecuteNonQuery(myUser);

            return myUser;

        }

        static void AddUserBDExecuteNonQuery(User user)
        {
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                {
                    var sqlString = "Insert into Users (Code,Name,PassWord) Values(@Code,@Name,@PassWord)";

                    var command = new SqlCommand(sqlString, connection);
                    //var command1 = new SqlCommand(sqlString);


                    command.Parameters.Add("@Code", System.Data.SqlDbType.VarChar, 20, "Code");
                    command.Parameters["@Code"].Value = user.Code;

                    command.Parameters.AddWithValue("Name", user.Name);
                    command.Parameters.AddWithValue("PassWord", user.PassWord);


                    connection.Open();

                    int usersCount = command.ExecuteNonQuery();//we insert a row in users table and return a rows number



                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }


        }

        static int GetUserBDExecuteScalarNumeric()
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                string sql() => "Select Count(*) From Users";
                var command = new SqlCommand(sql(), connection);
                connection.Open();
                var result = command.ExecuteScalar();

                return (int)result;


            }
        }

        static T GetUserBDExecuteScalarTable<T>()
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                string sql() => "Select Id,Name,PassWord From Users";
                var command = new SqlCommand(sql(), connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string pass = reader.GetString(2);
                    }
                }

                if (typeof(T).Name == "User")
                {
                    Console.WriteLine("El tipo es de tipo User");

                }

                Type myType = Type.GetType(typeof(T).Name);

                if (typeof(T).IsClass)
                {
                    Console.WriteLine("Soy una clase");
                }

                var myClass = Activator.CreateInstance<T>();

                return myClass;

            }
        }


        public void BuildConfig(IConfigurationBuilder builder)
        {
            //The second instruction override e first instruction(AddJsonFile)
            //This is a good practice for diferents environments.
            builder.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                   .AddEnvironmentVariables();
        }


        static string GetConnectionString()
        {
            //Se añaden las extensiones de 
            //Microsoft.extensions.Configuration
            //Microsoft.extensions.Configuration.json

            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            //builder.SetBasePath(Directory.GetCurrentDirectory());
            //builder.AddJsonFile("config.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            //When create a file appsettings.json we have to change the property--> copiar al directorio de salida and assigned always(siempre)
            var connectionString = configuration["Data:DefaultConnection:ConnectionString"];

            //Return null
            var conectionString1 = configuration["ConnectionString"];

            return connectionString;

            //var temp = ConfigurationManager.ConnectionStrings["Data:DefaultConnection"].ConnectionString;


            //var builder = new ConfigurationBuilder()
            //  .SetBasePath(Directory.GetCurrentDirectory())
            //  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //  .AddJsonFile("archivodos.json", optional: true, reloadOnChange: true);
            //IConfiguration configuration = builder.Build();

            //string llave1 = configuration["llave1"];
            //string llave2 = configuration["llave2"];
            //string licencia = configuration["licencia"];
            //string api = configuration["api"];
            //string condicion = configuration["condicion"];

            //Console.WriteLine(llave1);
            //Console.WriteLine(llave2);
            //Console.WriteLine(licencia);
            //Console.WriteLine(api);
            //Console.WriteLine(condicion);
            //Console.WriteLine(configuration["archivo"]);
        }
        public void Run()
        {
            InitAliceKeys();
            byte[] aliceData = Encoding.UTF8.GetBytes("Alice");
            byte[] aliceSignature = CreateSignature(aliceData, _aliceKeySignature);
            Console.WriteLine($"Alice created signature: " + $"{Convert.ToBase64String(aliceSignature)}");
            if (VerifySignature(aliceData, aliceSignature, _alicePubKeyBlob))
            {
                Console.WriteLine("Alice signature verified successfully");
            }


        }

        private void InitAliceKeys()
        {
            _aliceKeySignature = CngKey.Create(CngAlgorithm.ECDiffieHellmanP521);
            _alicePubKeyBlob = _aliceKeySignature.Export(CngKeyBlobFormat.GenericPublicBlob);
        }

        public bool VerifySignature(byte[] data, byte[] signature, byte[] pubKey)
        {
            bool retValue = false;
            using (CngKey key = CngKey.Import(pubKey,
            CngKeyBlobFormat.GenericPublicBlob))
            using (var signingAlg = new ECDsaCng(key))
            {
                retValue = signingAlg.VerifyData(data, signature,
                HashAlgorithmName.SHA512);
                signingAlg.Clear();
            }
            return retValue;
        }

        public byte[] CreateSignature(byte[] data, CngKey key)
        {
            byte[] signature;
            using (var signingAlg = new ECDsaCng(key))
            {
                signature = signingAlg.SignData(data,
                HashAlgorithmName.SHA512);
                signingAlg.Clear();

            }
            return signature;
        }

        static WindowsIdentity ShowIdentityInformation()
        {
            var identity = WindowsIdentity.GetCurrent();
            if (identity == null)
            {
                Console.WriteLine("not a Windows Identity");
                return null;
            }

            Console.WriteLine($"IdentityType:{identity}");
            Console.WriteLine($"Name:{identity.Name}");
            Console.WriteLine($"Authenticated:{identity.IsAuthenticated}");
            Console.WriteLine($"Authentication Type:{identity.AuthenticationType}");
            Console.WriteLine($"Anonymous?{identity.IsAnonymous}");
            Console.WriteLine($"Access Token:" + $"{identity.AccessToken.DangerousGetHandle()}");
            Console.WriteLine();
            return identity;
        }

        static WindowsPrincipal ShowPrincipal(WindowsIdentity identity)
        {
            Console.WriteLine("Show principal information");
            WindowsPrincipal principal = new WindowsPrincipal(identity);

            if (principal == null)
            {
                Console.WriteLine("not a Windows Principal");
            }
            Console.WriteLine($"Users?{ principal.IsInRole(WindowsBuiltInRole.User)}");
            Console.WriteLine($"Administrators?{ principal.IsInRole(WindowsBuiltInRole.Administrator)}");
            Console.WriteLine();

            return principal;

        }

        static void ShowClaims(IEnumerable<Claim> claims)
        {
            Console.WriteLine("claims");
            foreach (var claim in claims)
            {
                Console.WriteLine($"Subject: {claim.Subject}");
                Console.WriteLine($"Issuer: {claim.Issuer}");
                Console.WriteLine($"Type: {claim.Type}");
                Console.WriteLine($"Value type: {claim.ValueType}");
                Console.WriteLine($"Value: {claim.Value}");
                foreach (var prop in claim.Properties)
                {
                    Console.WriteLine($"\tProperty: {prop.Key}{ prop.Value}");

                }

            }



        }

        public static void DecompressFile()
        {

            const string fileName = @"C:\GitFran\Sample1Compress.zip";
            FileStream inputStream = File.OpenRead(fileName);
            using (MemoryStream outputStream = new MemoryStream())
            using (var compressStream = new DeflateStream(inputStream, CompressionMode.Decompress))
            {
                compressStream.CopyTo(outputStream);
                outputStream.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(outputStream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, bufferSize: 4096, leaveOpen: true))
                {
                    string result = reader.ReadToEnd();
                    Console.WriteLine(result);
                }
                // you could use the outputStream after the StreamReaderis closed
            }
        }

        static void CompressFile()
        {
            const string fileName = @"C:\GitFran\Sample1.txt";
            const string compressName = @"C:\GitFran\Sample1Compress.zip";

            using (var inputStream = File.OpenRead(fileName))
            {
                var outputStream = File.OpenWrite(compressName);
                using (var compressStream = new DeflateStream(outputStream, CompressionMode.Compress))
                {
                    inputStream.CopyTo(compressStream);
                }
            }
        }

        public static void WriteFileUsingBinaryWriter()
        {

            const string binFile = @"C:\GitFran\WriteFileNameBinary.txt";
            var outputStream = File.Create(binFile);
            using (var writer = new BinaryWriter(outputStream))
            {
                double d = 47.47;
                int i = 42;
                long l = 987654321;
                string s = "sample";
                writer.Write(d);
                writer.Write(i);
                writer.Write(l);
                writer.Write(s);
            }
        }

        static void ReadFileUsingBinaryReader()
        {
            const string binFile = @"C:\GitFran\WriteFileNameBinary.txt";
            var inputStream = File.Open(binFile, FileMode.Open);
            using (var reader = new BinaryReader(inputStream))
            {
                double d = reader.ReadDouble();
                int i = reader.ReadInt32();
                long l = reader.ReadInt64();
                string s = reader.ReadString();


                Console.WriteLine($"d: {d}, i: {i}, l: {l}, s: {s}");
            }
        }



        static void WriteFileUsingWriter()
        {

            const string fileName = @"C:\GitFran\WriteFileName.txt";
            string[] lines = new string[]{"Primero",
                                          "Segundo"};


            var outputStream = File.OpenWrite(fileName);
            using (var writter = new StreamWriter(outputStream))
            {
                var preamble = Encoding.UTF8.GetPreamble();
                outputStream.Write(preamble, 0, preamble.Length);
                lines.ToList().ForEach(item =>
                {
                    writter.Write(item);
                });

            }

        }
        static void ReadFileUsingFileStream()
        {

            var fileName = Path.Combine(@"C:\GitFran", "Sample1.txt");

            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                ShowStreamInformation(stream);

                var a = Encoding.UTF8.GetBytes(new StreamReader(stream, Encoding.UTF8).ReadToEnd().ToString());

                const int BUFFERSIZE = 256;
                byte[] buffer = new byte[BUFFERSIZE];
                var completed = false;

                do
                {
                    int nread = stream.Read(buffer, 0, BUFFERSIZE);
                    if (nread == 0) completed = true;
                    if (nread < BUFFERSIZE)
                    {
                        Array.Clear(buffer, nread, BUFFERSIZE - nread);
                    }
                    var s = Encoding.UTF8;
                    Console.WriteLine($"read {nread} bytes");
                    Console.WriteLine(s);
                } while (!completed);
            }


        }

        static void ShowStreamInformation(Stream stream)
        {
            Console.WriteLine($"stream can read: {stream.CanRead}, " + $"can write: {stream.CanWrite}, can seek: { stream.CanSeek}," +
                              $"can timeout: {stream.CanTimeout}");

            Console.WriteLine($"length: {stream.Length}, position:{ stream.Position} ");
            if (stream.CanTimeout)
            {
                Console.WriteLine($"read timeout: {stream.ReadTimeout} " + $"write timeout: {stream.WriteTimeout} ");
            }
        }
        static void PrintFiles()
        {
            Console.WriteLine(Path.Combine(@"C:\", "Libro.txt")); //write c:\Libro.text but this file isn't in this directory

            //Create Files
            const string Sample1FileName = "Sample1.txt";
            const string Sample2FileName = "Sample2.txt";

            var fileName = Path.Combine(@"C:\GitFran", Sample1FileName);
            var fileName2 = Path.Combine(@"C:\GitFran", Sample2FileName);


            File.WriteAllText(fileName, "Hello World");


            var file = new FileInfo(fileName);
            //file.CopyTo(fileName2); //I comment this because every time is generate an error
            //File.Copy(fileName, fileName2);//Throw an execption because this file exists in this directory
            PrintFileInfo(@"C:\GitFran\Libro.txt");
            //Diference between File.ReadAllFiles(FileName) and File.ReadLines(FileName)
            //ReadAllFiles:Wait until all lines have been read
            //ReadLines:Wait until execute a loop
            string fileNameMovies = Path.Combine(@"C:\GitFran", "movies.txt");
            string[] movies =
                        {
                         "Snow White And The Seven Dwarfs",
                         "Gone With The Wind",
                         "Casablanca",
                         "The Bridge On The River Kwai",
                         "Some Like It Hot"
            };
            File.WriteAllLines(fileName, movies);




        }

        static void PrintFileInfo(string fileName)
        {
            var file = new FileInfo(fileName);
            Console.WriteLine($"Name: {file.Name}");
            Console.WriteLine($"Directory: {file.DirectoryName}");
            Console.WriteLine($"Read only: {file.IsReadOnly}");
            Console.WriteLine($"Extension: {file.Extension}");
            Console.WriteLine($"Length: {file.Length}");
            Console.WriteLine($"Creation time: {file.CreationTime:F}");
            Console.WriteLine($"Access time: {file.LastAccessTime:F}");
            Console.WriteLine($"File attributes: {file.Attributes}");
        }
        static void PrintAllDrives()
        {
            var drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                if (drive.IsReady)
                {
                    Console.WriteLine($"Drive name: {drive.Name}");
                    Console.WriteLine($"Format: {drive.DriveFormat}");
                    Console.WriteLine($"Type: {drive.DriveType}");
                    Console.WriteLine($"Root directory:{ drive.RootDirectory} ");
                    Console.WriteLine($"Volume label: {drive.VolumeLabel}");
                    Console.WriteLine($"Free space: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Available space:{ drive.AvailableFreeSpace}");
                    Console.WriteLine($"Total size: {drive.TotalSize}");
                    Console.WriteLine();
                }
            }

        }
        public static void ContinuationTasks()
        {
            Task t1 = new Task(DoOnFirst);
            Task t2 = t1.ContinueWith(DoOnSecond);
            Task t3 = t1.ContinueWith(DoOnSecond);
            Task t4 = t2.ContinueWith(DoOnSecond);
            t1.Start();
        }

        private static void DoOnFirst()
        {
            Console.WriteLine($"doing some task {Task.CurrentId}");
            Task.Delay(3000).Wait();
        }
        private static void DoOnSecond(Task t)
        {
            Console.WriteLine($"task {t.Id} finished");
            Console.WriteLine($"this task id {Task.CurrentId}");
            Console.WriteLine("do some cleanup");
            Task.Delay(3000).Wait();
        }
        public static void TaskWithResultDemo()
        {
            var t1 = new Task<(int Result, int Remainder)>(TaskWithResult, (8, 3));
            t1.Start();
            Console.WriteLine(t1.Result);
            t1.Wait();
            Console.WriteLine($"result from task: {t1.Result.Result} " + $"{t1.Result.Remainder}");
        }
        static (int Result, int Remainder) TaskWithResult(object division)
        {
            (int x, int y) = ((int x, int y))division;
            int result = x / y;
            int remainder = x % y;
            Console.WriteLine("Task creates a result....");
            return (result, remainder);
        }

        static void ProcessAndDisplayNumber(DoubleOp action, double value)
        {
            var result = action(value);
            Console.WriteLine($"Value is {value}, result of operation is {result}");
        }

        static void Data_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine($"action:{e.Action.ToString()}");
            if (e.OldItems != null)
            {
                Console.WriteLine($"starting index for old item(s):{e.OldStartingIndex}");
                Console.WriteLine("old item(s):");
                foreach (var item in e.OldItems)
                {
                    Console.WriteLine(item);
                }
            }

            if (e.NewItems != null)
            {
                Console.WriteLine($"starting index for new item(s):{e.NewStartingIndex}");
                Console.WriteLine("new item(s):");
                foreach (var item in e.NewItems)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine();

        }

        private static void IntroWithLambdaExpression()
        {
            Func<int, int, int> add = (x, y) =>
               {
                   return x + y;
               };

            int result = add(37, 5);
            Console.WriteLine(result);

        }

        private static void IntroWithLocalFunctions()
        {
            int add(int x, int y)
            {
                return x + y;
            };

            int result = add(37, 5);


        }

        static (int result, int remainder) Divide(int dividend, int divisor)
        {
            int result1 = dividend / divisor;
            int remainder1 = dividend % divisor;
            return (result1, remainder1);

        }

        static void TestException()
        {

            try
            {
                var person = new Person("Fran", "Dieste");
                person.WriteDescription();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The error is {ex.Message}");
                ex.Data.Add("Person", "Error en TestException");
                throw;
            }




        }

        //synchronous call
        //Using WebClient

        private static void SynchronizeApi()
        {
            const string url = "http://www.cninnovation.com";
            Console.WriteLine(nameof(SynchronizeApi));
            using (var client = new WebClient())
            {
                string content = client.DownloadString(url);
                Console.WriteLine(content.Substring(0, 100));
            }
            Console.WriteLine("Fin synchronize");
        }

        private static void AsynchronousPattern()
        {
            const string url = "http://www.cninnovation.com";
            Console.WriteLine(nameof(AsynchronousPattern));
            var request = WebRequest.Create(url);

            var result = request.BeginGetResponse(ReadResponse, null);

            void ReadResponse(IAsyncResult ar)
            {
                using (var response = request.EndGetResponse(ar))
                {
                    var stream = response.GetResponseStream();
                    var read = new StreamReader(stream);
                    var content = read.ReadToEnd();
                    Console.WriteLine(content.Substring(0, 100));
                    Console.WriteLine("Fin asynchronous");
                }
            }
        }

        private static void EventBasedAsyncPattern()
        {
            const string url = "http://www.google.com";
            Console.WriteLine(nameof(EventBasedAsyncPattern));
            using (var client = new WebClient())
            {
                client.DownloadStringCompleted += (sender, e) =>
               {
                   Console.WriteLine(e.Result.Substring(0, 100));
               };

                client.DownloadStringAsync(new Uri(url));
                Console.WriteLine();

            }
        }

        static void PrintTaskPattern()
        {
            //En éste caso el metodo TaskBasedAsyncPatternAsync corre asincrono ya que  tiene la palabra await
            var tk1 = Task.Run(async () =>
            {
                var result = await TaskBasedAsyncPatternAsync();
                Console.WriteLine(result);

                //var result2 = TaskBasedAsyncPatternAsync();
                //Console.WriteLine(result);
            });

            ////En éste caso el metodo TaskBasedAsyncPatternAsync corre sincrono ya que no tiene la palabra await
            var tk2 = Task.Run(() =>
            {
                var result = TaskBasedAsyncPatternAsync();
                Console.WriteLine(result);


            });

            tk1.Wait();

            tk2.Wait();


            var a = TaskBasedAsyncPatternAsync2();


            //using awaiter

            var awaiterResult = TaskBasedAsyncPatternAsync().GetAwaiter().GetResult();

            var awaiter = TaskBasedAsyncPatternAsync().GetAwaiter();

            awaiter.OnCompleted(OnCompleteAwaiter);
            void OnCompleteAwaiter()
            {
                Console.WriteLine(awaiter.GetResult());
                Console.WriteLine("Fin awaiter");
            }

            //Task.WaitAll(tk1, tk2);

            //TaskBasedAsyncPatternAsync2();

            //Using ValueTasks
            var result = GreetingValueTask2Async("Hola value Task Mundo");

            Console.WriteLine("aqui");
        }
        private static async Task<string> TaskBasedAsyncPatternAsync()
        {
            const string url = "http://www.google.com";
            Console.WriteLine(nameof(TaskBasedAsyncPatternAsync));
            using (var client = new WebClient())
            {

                var content = await client.DownloadStringTaskAsync(url);
                Console.WriteLine(content.Substring(0, 100));
                Console.WriteLine();

                return content;

            }
        }

        private static string TaskBasedAsyncPatternAsync2()
        {
            const string url = "http://www.google.com";
            Console.WriteLine(nameof(TaskBasedAsyncPatternAsync));
            using (var client = new WebClient())
            {
                var content = client.DownloadStringTaskAsync(url).GetAwaiter().GetResult();

                Console.WriteLine(content.Substring(0, 100));

                // var content = await client.DownloadStringTaskAsync(url);

                Console.WriteLine();

                return content;

            }
        }

        //awaiter
        //private static void CallerWithAwaiter()
        //{
        //    TraceThreadAndTask($"starting {nameof(CallerWithAwaiter)}");
        //    TaskAwaiter<string> awaiter = GreetingAsync("Matthias").GetAwaiter();
        //    awaiter.OnCompleted(OnCompleteAwaiter);
        //    void OnCompleteAwaiter()
        //    {
        //        Console.WriteLine(awaiter.GetResult());
        //        TraceThreadAndTask($"ended {nameof(CallerWithAwaiter)}");

        //    }
        //}

        public static void TraceThreadAndTask(string info)
        {
            string taskInfo = Task.CurrentId == null ? "no task" :
            "task " +
            Task.CurrentId;

            Console.WriteLine($"{info} in thread { Thread.CurrentThread.ManagedThreadId} " +
                              $"and {taskInfo}");
        }
        static string Greeting(string name)
        {
            TraceThreadAndTask($"running {nameof(Greeting)}");
            Task.Delay(3000).Wait();
            return $"Hello, {name}";
        }

        static Task<string> GreetingAsync(string name) =>
        Task.Run<string>(() =>
        {
            TraceThreadAndTask($"running {nameof(GreetingAsync)}");
            return Greeting(name);
        });

        static async ValueTask<string> GreetingValueTaskAsync(string name)
        {
            if (names.TryGetValue(name, out string result))
            {
                return result;
            }
            else
            {
                result = await GreetingAsync(name);
                names.Add(name, result);
                return result;
            }
        }

        static ValueTask<string> GreetingValueTask2Async(string name)
        {
            if (names.TryGetValue(name, out string result))
            {
                return new ValueTask<string>(result);
            }
            else
            {
                Task<string> t1 = GreetingAsync(name);
                TaskAwaiter<string> awaiter = t1.GetAwaiter();
                awaiter.OnCompleted(OnCompletion);
                return new ValueTask<string>(t1);
                void OnCompletion()
                {
                    names.Add(name, awaiter.GetResult());
                }
            }
        }

        static object CreateDynamicallyObjectClass(string classPath, string className)
        {

            var assembly = Assembly.LoadFile(classPath); //hay que pasar la ruta del fichero
            var myObject = assembly.CreateInstance(className);
            return myObject;

        }

        static ServiceProvider RegisterServices()
        {

            var assembly = Assembly.GetAssembly(typeof(Program));
            foreach (var item in assembly.DefinedTypes)
            {
                Console.WriteLine(item);
            }





            var services = new ServiceCollection();

            
            services.AddSingleton<IGeetingService, GeetingService>();
            services.AddTransient<HomeController>();
            return services.BuildServiceProvider();

        }

        static void PrintParallelFor()
        {
            var result = Parallel.For(0, 10, i =>
            {
                Console.WriteLine($"S{i}");
                Task.Delay(10).Wait();

            });

            Console.WriteLine($"Is completed:{result.IsCompleted}");

            var result1 = Parallel.For(0, 10, async i =>
            {
                Console.WriteLine($"S{i}");
                await Task.Delay(10);

            });

            //Stop Parallel loop
            var result2 = Parallel.For(10, 40, (int i, ParallelLoopState pls) =>
            {
                if (i > 12)
                {
                    pls.Break();
                    Console.WriteLine($"Parallel process is stopped");
                }

                Console.WriteLine($"S{i}");
                Task.Delay(10).Wait();

            });



            Console.WriteLine($"Is completed:{result1.IsCompleted}");

        }

        static void PrintParallelForEach()
        {
            string[] data = {"zero", "one", "two", "three", "four",
                             "five","six", "seven", "eight", "nine", "ten", "eleven",
                             "twelve"};

            ParallelLoopResult result = Parallel.ForEach<string>(data, s =>
            {
                Console.WriteLine(s);
            });

            //Invoke diferents methods.
            Parallel.Invoke(Foo, Bar);

            Console.WriteLine("Fin");

        }

        static void Foo() => Console.WriteLine("Foo");
        static void Bar() => Console.WriteLine("bar");

        static void TaskMethod(object o)
        {
            Log(o?.ToString());
        }
        static void Log(string title)
        {
            lock (s_logLock)
            {
                Console.WriteLine(title);
                Console.WriteLine($"Task id: {Task.CurrentId?.ToString() ?? "no task"}, " + $"thread: {Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine($"is pooled thread: " + $"{Thread.CurrentThread.IsThreadPoolThread}");
                Console.WriteLine($"is background thread: " + $"{Thread.CurrentThread.IsBackground}");
                Console.WriteLine();
            }

        }

        public static void TasksUsingThreadPool()
        {
            var tf = new TaskFactory();
            Task t1 = tf.StartNew(TaskMethod, "using a task factory");
            Task t2 = Task.Factory.StartNew(TaskMethod, "factory via a task");
            var t3 = new Task(TaskMethod, "using a task constructor and Start");
            t3.Start();
            Task t4 = Task.Run(() => TaskMethod("using the Run  method"));
        }

        private static void RunSynchronousTask()
        {
            //Tasks can also run synchronously, with
            //the same thread as the calling thread

            TaskMethod("just the main thread");
            var t1 = new Task(TaskMethod, "run sync");
            t1.RunSynchronously();
        }

        private static void LongRunningTask()
        {
            var t1 = new Task(TaskMethod, "long running",
            TaskCreationOptions.LongRunning);
            t1.Start();
        }

        static double DoubleTest(int a, int b)
        {
            double result = (double)((double)(a + b) / 2); //Correct

            double result1 = (double)(a + b) / 2;  //Correct

            double result2 = (double)(a + b / 2);//Wrong


            return result;
        }

        public static string[] UniqueNames(string[] names1, string[] names2)
        {




            var a = names1.Where(x => !names2.Contains(x)).ToArray();
            var b = names2.Where(x => !names1.Contains(x)).ToArray();
            var c = a.Concat(b).ToArray();



            return c;
        }

        static async Task<string> GetDataSimpleAsync()
        {
           // const string NorthwindUrl = "http://services.data.org/Northwind/Northwind.svc/Regions";

            //const string google = "https://www.google.com";

            var url = "http://www.cninnovation.com";

            HttpClient client = new HttpClient();

            try
            {

                //Falta pasar un Header en GetDataSimpleAsync pag 1153
                client.DefaultRequestHeaders.Add("Accept", "application/json;data=verbose");
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Response Status Code:{ (int)response.StatusCode} " + $"{response.ReasonPhrase}");
                    string responseBodyAsText = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Received payload of { responseBodyAsText.Length} characters");
                    Console.WriteLine();
                    Console.WriteLine(responseBodyAsText);
                    return responseBodyAsText;
                }

                return "Not ok";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }



    }

}

