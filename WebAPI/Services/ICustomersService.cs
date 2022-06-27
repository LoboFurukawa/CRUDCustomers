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
        Task<int> InsertCustomers(Customers customersInfo);
        Task<int> InsertMaritalStatus(MaritalStatus maritalStatus);
        Task<int> InsertUFs(UFs uFs);
        Task<int> InsertDispatchAgency(DispatchAgency dispatchAgency);
        Task<int> UpdateCustomers(Customers customersInfo);
        Task<int> DeleteCustomers(Customers customersInfo);
    }
}
