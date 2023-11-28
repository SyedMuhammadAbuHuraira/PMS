using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyManagementSystem.Forms
{
    public partial class AuditTables : Form
    {
        public AuditTables()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd4;
           // try
            //{


                if (comboBox1.Text != "Patient-Audit" || comboBox1.Text != "User-Audit" || comboBox1.Text != "Manufacture-Audit" || comboBox1.Text != "Supplier-Audit" || comboBox1.Text != "Person-Audit")
                {
                    if (comboBox1.SelectedIndex == 0)
                    {

                        cmd4 = new SqlCommand("Select * From PatientAudit ", con);
                        using (SqlDataReader reader = cmd4.ExecuteReader())
                        {
                            // Check if the reader has rows
                            if (reader.HasRows)
                            {
                                // Create a DataTable to store the data
                                DataTable dataTable = new DataTable();
                                dataTable.Load(reader);

                                // Bind the DataTable to your grid
                                dataGridView1.DataSource = dataTable;
                                dataGridView1.Columns[1].ReadOnly = true;
                                dataGridView1.Columns[2].ReadOnly = true;
                                dataGridView1.Columns[3].ReadOnly = true;
                                dataGridView1.Columns[4].ReadOnly = true;
                                dataGridView1.Columns[5].ReadOnly = true;
                                dataGridView1.Columns[6].ReadOnly = true;
                               // dataGridView1.Columns[7].ReadOnly = true;

                            }
                        }
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {

                        cmd4 = new SqlCommand("Select * From SupplierAudit ", con);
                        using (SqlDataReader reader = cmd4.ExecuteReader())
                        {
                            // Check if the reader has rows
                            if (reader.HasRows)
                            {
                                // Create a DataTable to store the data
                                DataTable dataTable = new DataTable();
                                dataTable.Load(reader);

                                // Bind the DataTable to your grid
                                dataGridView1.DataSource = dataTable;
                                dataGridView1.Columns[1].ReadOnly = true;
                                dataGridView1.Columns[2].ReadOnly = true;
                                dataGridView1.Columns[3].ReadOnly = true;
                                dataGridView1.Columns[4].ReadOnly = true;
                                //dataGridView1.Columns[5].ReadOnly = true;

                            }
                        }
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {

                        cmd4 = new SqlCommand("Select * From ManufacturerAudit ", con);
                        using (SqlDataReader reader = cmd4.ExecuteReader())
                        {
                            // Check if the reader has rows
                            if (reader.HasRows)
                            {
                                // Create a DataTable to store the data
                                DataTable dataTable = new DataTable();
                                dataTable.Load(reader);

                                // Bind the DataTable to your grid
                                dataGridView1.DataSource = dataTable;
                                dataGridView1.Columns[1].ReadOnly = true;
                                dataGridView1.Columns[2].ReadOnly = true;
                                dataGridView1.Columns[3].ReadOnly = true;
                                dataGridView1.Columns[4].ReadOnly = true;
                                //dataGridView1.Columns[5].ReadOnly = true;

                            }
                        }
                    }
                    else if (comboBox1.SelectedIndex == 3)
                    {

                        cmd4 = new SqlCommand("Select * From UsersAudit ", con);
                        using (SqlDataReader reader = cmd4.ExecuteReader())
                        {
                            // Check if the reader has rows
                            if (reader.HasRows)
                            {
                                // Create a DataTable to store the data
                                DataTable dataTable = new DataTable();
                                dataTable.Load(reader);

                                // Bind the DataTable to your grid
                                dataGridView1.DataSource = dataTable;
                                dataGridView1.Columns[1].ReadOnly = true;
                                dataGridView1.Columns[2].ReadOnly = true;
                                dataGridView1.Columns[3].ReadOnly = true;
                                dataGridView1.Columns[4].ReadOnly = true;
                                dataGridView1.Columns[5].ReadOnly = true;
                                dataGridView1.Columns[6].ReadOnly = true;
                                dataGridView1.Columns[7].ReadOnly = true;
                                dataGridView1.Columns[8].ReadOnly = true;
                                dataGridView1.Columns[9].ReadOnly = true;
                                dataGridView1.Columns[10].ReadOnly = true;
                                //dataGridView1.Columns[11].ReadOnly = true;

                            }
                        }
                    }
                    else if (comboBox1.SelectedIndex == 4)
                    {

                        cmd4 = new SqlCommand("Select * From PersonAudit ", con);
                        using (SqlDataReader reader = cmd4.ExecuteReader())
                        {
                            // Check if the reader has rows
                            if (reader.HasRows)
                            {
                                // Create a DataTable to store the data
                                DataTable dataTable = new DataTable();
                                dataTable.Load(reader);

                                // Bind the DataTable to your grid
                                dataGridView1.DataSource = dataTable;
                                dataGridView1.Columns[1].ReadOnly = true;
                                dataGridView1.Columns[2].ReadOnly = true;
                                dataGridView1.Columns[3].ReadOnly = true;
                                dataGridView1.Columns[4].ReadOnly = true;
                                dataGridView1.Columns[5].ReadOnly = true;
                                dataGridView1.Columns[6].ReadOnly = true;
                                dataGridView1.Columns[7].ReadOnly = true;
                                dataGridView1.Columns[8].ReadOnly = true;
                                dataGridView1.Columns[9].ReadOnly = true;
                                dataGridView1.Columns[10].ReadOnly = true;
                                dataGridView1.Columns[11].ReadOnly = true;
                                dataGridView1.Columns[12].ReadOnly = true;
                                dataGridView1.Columns[13].ReadOnly = true;
                               // dataGridView1.Columns[14].ReadOnly = true;

                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select the Correct One");
                    return;
                }
           /* }
            catch(Exception exp)
            {
                cmd4 = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd4.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd4.Parameters.AddWithValue("@LogTitle", exp.Message);
                cmd4.Parameters.AddWithValue("@LogClass", "AuditTables");
                cmd4.Parameters.AddWithValue("@LogFunction", "SearchButton");
                cmd4.ExecuteNonQuery();
            }*/
          
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd4;
           // try
            //{



                        cmd4 = new SqlCommand("Select * From LOGS ", con);
                        using (SqlDataReader reader = cmd4.ExecuteReader())
                        {
                            // Check if the reader has rows
                            if (reader.HasRows)
                            {
                                // Create a DataTable to store the data
                                DataTable dataTable = new DataTable();
                                dataTable.Load(reader);

                                // Bind the DataTable to your grid
                                dataGridView1.DataSource = dataTable;
                                dataGridView1.Columns[1].ReadOnly = true;
                                dataGridView1.Columns[2].ReadOnly = true;
                                dataGridView1.Columns[3].ReadOnly = true;
                                dataGridView1.Columns[4].ReadOnly = true;
                              //  dataGridView1.Columns[5].ReadOnly = true;
                               

                            }
                        }
                    
                   
                    
                   
          /*  }
            catch (Exception exp)
            {
                cmd4 = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd4.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd4.Parameters.AddWithValue("@LogTitle", exp.Message);
                cmd4.Parameters.AddWithValue("@LogClass", "AuditTables");
                cmd4.Parameters.AddWithValue("@LogFunction", "Show LOGS Button");
                cmd4.ExecuteNonQuery();
            }*/
        }
    }
}
