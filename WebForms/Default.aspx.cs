using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Models;

namespace WebForms
{
    public partial class _Default : Page
    {
        CRUDCustomersServices.Service1Client services = new CRUDCustomersServices.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindEmpDetails();
                dropdownMaritalStatus_Load();
                dropdownUfs_Load();
                dropdownDispatchAgency_Load();
                dropdownUfsCustomer_Load();
                ClearControls();
            }
        }

        private void ClearControls()
        {
            txtCity.Text = string.Empty;
            txtBirthDate.Text = string.Empty;
            txtCEP.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtComplement.Text = string.Empty;
            txtCPF.Text = string.Empty;
            txtIdAddress.Text = string.Empty;
            txtName.Text = string.Empty;
            txtNeighborhood.Text = string.Empty;
            txtNumber.Text = string.Empty;
            txtRG.Text = string.Empty;
            txtShippingDate.Text = string.Empty;
            txtStreet.Text = string.Empty;
            lstDispatchAgency = null;
            lstMaritalStatus = null;
            lstUFs = null;
            lstUFsCustomers = null;
        }
        private void BindEmpDetails() //This function defined for bind to grid view.  
        {
            Customers eDetails = new Customers();
            DataSet ds = new DataSet();
            ds = services.GetCustomers();
            grdWcfTest.DataSource = ds;
            grdWcfTest.DataBind();
        }
        protected void lnkEdit_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            Customers eDetails = new Customers(); //By clicking edit link button in gridview all existing data will come to respected controls.  
            eDetails.Id = int.Parse(e.CommandArgument.ToString());
            ViewState["Id"] = eDetails.Id; //Viewstate variable helps to pass id of respected data.  
            DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();
            WebForms.CRUDCustomersServices.Customers customersInfo = new CRUDCustomersServices.Customers()
            {
                Id = eDetails.Id
            };
            ds = services.GetCustomerById(customersInfo); //this function will help you fetch updated records.  
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                txtCPF.Text = ds.Tables[0].Rows[0]["CPF"].ToString();
                txtRG.Text = ds.Tables[0].Rows[0]["RG"].ToString();
                txtBirthDate.Text = ds.Tables[0].Rows[0]["BirthDate"].ToString();
                txtShippingDate.Text = ds.Tables[0].Rows[0]["ShippingDate"].ToString();
            }
            ds2 = services.GetAddressCustomerById(customersInfo);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                txtIdAddress.Text = ds2.Tables[0].Rows[0]["Id"].ToString();
                txtCEP.Text = ds2.Tables[0].Rows[0]["PostalCode"].ToString();
                txtStreet.Text = ds2.Tables[0].Rows[0]["Street"].ToString();
                txtNumber.Text = ds2.Tables[0].Rows[0]["Number"].ToString();
                txtComplement.Text = ds2.Tables[0].Rows[0]["Complement"].ToString();
                txtNeighborhood.Text = ds2.Tables[0].Rows[0]["Neighborhood"].ToString();
                txtCity.Text = ds2.Tables[0].Rows[0]["City"].ToString();
            }
            btnSubmit.Text = "Atualizar";
        }
        private void dropdownMaritalStatus_Load()
        {
            lstMaritalStatus.Items.Clear();
            lstMaritalStatus.DataSource = services.GetMaritalStatus();
            lstMaritalStatus.DataTextField = "Description";
            lstMaritalStatus.DataValueField = "Id";
            lstMaritalStatus.DataBind();
            //services.Close();
        }
        private void dropdownUfs_Load()
        {
            lstUFs.Items.Clear();
            lstUFs.DataSource = services.GetUFs();
            lstUFs.DataTextField = "Description";
            lstUFs.DataValueField = "Id";
            lstUFs.DataBind();
            //services.Close();
        }
        private void dropdownDispatchAgency_Load()
        {
            lstDispatchAgency.Items.Clear();
            lstDispatchAgency.DataSource = services.GetDispatchAgency();
            lstDispatchAgency.DataTextField = "Description";
            lstDispatchAgency.DataValueField = "Id";
            lstDispatchAgency.DataBind();
            //services.Close();
        }
        private void dropdownUfsCustomer_Load()
        {
            lstUFsCustomers.Items.Clear();
            lstUFsCustomers.DataSource = services.GetUFs();
            lstUFsCustomers.DataTextField = "Description";
            lstUFsCustomers.DataValueField = "Id";
            lstUFsCustomers.DataBind();
            //services.Close();
        }
        protected void btnSubmit_Click(object sender, EventArgs e) //In submit button click event i added "SaveEmpDetails()" to insert new records  
        {
            if (btnSubmit.Text == "Atualizar")
            {
                UpdateCustomerDetails(); //for update existing records.  
            }
            else
            {
                SaveCustomerDetails(); //for insert new records  
            }
        }
        private void UpdateCustomerDetails() //This function defined for update data.  
        {
            Customers eDetails = new Customers();
            eDetails.Id = Convert.ToInt32(ViewState["Id"].ToString());
            eDetails.Name = txtName.Text.Trim();
            eDetails.CPF = txtCPF.Text.Trim();
            eDetails.RG = txtRG.Text.Trim();
            eDetails.BirthDate = Convert.ToDateTime(txtBirthDate.Text.Trim());
            eDetails.ShippingDate = Convert.ToDateTime(txtShippingDate.Text.Trim());
            eDetails.IdDispatchAgency = Convert.ToInt32(lstDispatchAgency.SelectedValue.Trim());
            eDetails.IdMaritalStatus = Convert.ToInt32(lstMaritalStatus.SelectedValue.Trim());
            eDetails.IdUF = Convert.ToInt32(lstUFsCustomers.SelectedValue.Trim());
            eDetails.Address.Id = Convert.ToInt32(txtIdAddress.Text.Trim());
            eDetails.Address.IdCustomer = Convert.ToInt32(ViewState["Id"].ToString());
            eDetails.Address.Neighborhood = txtNeighborhood.Text.Trim();
            eDetails.Address.Number = Convert.ToInt32(txtNumber.Text.Trim());
            eDetails.Address.PostalCode = txtCEP.Text.Trim();
            eDetails.Address.City = txtCity.Text.Trim();
            eDetails.Address.Complement = txtComplement.Text.Trim();
            eDetails.Address.Street = txtStreet.Text.Trim();
            eDetails.Address.IdUF = Convert.ToInt32(lstUFs.SelectedValue.Trim());
            WebForms.CRUDCustomersServices.Customers customersInfo = new CRUDCustomersServices.Customers()
            {
                Id = eDetails.Id,
                Name = eDetails.Name,
                CPF = eDetails.CPF,
                RG = eDetails.RG,
                BirthDate = eDetails.BirthDate,
                ShippingDate = eDetails.ShippingDate,
                Gender = eDetails.Gender,
                IdDispatchAgency = eDetails.IdDispatchAgency,
                IdMaritalStatus = eDetails.IdMaritalStatus,
                IdUF = eDetails.IdUF,
                Address = new CRUDCustomersServices.Address()
                {
                    Id = eDetails.Address.Id,
                    IdCustomer = eDetails.Address.IdCustomer,
                    Neighborhood = eDetails.Address.Neighborhood,
                    Number = eDetails.Address.Number,
                    PostalCode = eDetails.Address.PostalCode,
                    City = eDetails.Address.City,
                    Complement = eDetails.Address.Complement,
                    Street = eDetails.Address.Street,
                    IdUF = eDetails.Address.IdUF
                }

            };
            services.UpdateCustomers(customersInfo);
            //lblStatus.Text = services.GetCustomerspDetails(eDetails);
            //lblStatus.ForeColor = System.Drawing.Color.Maroon;
            //ClearControls();
            //BindEmpDetails(null);
        }
        private void SaveCustomerDetails() //This function defined for update data.  
        {
            Customers eDetails = new Customers();
            //eDetails.Id = Convert.ToInt32(ViewState["Id"].ToString());
            eDetails.Name = txtName.Text.Trim();
            eDetails.CPF = txtCPF.Text.Trim();
            eDetails.RG = txtRG.Text.Trim();
            eDetails.BirthDate = Convert.ToDateTime(txtBirthDate.Text.Trim());
            eDetails.ShippingDate = Convert.ToDateTime(txtShippingDate.Text.Trim());
            eDetails.IdDispatchAgency = Convert.ToInt32(lstDispatchAgency.SelectedValue.Trim());
            eDetails.IdMaritalStatus = Convert.ToInt32(lstMaritalStatus.SelectedValue.Trim());
            eDetails.IdUF = Convert.ToInt32(lstUFsCustomers.SelectedValue.Trim());
            //eDetails.Address.IdCustomer = Convert.ToInt32(ViewState["Id"].ToString());
            eDetails.Address.Neighborhood = txtNeighborhood.Text.Trim();
            eDetails.Address.Number = Convert.ToInt32(txtNumber.Text.Trim());
            eDetails.Address.PostalCode = txtCEP.Text.Trim();
            eDetails.Address.City = txtCity.Text.Trim();
            eDetails.Address.Complement = txtComplement.Text.Trim();
            eDetails.Address.Street = txtStreet.Text.Trim();
            eDetails.Address.IdUF = Convert.ToInt32(lstUFs.SelectedValue.Trim());
            WebForms.CRUDCustomersServices.Customers customersInfo = new CRUDCustomersServices.Customers()
            {
                //Id = eDetails.Id,
                Name = eDetails.Name,
                CPF = eDetails.CPF,
                RG = eDetails.RG,
                BirthDate = eDetails.BirthDate,
                ShippingDate = eDetails.ShippingDate,
                Gender = eDetails.Gender,
                IdDispatchAgency = eDetails.IdDispatchAgency,
                IdMaritalStatus = eDetails.IdMaritalStatus,
                IdUF = eDetails.IdUF,
                Address = new CRUDCustomersServices.Address()
                {
                    IdCustomer = eDetails.Address.IdCustomer,
                    Neighborhood = eDetails.Address.Neighborhood,
                    Number = eDetails.Address.Number,
                    PostalCode = eDetails.Address.PostalCode,
                    City = eDetails.Address.City,
                    Complement = eDetails.Address.Complement,
                    Street = eDetails.Address.Street,
                    IdUF = eDetails.Address.IdUF
                }
            };
            services.InsertCustomers(customersInfo);
            //lblStatus.Text = services.GetCustomerspDetails(eDetails);
            //lblStatus.ForeColor = System.Drawing.Color.Maroon;
            //ClearControls();
            //BindEmpDetails(null);
        }
        protected void lnkDelete_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            Customers eDetails = new Customers(); //This part helps us to delete records using Delete link button.  
            eDetails.Id = int.Parse(e.CommandArgument.ToString());
            WebForms.CRUDCustomersServices.Customers customersInfo = new CRUDCustomersServices.Customers()
            {
                Id = eDetails.Id
            };
            services.DeleteCustomers(customersInfo);
        }
    }
}