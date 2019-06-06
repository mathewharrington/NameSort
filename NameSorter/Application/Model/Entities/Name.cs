using System;
namespace NameSorter.Application.Model.Entities
{
    public class Name
    {
        #region Properties

        public string Surname { get; set; }
        public string FirstGivenName { get; set; }
        public string SecondGivenName { get; set; }
        public string ThirdGivenName { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Builds the concatenated name for display.
        /// </summary>
        /// <returns>The concatenated name for display.</returns>
        public string GetConcatenatedName()
        {
            var displayName = $"{FirstGivenName} ";

            if (!string.IsNullOrEmpty(SecondGivenName))
                displayName += $"{SecondGivenName} ";

            if (!string.IsNullOrEmpty(ThirdGivenName))
                displayName += $"{ThirdGivenName} ";

            displayName += $"{Surname}";

            return displayName;
        }

        #endregion
    }
}
