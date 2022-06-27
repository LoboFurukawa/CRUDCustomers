using CRUDCustomersWebAPI.Models;
using CRUDCustomersWebAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace CRUDCustomersWebAPI.Controllers
{
    [RoutePrefix("api/[controller]")]
    public class CustomersController : ApiController
    {
        private readonly ICustomersService _customersService;
        public CustomersController(ICustomersService customersService)
        {
            customersService = _customersService;
        }
        [HttpGet]
        [Route("GetCustomers")]
        [ResponseType(typeof(IEnumerable<Customers>))]
        public async Task<IHttpActionResult> GetCustomers()
        {
            try
            {
                var result = await _customersService.GetCustomers();
                return (IHttpActionResult)result;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
