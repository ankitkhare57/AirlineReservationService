using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace AirlineReservationServiceLibrary
{
    public sealed class FlightDB
    {
        private static readonly int TIMEOUT = 5000;
        private static ConcurrentDictionary<string, Flight> flightDB;
        private FlightDB()
        {
            flightDB = new ConcurrentDictionary<string, Flight>();
        }

        private static readonly FlightDB _instance = new FlightDB();
        public static FlightDB Instance => _instance;
        public static void addFlight(Flight flight)
        {
            if (flightDB.ContainsKey(flight.FlightNumber))
            {
                throw new InvalidOperationException(String.Format("Flight {0} already exists.\n", flight.FlightNumber));
            }
            flightDB[flight.FlightNumber] = flight;
        }
        public static Flight getFlight(string flightNumber)
        {
            Flight result = flightDB.ContainsKey(flightNumber) ? flightDB[flightNumber] : null;
            return result;
        }
        public static string showAllFlightDetails()
        {
            
            string output = "";
            foreach(var flight in flightDB)
            {
                try
                {
                    flight.Value.Rwl.AcquireReaderLock(TIMEOUT);
                    output += flight.Value.printFlight();
                }
                finally
                {
                    flight.Value.Rwl.ReleaseReaderLock();
                }
               
            }
            if (output == "")
            {
                return "No flights exist in the database.\n";
            }
            return output;
        }
        public static string showSeatingChart(string flightNumber)
        {
            string result = "";
            Flight flight = getFlight(flightNumber);

            if (flight == null)
            {
                return String.Format("Flight {0} does not exist.\n", flightNumber);
            }
            try
            {
                flight.Rwl.AcquireReaderLock(TIMEOUT);
                foreach (var seat in flight.SeatingChart)
                {
                    result += String.Format("{0}: {1}\n", seat.Key, seat.Value == null ? "Available" : "Reserved");
                }
            }
            finally
            {
                flight.Rwl.ReleaseReaderLock();
            }
            return result;
        }
        public static string reserveSeat(string flightNumber, string seatNumber, string name, int age)
        {
            if (!flightDB.ContainsKey(flightNumber))
            {
                return String.Format("Flight {0} does not exist.\n", flightNumber);
            }

            Flight flight = flightDB[flightNumber];

            try
            {
                flight.Rwl.AcquireWriterLock(TIMEOUT);
                if (!flight.SeatingChart.ContainsKey(seatNumber))
                {
                    return String.Format("Seat {0} does not exist in flight {1}.\n", seatNumber, flightNumber);
                }

                if (flight.SeatingChart[seatNumber] != null)
                {
                    return String.Format("Seat {0} in flight {1} is already reserved.\n" +
                        "Please choose another seat number.\n{3}",
                        seatNumber, flightNumber, showSeatingChart(flightNumber));
                }

                flight.SeatingChart[seatNumber] = new Tuple<string, int>(name, age);
                return String.Format("Seat {0} in flight {1} was successfully reserved.\n", seatNumber, flightNumber);

            }
            catch (ApplicationException e)
            {
                return String.Format("Seat {0} in flight {1} could not be reserved. Operation Timed Out.\n", seatNumber, flightNumber);
            }
            finally
            {
                flight.Rwl.ReleaseWriterLock();
            }
        }

    }
}
