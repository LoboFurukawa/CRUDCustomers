using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServiceHost.Models;

namespace WCFServiceHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
        //Inserts
        [OperationContract]
        string InsertCustomers(Customers customersInfo);
        [OperationContract]
        string InsertMaritalStatus(MaritalStatus maritalStatus);
        [OperationContract]
        string InsertUFs(UFs uFs);
        [OperationContract]
        string InsertDispatchAgency(DispatchAgency dispatchAgency);
        //Gets
        [OperationContract]
        List<Customers> GetCustomers();
        [OperationContract]
        List<MaritalStatus> GetMaritalStatus();
        [OperationContract]
        List<DispatchAgency> GetDispatchAgency();
        [OperationContract]
        List<UFs> GetUFs();
        //Updates
        [OperationContract]
        string UpdateCustomers(Customers customersInfo);
        //Deletes
        [OperationContract]
        string DeleteCustomers(Customers customersInfo);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WCFServiceHost.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
