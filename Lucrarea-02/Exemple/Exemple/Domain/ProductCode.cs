using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    public record ProductCode
    {
        private static readonly Regex ValidPattern = new("^.*$");

        public string Code { get; }

        public ProductCode(string value)
        {
            if (ValidPattern.IsMatch(value))
            {
                Code = value;
            }
            else
            {
                throw new InvalidProductCodeException("");
            }
        }

        public override string ToString()
        {
            return Code;
        }

        private static bool IsValid(string stringValue) => ValidPattern.IsMatch(stringValue);

        public static bool TryParse(string productCodeString, out ProductCode productCode)
        {
            bool isValid = false;
            productCode = null;
            if (IsValid(productCodeString))
            {
                isValid = true;
                productCode = new(productCodeString);
            }
            return isValid;
        }
    }
}
