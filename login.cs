using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace bookshop
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=bookshopp;Integrated Security=True");
        public static string UserName = "";
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from userTbl where UName ='" + usernametb.Text + "' and  Upassword='" + passwordtb.Text + " '", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
               UserName = usernametb.Text;
                billing obj = new billing();
                obj.Show();
                this.Hide();
                con.Close();
            }
            else
            {
                MessageBox.Show("wrong username and password");
            }

            con.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            adminlogin obj = new adminlogin();
            obj.Show();

            this.Hide();
        }
    }
}
