﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NETCRUD
{
    public partial class Contact : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=BD-PNTL4-06D\\SQLSQL;Initial Catalog=ASPCRUD;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDelete.Enabled = false;
            }
            GridViewFiil();
          
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            hfContactID.Value = "";
            txtName.Text = txtMobile.Text = txtAddress.Text = "";
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("ContactCreateOrUpdate",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContactID",(hfContactID.Value==""?0:Convert.ToInt32(hfContactID.Value)));
            cmd.Parameters.AddWithValue("@Name",txtName.Text.Trim());
            cmd.Parameters.AddWithValue("@Mobile",txtMobile.Text.Trim());
            cmd.Parameters.AddWithValue("@Address",txtAddress.Text.Trim());
            cmd.ExecuteNonQuery();
            con.Close();
            string contactID = hfContactID.Value;
            Clear();
            if (contactID == "")
            {
                lblSuccessMessage.Text = "Saved successfully";
            }
            else
            {
                lblSuccessMessage.Text = "Updated successfully";
            }
            GridViewFiil();
         
        }
        void GridViewFiil()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("ContactViewAll", con);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            gvContact.DataSource = dt;
            gvContact.DataBind();
        }
        protected void lnk_OnClick(object sender, EventArgs e)
        {
            int contactID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("ContactViewByID", con);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@ContactID",contactID);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            hfContactID.Value = contactID.ToString();
            txtName.Text = dt.Rows[0]["Name"].ToString();
            txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            btnSave.Text = "Update";
            btnDelete.Enabled = true;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("ContactDeleteByID",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContactID", Convert.ToInt32(hfContactID.Value));
            cmd.ExecuteNonQuery();
            con.Close();
            Clear();
            GridViewFiil();
            lblSuccessMessage.Text = "Deleted successfully.";
        }
    }
}