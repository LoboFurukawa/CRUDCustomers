using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceHost.Models
{
    public class Customers
    {
        string cpf = string.Empty;
        string name = string.Empty;
        string rg = string.Empty;
        DateTime shippingDate = DateTime.Now;
        DateTime birthDate = DateTime.Now;
        int idDispatchAgency = 0;
        int idUF = 0;
        int idMaritalStatus = 0;
        string gender = string.Empty;

        [DataMember]
        public string CPF
        {
            get { return cpf; }
            set { cpf = value; }
        }
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public string RG
        {
            get { return rg; }
            set { rg = value; }
        }
        [DataMember]
        public DateTime ShippingDate
        {
            get { return shippingDate; }
            set { shippingDate = value; }
        }
        [DataMember]
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }
        [DataMember]
        public int IdDispatchAgency
        {
            get { return idDispatchAgency; }
            set { idDispatchAgency = value; }
        }
        [DataMember]
        public int IdUF
        {
            get { return idUF; }
            set { idUF = value; }
        }
        [DataMember]
        public int IdMaritalStatus
        {
            get { return idMaritalStatus; }
            set { idMaritalStatus = value; }
        }
        [DataMember]
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
    }
}
