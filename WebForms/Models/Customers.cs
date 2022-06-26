using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebForms.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public string RG { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime BirthDate { get; set; }
        public int IdDispatchAgency { get; set; }
        public int IdUF { get; set; }
        public int IdMaritalStatus { get; set; }
        public string Gender = string.Empty;
        public Address Address = new Address();
    }
}
