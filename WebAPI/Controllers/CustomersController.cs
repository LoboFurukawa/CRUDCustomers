using CRUDCustomersWebAPI.Models;
using CRUDCustomersWebAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace CRUDCustomersWebAPI.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly ICustomersRepository _customersRepository;

        [HttpGet]
        [ResponseType(typeof(IEnumerable<Customers>))]
        public async Task<IEnumerable<Customers>> GetCustomers()
        {
            CustomersService customersService = new CustomersService(_customersRepository);
            try
            {
                var result = await customersService.GetCustomers();
                return result;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]
        [ResponseType(typeof(IEnumerable<MaritalStatus>))]
        public async Task<IEnumerable<MaritalStatus>> GetMaritalStatus()
        {
            CustomersService customersService = new CustomersService(_customersRepository);
            try
            {
                var result = await customersService.GetMaritalStatus();
                return result;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]
        [ResponseType(typeof(IEnumerable<DispatchAgency>))]
        public async Task<IEnumerable<DispatchAgency>> GetDispatchAgency()
        {
            CustomersService customersService = new CustomersService(_customersRepository);
            try
            {
                var result = await customersService.GetDispatchAgency();
                return result;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]
        [ResponseType(typeof(IEnumerable<UFs>))]
        public async Task<IEnumerable<UFs>> GetUFs()
        {
            CustomersService customersService = new CustomersService(_customersRepository);
            try
            {
                var result = await customersService.GetUFs();
                return result;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
