namespace Pizzaria;

public class Pedido
{
  public int? numeroPedido { get; private set; }

  public static int ProximoNumeroPedido { get; private set; }

  public string? nome_cliente;

  public string? telefone_cliente;

  public List<Pizza>? pizzas_pedido;

  public double? valorFinal_pedido;
  public double? valorPendente_pedido = 0;

  public bool? pago = false;

  public void AddPedido(List<Pizza> lista)
  {
    Console.WriteLine("Adicionar Pedido!");

    Console.WriteLine("Digite o nome do Cliente: ");
    nome_cliente = Console.ReadLine()!;

    Console.WriteLine("Digite o Telefone do Cliente: ");
    telefone_cliente = Console.ReadLine()!;


    while (true)
    {
      AddPizzaInPedido(lista);

      Console.WriteLine("Deseja acrescentar uma pizza? (S - SIM | N - NÃO)");
      string resposta = Console.ReadLine()!.ToLower();

      if (resposta != "s")
      {
        break;
      }
    }
  }

  private void AddPizzaInPedido(List<Pizza> lista)
  {
    Console.WriteLine("Escolha uma pizza para adicionar: ");
    foreach (Pizza pizza in lista)
    {
      Console.WriteLine(pizza.nome + " - " + pizza.preco);
    }
    var nomeDaPizza = Console.ReadLine()!;
    Pizza pizzaEncontrada = lista.Find(item => item.nome == nomeDaPizza)!;
    if (pizzaEncontrada != null)
    {
      pizzas_pedido!.Add(pizzaEncontrada);
    }
    else
    {
      Console.WriteLine("Pizza não encontrada. Verifique o nome.");
    }
  }

  public void listPizzasPedido()
  {
    Console.WriteLine("Pizzas no pedido:");
    ListingHelper.ListPizzas(pizzas_pedido!);
  }

  public Pedido()
  {
    pizzas_pedido = new List<Pizza>();

    numeroPedido = ProximoNumeroPedido;
    ProximoNumeroPedido++;
  }
}
