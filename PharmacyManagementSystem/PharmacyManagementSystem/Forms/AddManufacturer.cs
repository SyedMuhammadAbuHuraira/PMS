using PharmacyManagementSystem.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PharmacyManagementSystem.DL;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace PharmacyManagementSystem.Forms
{
    public partial class AddManufacturer : Form
    {
        public AddManufacturer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddManufacturer_Load(object sender, EventArgs e)
        {

        }

        private void Pharmacy_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            Manufacturer obj;
            SqlCommand cmd;
            var con = Configuration.getInstance().getConnection();

            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    if (ManufacturerDL.isValid(textBox4.Text))
                    {
                        if (textBox3.Text.Length == 11)
                        {
                            if (ManufacturerDL.isExist(textBox1.Text))
                            {
                                if (ManufacturerDL.isExistAddress(textBox2.Text))
                                {
                                    if (ManufacturerDL.isExistEmail(textBox4.Text))
                                    {
                                        // add data into the person table 
                                        cmd = new SqlCommand("insert into Person values (@CreatedAt , @UpdatedAt , @Active, @Name ,@Email , @Address , @PhoneNo ,@LoggedID)", con);
                                        cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                                        cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                        cmd.Parameters.AddWithValue("@Active", "Active");
                                        cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                                        cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                                        cmd.Parameters.AddWithValue("@Address", textBox2.Text);
                                        cmd.Parameters.AddWithValue("@PhoneNo", textBox3.Text);
                                        cmd.Parameters.AddWithValue("@LoggedID", UsersDL.GetLoggedId());
                                        cmd.ExecuteNonQuery();


                                        // PersonAudit Table Query  insert
                                        cmd = new SqlCommand("insert into PersonAudit values (@CreatedAt , @UpdatedAt , @Active, (Select Max(ID) from Person), @OldName ,@OldEmail , @OldAddress , @OldPhoneNo, @NewName ,@NewEmail , @NewAddress , @NewPhoneNo ,@LoggedID)", con);
                                        cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                                        cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                        cmd.Parameters.AddWithValue("@Active", "Active");

                                        cmd.Parameters.AddWithValue("@OldName", textBox1.Text);
                                        cmd.Parameters.AddWithValue("@OldEmail", textBox4.Text);
                                        cmd.Parameters.AddWithValue("@OldAddress", textBox2.Text);
                                        cmd.Parameters.AddWithValue("@OldPhoneNo", textBox3.Text);

                                        cmd.Parameters.AddWithValue("@NewName", textBox1.Text);
                                        cmd.Parameters.AddWithValue("@NewEmail", textBox4.Text);
                                        cmd.Parameters.AddWithValue("@NewAddress", textBox2.Text);
                                        cmd.Parameters.AddWithValue("@NewPhoneNo", textBox3.Text);
                                        cmd.Parameters.AddWithValue("@LoggedID", UsersDL.GetLoggedId());
                                        int PersonAuditId = (int)cmd.ExecuteNonQuery();

                                        // add data into the manufacture table 
                                        cmd = new SqlCommand("insert into Manufacturer values (@CreatedAt , @UpdatedAt , @Active,(Select Max(ID) from Person) )", con);
                                        cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                                        cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                        cmd.Parameters.AddWithValue("@Active", "Active");
                                        cmd.ExecuteNonQuery();

                                        // add data into the manufacture audit
                                        cmd = new SqlCommand("insert into ManufacturerAudit values ((select MAX(ID) From Manufacturer), @CreatedAt , @UpdatedAt , @Active  )", con);
                                        cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                                        cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                        cmd.Parameters.AddWithValue("@Active", "Active");
                                        int MIDAudit = (int)cmd.ExecuteNonQuery();

                                        SqlCommand cmd1;
                                        cmd1 = new SqlCommand("Select MAX(ID) from Manufacturer", con);
                                        int MID = (int)cmd1.ExecuteScalar();

                                        SqlCommand cmd2;
                                        cmd2 = new SqlCommand("Select MAX(ID) from Person", con);
                                        int PersonId = (int)cmd2.ExecuteScalar();
                                        obj = new Manufacturer(DateTime.Now, DateTime.Now, "Active", MID, PersonId, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, UsersDL.GetLoggedUser());
                                        ManufacturerDL.addIntoList(obj);
                                        MessageBox.Show("saved ");

                                    }
                                    else
                                    {
                                        MessageBox.Show("email already exists");
                                    }

                                }
                                else
                                {
                                    MessageBox.Show(" Two Manufacturere cannot be on same address  ");
                                }
                            }
                            else
                            {
                                MessageBox.Show(" Manufacturere Already Exist ");
                            }
                        }
                        else
                        {
                            MessageBox.Show("phone no must be in length 11");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email must be in valid format  ");
                    }



                }
                else
                {
                    MessageBox.Show(" Must Fill All The Enteries ");
                }
            }
            catch(Exception exp)
            {
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", "error in the insert function");
                cmd.Parameters.AddWithValue("@LogClass", "Manufacturer");
                cmd.Parameters.AddWithValue("@LogFunction", "Add_Manufacturer");
                cmd.ExecuteNonQuery();
            }
           
        }
      
        private void iconButton1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            var con = Configuration.getInstance().getConnection();
           try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("CreatedAt");
                dt.Columns.Add("UpdatedAt");
                dt.Columns.Add("Active");
                dt.Columns.Add("ID");
                dt.Columns.Add("name");
                dt.Columns.Add("address");
                dt.Columns.Add("PhoneNo");
                dt.Columns.Add("Email");
                dt.Columns.Add("LoggedUser");
                foreach (Manufacturer o in ManufacturerDL.GetManufacturerList())
                {
                    dt.Rows.Add(o.GetCreateAt(), o.GetUpdatedAt(), o.GetStatus(), o.GetID(), o.GetUsername(), o.GetAddress(), o.GetPhoneNo(), o.GetEmail(), o.GetUserLogg());
                }
                dataGridView1.Refresh();
                dataGridView1.DataSource = dt;
            }
            catch(Exception exp)
            {
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", "error in the show function");
                cmd.Parameters.AddWithValue("@LogClass", "Manufacturer");
                cmd.Parameters.AddWithValue("@LogFunction", "show_Manufacturer");
                cmd.ExecuteNonQuery();
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            var con = Configuration.getInstance().getConnection();
            int PersonId =-1;
            int ManufactureId = -1;
            DateTime CreateAt = DateTime.Now;
            string   email = " ", address = " " , phoneNo = " " ;
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    if (ManufacturerDL.isValid(textBox4.Text))
                    {
                        if (textBox3.Text.Length == 11)
                        {
                            if (ManufacturerDL.isExistAddress(textBox2.Text, textBox1.Text))
                            {
                                if (ManufacturerDL.isExistEmail(textBox4.Text, textBox1.Text))
                                {
                                    foreach (Manufacturer o in ManufacturerDL.GetManufacturerList())
                                    {
                                        if (textBox1.Text == o.GetUsername())
                                        {
                                            ManufactureId = o.GetID();
                                            CreateAt = o.GetCreateAt();
                                            PersonId = o.GetPersonId();
                                            email = o.GetEmail();
                                            address = o.GetAddress();
                                            phoneNo = o.GetPhoneNo();
                                            o.SetAddress(textBox2.Text);
                                            o.SetPhoneNo(textBox3.Text);
                                            o.SetEmail(textBox4.Text);
                                            o.SetUpdatedAt(DateTime.Now);
                                            o.SetUserLogg(UsersDL.GetLoggedUser());

                                        }
                                    }
                                    // updated in person table 
                                    cmd = new SqlCommand("UPDATE Person set UpdatedAt = @UpdatedAt  ,Email = @Email, Address= @Address,PhoneNo= @PhoneNo , LoggedID =@LoggedID where Name = @Name ", con);
                                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@Address", textBox2.Text);
                                    cmd.Parameters.AddWithValue("@PhoneNo", textBox3.Text);
                                    cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                                    cmd.Parameters.AddWithValue("@LoggedID", UsersDL.GetLoggedId());
                                    cmd.ExecuteNonQuery();
                                    // updated in manufacturer table 
                                    cmd = new SqlCommand("UPDATE Manufacturer set  UpdatedAt = @UpdatedAt where PersonID = @PersonID  ",con);
                                    cmd.Parameters.AddWithValue("@PersonID", PersonId);
                                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                    cmd.ExecuteNonQuery();
                                    // insert in manufacturer audit  Table Query 
                                    cmd = new SqlCommand("insert into ManufacturerAudit values (@ManufactureId, @CreatedAt , @UpdatedAt , @Active )", con);
                                    cmd.Parameters.AddWithValue("@ManufactureId", ManufactureId);
                                    cmd.Parameters.AddWithValue("@CreatedAt", CreateAt);
                                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@Active", "Active");
                                    int PatientAuditId = (int)cmd.ExecuteNonQuery();

                                    // insert in PersonAudit Table Query  
                                    cmd = new SqlCommand("insert into PersonAudit values (@CreatedAt , @UpdatedAt , @Active , @PersonId, @OldName ,@OldEmail , @OldAddress , @OldPhoneNo, @NewName ,@NewEmail , @NewAddress , @NewPhoneNo ,@LoggedID)", con);
                                    cmd.Parameters.AddWithValue("@CreatedAt", CreateAt);
                                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                    cmd.Parameters.AddWithValue("@Active", "Active");

                                    cmd.Parameters.AddWithValue("@OldName", textBox1.Text);
                                    cmd.Parameters.AddWithValue("@OldEmail", email);
                                    cmd.Parameters.AddWithValue("@OldAddress", address);
                                    cmd.Parameters.AddWithValue("@OldPhoneNo", phoneNo);

                                    cmd.Parameters.AddWithValue("@PersonId", PersonId);
                                    cmd.Parameters.AddWithValue("@NewName", textBox1.Text);
                                    cmd.Parameters.AddWithValue("@NewEmail", textBox4.Text);
                                    cmd.Parameters.AddWithValue("@NewAddress", textBox2.Text);
                                    cmd.Parameters.AddWithValue("@NewPhoneNo", textBox3.Text);
                                    cmd.Parameters.AddWithValue("@LoggedID", UsersDL.GetLoggedId());
                                    int PersonAuditId = (int)cmd.ExecuteNonQuery();
                                    MessageBox.Show("updated");

                                }
                                else
                                {
                                    MessageBox.Show(" Email already exists ");
                                }

                            }
                            else
                            {
                                MessageBox.Show(" Two Manufacturere cannot be on same address  ");
                            }
                        }
                        else
                        {
                            MessageBox.Show("phone no must be in length 11");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email must be in valid format  ");

                    }


                }
                else
                {
                    MessageBox.Show(" Must Fill All The Enteries ");
                }
            }
            catch(Exception exp)
            {
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", "error in the update function");
                cmd.Parameters.AddWithValue("@LogClass", "Manufacturer");
                cmd.Parameters.AddWithValue("@LogFunction", "Update_Manufacturer");
                cmd.ExecuteNonQuery();
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
                        textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                        textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["address"].Value.ToString();
                        textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["PhoneNo"].Value.ToString();
                        textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
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
                        string name = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                        string address = dataGridView1.Rows[e.RowIndex].Cells["address"].Value.ToString();
                        string phoneNo = dataGridView1.Rows[e.RowIndex].Cells["PhoneNo"].Value.ToString();
                        string email = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();

                        DateTime CreateAt = DateTime.Now;
                        string oldemail = " ", oldaddress = " ", oldphoneno = " ";
                        int PersonId = -1;
                        int ManufactureId = -1;
                        foreach (Manufacturer o in ManufacturerDL.GetManufacturerList())
                        {
                            if (o.GetUsername() == name )
                            {
                                oldemail = o.GetEmail();
                                oldphoneno = o.GetPhoneNo();
                                oldaddress = o.GetAddress();
                                PersonId = o.GetPersonId();
                                ManufactureId = o.GetID();
                                CreateAt = o.GetCreateAt();
                                o.SetAddress(textBox2.Text);
                                o.SetPhoneNo(textBox3.Text);
                                o.SetEmail(textBox4.Text);
                                o.SetStatus(Status);
                                o.SetUserLogg(UsersDL.GetLoggedUser());
                                o.SetUpdatedAt(DateTime.Now);


                            }
                        }



                        // update in person table 
                        cmd = new SqlCommand("UPDATE Person set UpdatedAt = @UpdatedAt, Active = @Active ,  LoggedID =@LoggedID where   ID = @ID ", con);
                        cmd.Parameters.AddWithValue("@ID", PersonId);

                        cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Active", Status);
                        cmd.Parameters.AddWithValue("@LoggedID", UsersDL.GetLoggedId());
                        cmd.ExecuteNonQuery();


                        // update in Manufacture Table
                        cmd = new SqlCommand("UPDATE Manufacturer set  UpdatedAt = @UpdatedAt , Active = @Active   where PersonID = @PersonID  ",con);
                        cmd.Parameters.AddWithValue("@PersonID", PersonId);
                        cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Active", Status);
                        cmd.ExecuteNonQuery();



                    // Manufacturre Audit Table Query insert 
                    cmd = new SqlCommand("insert into ManufacturerAudit values (@ManufactureId , @CreatedAt , @UpdatedAt , @Active )", con);
                        cmd.Parameters.AddWithValue("@ManufactureId", ManufactureId);
                        cmd.Parameters.AddWithValue("@CreatedAt", CreateAt);
                        cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Active", Status);
                        int PatientAuditId = (int)cmd.ExecuteNonQuery();

                    // PersonAudit Table Query  insert
                    cmd = new SqlCommand("insert into PersonAudit values (@CreatedAt , @UpdatedAt , @Active , @PersonId, @OldName ,@OldEmail , @OldAddress , @OldPhoneNo, @NewName ,@NewEmail , @NewAddress , @NewPhoneNo ,@LoggedID)", con);
                        cmd.Parameters.AddWithValue("@CreatedAt", CreateAt);
                        cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Active", Status);

                        cmd.Parameters.AddWithValue("@OldName", name);
                        cmd.Parameters.AddWithValue("@OldEmail", oldemail);
                        cmd.Parameters.AddWithValue("@OldAddress", oldaddress);
                        cmd.Parameters.AddWithValue("@OldPhoneNo", oldphoneno);

                        cmd.Parameters.AddWithValue("@PersonId", PersonId);
                        cmd.Parameters.AddWithValue("@NewName", name);
                        cmd.Parameters.AddWithValue("@NewEmail", email);
                        cmd.Parameters.AddWithValue("@NewAddress", address);
                        cmd.Parameters.AddWithValue("@NewPhoneNo", phoneNo);
                        cmd.Parameters.AddWithValue("@LoggedID", UsersDL.GetLoggedId());
                        int PersonAuditId = (int)cmd.ExecuteNonQuery();
                    MessageBox.Show("Changed Status");
                }
                }
            }
            catch(Exception exp)
            {
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", "error in the status update function");
                cmd.Parameters.AddWithValue("@LogClass", "Manufacturer");
                cmd.Parameters.AddWithValue("@LogFunction", "Grid_Update_Manufacturer");
                cmd.ExecuteNonQuery();
            }
        }
    }
}
