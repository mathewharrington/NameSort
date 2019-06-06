using System;
using System.Collections.Generic;
using System.Linq;
using NameSorter.Application.Model;
using NameSorter.Application.Model.Entities;
using NUnit.Framework;

namespace NameSorter.Tests.Application.Model
{
    [TestFixture]
    public class NameSorterTest
    {
        [Test]
        public void SortNames_GivenNullList_ExpectExceptionNotThrown()
        {
            // Arrange.
            var target = new Sorter();

            // Assert.
            Assert.DoesNotThrow(() => target.SortNames(null));
        }

        [Test]
        public void SortNames_GivenEmptyList_ExpectExceptionNotThrown()
        {
            // Arrange.
            var target = new Sorter();
            var names = new List<Name>();

            // Assert.
            Assert.DoesNotThrow(() => target.SortNames(names));
        }

        [Test]
        public void SortNames_GivenListWithFirstAndLastNames_ExpectCorrectOrdering()
        {
            // Arrange.
            var names = new List<Name>
            {
                new Name
                {
                    FirstGivenName = "Bob",
                    Surname = "Brenton"
                },
                new Name
                {
                    FirstGivenName = "Andrew",
                    Surname = "Ainscow"

                },
                new Name
                {
                    FirstGivenName = "Ben",
                    Surname = "Ainscow"
                },
                new Name
                {
                    FirstGivenName = "James",
                    Surname = "Carson"
                },
                new Name
                {
                    FirstGivenName = "Charlie",
                    Surname = "Ainscow"
                },
            };

            var expected = new List<Name>
            {
                new Name
                {
                    FirstGivenName = "Andrew",
                    Surname = "Ainscow"

                },
                new Name
                {
                    FirstGivenName = "Ben",
                    Surname = "Ainscow"
                },
                 new Name
                {
                    FirstGivenName = "Charlie",
                    Surname = "Ainscow"
                },
                new Name
                {
                    FirstGivenName = "Bob",
                    Surname = "Brenton"
                },
                new Name
                {
                    FirstGivenName = "James",
                    Surname = "Carson"
                },               
            };

            var target = new Sorter();

            // Act.
            var result = target.SortNames(names);

            // Assert.
            Assert.AreEqual(5, result.Count);
            Assert.AreEqual(expected.ElementAt(0).GetConcatenatedName(), result.ElementAt(0).GetConcatenatedName());
            Assert.AreEqual(expected.ElementAt(1).GetConcatenatedName(), result.ElementAt(1).GetConcatenatedName());
            Assert.AreEqual(expected.ElementAt(2).GetConcatenatedName(), result.ElementAt(2).GetConcatenatedName());
            Assert.AreEqual(expected.ElementAt(3).GetConcatenatedName(), result.ElementAt(3).GetConcatenatedName());
            Assert.AreEqual(expected.ElementAt(4).GetConcatenatedName(), result.ElementAt(4).GetConcatenatedName());
        }

