using System;
using System.Collections.Generic;
using System.Data;
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
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
                //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
                //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
                //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
                //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
        public DataSet GetCustomers()
        {
            try
            {
                //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM TB_Customers", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.ExecuteNonQuery();
                con.Close();
                return ds;
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
                //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
                //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
                //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
        public DataSet GetCustomerById(Customers customers)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM TB_Customers WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", customers.Id);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }
        public DataSet GetAddressCustomerById(Customers customers)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM TB_Address WHERE IdCustomer = @IdCustomer", con);
            cmd.Parameters.AddWithValue("@IdCustomer", customers.Id);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }
        //Updates
        public string UpdateCustomers(Customers customersInfo)
        {
            string Message;
            try
            {
                //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"UPDATE TB_Customers SET
                CPF = @CPF,
                Name = @Name,
                RG = @RG,
                ShippingDate = @ShippingDate,
                IdDispatchAgency = @IdDispatchAgency,
                IdUF = @IdUF,
                BirthDate = @BirthDate,
                Gender = @Gender,
                IdMaritalStatus = @IdMaritalStatus WHERE Id= @Id", con);
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
                int result = cmd.ExecuteNonQuery();
                con.Close();

                con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                cmd = new SqlCommand(@"UPDATE TB_Address SET
                PostalCode = @PostalCode,
                Street = @Street,
                Number = @Number,
                Complement = @Complement,
                Neighborhood = @Neighborhood,
                City = @City,
                IdUf = @IdUf,
                IdCustomer = @IdCustomer WHERE IdCustomer = @IdCustomer AND Id= @Id", con);
                cmd.Parameters.AddWithValue("@Id", customersInfo.Address.Id);
                cmd.Parameters.AddWithValue("@PostalCode", customersInfo.Address.PostalCode);
                cmd.Parameters.AddWithValue("@Street", customersInfo.Address.Street);
                cmd.Parameters.AddWithValue("@Number", customersInfo.Address.Number);
                cmd.Parameters.AddWithValue("@Complement", customersInfo.Address.Complement);
                cmd.Parameters.AddWithValue("@Neighborhood", customersInfo.Address.Neighborhood);
                cmd.Parameters.AddWithValue("@City", customersInfo.Address.City);
                cmd.Parameters.AddWithValue("@IdUf", customersInfo.Address.IdUF);
                cmd.Parameters.AddWithValue("@IdCustomer", customersInfo.Id);

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
                //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=D:\PROJECT\CRUDCUSTOMERS\SQLSCRIPTS\CUSTOMERSCRUD.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
                    Message = customersInfo.Name + "Details delete successfully";
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
