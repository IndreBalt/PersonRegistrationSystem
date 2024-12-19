using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PersonRegistrationSystem.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class EmailValidatorAttribute: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var type = value as string;
            if (type is not null)
            {
                string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`
                            {|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                return regex.IsMatch(type);
            }
            return false;
        }
    }
}
