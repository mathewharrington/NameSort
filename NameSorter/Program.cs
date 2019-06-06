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
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            var fullFileArgument = args[0];
            var fileName = Path.GetFileName(fullFileArgument);
            var directory = Path.GetDirectoryName(fullFileArgument);

            // Configure container and get instance of Name Service.
            ConfigureServices();
            var nameService = _serviceProvider.GetService<INameService>();

            // Read in names from file.
            var names = nameService.GetNames(fileName, directory);

            // Sort names.
            var sortedNames = nameService.SortNames(names);

            // Print names to screen.
            foreach(var name in sortedNames)
            {
                var displayName = $"{name.FirstGivenName} ";

                if(!string.IsNullOrEmpty(name.SecondGivenName))
                    displayName += $"{name.SecondGivenName} ";

                if(!string.IsNullOrEmpty(name.ThirdGivenName))
                    displayName += $"{name.ThirdGivenName} ";

                displayName += $"{name.Surname}";

                Console.WriteLine(displayName);
            }

            // Save sorted names to file.

            // Dispose container.
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

        #endregion
    }
}
