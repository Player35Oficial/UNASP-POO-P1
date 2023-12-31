﻿using System;

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
            Console.WriteLine();
            Console.WriteLine("Bem-vindo ao projeto de Pizzaria!");

            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Adicionar Pizza"); // Objetificado
            Console.WriteLine("2 - Listar Pizzas"); // Objetificado
            Console.WriteLine("3 - Criar Novo Pedido"); // Objetificado
            Console.WriteLine("4 - Listar Pedidos"); // Objetificado
            Console.WriteLine("5 - Pagar Pedido");
            Console.WriteLine("55 - SAIR");

            Console.WriteLine("Digite sua opção:");
            opcao = int.Parse(Console.ReadLine()!);

            if (opcao == 1)
            {
                var pizza = new Pizza();
                pizza.AddPizza();

                listaPizzas.Add(pizza);
            }
            else if (opcao == 2)
            {
                ListingHelper.ListPizzas(listaPizzas);
            }
            else if (opcao == 3)
            {
                var pedido = new Pedido();
                pedido.AddPedido(listaPizzas);

                double valorFinal = 0.0;
                foreach (Pizza pizza in pedido.pizzas_pedido!)
                {
                    Console.WriteLine("Preço: " + pizza.preco);
                    valorFinal += pizza.preco;
                }
                Console.WriteLine("Preço Final: " + valorFinal);

                pedido.valorFinal_pedido = valorFinal;
                pedido.valorPendente_pedido = pedido.valorFinal_pedido;

                listaPedidos.Add(pedido);
                Console.WriteLine("PEDIDO CRIADO!");
            }
            else if (opcao == 4)
            {
                ListingHelper.ListPedido(listaPedidos);
            }
            else if (opcao == 5)
            {
                Console.WriteLine("Qual o número do pedido:");
                int numeroPedido = int.Parse(Console.ReadLine()!);

                Pedido pedidoSelecionado = listaPedidos.FirstOrDefault(pedido => pedido.numeroPedido == numeroPedido)!;

                if (pedidoSelecionado != null)
                {
                    Console.WriteLine($"Cliente: {pedidoSelecionado.nome_cliente} - Falta: R$ {pedidoSelecionado.valorPendente_pedido}");
                    Console.WriteLine("Digite a forma de pagamento (1 - Dinheiro, 2 - Cartão):");
                    int formaPagamento = int.Parse(Console.ReadLine()!);

                    if (formaPagamento == 1)
                    {
                        Console.WriteLine("Qual o valor:");
                        double valorPago = double.Parse(Console.ReadLine()!);

                        // O que foi pago é exatamento o valor do pedido
                        if (valorPago == pedidoSelecionado.valorPendente_pedido)
                        {
                            pedidoSelecionado.valorPendente_pedido = 0;
                            Console.WriteLine($"VALOR RECEBIDO COM SUCESSO\nTOTAL PAGO: R$ {valorPago} (DINHEIRO)");
                            pedidoSelecionado.pago = true;
                        }
                        // O que foi pago é acima do valor do pedido
                        else if (valorPago > pedidoSelecionado.valorPendente_pedido)
                        {
                            double? diff = pedidoSelecionado.valorPendente_pedido - valorPago;
                            double? positiveDiff = Math.Abs((double)diff);
                            Console.WriteLine($"VALOR RECEBIDO COM SUCESSO \n TOTAL PAGO: R$ {valorPago} (DINHEIRO)");
                            Console.WriteLine($"Troco: R$ {positiveDiff}");
                            pedidoSelecionado.valorPendente_pedido = 0;
                            pedidoSelecionado.pago = true;
                        }
                        // O que foi pago é (provavelmente) abaixo do valor do pedido
                        else
                        {
                            pedidoSelecionado.valorPendente_pedido -= valorPago;
                            Console.WriteLine($"Falta: R$ {pedidoSelecionado.valorPendente_pedido}");
                            pedidoSelecionado.pago = false;
                        }
                    }
                    else if (formaPagamento == 2)
                    {
                        // Implementa na próxima Sprint
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida de forma de pagamento.");
                    }
                }
                else
                {
                    Console.WriteLine("Pedido não encontrado. Verifique o número do pedido.");
                }
            }
        } while (opcao != 55);
    }
}
