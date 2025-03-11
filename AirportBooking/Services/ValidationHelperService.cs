using AirportBooking.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Reflection;


namespace AirportBooking.Services
{
    class ValidationHelperService
    {
        public static List<string> ValidateModel(object model)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            bool isValid = Validator.TryValidateObject(model, context, results, true);

            var errors = new List<string>();
            foreach (var validationResult in results)
            {
                errors.Add(validationResult.ErrorMessage);
            }
            return errors;
        }

        public static Dictionary<string, List<string>> GetValidationRules(Type modelType)
        {
            var validationRules = new Dictionary<string, List<string>>();

            foreach (var property in modelType.GetProperties())
            {
                var rules = new List<string>();

                foreach (var attribute in property.GetCustomAttributes<ValidationAttribute>())
                {
                    if (attribute is RequiredAttribute)
                        rules.Add("Required");

                    if (attribute is RangeAttribute range)
                        rules.Add($"Range: {range.Minimum} - {range.Maximum}");

                    if (attribute is DataTypeAttribute dataType)
                        rules.Add($"Type: {dataType.DataType}");

                    if (attribute is FutureDateAttribute)
                        rules.Add("Must be a future date");
                }

                if (rules.Count > 0)
                    validationRules[property.Name] = rules;
            }

            return validationRules;
        }
    }
}
