using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class XuLyDangNhap
    {
        public XuLyDangNhap() { }
        public int Check_Config()
        {
            if (Properties.Settings.Default.cnString == string.Empty)
            {
                return 1;
            }
            SqlConnection _Sqlconn = new SqlConnection(Properties.Settings.Default.cnString);
            try
            {
                if (_Sqlconn.State == System.Data.ConnectionState.Closed)
                {
                    _Sqlconn.Open();
                }
                return 0;
            }
            catch (Exception)
            {

                return 2;
            }

        }

        public LoginResult Check_User(string pUser, string pPass)
        {
            SqlDataAdapter daUser = new SqlDataAdapter("select * from QL_NguoiDung where TenDangNhap='"
                + pUser
                + "' and MatKhau ='" + pPass
                + "'", Properties.Settings.Default.cnString);
            DataTable dt = new DataTable();
            daUser.Fill(dt);
            if (dt.Rows.Count == 0)
                return LoginResult.Invalid;// User không tồn tại
            else if (dt.Rows[0][2] == null || dt.Rows[0][2].ToString() ==
            "False")
            {
                return LoginResult.Disabled;// Không hoạt động
            }
            return LoginResult.Success;// Đăng nhập thành công
        }
        public DataTable GetDBName(string pServer, string pUser, string pPass)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select name from sys.Databases", "Data Source=" + pServer + ";Initial Catalog=master;User ID=" + pUser + ";pwd = " + pPass + "");
            da.Fill(dt);
            return dt;
        }
        public DataTable GetServerName()
        {
            DataTable dt = new DataTable();
            dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            return dt;
        }
        public void SaveConfig(string pServer, string pUser, string pPass, string pDBname)
        {
            GUI.Properties.Settings.Default.cnString = "Data Source=" +
            pServer + ";Initial Catalog=" + pDBname + ";User ID=" + pUser + ";pwd = " + pPass + "";
            GUI.Properties.Settings.Default.Save();
        }
    }
}
