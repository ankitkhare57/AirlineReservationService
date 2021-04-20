using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AirlineReservationServiceLibrary
{
    public class Flight
    {
        public ReaderWriterLock Rwl { get; }
        public string FlightNumber { get; }
        public int SeatCapacity { get; }
        public float FirstClassPrice { get; }
        public float EconomyClassPrice { get; }
        public string ArrivalAirport { get; }
        public string DepartureAirport { get; }
        public DateTime ArrivalTime { get; }
        public DateTime DepartureTime { get; }
        public Dictionary<string, Tuple<string, int>> SeatingChart { get; }

        public Flight(string flightNumber, int seatCapacity,
            float firstClassPrice, float economyClassPrice,
            string arrivalAirport, string departureAirport,
            DateTime arrivalTime, DateTime departureTime)
        {
            sanityCheckOnArguments(flightNumber, seatCapacity,
            firstClassPrice, economyClassPrice,
            arrivalAirport, departureAirport,
            arrivalTime, departureTime);

            Rwl = new ReaderWriterLock();

            FlightNumber = flightNumber;
            SeatCapacity = seatCapacity;
            FirstClassPrice = firstClassPrice;
            EconomyClassPrice = economyClassPrice;
            ArrivalAirport = arrivalAirport;
            DepartureAirport = departureAirport;
            ArrivalTime = arrivalTime;
            DepartureTime = departureTime;
            SeatingChart = new Dictionary<string, Tuple<string, int>>();

            for (int i = 0; i < seatCapacity; i++)
            {
                SeatingChart.Add(String.Format("Seat_{0}", i), null);
            }

        }

        public string printFlight()
        {
            return String.Format("Flight Number: {0}, Departure Airport: {1}, " +
                "Arrival Airport: {2}, Departure Time: {3}, Arrival Time: {4}, " +
                "Economy Price: {5}, First Class Price: {6}\n", FlightNumber,
                DepartureAirport, ArrivalAirport, DepartureTime, ArrivalTime,
                EconomyClassPrice, FirstClassPrice);
        }

        private void sanityCheckOnArguments(string flightNumber, int seatCapacity,
            float firstClassPrice, float economyClassPrice,
            string arrivalAirport, string departureAirport,
            DateTime arrivalTime, DateTime departureTime)
        {
            if (flightNumber == null)
            {
                throw new ArgumentNullException("Flight number cannot be null.\n");
            }
            if (flightNumber.Length != 4)
            {
                throw new ArgumentException("Flight number length must be 4.\n");
            }
            if (!flightNumber.All(Char.IsLetterOrDigit))
            {
                throw new ArgumentException("Flight number must be alphanumeric.\n");
            }
            if (seatCapacity < 1 || seatCapacity > 10)
            {
                throw new ArgumentOutOfRangeException("Seat capacity must be in range 1-10.\n");
            }
            if (arrivalTime == null || departureTime == null)
            {
                throw new ArgumentNullException("Arrival/Departure Time cannot be null.\n");
            }
            if (DateTime.Compare(arrivalTime, departureTime) < 0)
            {
                throw new ArgumentException("Arrival Time must be later than Departure Time.\n");
            }
            if (economyClassPrice < 0)
            {
                throw new ArgumentOutOfRangeException("Economy Price cannot be negative.\n");
            }
            if (firstClassPrice < 0)
            {
                throw new ArgumentOutOfRangeException("First class Price cannot be negative.\n");
            }
            if (arrivalAirport == null || departureAirport == null)
            {
                throw new ArgumentNullException("Arrival/Departure airports cannot be null.\n");
            }
            if (arrivalAirport.Length != 3 || departureAirport.Length != 3)
            {
                throw new ArgumentException("Arrival/Departure airport name length must be 3.\n");
            }
            if (!arrivalAirport.All(Char.IsLetter) || !departureAirport.All(Char.IsLetter))
            {
                throw new ArgumentException("Arrival/Departure airport must be alphabetic.\n");
            }
        }
    }
}
