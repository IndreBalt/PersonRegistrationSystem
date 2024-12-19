using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PersonRegistrationSystem.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class PhoneNumberLTValidatorAttribute: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var type = value.ToString();
            if(type is not null)
            {
                string pattern = @"^\+370\d{8}$|^370\d{8}$";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                return regex.IsMatch(type);
            }
            return false;
        }
    }
}
