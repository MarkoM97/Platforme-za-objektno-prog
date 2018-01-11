using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POP_SF_15_2016.UI
{
    public class dobleValidationRule: ValidationRule
    {
        Regex myRegex = new Regex(@"-?\d+(?:\.\d+)?", RegexOptions.IgnoreCase);


        public override ValidationResult Validate(Object value, System.Globalization.CultureInfo cultureInfo)
        {
            String v = value as string;
            if (v != null && myRegex.Match(v).Success)
                return new ValidationResult(true, null);
            else
                return new ValidationResult(false, "Vrednost mora biti broj");
        }

    }

   
}
