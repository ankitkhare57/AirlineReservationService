using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Collections.Concurrent;

namespace AirlineReservationServiceLibrary
{
    [ServiceContract(Namespace = "AdministratorNamespace")]
    public interface IAdministrator
    {
        [OperationContract]
        string createNewFlight(string flightNumber, int seatCapacity
            , float firstClassPrice, float economyClassPrice
            , string arrivalAirport, string departureAirport
            , DateTime arrivalTime, DateTime departureTime);

        [OperationContract]
        string showAllFlights();

        [OperationContract]
        string showSeatingChart(string flightNumber);
    }

    [ServiceContract(Namespace = "CustomerNamespace")]
    public interface ICustomer
    {
        [OperationContract]
        string showAllFlights();

        [OperationContract]
        string showSeatingChart(string flightNumber);

        [OperationContract]
        string reserveSeat(string flightNumber, string seatNumber, string name, int age);
    }
}
