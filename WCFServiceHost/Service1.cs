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
        //Inserts
        public string InsertCustomers(Customers customersInfo)
        {
            string Message;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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

                con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return Message;
        }

        public string InsertMaritalStatus(MaritalStatus maritalStatus)
        {
            string Message;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Message;
        }

        public string InsertUFs(UFs uFs)
        {
            string Message;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Message;
        }

        public string InsertDispatchAgency(DispatchAgency dispatchAgency)
        {
            string Message;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Message;
        }
        //Gets
        public List<Customers> GetCustomers()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM TB_Customers", con);
                var result = cmd.ExecuteReader();
                List<Customers> ListCustomers = new List<Customers>();

                while (result.Read())
                {
                    Customers func = new Customers();

                    func.Id = result.GetInt32(0);
                    func.CPF = result.GetString(1);
                    func.Name = result.GetString(2);
                    func.RG = result.GetString(3);
                    func.ShippingDate = result.GetDateTime(4);
                    func.IdDispatchAgency = result.GetInt32(5);
                    func.IdUF = result.GetInt32(6);
                    func.BirthDate = result.GetDateTime(7);
                    func.Gender = result.GetString(8);
                    func.IdMaritalStatus = result.GetInt32(9);
                    ListCustomers.Add(func);
                }
                con.Close();
                return ListCustomers;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<MaritalStatus> GetMaritalStatus()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM TB_MaritalStatus", con);
                var result = cmd.ExecuteReader();
                List<MaritalStatus> maritalStatuses = new List<MaritalStatus>();

                while (result.Read())
                {
                    MaritalStatus func = new MaritalStatus();

                    func.Id = result.GetInt32(0);
                    func.Description = result.GetString(1);
                    maritalStatuses.Add(func);
                }
                con.Close();
                return maritalStatuses;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<DispatchAgency> GetDispatchAgency()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM TB_DispatchAgency", con);
                var result = cmd.ExecuteReader();
                List<DispatchAgency> dispatchAgencies = new List<DispatchAgency>();

                while (result.Read())
                {
                    DispatchAgency func = new DispatchAgency();

                    func.Id = result.GetInt32(0);
                    func.Description = result.GetString(1);
                    dispatchAgencies.Add(func);
                }
                con.Close();
                return dispatchAgencies;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<UFs> GetUFs()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM TB_UFs", con);
                var result = cmd.ExecuteReader();
                List<UFs> uFs = new List<UFs>();

                while (result.Read())
                {
                    UFs func = new UFs();

                    func.Id = result.GetInt32(0);
                    func.Description = result.GetString(1);
                    uFs.Add(func);
                }
                con.Close();
                return uFs;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //Updates
        public string UpdateCustomers(Customers customersInfo)
        {
            string Message;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"UPDATE TB_Customers(
                Id
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
                cmd.Parameters.AddWithValue("@Id", customersInfo.Id);
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

                con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                cmd = new SqlCommand(@"UPDATE TB_Address(
                Id,
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
                cmd.Parameters.AddWithValue("@Id", customersInfo.Address.Id);
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
                    Message = customersInfo.Name + " Details update successfully";
                }
                else
                {
                    Message = customersInfo.Name + " Details not update successfully";
                }
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return Message;
        }
        //Deletes
        public string DeleteCustomers(Customers customersInfo)
        {
            string Message;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"DELETE TB_Address WHERE IdCustomer = @IdCustomer", con);
                cmd.Parameters.AddWithValue("@IdCustomer", customersInfo.Id);
                int result = cmd.ExecuteNonQuery();
                con.Close();

                con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                cmd = new SqlCommand(@"DELETE TB_Customers WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", customersInfo.Id);
                int resultfinal = cmd.ExecuteNonQuery();

                if (resultfinal == 1)
                {
                    Message = customersInfo.Name + " Details delete successfully";
                }
                else
                {
                    Message = customersInfo.Name + " Details not delete successfully";
                }
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return Message;
        }
    }
}
