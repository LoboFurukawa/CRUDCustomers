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

        public async Task<IEnumerable<DispatchAgency>> GetDispatchAgency()
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

        public async Task<IEnumerable<MaritalStatus>> GetMaritalStatus()
        {
            CustomersRepository customersRepository = new CustomersRepository();
            try
            {
                IEnumerable<MaritalStatus> customers = await customersRepository.GetMaritalStatus();
                return customers;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<UFs>> GetUFs()
        {
            CustomersRepository customersRepository = new CustomersRepository();
            try
            {
                IEnumerable<UFs> customers = await customersRepository.GetUFs();
                return customers;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> InsertCustomers(Customers customersInfo)
        {
            CustomersRepository customersRepository = new CustomersRepository();
            try
            {
                var customers = await customersRepository.InsertCustomers(customersInfo);
                return customers;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> InsertDispatchAgency(DispatchAgency dispatchAgency)
        {
            CustomersRepository customersRepository = new CustomersRepository();
            try
            {
                var customers = await customersRepository.InsertDispatchAgency(dispatchAgency);
                return customers;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> InsertMaritalStatus(MaritalStatus maritalStatus)
        {
            CustomersRepository customersRepository = new CustomersRepository();
            try
            {
                var customers = await customersRepository.InsertMaritalStatus(maritalStatus);
                return customers;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> InsertUFs(UFs uFs)
        {
            CustomersRepository customersRepository = new CustomersRepository();
            try
            {
                var customers = await customersRepository.InsertUFs(uFs);
                return customers;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> UpdateCustomers(Customers customersInfo)
        {
            CustomersRepository customersRepository = new CustomersRepository();
            try
            {
                var customers = await customersRepository.UpdateCustomers(customersInfo);
                return customers;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> DeleteCustomers(Customers customersInfo)
        {
            CustomersRepository customersRepository = new CustomersRepository();
            try
            {
                var customers = await customersRepository.DeleteCustomers(customersInfo);
                return customers;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
