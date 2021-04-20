# AirlineReservationService

This is WCF implementation of a Mini Airline Reservation Service. In this service, an administrator can create a new flight and a customer can reserve a seat in the flight created by the administrator. This implementation uses synchronization constructs namely, ReaderWriterLocks and ConcurrentDictionary to support multiple customers and administrators at the same time.

## Steps to run the service
1. Import the solution into visual studio and build the solution.
2. Run the Airline Reservation Service in visual studio (AirlineReservationServiceHost as the startup project)
3. In a new terminal, start the Administrator by running the following command:

```
cd path_to_project\
AdministratorServiceClient\bin\Debug\AdministratorServiceClient.exe
```
To create flights, choose option 3. To run the multithreaded test suite choose, option 4.
    
4. In a new terminal, start the Customer by running the following command:

```
cd path_to_project\
CustomerServiceClient\bin\Debug\CustomerServiceClient.exe
```
To reserve the seats in the flights created, choose option 3. To run the multithreaded test suite choose, option 4.
