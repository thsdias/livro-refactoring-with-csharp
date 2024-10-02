


namespace Packt.CloudySkiesAir.Chapter7;

public class MileageTracker
{
  private const int SignUpBonus = 100;

  public int Balance { get; set; } = SignUpBonus;

  public void AddMiles(int miles) 
  {
    Balance += miles;
  }

  public void RedeemMiles(int miles)
  {
    if(Balance >= miles)
      Balance -= miles;
  }
}