using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcTraining.Entities
{
    public class Address : IValidatableObject
    {
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var count = CountEmptyProperties();
            if (count == 3 || count == 0)
                yield break;

            if (string.IsNullOrWhiteSpace(Street))
                yield return new ValidationResult("Die Straße muss dabei sein", new[] { "Street" });
            if (string.IsNullOrWhiteSpace(ZipCode))
                yield return new ValidationResult("Die PLZ muss dabei sein", new[] { "ZipCode" });
            if (string.IsNullOrWhiteSpace(City))
                yield return new ValidationResult("Die Stadt muss dabei sein", new[] { "City" });
        }

        private int CountEmptyProperties()
        {
            int count = 0;
            if (string.IsNullOrWhiteSpace(Street))
                count++;
            if (string.IsNullOrWhiteSpace(City))
                count++;
            if (string.IsNullOrWhiteSpace(ZipCode))
                count++;
            return count;
        }
    }
}