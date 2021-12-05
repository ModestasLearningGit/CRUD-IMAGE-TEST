using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageCRUDtest
{
    class MemberDAL
    {
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        public bool Insert(MemberBLL bll)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string sql = "INSERT INTO MemberInfo(PicuteName, Fname, Lname, Email)" +
                "VALUES(@PictureName, @Fname,@Lname,@Email)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@PictureName", bll.imageName);
                cmd.Parameters.AddWithValue("@Fname", bll.fName);
                cmd.Parameters.AddWithValue("@Lname", bll.lName);
                cmd.Parameters.AddWithValue("@Email", bll.Email);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if(rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }

        public DataTable Select()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string sql = "SELECT * FROM MemberInfo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
            finally
            {
                conn.Close();
            }



            return dt;

        }

        public bool Update(MemberBLL bll)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string sql = "UPDATE MemberInfo Set PicuteName=@PictureName, Fname=@Fname, Lname=@Lname, Email=@Email " +
                "WHERE MID=@MID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@PictureName", bll.imageName);
                cmd.Parameters.AddWithValue("@Fname", bll.fName);
                cmd.Parameters.AddWithValue("@Lname", bll.lName);
                cmd.Parameters.AddWithValue("@Email", bll.Email);
                cmd.Parameters.AddWithValue("@MID", bll.memberId);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if(rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        public DataTable Search(string keyword)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string sql = "SELECT MID,Fname,Lname,Email From MemberInfo WHERE MID LIKE '%" + keyword + "%'  OR " +
                "Fname LIKE '&" + keyword + "&' OR Lname LIKE '%" + keyword + "%'  OR Email LIKE '%" + keyword + "%'";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }


            return dt;
        }
        public bool Delete(MemberBLL bll)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                string sql = "DELETE FROM MemberInfo WHERE MID=@MID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MID", bll.memberId);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    //Query excecuted sufesfullly
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }


            return isSuccess;

        }
    }
}
