using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POP_SF_15_2016.UI
{
    public class stringValidationRule: ValidationRule
    {
        Regex myRegex = new Regex(@"^\w\d+$", RegexOptions.IgnoreCase);


        public override ValidationResult Validate(Object value, System.Globalization.CultureInfo cultureInfo)
        {
            String v = value as string;
            if (v != null && myRegex.Match(v).Success)
                return new ValidationResult(true, null);
            else
                return new ValidationResult(false, "Polje ne sme biti prazno");
        }
    }
}
