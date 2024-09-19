﻿using Packt.CloudySkiesAir.Chapter6.Flight.Scheduling;
using Packt.CloudySkiesAir.Chapter6.Flight.Scheduling.Flights;

namespace Chapter6XUnitTests;

public class FlightSchedulerTests
{
    private readonly Airport _airport1;
    private readonly Airport _airport2;
    
    public FlightSchedulerTests()
    {
        _airport1 = new()
        {
            Code = "DNA",
            Country = "United States",
            Name = "Dotnet Airport"
        };
    
        _airport2 = new()
        {
            Code = "CSI",
            Country = "United Kingdom",
            Name = "C# International Airport"
        };
    }

    /// <summary>
    /// Initializing test code with constructors and fields.
    /// </summary>
    [Fact]
    public void ScheduleFlightShouldAddFlight()
    {
        // Arrange
        FlightScheduler scheduler = new();
        PassengerFlightInfo flight = CreateFlight("CS2024");

        // Act
        scheduler.ScheduleFlight(flight);

        // Assert
        IEnumerable<IFlightInfo> result = scheduler.GetAllFlights();
        Assert.NotNull(result);
        Assert.Contains(flight, result);
    }

    /// <summary>
    /// Testing void methods.
    /// </summary>
    [Fact]
    public void RemoveShouldRemoveFlight()
    {
        // Arrange
        FlightScheduler scheduler = new();
        PassengerFlightInfo flight = CreateFlight("CS2024");

        // Act
        scheduler.RemoveFlight(flight);

        // Assert
        IEnumerable<IFlightInfo> result = scheduler.GetAllFlights();
        Assert.NotNull(result);
        Assert.DoesNotContain(flight, result);
    }

    private PassengerFlightInfo CreateFlight(string id) 
        => new()
        {
            Status = FlightStatus.OnTime,
            Id = id,
            Departure = new AirportEvent()
            {
                Location = _airport1,
                Time = DateTime.Now
            },
            Arrival = new AirportEvent()
            {
                Location = _airport2,
                Time = DateTime.Now.AddHours(2)
            }
        };
}
