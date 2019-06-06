using NameSorter.Application.Model.Entities;
using NUnit.Framework;

namespace NameSorter.Tests.Application.Model.Entities
{
    [TestFixture]
    public class NameEntityTest
    {
        [Test]
        public void GetConcatenatedName_GivenAllNamesPopulated_ExpectAllInResult()
        {
            // Arrange.
            var expected = "Patrick Simon Alex Dangerfield";

            var target = new Name
            {
                FirstGivenName = "Patrick",
                SecondGivenName = "Simon",
                ThirdGivenName = "Alex",
                Surname = "Dangerfield"
            };

            // Act.
            var result = target.GetConcatenatedName();

            // Assert.
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetConcatenatedName_GivenOnlyFirstAndLastNamesPopulated_ExpectOnlyThemInResult()
        {
            // Arrange.
            var expected = "Patrick Dangerfield";

            var target = new Name
            {
                FirstGivenName = "Patrick",
                Surname = "Dangerfield"
            };

            // Act.
            var result = target.GetConcatenatedName();

            // Assert.
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetConcatenatedName_GivenThreeNamesPopulated_ExpectThemInResult()
        {
            // Arrange.
            var expected = "Patrick James Dangerfield";

            var target = new Name
            {
                FirstGivenName = "Patrick",
                SecondGivenName = "James",
                Surname = "Dangerfield"
            };

            // Act.
            var result = target.GetConcatenatedName();

            // Assert.
            Assert.AreEqual(expected, result);
        }
    }
}
