using Packt.CloudySkiesAir.Chapter6.Flight.Boarding;

namespace Chapter06MSTests;

[TestClass]
public sealed class PassengerTests
{
    /// <summary>
    /// Verifies the FullName property of the Passenger class.
    /// </summary>
    [TestMethod]
    [DataRow("Calvin", "Allen", "Calvin Allen")]
    [DataRow("Matthew", "Groves", "Matthew Groves")]
    [DataRow("Sam", "Gomez", "Sam Gomez")]
    [DataRow("Brad", "Knowles", "Brad Knowles")]
    public void PassengerNameShouldBeCorrect(string first, string last, string expected)
    {
        // Arrange
        Passenger passenger = new()
        {
            FirstName = first,
            LastName = last,
        };

        // Act
        string fullName = passenger.FullName;
        
        // Assert
        Assert.AreEqual(expected, fullName);
    }
}
