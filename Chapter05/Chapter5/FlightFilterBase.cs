namespace Packt.CloudySkiesAir.Chapter5;

public abstract class FlightFilterBase 
{
  public abstract bool ShouldInclude(IFlightInfo flight);
}
