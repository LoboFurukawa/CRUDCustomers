using CRUDCustomersWebAPI.Models;
using CRUDCustomersWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCustomersWebAPI.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomersService(ICustomersRepository customersRepository)
        {
            customersRepository = _customersRepository;
        }

        public Task<string> DeleteCustomers(Customers customersInfo)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Address>> GetAddressCustomerById(Customers customers)
        {
            CustomersRepository customersRepository = new CustomersRepository();
            try
            {
                IEnumerable<Address> addresses = await customersRepository.GetAddressCustomerById(customers);
                return addresses;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Customers>> GetCustomerById(Customers customers)
        {
            CustomersRepository customersRepository = new CustomersRepository();
            try
            {
                IEnumerable<Customers> customer = await customersRepository.GetCustomerById(customers);
                return customer;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Customers>> GetCustomers()
        {
            CustomersRepository customersRepository = new CustomersRepository();
            try
            {
                IEnumerable<Customers> customers = await customersRepository.GetCustomers();
                return customers;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<IEnumerable<DispatchAgency>> GetDispatchAgency()
        {
            CustomersRepository customersRepository = new CustomersRepository();
            try
            {
                IEnumerable<DispatchAgency> customers = await customersRepository.GetDispatchAgency();
                return customers;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<IEnumerable<MaritalStatus>> GetMaritalStatus()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UFs>> GetUFs()
        {
            throw new NotImplementedException();
        }

        public Task<string> InsertCustomers(Customers customersInfo)
        {
            throw new NotImplementedException();
        }

        public Task<string> InsertDispatchAgency(DispatchAgency dispatchAgency)
        {
            throw new NotImplementedException();
        }

        public Task<string> InsertMaritalStatus(MaritalStatus maritalStatus)
        {
            throw new NotImplementedException();
        }

        public Task<string> InsertUFs(UFs uFs)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateCustomers(Customers customersInfo)
        {
            throw new NotImplementedException();
        }
    }
}
