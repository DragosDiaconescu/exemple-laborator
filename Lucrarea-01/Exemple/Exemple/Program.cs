using Exemple.Domain;
using System;
using System.Collections.Generic;
using static Exemple.Domain.Carts;

namespace Exemple.Domain
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            var listOfShoppingCarts = ReadListOfShoppingCarts().ToArray();
            EmptyCarts emptyShoppingCarts = new(listOfShoppingCarts);
            IShoppingCart result = ValidateShoppingCarts(emptyShoppingCarts);
            result.Match(
                whenEmptyCarts: emptyResult => emptyShoppingCarts,
                whenUnvalidatedCarts: unvalidatedResult => unvalidatedResult,
                whenPaidCarts: paidResult => paidResult,
                whenValidatedCarts: validatedResult => PayShoppingCart(validatedResult)
            );

            Console.WriteLine("Greseala, introduceti inca un set de date !");
        }

        private static List<EmptyCart> ReadListOfShoppingCarts()
        {
            List<EmptyCart> listOfShoppingCarts = new();
            do
            {
                var quantity = ReadValue("Cantitatea produsului comandat: ");
                if (string.IsNullOrEmpty(quantity))
                {
                    break;
                }

                var product_code = ReadValue("Codul produsului comandat: ");
                if (string.IsNullOrEmpty(product_code))
                {
                    break;
                }

                var address = ReadValue("Adresa la care se doreste livrarea: ");
                if (string.IsNullOrEmpty(address))
                {
                    break;
                }

                listOfShoppingCarts.Add(new(quantity, product_code, address));
            } while (true);
            return listOfShoppingCarts;
        }

        private static IShoppingCart ValidateShoppingCarts(EmptyCarts emptyShoppingCarts) =>
            random.Next(100) > 50 ?
            new UnvalidatedCarts(new List<UnvalidatedCart>(), "Random")
            : new ValidatedCarts(new List<ValidatedCart>());

        private static IShoppingCart PayShoppingCart(ValidatedCarts validatedShoppingCarts) =>
            new PaidCarts(new List<ValidatedCart>(), DateTime.Now);

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