        [Test]
        public void SortNames_GivenListWithFirstSecondAndLastNames_ExpectCorrectOrdering()
        {
            // Arrange.
            var names = new List<Name>
            {
                new Name
                {
                    FirstGivenName = "Bob",
                    Surname = "Brenton"
                },
                new Name
                {
                    FirstGivenName = "Andrew",
                    Surname = "Ainscow"

                },
                new Name
                {
                    FirstGivenName = "Ben",
                    SecondGivenName = "Simon",
                    Surname = "Ainscow"
                },
                new Name
                {
                    FirstGivenName = "James",
                    Surname = "Carson"
                },
                new Name
                {
                    FirstGivenName = "Ben",
                    SecondGivenName = "Zach",
                    Surname = "Ainscow"
                },
            };

            var expected = new List<Name>
            {
                new Name
                {
                    FirstGivenName = "Andrew",
                    Surname = "Ainscow"

                },
                new Name
                {
                    FirstGivenName = "Ben",
                    SecondGivenName = "Simon",
                    Surname = "Ainscow"
                },
                 new Name
                {
                    FirstGivenName = "Ben",
                    SecondGivenName = "Zach",
                    Surname = "Ainscow"
                },
                new Name
                {
                    FirstGivenName = "Bob",
                    Surname = "Brenton"
                },
                new Name
                {
                    FirstGivenName = "James",
                    Surname = "Carson"
                },
            };

            var target = new Sorter();

            // Act.
            var result = target.SortNames(names);

            // Assert.
            Assert.AreEqual(5, result.Count);
            Assert.AreEqual(expected.ElementAt(0).GetConcatenatedName(), result.ElementAt(0).GetConcatenatedName());
            Assert.AreEqual(expected.ElementAt(1).GetConcatenatedName(), result.ElementAt(1).GetConcatenatedName());
            Assert.AreEqual(expected.ElementAt(2).GetConcatenatedName(), result.ElementAt(2).GetConcatenatedName());
            Assert.AreEqual(expected.ElementAt(3).GetConcatenatedName(), result.ElementAt(3).GetConcatenatedName());
            Assert.AreEqual(expected.ElementAt(4).GetConcatenatedName(), result.ElementAt(4).GetConcatenatedName());
        }

        [Test]
        public void SortNames_GivenListWithAllNames_ExpectCorrectOrdering()
        {
            // Arrange.
            var names = new List<Name>
            {
                new Name
                {
                    FirstGivenName = "James",
                    SecondGivenName = "John",
                    ThirdGivenName = "Michale",
                    Surname = "Carson"
                },
                new Name
                {
                    FirstGivenName = "Andrew",
                    SecondGivenName = "Mathew",
                    ThirdGivenName = "Steven",
                    Surname = "Ainscow"
                },
                new Name
                {
                    FirstGivenName = "Bob",
                    SecondGivenName = "Mathew",
                    ThirdGivenName = "Zach",
                    Surname = "Brenton"
                },
                new Name
                {
                    FirstGivenName = "Andrew",
                    SecondGivenName = "Mathew",
                    ThirdGivenName = "Zach",
                    Surname = "Ainscow"
                },

                new Name
                {
                    FirstGivenName = "Andrew",
                    SecondGivenName = "David",
                    ThirdGivenName = "Steven",
                    Surname = "Ainscow"
                },
            };

            var expected = new List<Name>
            {
                new Name
                {
                    FirstGivenName = "Andrew",
                    SecondGivenName = "David",
                    ThirdGivenName = "Steven",
                    Surname = "Ainscow"

                },
                new Name
                {
                    FirstGivenName = "Andrew",
                    SecondGivenName = "Mathew",
                    ThirdGivenName = "Steven",
                    Surname = "Ainscow"
                },
                new Name
                {
                    FirstGivenName = "Andrew",
                    SecondGivenName = "Mathew",
                    ThirdGivenName = "Zach",
                    Surname = "Ainscow"
                },
                new Name
                {
                    FirstGivenName = "Bob",
                    SecondGivenName = "Mathew",
                    ThirdGivenName = "Zach",
                    Surname = "Brenton"
                },
                new Name
                {
                    FirstGivenName = "James",
                    SecondGivenName = "John",
                    ThirdGivenName = "Michale",
                    Surname = "Carson"
                },
            };

            var target = new Sorter();

            // Act.
            var result = target.SortNames(names);

            // Assert.
            Assert.AreEqual(5, result.Count);
            Assert.AreEqual(expected.ElementAt(0).GetConcatenatedName(), result.ElementAt(0).GetConcatenatedName());
            Assert.AreEqual(expected.ElementAt(1).GetConcatenatedName(), result.ElementAt(1).GetConcatenatedName());
            Assert.AreEqual(expected.ElementAt(2).GetConcatenatedName(), result.ElementAt(2).GetConcatenatedName());
            Assert.AreEqual(expected.ElementAt(3).GetConcatenatedName(), result.ElementAt(3).GetConcatenatedName());
            Assert.AreEqual(expected.ElementAt(4).GetConcatenatedName(), result.ElementAt(4).GetConcatenatedName());
        }
    }
}
