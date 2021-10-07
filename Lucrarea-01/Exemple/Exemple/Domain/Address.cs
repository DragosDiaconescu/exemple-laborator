using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    class Address
    {
        private static readonly Regex ValidPattern = new("{str}");

        public string _address { get; }

        private Address(string address)
        {
            if (ValidPattern.IsMatch(address))
            {
                _address = address;
            }
            else
            {
                throw new InvalidAddressException("");
            }
        }

        public override string ToString()
        {
            return _address;
        }
    }
}
