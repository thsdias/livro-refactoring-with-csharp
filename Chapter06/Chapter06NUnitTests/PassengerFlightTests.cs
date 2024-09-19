using Packt.CloudySkiesAir.Chapter6.Flight.Scheduling.Flights;

namespace Chapter06NUnitTests;

public class PassengerFlightTests
{
    [TestCase(6)]
    public void AddPassengerShouldAdd(int passengers)
    {
        // Arrange
        PassengerFlightInfo flight = new();

        // Act
        flight.Load(passengers);
        
        // Assert
        int actual = flight.Passengers;
        Assert.AreEqual(passengers, actual);
        Assert.That(actual, Is.EqualTo(passengers));
    }
}