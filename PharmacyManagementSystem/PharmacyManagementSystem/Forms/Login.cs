using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PharmacyManagementSystem.BL;
using PharmacyManagementSystem.DL;
namespace PharmacyManagementSystem.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            label1.Visible = false;
            label7.Visible = false;
            UsersDL.loadData();
            ManufacturerDL.loadData();
            SupplierDL.loadData();
            PatientDL.loadData();
          
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                foreach(Users obj in UsersDL.GetUsersList())
                {
                    if(obj.GetUsername() == textBox1.Text && obj.GetPassword() == textBox2.Text)
                    {
                        UsersDL.SetLoggedUser(obj.GetUsername());
                        UsersDL.SetLoggedId(obj.GetID());
                         if(obj.GetStatus() == "Active"  )
                         {
                             Form frm = new Form1();
                             frm.ShowDialog();
                         }
                         else
                         {
                             MessageBox.Show("InActive");
                         }
                       
                    }
                    else
                    {
                        label1.Visible = true;
                        label7.Visible = true;
                    }
                }
            }


            /*var con = Configuration.getInstance().getConnection();
            SqlCommand cmd;
            if (textBox1.Text !="" && textBox2.Text !="")
            {
                cmd = new SqlCommand("Select ID from Users where  Username = @Username and Password = @Password", con);
                cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                if (cmd.ExecuteScalar() != null)
                {
                    int Id = cmd.ExecuteNonQuery();
                    temp = Id;
                    Form frm = new Form1();
                    frm.ShowDialog();
                }
                else
                {
                    label1.Visible = true;
                    label7.Visible = true;
                }
            }*/

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
