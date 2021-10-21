﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    public record ValidatedCart(ProductCode productCode, Quantity quantity, Address address, Price price);
}
