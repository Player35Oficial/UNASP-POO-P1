namespace Pizzaria;

public class Pedido
{
  public string? nome_cliente;

  public string? telefone_cliente;

  public List<Pizza>? pizzas_pedido;

  public double? valorFinal_pedido;

  public Pedido()
  {
    pizzas_pedido = new List<Pizza>();
  }
}
