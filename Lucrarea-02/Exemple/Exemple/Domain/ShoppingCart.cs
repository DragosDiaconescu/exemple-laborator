using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    [AsChoice]
    public static partial class ShoppingCart
    {
        public interface IShoppingCarts { }

        public record EmptyShoppingCarts : IShoppingCarts
        {
            public EmptyShoppingCarts(IReadOnlyCollection<EmptyCart> shoppingCartList)
            {
                ShoppingCartList = shoppingCartList;
            }

            public IReadOnlyCollection<EmptyCart> ShoppingCartList { get; }
        }

        public record UnvalidatedShoppingCarts : IShoppingCarts
        {
            internal UnvalidatedShoppingCarts(IReadOnlyCollection<EmptyCart> shoppingCartList, string reason)
            {
                ShoppingCartList = shoppingCartList;
                Reason = reason;
            }

            public IReadOnlyCollection<EmptyCart> ShoppingCartList { get; }
            public string Reason { get; }
        }

        public record ValidatedShoppingCarts : IShoppingCarts
        {
            internal ValidatedShoppingCarts(IReadOnlyCollection<ValidatedCart> shoppingCartList)
            {
                ShoppingCartList = shoppingCartList;
            }

            public IReadOnlyCollection<ValidatedCart> ShoppingCartList { get; }
        }

        public record CalculatedShoppingCarts : IShoppingCarts
        {
            internal CalculatedShoppingCarts(IReadOnlyCollection<CalculatedCart> shoppingCartList)
            {
                ShoppingCartList = shoppingCartList;
            }

            public IReadOnlyCollection<CalculatedCart> ShoppingCartList { get; }
        }

        public record PaidShoppingCarts : IShoppingCarts
        {
            internal PaidShoppingCarts(IReadOnlyCollection<CalculatedCart> shoppingCartsList, string csv, DateTime publishedDate)
            {
                ShoppingCartList = shoppingCartsList;
                PublishedDate = publishedDate;
                Csv = csv;
            }

            public IReadOnlyCollection<CalculatedCart> ShoppingCartList { get; }
            public DateTime PublishedDate { get; }
            public string Csv { get; }
        }
    }
}
