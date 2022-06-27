using CRUDCustomersWebAPI.Models;
using Dapper;
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
        public Task<IEnumerable<Customers>> GetCustomers()
        {
            return _db.QueryAsync<Customers>("SELECT * FROM TB_Customers");
        }
    }
}
