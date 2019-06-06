using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using NameSorter.Application.Infrastructure;
using NameSorter.Application.Model;
using NameSorter.Application.Service;

namespace NameSorter
{
    class Program
    {
        #region Private Members

        private static IServiceProvider _serviceProvider;
        private static readonly string _exceptionFile = "errors.txt";

        #endregion

        static void Main(string[] args)
        {
            if(!ValidateArgsLength(args))
            {
                return;
            }

            var filenameArgument = args[0];
            var fileName = Path.GetFileName(filenameArgument);

            // Configure container and get instance of Name Service.
            ConfigureServices();

            var nameService = _serviceProvider.GetService<INameService>();

            try
            {
                // Get sorted names from file.
                var sortedNames = nameService.GetSortedNames(fileName);

                // Print names to screen.
                foreach (var name in sortedNames)
                {
                    Console.WriteLine(name.GetConcatenatedName());
                }

                // Save sorted names to file.
                nameService.SaveNames(sortedNames);
            }

            catch(FileNotFoundException ex)
            {
                Console.WriteLine($"Could not find file {filenameArgument}");
                Console.WriteLine("See errors.txt for full stack trace");
                LogError(ex);
            }

            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine("See errors.txt for full stack trace");
                LogError(ex);
            }

            // Release resources.
            DisposeServices();

        }

        #region Private Methods

        private static void ConfigureServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<INameService, NameService>();
            collection.AddScoped<INameRepository, NameRepository>();
            collection.AddScoped<INameDao, NameFileSystemDao>();
            collection.AddScoped<ISorter, Sorter>();

            _serviceProvider = collection.BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider != null && _serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }

        private static void LogError(Exception ex)
        {
            if (File.Exists(_exceptionFile))
            {
                File.Delete(_exceptionFile);
            }

            using (StreamWriter writer = File.AppendText(_exceptionFile))
            {
                writer.WriteLine($"{DateTime.Now.ToString()} {ex.StackTrace}");                
            }
        }

        private static bool ValidateArgsLength(string[] args)
        {
            if (args.Length > 0)
                return true;

            Console.WriteLine("Filename must be provided.");
            return false;
        }

        #endregion
    }
}
