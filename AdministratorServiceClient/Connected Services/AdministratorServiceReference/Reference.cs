﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdministratorServiceClient.AdministratorServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="AdministratorNamespace", ConfigurationName="AdministratorServiceReference.IAdministrator")]
    public interface IAdministrator {
        
        [System.ServiceModel.OperationContractAttribute(Action="AdministratorNamespace/IAdministrator/createNewFlight", ReplyAction="AdministratorNamespace/IAdministrator/createNewFlightResponse")]
        string createNewFlight(string flightNumber, int seatCapacity, float firstClassPrice, float economyClassPrice, string arrivalAirport, string departureAirport, System.DateTime arrivalTime, System.DateTime departureTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="AdministratorNamespace/IAdministrator/createNewFlight", ReplyAction="AdministratorNamespace/IAdministrator/createNewFlightResponse")]
        System.Threading.Tasks.Task<string> createNewFlightAsync(string flightNumber, int seatCapacity, float firstClassPrice, float economyClassPrice, string arrivalAirport, string departureAirport, System.DateTime arrivalTime, System.DateTime departureTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="AdministratorNamespace/IAdministrator/showAllFlights", ReplyAction="AdministratorNamespace/IAdministrator/showAllFlightsResponse")]
        string showAllFlights();
        
        [System.ServiceModel.OperationContractAttribute(Action="AdministratorNamespace/IAdministrator/showAllFlights", ReplyAction="AdministratorNamespace/IAdministrator/showAllFlightsResponse")]
        System.Threading.Tasks.Task<string> showAllFlightsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="AdministratorNamespace/IAdministrator/showSeatingChart", ReplyAction="AdministratorNamespace/IAdministrator/showSeatingChartResponse")]
        string showSeatingChart(string flightNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="AdministratorNamespace/IAdministrator/showSeatingChart", ReplyAction="AdministratorNamespace/IAdministrator/showSeatingChartResponse")]
        System.Threading.Tasks.Task<string> showSeatingChartAsync(string flightNumber);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAdministratorChannel : AdministratorServiceClient.AdministratorServiceReference.IAdministrator, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AdministratorClient : System.ServiceModel.ClientBase<AdministratorServiceClient.AdministratorServiceReference.IAdministrator>, AdministratorServiceClient.AdministratorServiceReference.IAdministrator {
        
        public AdministratorClient() {
        }
        
        public AdministratorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AdministratorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AdministratorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AdministratorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string createNewFlight(string flightNumber, int seatCapacity, float firstClassPrice, float economyClassPrice, string arrivalAirport, string departureAirport, System.DateTime arrivalTime, System.DateTime departureTime) {
            return base.Channel.createNewFlight(flightNumber, seatCapacity, firstClassPrice, economyClassPrice, arrivalAirport, departureAirport, arrivalTime, departureTime);
        }
        
        public System.Threading.Tasks.Task<string> createNewFlightAsync(string flightNumber, int seatCapacity, float firstClassPrice, float economyClassPrice, string arrivalAirport, string departureAirport, System.DateTime arrivalTime, System.DateTime departureTime) {
            return base.Channel.createNewFlightAsync(flightNumber, seatCapacity, firstClassPrice, economyClassPrice, arrivalAirport, departureAirport, arrivalTime, departureTime);
        }
        
        public string showAllFlights() {
            return base.Channel.showAllFlights();
        }
        
        public System.Threading.Tasks.Task<string> showAllFlightsAsync() {
            return base.Channel.showAllFlightsAsync();
        }
        
        public string showSeatingChart(string flightNumber) {
            return base.Channel.showSeatingChart(flightNumber);
        }
        
        public System.Threading.Tasks.Task<string> showSeatingChartAsync(string flightNumber) {
            return base.Channel.showSeatingChartAsync(flightNumber);
        }
    }
}
