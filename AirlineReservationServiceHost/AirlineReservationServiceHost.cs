using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using AirlineReservationServiceLibrary;

namespace AirlineReservationServiceHost
{
    class AirlineReservationServiceHost
    {
        static void Main(string[] args)
        {
            // Step 1: Create a URI to serve as the base address.
            Uri adminBaseAddress = new Uri("http://localhost:8000/AirlineReservationServiceLibrary/");
            Uri customerBaseAddress = new Uri("http://localhost:8001/AirlineReservationServiceLibrary/");
            // Step 2: Create a ServiceHost instance.
            ServiceHost adminHost = new ServiceHost(typeof(AdministratorService), adminBaseAddress);
            ServiceHost customerHost = new ServiceHost(typeof(CustomerService), customerBaseAddress);
            try
            {
                // Step 3: Add a service endpoint.
                adminHost.AddServiceEndpoint(typeof(IAdministrator), new WSHttpBinding(), "AdministratorService");
                customerHost.AddServiceEndpoint(typeof(ICustomer), new WSHttpBinding(), "CustomerService");
                
                // Step 4: Enable metadata exchange.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                adminHost.Description.Behaviors.Add(smb);
                customerHost.Description.Behaviors.Add(smb);

                // Step 5: Start the service.
                adminHost.Open();
                customerHost.Open();
                Console.WriteLine("The service is ready.");

                // Close the ServiceHost to stop the service.
                Console.WriteLine("Press <Enter> to terminate the service.");
                Console.WriteLine();
                Console.ReadLine();
                adminHost.Close();
                customerHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                adminHost.Abort();
            }
        }
    }
}