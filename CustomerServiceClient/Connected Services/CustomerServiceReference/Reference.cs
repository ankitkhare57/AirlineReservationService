﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CustomerServiceClient.CustomerServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="CustomerNamespace", ConfigurationName="CustomerServiceReference.ICustomer")]
    public interface ICustomer {
        
        [System.ServiceModel.OperationContractAttribute(Action="CustomerNamespace/ICustomer/showAllFlights", ReplyAction="CustomerNamespace/ICustomer/showAllFlightsResponse")]
        string showAllFlights();
        
        [System.ServiceModel.OperationContractAttribute(Action="CustomerNamespace/ICustomer/showAllFlights", ReplyAction="CustomerNamespace/ICustomer/showAllFlightsResponse")]
        System.Threading.Tasks.Task<string> showAllFlightsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="CustomerNamespace/ICustomer/showSeatingChart", ReplyAction="CustomerNamespace/ICustomer/showSeatingChartResponse")]
        string showSeatingChart(string flightNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="CustomerNamespace/ICustomer/showSeatingChart", ReplyAction="CustomerNamespace/ICustomer/showSeatingChartResponse")]
        System.Threading.Tasks.Task<string> showSeatingChartAsync(string flightNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="CustomerNamespace/ICustomer/reserveSeat", ReplyAction="CustomerNamespace/ICustomer/reserveSeatResponse")]
        string reserveSeat(string flightNumber, string seatNumber, string name, int age);
        
        [System.ServiceModel.OperationContractAttribute(Action="CustomerNamespace/ICustomer/reserveSeat", ReplyAction="CustomerNamespace/ICustomer/reserveSeatResponse")]
        System.Threading.Tasks.Task<string> reserveSeatAsync(string flightNumber, string seatNumber, string name, int age);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICustomerChannel : CustomerServiceClient.CustomerServiceReference.ICustomer, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CustomerClient : System.ServiceModel.ClientBase<CustomerServiceClient.CustomerServiceReference.ICustomer>, CustomerServiceClient.CustomerServiceReference.ICustomer {
        
        public CustomerClient() {
        }
        
        public CustomerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CustomerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
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
        
        public string reserveSeat(string flightNumber, string seatNumber, string name, int age) {
            return base.Channel.reserveSeat(flightNumber, seatNumber, name, age);
        }
        
        public System.Threading.Tasks.Task<string> reserveSeatAsync(string flightNumber, string seatNumber, string name, int age) {
            return base.Channel.reserveSeatAsync(flightNumber, seatNumber, name, age);
        }
    }
}
