using CRUDCustomersWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCustomersWebAPI.Services
{
    public class CustomersService
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomersService(ICustomersRepository customersRepository)
        {
            customersRepository = _customersRepository;
        }

        public async Task<IEnumerable<Customers>> GetCustomers()
        {
            try
            {
                IEnumerable<Customers> customers = await _customersRepository.GetCustomers();
                return customers;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
