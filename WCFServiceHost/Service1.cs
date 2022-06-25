using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServiceHost.Models;

namespace WCFServiceHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string InsertCustomers(Customers customersInfo)
        {
            string Message;
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CustomersCRUD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO TB_Customers(
                CPF,
                Name,
                RG,
                ShippingDate,
                IdDispatchAgency,
                IdUF,
                BirthDate,
                Gender,
                IdMaritalStatus) 
       output INSERTED.ID  values(@CPF,
                @Name,
                @RG,
                @ShippingDate,
                @IdDispatchAgency,
                @IdUF,
                @BirthDate,
                @Gender,
                @IdMaritalStatus)", con);
            cmd.Parameters.AddWithValue("@CPF", customersInfo.CPF);
            cmd.Parameters.AddWithValue("@Name", customersInfo.Name);
            cmd.Parameters.AddWithValue("@RG", customersInfo.RG);
            cmd.Parameters.AddWithValue("@ShippingDate", customersInfo.ShippingDate);
            cmd.Parameters.AddWithValue("@IdDispatchAgency", customersInfo.IdDispatchAgency);
            cmd.Parameters.AddWithValue("@IdUF", customersInfo.IdUF);
            cmd.Parameters.AddWithValue("@BirthDate", customersInfo.BirthDate);
            cmd.Parameters.AddWithValue("@Gender", customersInfo.Gender);
            cmd.Parameters.AddWithValue("@IdMaritalStatus", customersInfo.IdMaritalStatus);
            //int result = cmd.ExecuteNonQuery();
            int result = (int)cmd.ExecuteScalar();
            con.Close();

            con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CustomersCRUD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            cmd = new SqlCommand(@"INSERT INTO TB_Address(
                PostalCode,
                Street,
                Number,
                Complement,
                Neighborhood,
                City,
                IdUf,
                IdCustomer) 
       values(  @PostalCode,
                @Street,
                @Number,
                @Complement,
                @Neighborhood,
                @City,
                @IdUf,
                @IdCustomer)", con);
            cmd.Parameters.AddWithValue("@PostalCode", customersInfo.Address.PostalCode);
            cmd.Parameters.AddWithValue("@Street", customersInfo.Address.Street);
            cmd.Parameters.AddWithValue("@Number", customersInfo.Address.Number);
            cmd.Parameters.AddWithValue("@Complement", customersInfo.Address.Complement);
            cmd.Parameters.AddWithValue("@Neighborhood", customersInfo.Address.Neighborhood);
            cmd.Parameters.AddWithValue("@City", customersInfo.Address.City);
            cmd.Parameters.AddWithValue("@IdUf", customersInfo.Address.IdUF);
            cmd.Parameters.AddWithValue("@IdCustomer", result);

            int resultfinal = cmd.ExecuteNonQuery();

            if (resultfinal == 1)
            {
                Message = customersInfo.Name + " Details inserted successfully";
            }
            else
            {
                Message = customersInfo.Name + " Details not inserted successfully";
            }
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return Message;
        }

        public string InsertMaritalStatus(MaritalStatus maritalStatus)
        {
            string Message;
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CustomersCRUD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO TB_MaritalStatus(Description) values (@Description)", con);
            cmd.Parameters.AddWithValue("@Description", maritalStatus.Description);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = maritalStatus.Description + " Details inserted successfully";
            }
            else
            {
                Message = maritalStatus.Description + " Details not inserted successfully";
            }
            con.Close();
            return Message;
        }

        public string InsertUFs(UFs uFs)
        {
            string Message;
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CustomersCRUD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO TB_UFs(Description) values (@Description)", con);
            cmd.Parameters.AddWithValue("@Description", uFs.Description);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = uFs.Description + " Details inserted successfully";
            }
            else
            {
                Message = uFs.Description + " Details not inserted successfully";
            }
            con.Close();
            return Message;
        }

        public string InsertDispatchAgency(DispatchAgency dispatchAgency)
        {
            string Message;
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CustomersCRUD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO TB_DispatchAgency(Description) values (@Description)", con);
            cmd.Parameters.AddWithValue("@Description", dispatchAgency.Description);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = dispatchAgency.Description + " Details inserted successfully";
            }
            else
            {
                Message = dispatchAgency.Description + " Details not inserted successfully";
            }
            con.Close();
            return Message;
        }
    }
}
