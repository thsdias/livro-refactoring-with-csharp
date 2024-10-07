﻿namespace Packt.CloudySkiesAir.Chapter8;

public class FlightBookingManager {
  private readonly IEmailClient _email;
  public FlightBookingManager(IEmailClient email) {
    _email = email;
  }

  public bool BookFlight(Passenger passenger,
    PassengerFlightInfo flight, string seat) {
    if (!flight.IsSeatAvailable(seat)) {
      return false;
    }
    flight.AssignSeat(passenger, seat);

    string message = "Your seat is confirmed";
    _email.SendMessage(passenger.Email, message);

    return true;
  }
}
