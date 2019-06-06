using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NameSorter.Application.Model.Entities;

namespace NameSorter.Application.Infrastructure
{
    public class NameFileSystemDao : INameDao
    {
        /// <summary>
        /// Load names from file.
        /// </summary>
        /// <returns>The names.</returns>
        /// <param name="fileName">File name.</param>
        public IList<Name> LoadNames(string fileName)
        {
            var names = new List<Name>();

            FileStream fileStream = new FileStream(fileName, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                while (reader.Peek() >= 0)
                {
                    // One name per line.
                    var line = reader.ReadLine();

                    var nameParts = line.Split(' ').ToList();

                    // We know the last token will be surname, the rest will be given names.
                    var surname = nameParts.Last();
                    nameParts.Remove(surname);

                    var givenNameOne = nameParts.First();
                    var givenNameTwo = nameParts.ElementAtOrDefault(1);
                    var givenNameThree = nameParts.ElementAtOrDefault(2);

                    names.Add(new Name
                    {
                        FirstGivenName = givenNameOne,
                        SecondGivenName = givenNameTwo,
                        ThirdGivenName = givenNameThree,
                        Surname = surname
                    });
                }
            }

            return names;
        }

        /// <summary>
        /// Save provided names to file.
        /// </summary>
        /// <param name="names">Names.</param>
        public void SaveNames(IList<Name> names)
        {
         
        }
    }
}
