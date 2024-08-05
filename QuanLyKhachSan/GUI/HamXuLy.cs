using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class HamXuLy
    {
        public HamXuLy() { }    
        public static DateTime NgayDauThang(int year, int month)
        {
            return new DateTime(year, month, 1);
        }
        static SqlConnection connection;
        public static void taoKetNoi()
        {
            connection = new SqlConnection("Data Source=DESKTOP-J8JE5C3;Initial Catalog=QL_KHACHSAN;Persist Security Info=True;User ID=sa;Password=123");
            connection.Open();
        }
        public static DataTable layDuLieu( string query)
        {
            taoKetNoi();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(query, connection);
            adapter.Fill(dt);
            dongKetNoi();
            return dt;
        }

        private static void dongKetNoi()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}   
