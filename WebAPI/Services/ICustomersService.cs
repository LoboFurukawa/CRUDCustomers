using CRUDCustomersWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCustomersWebAPI.Services
{
    public interface ICustomersService
    {
        Task<IEnumerable<Customers>> GetCustomers();
        Task<IEnumerable<MaritalStatus>> GetMaritalStatus();
        Task<IEnumerable<UFs>> GetUFs();
        Task<IEnumerable<DispatchAgency>> GetDispatchAgency();
        Task<IEnumerable<Customers>> GetCustomerById(Customers customers);
        Task<IEnumerable<Address>> GetAddressCustomerById(Customers customers);
        Task<string> InsertCustomers(Customers customersInfo);
        Task<string> InsertMaritalStatus(MaritalStatus maritalStatus);
        Task<string> InsertUFs(UFs uFs);
        Task<string> InsertDispatchAgency(DispatchAgency dispatchAgency);
        Task<string> UpdateCustomers(Customers customersInfo);
        Task<string> DeleteCustomers(Customers customersInfo);
    }
}
