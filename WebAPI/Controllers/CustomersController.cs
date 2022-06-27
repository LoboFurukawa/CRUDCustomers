using CRUDCustomersWebAPI.Models;
using CRUDCustomersWebAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace CRUDCustomersWebAPI.Controllers
{
    //[Route("api/[controller]")]
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
        [ResponseType(typeof(IEnumerable<Customers>))]
        public async Task<IEnumerable<Customers>> GetMaritalStatus()
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
    }
}
