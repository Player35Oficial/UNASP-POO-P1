using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria
{
    public class ListingHelper
    {
        public static void ListPizzas(List<Pizza> lista)
        {
            foreach (Pizza pizza in lista)
            {
                Console.WriteLine("\n");
                Console.WriteLine("<===============>");
                Console.WriteLine("NOME: " + pizza.nome);
                Console.WriteLine("SABORES: " + pizza.sabores);
                Console.WriteLine("PREÇO: " + pizza.preco);
            }
        }

        public static void ListPedido(List<Pedido> lista)
        {
            foreach (Pedido pedido in lista)
            {
                Console.WriteLine("\n");
                Console.WriteLine("<===============>");
                Console.WriteLine("ID_Cliente: " + pedido.numeroPedido);
                Console.WriteLine("Cliente: " + pedido.nome_cliente + " " + pedido.telefone_cliente);
                Console.WriteLine("Pizzas do Pedido: ");
                foreach (Pizza pizza in pedido.pizzas_pedido!)
                {
                    Console.WriteLine(pizza.nome + " - R$ " + pizza.preco);
                }
                Console.WriteLine("Total: " + pedido.valorFinal_pedido);
                Console.WriteLine("Quanto falta para pagar: " + pedido.valorPendente_pedido);
                Console.WriteLine("Pago: " + ((bool)pedido.pago! ? "Sim" : "Não"));
                Console.WriteLine();
            }
        }
    }
}