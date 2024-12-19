using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PersonRegistrationSystem.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class PersonalCodeValidatorAttribute: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var personalCode = value.ToString();
            if (personalCode is not null)
            {                
                string pattern = @"^(1|2|3|4)\d{2}(0[1-9]|1[0-2])(0[1-9]|[12][0-9]|3[01])\d{4}";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                return regex.IsMatch(personalCode);
            }
            return false;
        }
    }
}
