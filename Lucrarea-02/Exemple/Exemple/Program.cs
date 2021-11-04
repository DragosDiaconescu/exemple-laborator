using System;
using System.Collections.Generic;
using Exemple.Domain;
using static Exemple.Domain.ShoppingCart;

namespace Exemple
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            var listOfGrades = ReadListOfShoppingCarts().ToArray();
            ShoppingCartCommand command = new(listOfGrades);
            PayShoppingCartWorkflow workflow = new PayShoppingCartWorkflow();
            var result = workflow.Execute(command, (productCode) => true);

            result.Match(
                    whenShoppingCartsPaidFailedEvent: @event =>
                    {
                        Console.WriteLine($"Plata esuata: {@event.Reason}");
                        return @event;
                    },
                    whenShoppingCartsPaidScucceededEvent: @event =>
                    {
                        Console.WriteLine($"Plata reusita !");
                        Console.WriteLine(@event.Csv);
                        return @event;
                    }
                );

            Console.WriteLine("Adaugati un nou set de date !");
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

                var product_code = ReadValue("Codul produsului: ");
                if (string.IsNullOrEmpty(product_code))
                {
                    break;
                }

                var address = ReadValue("Adresa: ");
                if (string.IsNullOrEmpty(address))
                {
                    break;
                }

                var price = ReadValue("Pretul: ");
                if (string.IsNullOrEmpty(price))
                {
                    break;
                }

                listOfShoppingCarts.Add(new(product_code, quantity, address, price));
            } while (true);
            return listOfShoppingCarts;
        }

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
