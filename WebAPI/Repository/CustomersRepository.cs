using CRUDCustomersWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCustomersWebAPI.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        public List<Customers> GetCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
