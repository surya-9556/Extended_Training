using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace BooksAndAuthorDB.Models
{
    public class CRUDModel
    {
        public DataTable DisplayBook()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("server=DESKTOP-87C5QHV;Integrated security=true;database=BookDb;Trusted_Connection=True;");
            SqlCommand cmd = new SqlCommand("select BookId, BookTitle, AuthorName, BookPrice from tbl_Book B join tbl_author A on B.AuthorId = A.AuthorId order by AuthorName", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int NewBook(string title,int aid,Double price)
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-87C5QHV;Integrated security=true;database=BookDb;Trusted_Connection=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_INsBook", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookTitle", SqlDbType.NVarChar).Value = title;
            cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = aid;
            cmd.Parameters.AddWithValue("@BookPrice", SqlDbType.Money).Value = price;
            return cmd.ExecuteNonQuery();
        }

        public int NewBookS(string title, string aid, Double price)
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-87C5QHV;Integrated security=true;database=BookDb;Trusted_Connection=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into tbl_Book(BookTitle,AuthorId,BookPrice) values(@BookTitle,(select AuthorId from tbl_Author where AuthorName = @AuthorName),@BookPrice)", con);
            cmd.Parameters.AddWithValue("@BookTitle", SqlDbType.NVarChar).Value = title;
            cmd.Parameters.AddWithValue("@AuthorName", SqlDbType.NVarChar).Value = aid;
            cmd.Parameters.AddWithValue("@BookPrice", SqlDbType.Money).Value = price;
            return cmd.ExecuteNonQuery();
        }

        public int DeleteBook(int bookid)
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-87C5QHV;Integrated security=true;database=BookDb;Trusted_Connection=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from tbl_Book where bookid = @bkid", con);
            cmd.Parameters.AddWithValue("@bkid",bookid);
            return cmd.ExecuteNonQuery();
        }

        public DataTable BookbyID(int bookid)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("server=DESKTOP-87C5QHV;Integrated security=true;database=BookDb;Trusted_Connection=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_book where bookid =" + bookid, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int UpdateBook(int Bid,string Title,int Aid,double Price)
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-87C5QHV;Integrated security=true;database=BookDb;Trusted_Connection=True;");
            con.Open();
            string qry = "update tbl_Book set BookTitle = @title, AuthorId = @aid, BookPrice = @price where BookId = @bid";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@title", Title);
            cmd.Parameters.AddWithValue("@aid", Aid);
            cmd.Parameters.AddWithValue("@price", Price);
            cmd.Parameters.AddWithValue("@bid", Bid);
            return cmd.ExecuteNonQuery();
        }

        public DataTable AuthorDisplay()
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

        public DataTable BooksDetails(int bookid)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("server=DESKTOP-87C5QHV;Integrated security=true;database=BookDb;Trusted_Connection=True;");
            con.Open();
            string qry = "select BookId, BookTitle, AuthorName, BookPrice from tbl_Book B join tbl_author A on B.AuthorId = A.AuthorId where BookId = " + bookid;
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}