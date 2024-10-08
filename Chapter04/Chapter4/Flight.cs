﻿namespace Packt.CloudySkiesAir.Chapter4;

public class Flight 
{
    public string Id { get; set; }
    public string Destination { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public string Gate { get; set; }
    public FlightStatus Status { get; set; }

    public Flight(string id, string destination, DateTime departureTime) 
    {
        Id = id;
        Destination = destination;
        DepartureTime = departureTime;
    }

    public Flight(string id, string destination, DateTime departureTime, FlightStatus status) 
        : this(id, destination, departureTime)
    {
        Status = status;
    }

    public override string ToString() 
    {
        return $"{Id} to {Destination} at {DepartureTime}";
    }
}
