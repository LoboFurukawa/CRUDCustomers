using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceHost.Models
{
    public class Address
    {
        int id = 0;
        string postalCode = string.Empty;
        string street = string.Empty;
        int number = 0;
        string complement = string.Empty;
        string neighborhood = string.Empty;
        string city = string.Empty;
        int idUF = 0;
        int idCustomer = 0;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [DataMember]
        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }
        [DataMember]
        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        [DataMember]
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        [DataMember]
        public string Complement
        {
            get { return complement; }
            set { complement = value; }
        }
        [DataMember]
        public int IdUF
        {
            get { return idUF; }
            set { idUF = value; }
        }
        [DataMember]
        public int IdCustomer
        {
            get { return idCustomer; }
            set { idCustomer = value; }
        }
        [DataMember]
        public string Neighborhood
        {
            get { return neighborhood; }
            set { neighborhood = value; }
        }
        [DataMember]
        public string City
        {
            get { return city; }
            set { city = value; }
        }
    }
}
