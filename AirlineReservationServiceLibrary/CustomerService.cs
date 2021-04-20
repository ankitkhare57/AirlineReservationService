
namespace AirlineReservationServiceLibrary
{
    public class CustomerService : ICustomer
    {
        public string showAllFlights()
        {
            return FlightDB.showAllFlightDetails();
        }

        public string showSeatingChart(string flightNumber)
        {
            return FlightDB.showSeatingChart(flightNumber);
        }

        public string reserveSeat(string flightNumber, string seatNumber, string name, int age)
        {
            return FlightDB.reserveSeat(flightNumber, seatNumber, name, age);
        }
    }
}
