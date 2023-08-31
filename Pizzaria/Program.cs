using System;

namespace Pizzaria;
class Program
{
    static void Main(string[] args)
    {
        var listaPizzas = new List<Pizza> { new Pizza() { nome = "banana", sabores = "banana, massa", preco = 50 } };
        int opcao = 0;
        var listaPedidos = new List<Pedido> { };

        do
        {
            Console.WriteLine("Bem-vindo ao projeto de Pizzaria!");

            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Adicionar Pizza");
            Console.WriteLine("2 - Listar Pizzas");
            Console.WriteLine("3 - Criar Novo Pedido");
            Console.WriteLine("4 - Listar Pedidos");
            Console.WriteLine("55 - SAIR");

            Console.WriteLine("Digite sua opção:");
            opcao = Int32.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                var pizza = new Pizza();
                Console.WriteLine("Adicionar Pizza!");

                Console.WriteLine("Digite o nome da Pizza: ");
                string nome_pizza = Console.ReadLine();

                Console.WriteLine("Digite os sabores da pizza (Separados por vírgula): ");
                string sabores_pizza = Console.ReadLine();

                Console.WriteLine("Digite o preço da Pizza: ");
                float valor_pizza = float.Parse(Console.ReadLine());

                pizza.nome = nome_pizza;
                pizza.sabores = sabores_pizza;
                pizza.preco = valor_pizza;

                listaPizzas.Add(pizza);
            }
            else if (opcao == 2)
            {
                Console.WriteLine("LISTAR PIZZAS: ");
                foreach (Pizza umaPizza in listaPizzas)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("<===============>");
                    Console.WriteLine("NOME: " + umaPizza.nome);
                    Console.WriteLine("SABORES: " + umaPizza.sabores);
                    Console.WriteLine("PREÇO: " + umaPizza.preco);
                }
            }
            else if (opcao == 3)
            {
                var pedido = new Pedido();
                Console.WriteLine("Adicionar Pedido!");

                Console.WriteLine("Digite o nome do Cliente: ");
                string nome_cliente = Console.ReadLine();

                Console.WriteLine("Digite o Telefone do Cliente: ");
                int telefone_cliente = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Escolha uma pizza para adicionar: ");
                foreach (Pizza pizza in listaPizzas)
                {
                    Console.WriteLine(pizza.nome + " - " + pizza.preco);
                }

                int opcaoPedidos = 0;
                do
                {
                    var PizzaByName = Console.ReadLine();

                    var indexOfSelected = listaPizzas.IndexOf(PizzaByName);
                    pedido.pizzas_pedido.add(indexOfSelected);


                    Console.WriteLine("Deseja acrescentar mais uma pizza? (1 - SIM | 2 - NÃO)");
                    opcaoPedidos = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Escolha uma pizza para adicionar: ");
                } while (opcaoPedidos != 2);

                // Calcular valor final do Pedido;
                double valorFinal = 0.0;
                foreach (int index in pedido.pizzas_pedido)
                {
                    valorFinal += listaPizzas[index].preco;
                }

                pedido.nome_cliente = nome_cliente;
                pedido.telefone_cliente = telefone_cliente;
                pedido.valorFinal_pedido = valorFinal;

                listaPedidos.Add(pedido);
                Console.WriteLine("PEDIDO CRIADO!");
            }
            else if (opcao == 4)
            {
                Console.WriteLine("LISTAR PEDIDOS: ");
                foreach (Pedido umPedido in listaPedidos)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("<===============>");
                    Console.WriteLine("Cliente: " + umPedido.nome_cliente + " " + umPedido.telefone_cliente);
                    Console.WriteLine("Pizzas do Pedido: " + umPedido.pizzas_pedido);
                    Console.WriteLine("Valor Final: " + umPedido.valorFinal_pedido);
                }
            }
        } while (opcao != 55);


    }
}
