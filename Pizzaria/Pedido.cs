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

  public Pedido()
  {
    pizzas_pedido = new List<Pizza>();

    numeroPedido = ProximoNumeroPedido;
    ProximoNumeroPedido++;
  }
}
