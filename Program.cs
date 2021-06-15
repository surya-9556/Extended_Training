using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace BooksDb
{
    class Program
    {
        public void AuthorSp()
        {
            int choice;
            do
            {
                SqlConnection con = new SqlConnection("server=DESKTOP-87C5QHV;Integrated security=true;database=BookDb;Trusted_Connection=True;");
                Console.WriteLine("Enter your choice");
                Console.WriteLine("1. Insert");
                Console.WriteLine("2. Update");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        SqlCommand cmd = new SqlCommand("insert into tbl_Author values('LK sharma')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        break;
                    case 2:
                        SqlCommand qery = new SqlCommand("update tbl_Author set AuthorName = 'MM Keeravani' where AuthorId = '4' ", con);
                        con.Open();
                        qery.ExecuteNonQuery();
                        con.Close();
                        break;
                    case 3:
                        SqlCommand qery1 = new SqlCommand("delete tbl_author where AuthorId = '5'", con);
                        con.Open();
                        qery1.ExecuteNonQuery();
                        con.Close();
                        break;
                    case 4:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Invalied choice");
                        break;
                }
            } while (choice != 4);
        }

        public void AuthorStoreProcedure(string Name,int Id)
        {
            int choice;
            do
            {
                SqlConnection con = new SqlConnection("server=DESKTOP-87C5QHV;Integrated security=true;database=BookDb;Trusted_Connection=True;");
                Console.WriteLine("Enter your choice");
                Console.WriteLine("1. Insert");
                Console.WriteLine("2. Update");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        SqlCommand cmd = new SqlCommand("sp_INsAuthor", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AuthorName", SqlDbType.NVarChar).Value = Name;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        break;
                    case 2:
                        SqlCommand qery = new SqlCommand("sp_INsAuthor1", con);
                        qery.CommandType = System.Data.CommandType.StoredProcedure;
                        qery.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = Id;
                        qery.Parameters.AddWithValue("@AuthorName", SqlDbType.NVarChar).Value = Name;
                        con.Open();
                        qery.ExecuteNonQuery();
                        con.Close();
                        break;
                    case 3:
                        SqlCommand qery1 = new SqlCommand("sp_INsAuthor2", con);
                        qery1.CommandType = System.Data.CommandType.StoredProcedure;
                        qery1.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = Id;
                        con.Open();
                        qery1.ExecuteNonQuery();
                        con.Close();
                        break;
                    case 4:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Invalied choice");
                        break;
                }
            } while (choice != 4);
        }

        public string BookSp(string title,int aid,double price)
        {
            string res = null;
            SqlConnection con = new SqlConnection("server=DESKTOP-87C5QHV;Integrated security=true;database=BookDb;Trusted_Connection=True;");
            SqlCommand cmd = new SqlCommand("sp_INsBook", con);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@BookTitle", SqlDbType.NVarChar).Value = title;
            //cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = aid;
            //cmd.Parameters.AddWithValue("@BookPrice", SqlDbType.Money).Value = price;

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@BookTitle";
            p1.SqlDbType = SqlDbType.VarChar;
            p1.Value = title;
            cmd.Parameters.Add(p1);

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@AuthorId";
            p2.SqlDbType = SqlDbType.Int;
            p2.Value = aid;
            cmd.Parameters.Add(p2);

            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@BookPrice";
            p3.SqlDbType = SqlDbType.Money;
            p3.Value = price;
            cmd.Parameters.Add(p3);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            res = "Success";
            return res;
        }
        public void InsertBooks()
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-87C5QHV;Integrated security=true;database=BookDb;Trusted_Connection=True;");
            //SqlCommand cmd = new SqlCommand("insert into tbl_Book values('Harry potter',3,950)", con);
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandType = System.Data.CommandType.Text;
            //cmd.CommandText = "insert into tbl_Book values('Rich and poor dad',4,445) ";

            //string qry = "insert into tbl_Book values(@BookTitle,@AuthorId,@BookPrice) ";
            //SqlCommand cmd = new SqlCommand(qry,con);
            //cmd.Parameters.AddWithValue("@BookTitle", "Davinchi code");
            //cmd.Parameters.AddWithValue("@AuthorId", 4);
            //cmd.Parameters.AddWithValue("@BookPrice", 200);

            SqlCommand cmd = new SqlCommand("update tbl_Book set BookTitle = 'Game of throes' where BookId = '1007' ", con);

            //cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            //program.InsertBooks();
            //program.BookSp("Half girlfriend",1,220);
            //program.AuthorSp();
            program.AuthorStoreProcedure("Money Hiest",4);

            SqlConnection con = new SqlConnection("server=DESKTOP-87C5QHV;Integrated security=true;database=BookDb;Trusted_Connection=True;");
            SqlCommand cmd = new SqlCommand("select * from tbl_Author", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                Console.WriteLine(rdr["AuthorId"] + " " + rdr["AuthorName"].ToString());
            //while (rdr.Read())
            //    Console.WriteLine(rdr["BookId"] + " " + rdr["BookTitle"] + " " + rdr["BookPrice"].ToString());
            con.Close();
            Console.ReadLine();
        }
    }
}
