﻿namespace Packt.CloudySkiesAir.Chapter5;

public class PassengerFlightInfo : FlightInfoBase
{
  private int _passengers;

  public int Passengers 
  { 
    get => _passengers; 
    set => _passengers = value; 
  }

  public void Load(int passengers) => 
    Passengers = passengers;

  public void Unload() => 
    Passengers = 0;

  public override string BuildFlightIdentifier() =>
    base.BuildFlightIdentifier() + $"carrying {Passengers} people";
}
