namespace Packt.CloudySkiesAir.Chapter11;
public class RefactorMe 
{
  public void DisplayRandomNumbers()
  {
    List<int> numbers = new List<int>(10);
    Random rand = new();

    foreach (int _ in Enumerable.Range(0, 10)) 
    {
      int number = rand.Next(1, 101);
      numbers.Add(number);
    }
    
    String output = string.Join(", ", numbers.ToArray());
    Console.WriteLine(output);
  }
}
