using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    public record ShoppingCartCommand
    {
        public ShoppingCartCommand(IReadOnlyCollection<EmptyCart> inputShoppingCarts)
        {
            InputShoppingCarts = inputShoppingCarts;
        }

        public IReadOnlyCollection<EmptyCart> InputShoppingCarts { get; }
    }
}
