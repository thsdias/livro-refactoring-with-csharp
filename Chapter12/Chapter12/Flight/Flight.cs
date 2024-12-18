namespace Packt.CloudySkiesAir.Chapter12.Flight;

public class Flight
{
  [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
  public string BuildMessage(string id, string status)
  {
    return $"Flight {id} is {status}";
  }
}

