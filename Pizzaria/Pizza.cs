namespace Pizzaria;

public class Pizza
{
  public string? nome;

  public string? sabores;

  public float preco;

  public void AddPizza()
  {
    Console.WriteLine("Adicionar Pizza!");

    Console.WriteLine("Digite o nome da Pizza: ");
    nome = Console.ReadLine()!;

    Console.WriteLine("Digite os sabores da pizza (Separados por vírgula): ");
    sabores = Console.ReadLine()!;

    Console.WriteLine("Digite o preço da Pizza: ");
    preco = float.Parse(Console.ReadLine()!);
  }
}
