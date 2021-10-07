using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Choices;

namespace Exemple.Domain
{
    [AsChoice]
    public static partial class Carts
    {
        public interface IShoppingCart { }

        public record EmptyCarts(IReadOnlyCollection<EmptyCart> ShoppingCarts) : IShoppingCart;

        public record UnvalidatedCarts(IReadOnlyCollection<UnvalidatedCart> ShoppingCarts, string reason) : IShoppingCart;

        public record ValidatedCarts(IReadOnlyCollection<ValidatedCart> ShoppingCarts) : IShoppingCart;

        public record PaidCarts(IReadOnlyCollection<ValidatedCart> ShoppingCarts, DateTime PublishedDate) : IShoppingCart;
    }
}
