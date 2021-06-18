using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace BooksAndAuthorDB.Models
{
    public class AuthorCRUD
    {
        public DataTable Display()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("server=DESKTOP-87C5QHV;Integrated security=true;database=BookDb;Trusted_Connection=True;");
            SqlCommand cmd = new SqlCommand("select * from tbl_Author", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int Name(string AUName)
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-87C5QHV;Integrated security=true;database=BookDb;Trusted_Connection=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_INsAuthor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorName", SqlDbType.NVarChar).Value = AUName;
            return cmd.ExecuteNonQuery();
        }

        public int Update(int aid,string AUName)
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-87C5QHV;Integrated security=true;database=BookDb;Trusted_Connection=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_INsAuthor1", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorName", SqlDbType.NVarChar).Value = AUName;
            cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = aid;
            return cmd.ExecuteNonQuery();
        }
    }
}