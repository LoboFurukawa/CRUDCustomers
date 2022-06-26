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
                //ClearControls();
            }
        }

        private void ClearControls()
        {
            throw new NotImplementedException();
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
                txtCEP.Text = ds2.Tables[0].Rows[0]["PostalCode"].ToString();
                txtStreet.Text = ds2.Tables[0].Rows[0]["Street"].ToString();
                txtNumber.Text = ds2.Tables[0].Rows[0]["Number"].ToString();
                txtComplement.Text = ds2.Tables[0].Rows[0]["Complement"].ToString();
                txtNeighborhood.Text = ds2.Tables[0].Rows[0]["Neighborhood"].ToString();
                txtCity.Text = ds2.Tables[0].Rows[0]["City"].ToString();
            }
        }
    }
}