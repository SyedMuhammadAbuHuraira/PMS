using FontAwesome.Sharp;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using PharmacyManagementSystem.BL;
using PharmacyManagementSystem.DL;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PharmacyManagementSystem.Forms
{
    public partial class Add_Patient : Form
    {
        public Add_Patient()
        {
            InitializeComponent();
        }

        private void Add_Patient_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Pharmacy_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            Patient obj;
            SqlCommand cmd;
            var con = Configuration.getInstance().getConnection();

           try
            {

                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                {
                    if (PatientDL.isExist(textBox2.Text, textBox1.Text))
                    {
                        if (PatientDL.isValid(textBox5.Text))
                        {
                            if (textBox4.Text.Length == 11)
                            {
                                if (PatientDL.isExistCNIC(textBox1.Text))
                                {
                                    if (textBox1.Text.Length == 13)
                                    {
                                        if (SupplierDL.isExistEmail(textBox5.Text))
                                        {

                                            // Person Table  Query insert

                                            cmd = new SqlCommand("insert into Person values (@CreatedAt , @UpdatedAt , @Active, @Name ,@Email , @Address , @PhoneNo ,@LoggedID)", con);
                                            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                                            cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                            cmd.Parameters.AddWithValue("@Active", "Active");
                                            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                                            cmd.Parameters.AddWithValue("@Email", textBox5.Text);
                                            cmd.Parameters.AddWithValue("@Address", textBox3.Text);
                                            cmd.Parameters.AddWithValue("@PhoneNo", textBox4.Text);
                                            cmd.Parameters.AddWithValue("@LoggedID", UsersDL.GetLoggedId());
                                            cmd.ExecuteNonQuery();
                                          //  MessageBox.Show(PersonId.ToString());

                                            // PersonAudit Table Query  insert
                                            cmd = new SqlCommand("insert into PersonAudit values (@CreatedAt , @UpdatedAt , @Active, (select MAX(ID) from Person ), @OldName ,@OldEmail , @OldAddress , @OldPhoneNo, @NewName ,@NewEmail , @NewAddress , @NewPhoneNo ,@LoggedID)", con);
                                            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                                            cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                            cmd.Parameters.AddWithValue("@Active", "Active");

                                            cmd.Parameters.AddWithValue("@OldName", textBox2.Text);
                                            cmd.Parameters.AddWithValue("@OldEmail", textBox5.Text);
                                            cmd.Parameters.AddWithValue("@OldAddress", textBox3.Text);
                                            cmd.Parameters.AddWithValue("@OldPhoneNo", textBox4.Text);

                                            cmd.Parameters.AddWithValue("@NewName", textBox2.Text);
                                            cmd.Parameters.AddWithValue("@NewEmail", textBox5.Text);
                                            cmd.Parameters.AddWithValue("@NewAddress", textBox3.Text);
                                            cmd.Parameters.AddWithValue("@NewPhoneNo", textBox4.Text);
                                            cmd.Parameters.AddWithValue("@LoggedID", UsersDL.GetLoggedId());
                                            int PersonAuditId = (int)cmd.ExecuteNonQuery();



                                            // Patient Table Query insert
                                            cmd = new SqlCommand("insert into Patient values (@CreatedAt , @UpdatedAt , @Active, @CNIC , (Select Max(ID) from Person) ,NULL)", con);
                                            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                                            cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                            cmd.Parameters.AddWithValue("@Active", "Active");
                                            cmd.Parameters.AddWithValue("@CNIC", textBox1.Text);
                                            cmd.ExecuteNonQuery();
                                           // MessageBox.Show(PID.ToString());

                                            // Patient Audit Table Query insert 
                                            cmd = new SqlCommand("insert into PatientAudit values ( (select MAX(ID) from Patient ) , @CreatedAt , @UpdatedAt , @Active , @CNIC ,NULL )", con);
                                            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                                            cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                            cmd.Parameters.AddWithValue("@Active", "Active");
                                            cmd.Parameters.AddWithValue("@CNIC", textBox1.Text);
                                            int PatientAuditId = (int)cmd.ExecuteNonQuery();

                                            SqlCommand cmd1;
                                            cmd1 = new SqlCommand("Select MAX(ID) from Patient", con);
                                            int PID = (int)cmd1.ExecuteScalar();

                                            SqlCommand cmd2;
                                            cmd2 = new SqlCommand("Select MAX(ID) from Person", con);
                                            int PersonId = (int)cmd2.ExecuteScalar();

                                            obj = new Patient(DateTime.Now, DateTime.Now, "Active", PID, textBox1.Text, PersonId, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, UsersDL.GetLoggedUser());
                                            PatientDL.addIntoList(obj);
                                            MessageBox.Show("saved");

                                        }
                                        else
                                        {
                                            MessageBox.Show("email already exists");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("CNIC Length must be 13 in correct form");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(" Patient  Already Exist  with this CNIC ");
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
                        MessageBox.Show("Patient with same name and cnic already exist ");
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
                cmd.Parameters.AddWithValue("@LogTitle", "Error in add patient ");
                cmd.Parameters.AddWithValue("@LogClass", "Patient");
                cmd.Parameters.AddWithValue("@LogFunction", "Add_Patient");
                cmd.ExecuteNonQuery();
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Patient obj;
            SqlCommand cmd;
            DateTime CreateAt = DateTime.Now ;
            var con = Configuration.getInstance().getConnection();
            string email = " ", address = " ", phoneNo = " " , name ="" ,cnic ="" , status="";
            int logid = 0;
            try
            {
                
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                {
                    if (PatientDL.isValid(textBox5.Text))
                    {
                        if (textBox4.Text.Length == 11)
                        {
                            if (PatientDL.isExistEmail(textBox5.Text, textBox1.Text))
                            {
                                foreach (Patient o in PatientDL.GetPatientList())
                                {
                                    if (textBox1.Text == o.GetCNIC())
                                    {
                                       
                                        email = o.GetEmail();
                                        address = o.GetAddress();
                                        phoneNo = o.GetPhoneNo();
                                        name = o.GetUsername();
                                        logid = o.GetInvoiceId();
                                        cnic = o.GetCNIC();
                                        status = o.GetStatus();
                                        o.SetAddress(textBox3.Text);
                                        o.SetPhoneNo(textBox4.Text);
                                        o.SetEmail(textBox5.Text);
                                        o.SetUserLogg(UsersDL.GetLoggedUser());
                                        CreateAt = o.getCreateAt();
                                        o.SetUpdatedAt(DateTime.Now);
                                    }
                                }
                                int PersonId = -1;
                                int PatientId = -1;
                                foreach (Patient o in PatientDL.GetPatientList())
                                {
                                    if (o.GetUsername() == textBox2.Text && o.GetCNIC() == textBox1.Text)
                                    {
                                        PersonId = o.GetPersonId();
                                        PatientId = o.GetID();


                                    }
                                }


                                cmd = new SqlCommand("UPDATE Person set UpdatedAt = @UpdatedAt , Address= @Address,PhoneNo= @PhoneNo ,Email = @Email , LoggedID =@LoggedID where Name = @Name and ID = @ID ", con);
                                cmd.Parameters.AddWithValue("@ID", PersonId);

                                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                                cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Address", textBox3.Text);
                                cmd.Parameters.AddWithValue("@PhoneNo", textBox4.Text);
                                cmd.Parameters.AddWithValue("@Email", textBox5.Text);
                                cmd.Parameters.AddWithValue("@LoggedID", UsersDL.GetLoggedId());
                                cmd.ExecuteNonQuery();

                                cmd = new SqlCommand("UPDATE Patient set  UpdatedAt = @UpdatedAt , Active = @Active ,PersonId = @PersonId  where  CNIC = @CNIC ",con);
                                cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Active", status);
                                cmd.Parameters.AddWithValue("@PersonId", PersonId);
                                cmd.Parameters.AddWithValue("@CNIC", cnic);

                                int wd = (int)cmd.ExecuteNonQuery();



                                // Patient Audit Table Query insert 
                                cmd = new SqlCommand("insert into PatientAudit values (@PatientId,@CreatedAt , @UpdatedAt , @Active, @CNIC,NULL )", con);
                                cmd.Parameters.AddWithValue("@PatientId", PatientId);
                                cmd.Parameters.AddWithValue("@CreatedAt", CreateAt);
                                cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Active", "Active");
                                cmd.Parameters.AddWithValue("@CNIC", textBox1.Text);
                                int PatientAuditId = (int)cmd.ExecuteNonQuery();


                                // PersonAudit Table Query  insert
                                cmd = new SqlCommand("insert into PersonAudit values (@CreatedAt , @UpdatedAt , @Active , @PersonId, @OldName ,@OldEmail , @OldAddress , @OldPhoneNo, @NewName ,@NewEmail , @NewAddress , @NewPhoneNo ,@LoggedID)", con);
                                cmd.Parameters.AddWithValue("@CreatedAt", CreateAt);
                                cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                cmd.Parameters.AddWithValue("@Active", "Active");

                                cmd.Parameters.AddWithValue("@OldName", textBox2.Text);
                                cmd.Parameters.AddWithValue("@OldEmail", email);
                                cmd.Parameters.AddWithValue("@OldAddress", address);
                                cmd.Parameters.AddWithValue("@OldPhoneNo", phoneNo);

                                cmd.Parameters.AddWithValue("@PersonId", PersonId);
                                cmd.Parameters.AddWithValue("@NewName", textBox2.Text);
                                cmd.Parameters.AddWithValue("@NewEmail", textBox5.Text);
                                cmd.Parameters.AddWithValue("@NewAddress", textBox3.Text);
                                cmd.Parameters.AddWithValue("@NewPhoneNo", textBox4.Text);
                                cmd.Parameters.AddWithValue("@LoggedID", UsersDL.GetLoggedId());
                                int PersonAuditId = (int)cmd.ExecuteNonQuery();

                                MessageBox.Show("Updated");

                            }
                            else
                            {
                                MessageBox.Show(" Email already exists ");
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
            catch(Exception exp )
            {

                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", "error in the update function");
                cmd.Parameters.AddWithValue("@LogClass", "Patient");
                cmd.Parameters.AddWithValue("@LogFunction", "Update_Patient");
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
                dt.Columns.Add("CNIC");
                dt.Columns.Add("name");
                dt.Columns.Add("address");
                dt.Columns.Add("PhoneNo");
                dt.Columns.Add("Email");
                dt.Columns.Add("LoggedUser");
                foreach (Patient o in PatientDL.GetPatientList())
                {
                    dt.Rows.Add(o.getCreateAt(), o.GetUpdatedAt(), o.GetStatus(), o.GetID(), o.GetCNIC(), o.GetUsername(), o.GetAddress(), o.GetPhoneNo(), o.GetEmail(), o.GetUserLogg());
                }
                dataGridView1.Refresh();
                dataGridView1.DataSource = dt;
            }
            catch(Exception exp)
            {
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", "error in the show function");
                cmd.Parameters.AddWithValue("@LogClass", "Patient");
                cmd.Parameters.AddWithValue("@LogFunction", "Show_Patient");
                cmd.ExecuteNonQuery();
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

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
                        textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["CNIC"].Value.ToString();
                        textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                        textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["address"].Value.ToString();
                        textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["PhoneNo"].Value.ToString();
                        textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                        textBox1.ReadOnly = true;
                        textBox2.ReadOnly = true;

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
                        string cnic = dataGridView1.Rows[e.RowIndex].Cells["CNIC"].Value.ToString();
                        string name = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                        string address = dataGridView1.Rows[e.RowIndex].Cells["address"].Value.ToString();
                        string phoneNo = dataGridView1.Rows[e.RowIndex].Cells["PhoneNo"].Value.ToString();
                        string email = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();

                       
                        DateTime CreateAt = DateTime.Now;
                        string oldemail = " ", oldaddress = " ", oldphoneno = " ";
                        int PersonId = -1;
                        int PatientId = -1;
                        foreach (Patient o in PatientDL.GetPatientList())
                        {
                            if (o.GetUsername() == name && o.GetCNIC() == cnic)
                            {
                                oldemail = o.GetEmail();
                                oldphoneno = o.GetPhoneNo();
                                oldaddress = o.GetAddress();
                                PersonId = o.GetPersonId();
                                PatientId = o.GetID();
                                CreateAt = o.getCreateAt();
                                o.SetAddress(textBox3.Text);
                                o.SetPhoneNo(textBox4.Text);
                                o.SetEmail(textBox5.Text);
                                o.SetUserLogg(UsersDL.GetLoggedUser());
                                o.SetUpdatedAt(DateTime.Now);
                                o.SetStatus(Status);


                            }
                        }


                        

                        cmd = new SqlCommand("UPDATE Person set UpdatedAt = @UpdatedAt, Active = @Active ,  LoggedID =@LoggedID where Name = @Name and ID = @ID ", con);
                        cmd.Parameters.AddWithValue("@ID", PersonId);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Active", Status);
                        cmd.Parameters.AddWithValue("@LoggedID", UsersDL.GetLoggedId());
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("UPDATE Patient set  UpdatedAt = @UpdatedAt , Active = @Active   where PersonID = @PersonID  ",con);
                        cmd.Parameters.AddWithValue("@PersonID", PersonId);
                        cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Active", Status);
                        cmd.ExecuteNonQuery();



                        // Patient Audit Table Query insert 
                        cmd = new SqlCommand("insert into PatientAudit values (@PatientId , @CreatedAt , @UpdatedAt , @Active, @CNIC,NULL )", con);
                        cmd.Parameters.AddWithValue("@PatientId", PatientId);
                        cmd.Parameters.AddWithValue("@CreatedAt", CreateAt);
                        cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Active", Status);
                        cmd.Parameters.AddWithValue("@CNIC", cnic);
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

                        MessageBox.Show("Updated");



                    }
                }
            }
            catch(Exception exp)
            {
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", "Error in the status function");
                cmd.Parameters.AddWithValue("@LogClass", "Patient");
                cmd.Parameters.AddWithValue("@LogFunction", "GridView_Patient");
                cmd.ExecuteNonQuery();
            }
        }

    }
}
