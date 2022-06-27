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
    }
}
