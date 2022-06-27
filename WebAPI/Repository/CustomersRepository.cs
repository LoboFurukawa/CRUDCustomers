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

        public Task<string> DeleteCustomers(Customers customersInfo)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Address>> GetAddressCustomerById(Customers customers)
        {
            return _db.QueryAsync<Address>("SELECT * FROM TB_Address WHERE IdCustomer = @IdCustomer", new { IdCustomer = customers.Id });
        }

        public Task<IEnumerable<Customers>> GetCustomerById(Customers customers)
        {
            return _db.QueryAsync<Customers>("SELECT * FROM TB_Customers WHERE Id = @Id", new { Id = customers.Id });
        }

        public Task<IEnumerable<Customers>> GetCustomers()
        {
            return _db.QueryAsync<Customers>("SELECT * FROM TB_Customers");
        }

        public Task<IEnumerable<DispatchAgency>> GetDispatchAgency()
        {
            return _db.QueryAsync<DispatchAgency>("SELECT * FROM TB_DispatchAgency");
        }

        public Task<IEnumerable<MaritalStatus>> GetMaritalStatus()
        {
            return _db.QueryAsync<MaritalStatus>("SELECT * FROM TB_MaritalStatus");
        }

        public Task<IEnumerable<UFs>> GetUFs()
        {
            return _db.QueryAsync<UFs>("SELECT * FROM TB_UFs");
        }

        public async Task<int> InsertCustomers(Customers customersInfo)
        {
            try
            {
                int rowsAffected = await this._db.ExecuteAsync(@"INSERT INTO TB_Customers(
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
                @IdMaritalStatus)",
                new
                {
                    CPF = customersInfo.CPF,
                    Name = customersInfo.Name,
                    RG = customersInfo.RG,
                    ShippingDate = customersInfo.ShippingDate,
                    IdDispatchAgency = customersInfo.IdDispatchAgency,
                    IdUF = customersInfo.IdUF,
                    BirthDate = customersInfo.BirthDate,
                    Gender = customersInfo.Gender,
                    IdMaritalStatus = customersInfo.IdMaritalStatus,
                });
                if (rowsAffected > 0)
                {
                    rowsAffected = await this._db.ExecuteAsync(@"INSERT INTO TB_Address(
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
                @IdCustomer)",
                    new
                    {
                        PostalCode = customersInfo.Address.PostalCode,
                        Street = customersInfo.Address.Street,
                        Number = customersInfo.Address.Number,
                        Complement = customersInfo.Address.Complement,
                        Neighborhood = customersInfo.Address.Neighborhood,
                        City = customersInfo.Address.City,
                        IdUf = customersInfo.Address.IdUF,
                        IdCustomer = customersInfo.Id,

                    });
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<int> InsertDispatchAgency(DispatchAgency dispatchAgency)
        {
            try
            {
                int rowsAffected = await this._db.ExecuteAsync(@"INSERT INTO TB_DispatchAgency(Description) values (@Description)",
                    new
                    {
                        Description = dispatchAgency.Description
                    });
                return rowsAffected;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> InsertMaritalStatus(MaritalStatus maritalStatus)
        {
            try
            {
                int rowsAffected = await this._db.ExecuteAsync(@"INSERT INTO TB_MaritalStatus(Description) values (@Description)",
       new
       {
           Description = maritalStatus.Description
       });
                return rowsAffected;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<int> InsertUFs(UFs uFs)
        {
            try
            {
                int rowsAffected = await this._db.ExecuteAsync(@"INSERT INTO TB_UFs(Description) values (@Description)",
       new
       {
           Description = uFs.Description
       });
                return rowsAffected;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<int> UpdateCustomers(Customers customersInfo)
        {
            try
            {
                int rowsAffected = await this._db.ExecuteAsync(@"UPDATE TB_Customers SET
                CPF = @CPF,
                Name = @Name,
                RG = @RG,
                ShippingDate = @ShippingDate,
                IdDispatchAgency = @IdDispatchAgency,
                IdUF = @IdUF,
                BirthDate = @BirthDate,
                Gender = @Gender,
                IdMaritalStatus = @IdMaritalStatus WHERE Id= @Id",
       new
       {
           Id = customersInfo.Id,
           CPF = customersInfo.CPF,
           Name = customersInfo.Name,
           RG = customersInfo.RG,
           ShippingDate = customersInfo.ShippingDate,
           IdDispatchAgency = customersInfo.IdDispatchAgency,
           IdUF = customersInfo.IdUF,
           BirthDate = customersInfo.BirthDate,
           Gender = customersInfo.Gender,
           IdMaritalStatus = customersInfo.IdMaritalStatus,
       }); ;
                if (rowsAffected > 0)
                {
                    rowsAffected = await this._db.ExecuteAsync(@"UPDATE TB_Address SET
                PostalCode = @PostalCode,
                Street = @Street,
                Number = @Number,
                Complement = @Complement,
                Neighborhood = @Neighborhood,
                City = @City,
                IdUf = @IdUf,
                IdCustomer = @IdCustomer WHERE IdCustomer = @IdCustomer AND Id= @Id",
      new
      {
          Id = customersInfo.Address.Id,
          PostalCode = customersInfo.Address.PostalCode,
          Street = customersInfo.Address.Street,
          Number = customersInfo.Address.Number,
          Complement = customersInfo.Address.Complement,
          Neighborhood = customersInfo.Address.Neighborhood,
          City = customersInfo.Address.City,
          IdUf = customersInfo.Address.IdUF,
          IdCustomer = customersInfo.Id,
      });
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
