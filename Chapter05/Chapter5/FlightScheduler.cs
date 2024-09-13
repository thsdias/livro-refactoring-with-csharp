namespace Packt.CloudySkiesAir.Chapter5;

public class FlightScheduler 
{
  private readonly List<IFlightInfo> _flights = new();

  public void ScheduleFlight
  (
    string id, 
    Airport depart, 
    Airport arrive, 
    DateTime departTime, 
    DateTime arriveTime, 
    int passengers
  ) 
  {
    PassengerFlightInfo flight = new() 
    {
      Id = id,
      Arrival = new AirportEvent 
      {
        Location = arrive,
        Time = arriveTime,
      }, 
      Departure = new AirportEvent 
      {
        Location = depart,
        Time = departTime,
      }     
    };

    flight.Load(passengers);
    _flights.Add(flight);

    Console.WriteLine($"Scheduled Flight {flight}");
  }

  public void ScheduleFlight(IFlightInfo flight) 
  {
    _flights.Add(flight);
    Console.WriteLine($"Scheduled Flight {flight}");
  }

  public void RemoveFlight(IFlightInfo flight) 
  {
    _flights.Remove(flight);
  }

  public IEnumerable<IFlightInfo> GetAllFlights() 
  {
    return _flights.AsReadOnly();
  }

  List<IFlightInfo> Search(List<FlightFilterBase> rules) =>
    _flights.Where(f => rules.All(r => r.ShouldInclude(f))).ToList();

  public IEnumerable<IFlightInfo> Search(FlightSearch search) 
  {
    IEnumerable<IFlightInfo> results = _flights;

    if (search.Depart != null) 
    {
      results = results.Where(f => f.Departure.Location == search.Depart);
    }

    if (search.Arrive != null) 
    {
      results = results.Where(f => f.Arrival.Location == search.Arrive);
    }

    if (search.MinDepart != null) 
    {
      results = results.Where(f => f.Departure.Time >= search.MinDepart);
    }

    if (search.MaxDepart != null) 
    {
      results = results.Where(f => f.Departure.Time <= search.MaxDepart);
    }

    if (search.MinArrive != null) 
    {
      results = results.Where(f => f.Arrival.Time >= search.MinArrive);
    }

    if (search.MaxArrive != null) 
    {
      results = results.Where(f => f.Arrival.Time <= search.MaxArrive);
    }

    if (search.MinLength != null) 
    {
      results = results.Where(f => f.Duration >= search.MinLength);
    }

    if (search.MaxLength != null) 
    {
      results = results.Where(f => f.Duration <= search.MaxLength);
    }

    return results;
  }

  [Obsolete("Use the overload that takes a FlightSearch")]
  public IEnumerable<IFlightInfo> Search
  (
    Airport? depart, Airport? arrive,
    DateTime? minDepartTime, DateTime? maxDepartTime,
    DateTime? minArriveTime, DateTime? maxArriveTime,
    TimeSpan? minLength, TimeSpan? maxLength
  ) 
  {
    IEnumerable<IFlightInfo> results = _flights;

    if (depart != null)
      results = results.Where(f => f.Departure.Location == depart);

    if (arrive != null)
      results = results.Where(f => f.Arrival.Location == arrive);

    if (minDepartTime != null)
      results = results.Where(f => f.Departure.Time >= minDepartTime);

    if (maxDepartTime != null)
      results = results.Where(f => f.Departure.Time <= maxDepartTime);

    if (minArriveTime != null)
      results = results.Where(f => f.Arrival.Time >= minArriveTime);

    if (maxArriveTime != null)
      results = results.Where(f => f.Arrival.Time <= maxArriveTime);

    if (minLength != null)
      results = results.Where(f => f.Duration >= minLength);

    if (maxLength != null)
      results = results.Where(f => f.Duration <= maxLength);

    return results;
  }
}
