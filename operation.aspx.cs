using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentCrud
{
    public partial class operation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bView_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["studentDBcon"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("stuInsert", con);    
            cmd.CommandType = CommandType.StoredProcedure;   


            cmd.Parameters.AddWithValue("@sName", nametxt.Text.ToString());        
            cmd.Parameters.AddWithValue("@sStream ", streamtxt.Text.ToString());     
            cmd.Parameters.AddWithValue("@sAge ", agetxt.Text.ToString());         
            cmd.ExecuteNonQuery();
            con.Close();

            Response.Write(" student data insered");

            Show();
            
        }
        public void Show()
        {
            string cs = ConfigurationManager.ConnectionStrings["studentDBcon"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("stuShow", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataView.DataSource = ds;
            DataView.DataBind();

            cmd.ExecuteNonQuery();
            con.Close();

            
        }

        protected void DataView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DataView.EditIndex = e.NewEditIndex;
            Show();

        }

        protected void DataView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DataView.EditIndex = -1;
            Show();
        }

        protected void DataView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = int.Parse(DataView.DataKeys[e.RowIndex].Value.ToString());
            string cs = ConfigurationManager.ConnectionStrings["studentDBcon"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("upStu", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@sName",((TextBox)DataView.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString());
            cmd.Parameters.AddWithValue("@sStream",((TextBox)DataView.Rows[e.RowIndex].Cells[4].Controls[0]).Text.ToString());
            cmd.Parameters.AddWithValue("@sAge",((TextBox)DataView.Rows[e.RowIndex].Cells[5].Controls[0]).Text.ToString());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.Close();
            DataView.EditIndex = -1;
            Show();
        }

        protected void DataView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(DataView.DataKeys[e.RowIndex].Value.ToString());
            string cs = ConfigurationManager.ConnectionStrings["studentDBcon"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("delStu", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.Close();
            Show();
        }
    }
}