namespace Packt.CloudySkiesAir.Chapter5;

public interface IFlightInfo 
{
  string Id { get; }
  AirportEvent Departure { get; set; }
  AirportEvent Arrival { get; set; }
  TimeSpan Duration { get; }
}
