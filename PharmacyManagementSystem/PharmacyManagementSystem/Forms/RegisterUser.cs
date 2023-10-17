using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using PharmacyManagementSystem.BL;
using PharmacyManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace PharmacyManagementSystem.Forms
{
    public partial class RegisterUser : Form
    {
        public RegisterUser()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            Users obj;
           
            var con = Configuration.getInstance().getConnection();
            if(comboBox1.Text != "Manager" && comboBox1.Text !="User")
            {
                MessageBox.Show("select from the ComboBox");
                return;
            }
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
                {
                    if (UsersDL.isExistUsername(textBox1.Text))
                    {
                        if (UsersDL.isExistPassword(textBox2.Text))
                        {
                            if (UsersDL.isExistRole(comboBox1.Text))
                            {
                                SqlCommand cmd;
                                cmd = new SqlCommand("insert into Users values (@CreatedAt , @UpdatedAt , @Active , @Username ,@Password , @Role )", con);
                                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                                cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Active", "Active");
                                cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                                cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                                cmd.Parameters.AddWithValue("@Role", comboBox1.Text);
                                int id = (int)cmd.ExecuteNonQuery();
                               

                                SqlCommand cmd2;
                                cmd2 = new SqlCommand("insert into UsersAudit values ((Select MAX(ID) from Users) ,@CreatedAt , @UpdatedAt , @Active , @OldUsername ,@OldPassword , @OldRole,@NewUsername ,@NewPassword , @NewRole )", con);
                                cmd2.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                                cmd2.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                cmd2.Parameters.AddWithValue("@Active", "Active");
                                cmd2.Parameters.AddWithValue("@OldUsername", textBox1.Text);
                                cmd2.Parameters.AddWithValue("@OldPassword", textBox2.Text);
                                cmd2.Parameters.AddWithValue("@OldRole", comboBox1.Text);
                                cmd2.Parameters.AddWithValue("@NewUsername", textBox1.Text);
                                cmd2.Parameters.AddWithValue("@NewPassword", textBox2.Text);
                                cmd2.Parameters.AddWithValue("@NewRole", comboBox1.Text);
                                int UserAuditid = (int)cmd2.ExecuteNonQuery();

                                SqlCommand cmd1;
                                cmd1 = new SqlCommand("Select MAX(ID) from Users", con);
                                int userid = (int)cmd1.ExecuteScalar();

                                obj = new Users(DateTime.Now, DateTime.Now, "Active", userid, textBox1.Text, textBox2.Text, comboBox1.Text);
                                UsersDL.addIntoList(obj);

                                MessageBox.Show("saved");
                            }
                            else
                            {
                                MessageBox.Show(" cannot same role assigned  ");
                            }
                        }
                        else
                        {
                            MessageBox.Show(" cannot same password assigned   ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("name  is already  assigned  ");
                    }


                }
                else
                {
                    MessageBox.Show(" Must Fill All The Enteries ");
                }
            }
            catch(Exception exp) 
            {
                SqlCommand cmd;
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", "Error in the add users");
                cmd.Parameters.AddWithValue("@LogClass", "User");
                cmd.Parameters.AddWithValue("@LogFunction", "Add User");
                cmd.ExecuteNonQuery();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text != "Manager" && comboBox1.Text != "User")
            {
                MessageBox.Show("select from the ComboBox");
                return;
            }
            Users obj;
            SqlCommand cmd;
            DateTime CreateAt= DateTime.Now;
            string name = "", pass ="",  role = "";
            int id = -1;
            var con = Configuration.getInstance().getConnection();
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
                {
                    if (UsersDL.isExistPasswordd(textBox2.Text, textBox1.Text))
                    {
                        if (UsersDL.isExistRolee(comboBox1.Text, textBox1.Text))
                        {
                            foreach (Users o in UsersDL.GetUsersList())
                            {
                                if (o.GetUsername() == textBox1.Text)
                                {
                                    name = o.GetUsername();
                                    pass = o.GetPassword();
                                    role = o.GetRole();
                                    id = o.GetID();
                                    CreateAt = o.GetCreatedAt();
                                    o.SetPassword(textBox2.Text);
                                    o.SetRole(comboBox1.Text);
                                    o.SetUpdatedAt(DateTime.Now);
                                }
                            }
                            cmd = new SqlCommand("UPDATE Users set UpdatedAt = @UpdatedAt,Username= @Username, Password =@Password  , Role = @Role  where Username= @Username", con);
                            cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                            cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                            cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                            cmd.Parameters.AddWithValue("@Role", comboBox1.Text);
                            int UserUpdate = (int)cmd.ExecuteNonQuery();

                          

                            cmd = new SqlCommand("insert into UsersAudit values (@UserId , @CreatedAt , @UpdatedAt , @Active , @OldUsername ,@OldPassword , @OldRole,@NewUsername ,@NewPassword , @NewRole )", con);
                            cmd.Parameters.AddWithValue("@UserId", id);
                            cmd.Parameters.AddWithValue("@CreatedAt", CreateAt);
                            cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                            cmd.Parameters.AddWithValue("@Active", "Active");
                            cmd.Parameters.AddWithValue("@OldUsername", name);
                            cmd.Parameters.AddWithValue("@OldPassword", pass);
                            cmd.Parameters.AddWithValue("@OldRole", role);
                            cmd.Parameters.AddWithValue("@NewUsername", textBox1.Text);
                            cmd.Parameters.AddWithValue("@NewPassword", textBox2.Text);
                            cmd.Parameters.AddWithValue("@NewRole", comboBox1.Text);
                            int UserAuditid = (int)cmd.ExecuteNonQuery();

                            MessageBox.Show("updated");

                        }
                        else
                        {
                            MessageBox.Show(" cannot same role assigned  ");
                        }
                    }
                    else
                    {
                        MessageBox.Show(" cannot same password assigned ");
                    }

                }
                else
                {
                    MessageBox.Show(" Must Fill All The Enteries ");
                }
            }
            catch(Exception exp)
            {
                SqlCommand cmd1;
                cmd1 = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd1.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd1.Parameters.AddWithValue("@LogTitle", "error in the update ");
                cmd1.Parameters.AddWithValue("@LogClass", "User");
                cmd1.Parameters.AddWithValue("@LogFunction", "Update _ User");
                cmd1.ExecuteNonQuery();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            var con = Configuration.getInstance().getConnection();
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("CreatedAt");
                dt.Columns.Add("UpdatedAt");
                dt.Columns.Add("Active");
                dt.Columns.Add("UserID");
                dt.Columns.Add("Username");
                dt.Columns.Add("Password");
                dt.Columns.Add("Role");
                foreach (Users o in UsersDL.GetUsersList())
                {
                    dt.Rows.Add(o.GetCreatedAt(), o.GetUpdatedAt(), o.GetStatus(), o.GetID(), o.GetUsername(), o.GetPassword(), o.GetRole());
                }
                dataGridView1.Refresh();
                dataGridView1.DataSource = dt;
            }
            catch(Exception exp) 
            {
                SqlCommand cmd1;
                cmd1 = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd1.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd1.Parameters.AddWithValue("@LogTitle", "error in the show ");
                cmd1.Parameters.AddWithValue("@LogClass", "User");
                cmd1.Parameters.AddWithValue("@LogFunction", "show_User");
                cmd1.ExecuteNonQuery();
            }
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlCommand cmd;
            var con = Configuration.getInstance().getConnection();
            try
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "EDIT")
                {
                    if (MessageBox.Show("Are You Sure You Want To Edit This Record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                        textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Password"].Value.ToString();
                        comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Role"].Value.ToString();
                        textBox1.ReadOnly = true;


                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "STATUS")
                {
                    if (MessageBox.Show("Are You Sure You Want To Change the ststus of  This Record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string Create = dataGridView1.Rows[e.RowIndex].Cells["CreatedAt"].Value.ToString();
                        string Update = dataGridView1.Rows[e.RowIndex].Cells["UpdatedAt"].Value.ToString();
                        DateTime CreatedAt, UpdatedAt;
                        // Attempt to parse the strings to DateTime
                        if (DateTime.TryParse(Create, out CreatedAt)) { }
                        else
                        {
                            MessageBox.Show("error in the converting CreatedAt string to datetime");
                        }

                        if (DateTime.TryParse(Update, out UpdatedAt)) { }
                        else
                        {
                            MessageBox.Show("error in the converting UpdatedAt string to datetime");
                        }

                        string Status = dataGridView1.Rows[e.RowIndex].Cells["Active"].Value.ToString();
                        if (Status == "Active")
                        {
                            Status = "InActive";
                        }
                        else if (Status == "InActive")
                        {
                            Status = "Active";
                        }
                        string name = dataGridView1.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                        string Pass = dataGridView1.Rows[e.RowIndex].Cells["Password"].Value.ToString();
                        string Role = dataGridView1.Rows[e.RowIndex].Cells["Role"].Value.ToString();

                        DateTime CreateAt = DateTime.Now;
                        string oldname = " ", oldpass = " ", oldrole = "";
                        int UserId = -1;
                        foreach (Users o in UsersDL.GetUsersList())
                        {
                            if (o.GetUsername() == name)
                            {
                                oldname = o.GetUsername();
                                oldpass = o.GetPassword();
                                oldrole = o.GetRole();
                                UserId = o.GetID();
                                CreateAt = o.GetCreatedAt();
                                o.SetUsername(name);
                                o.SetPassword(Pass);
                                o.SetRole(Role);
                                o.SetStatus(Status);
                                o.SetUpdatedAt(DateTime.Now);


                            }
                        }


                        // update in User Table 
                        cmd = new SqlCommand("UPDATE Users set UpdatedAt = @UpdatedAt , Active = @Active,   Role = @Role  where Password = @Password AND  Username= @Username", con);
                        cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Active", Status);
                        cmd.Parameters.AddWithValue("@Username", name);
                        cmd.Parameters.AddWithValue("@Password", Pass);
                        cmd.Parameters.AddWithValue("@Role", Role);
                        cmd.ExecuteNonQuery();

                        //insert the uodated data of the user 
                        cmd = new SqlCommand("insert into UsersAudit values (@UserId , @CreatedAt , @UpdatedAt , @Active , @OldUsername ,@OldPassword , @OldRole,@NewUsername ,@NewPassword , @NewRole )", con);
                        cmd.Parameters.AddWithValue("@UserId", UserId);
                        cmd.Parameters.AddWithValue("@CreatedAt", CreateAt);
                        cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Active", Status);
                        cmd.Parameters.AddWithValue("@OldUsername", name);
                        cmd.Parameters.AddWithValue("@OldPassword", oldpass);
                        cmd.Parameters.AddWithValue("@OldRole", oldrole);
                        cmd.Parameters.AddWithValue("@NewUsername", name);
                        cmd.Parameters.AddWithValue("@NewPassword", Pass);
                        cmd.Parameters.AddWithValue("@NewRole", Role);
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch(Exception exp) 
            {
                SqlCommand cmd1;
                cmd1 = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd1.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd1.Parameters.AddWithValue("@LogTitle", "error in ststus update ");
                cmd1.Parameters.AddWithValue("@LogClass", "User");
                cmd1.Parameters.AddWithValue("@LogFunction", "Grid_Update_User");
                cmd1.ExecuteNonQuery();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            dataGridView1.DataSource = null;
        }
    
    }
}
