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
using PharmacyManagementSystem.DL;
using PharmacyManagementSystem.BL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using FontAwesome.Sharp;

namespace PharmacyManagementSystem.Forms
{
    public partial class AddItem : Form
    {
        public static int ProductID = 0;
        public AddItem()
        {
              InitializeComponent();
            iconButton2.Visible = false;
           
            try
            {
                SqlCommand cmd;
                SqlDataReader reader;
                var con = Configuration.getInstance().getConnection();

                cmd = new SqlCommand("SELECT p.Name  from  Person as p join Manufacturer as m on m.PersonID = p.ID   ", con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBox2.Items.Add(reader["Name"]);
                }
                reader.Close();

                cmd = new SqlCommand("SELECT p.Name  from  Person as p join Supplier as s on s.PersonID = p.ID   ", con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["Name"]);
                }
                reader.Close();
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", "Supplier and manufacturrer error ");
                cmd.Parameters.AddWithValue("@LogClass", "ADD_Item");
                cmd.Parameters.AddWithValue("@LogFunction", "ADD_Item_Start_ManufactureOrSupplier" );
                cmd.ExecuteNonQuery();
            }
        }

        private void AddItem_Load(object sender, EventArgs e)
        {
            lblcategory.Visible = false;
            lblcostprice.Visible = false;
            lblmanufacturare.Visible = false;
            lblname.Visible = false;
            lblretailprice.Visible = false;
            lblsupplier.Visible = false;
        }

        private void txtretailprice_TextChanged(object sender, EventArgs e)
        {
            try
            {


                textBox4.Clear();
                if (txtretailprice.Text != "" && txtcostprice.Text != "" && textBox4.Text == "")
                {
                    float costprice = float.Parse(txtcostprice.Text);
                    float retailprice = float.Parse(txtretailprice.Text);
                    float result = ((retailprice - costprice) / retailprice) * 100;
                    textBox4.Text = result.ToString();
                }
           }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", "Text retail price changed error");
                cmd.Parameters.AddWithValue("@LogClass", "ADD_Item");
                cmd.Parameters.AddWithValue("@LogFunction", "ADD_Item_RetailPriceChanged");
                cmd.ExecuteNonQuery();

            }
        }

        private void Pharmacy_Click(object sender, EventArgs e)
        {
            try
            {


                lblname.Visible = false;
                lblcategory.Visible = false;
                lblcostprice.Visible = false;
                lblmanufacturare.Visible = false;
                lblretailprice.Visible = false;
                lblsupplier.Visible = false;
                if (textBox1.Text != "" && txtcostprice.Text != "" && txtretailprice.Text != "" && float.Parse(textBox4.Text) > 0 && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && checkBox1.Text != "")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Select Count(*) From Products Where Name = @name", con);
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Product already existed");
                    }
                    else
                    {
                        int narcotics;
                        if (checkBox1.Checked)
                        {
                            narcotics = 1;
                        }
                        else
                        {
                            narcotics = 0;
                        }
                        SqlCommand cmd1 = new SqlCommand("Insert into Products(CreatedAt , UpdatedAt , Active,Company,Supplier,Name,Type,CostPrice,RetailPrice,Margin,ConversionalUnit,Narcotic) values(@CreatedAt , @UpdatedAt , @Active,@Company,@Supplier,@Name,@Type,@CostPrice,@RetailPrice,@Margin,@ConversionalUnit,@Narcotic)", con);
                        cmd1.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                        cmd1.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd1.Parameters.AddWithValue("@Active", "Active");
                        cmd1.Parameters.AddWithValue("@Company", comboBox2.Text);
                        cmd1.Parameters.AddWithValue("@Supplier", comboBox1.Text);
                        cmd1.Parameters.AddWithValue("@Name", textBox1.Text);
                        cmd1.Parameters.AddWithValue("@Type", comboBox3.Text);
                        cmd1.Parameters.AddWithValue("@CostPrice", float.Parse(txtcostprice.Text));
                        cmd1.Parameters.AddWithValue("@RetailPrice", float.Parse(txtretailprice.Text));
                        cmd1.Parameters.AddWithValue("@Margin", float.Parse(textBox4.Text));
                        cmd1.Parameters.AddWithValue("@ConversionalUnit", int.Parse(numericUpDown1.Text));
                        cmd1.Parameters.AddWithValue("@Narcotic", narcotics);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Item Added Successfully");
                        textBox1.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        comboBox1.Items.Clear();
                        comboBox2.Items.Clear();
                        comboBox3.Items.Clear();
                        numericUpDown1.ResetText();
                        checkBox1.Refresh();
                        
                    }
                }
                if (textBox1.Text == "")
                {
                    lblname.Visible = true;

                }
                if (textBox4.Text != "")
                {
                    float margin = float.Parse(textBox4.Text);
                    if (margin <= 0)
                    {
                        MessageBox.Show("Reatil Price must be greater than Cost Price");
                    }
                }
                if (txtcostprice.Text == "")
                {
                    lblcostprice.Visible = true;
                }
                if (txtretailprice.Text == "")
                {
                    lblretailprice.Visible = true;
                }
                if (comboBox1.Text == "")
                {
                    lblsupplier.Visible = true;
                }
                if (comboBox3.Text == "")
                {
                    lblcategory.Visible = true;
                }
                if (comboBox2.Text == "")
                {
                    lblmanufacturare.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", "Insert function error in the Product ");
                cmd.Parameters.AddWithValue("@LogClass", "ADD_Item");
                cmd.Parameters.AddWithValue("@LogFunction", "ADD_Item_InsertFunction");
                cmd.ExecuteNonQuery();

            }


        }

        private void txtcostprice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtretailprice.Text != "" && txtcostprice.Text != "")
                {
                    float costprice = float.Parse(txtcostprice.Text);
                    float retailprice = float.Parse(txtretailprice.Text);
                    float result = ((retailprice - costprice) / retailprice) * 100;
                    textBox4.Text = result.ToString();
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", "Retail price text changed error");
                cmd.Parameters.AddWithValue("@LogClass", "ADD_Item");
                cmd.Parameters.AddWithValue("@LogFunction", "ADD_Item_CostPriceChanged");
                cmd.ExecuteNonQuery();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                SqlCommand cmd4 = new SqlCommand("Select * From Products ", con);
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
                    }
                }
            }

            catch (Exception ex)
            {
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                MessageBox.Show("An error occurred while adding the item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", "Error in the show product in grid ");
                cmd.Parameters.AddWithValue("@LogClass", "ADD_Item");
                cmd.Parameters.AddWithValue("@LogFunction", "ADD_Item_Show Item");
                cmd.ExecuteNonQuery();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string status = "";
            SqlCommand cmd1;
            var con = Configuration.getInstance().getConnection(); ;
            try
            {


                if (e.ColumnIndex == 0)
                {
                    ProductID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                    comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                    comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                    txtcostprice.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                    txtretailprice.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                    textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                    numericUpDown1.Value = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString());
                    int narcotic = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString());
                    if (narcotic == 1)
                    {
                        checkBox1.Checked = true;
                    }
                    if (narcotic == 0)
                    {
                        checkBox1.Checked = false;
                    }
                    iconButton2.Visible = true;
                    Pharmacy.Visible = false;

                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "STATUS")
                {
                    if (MessageBox.Show("Are You Sure You Want To Change the ststus of  This Record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int ProductID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                        status = dataGridView1.Rows[e.RowIndex].Cells["Active"].Value.ToString();
                        if (status == "Active")
                        {
                            status = "InActive";
                        }
                        else if (status == "InActive")
                        {
                            status = "Active";
                        }
                        cmd1 = new SqlCommand("Update Products SET UpdatedAt = @UpdatedAt, Active = @Active Where ProductID = @pdid", con);
                        cmd1.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd1.Parameters.AddWithValue("@pdid", ProductID);
                        cmd1.Parameters.AddWithValue("@Active", status);
                        cmd1.ExecuteScalar();
                        MessageBox.Show("Item Updated Successfully");

                    }
                }

           }
            catch (Exception ex)
            {
                SqlCommand cmd;
                MessageBox.Show("An error occurred while adding the item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", "Update Status");
                cmd.Parameters.AddWithValue("@LogClass", "ADD_Item");
                cmd.Parameters.AddWithValue("@LogFunction", "ADD_Item_GridProblem");
                cmd.ExecuteNonQuery();
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            try
            {


                if (ProductID != 0)
                {
                    lblname.Visible = false;
                    lblcategory.Visible = false;
                    lblcostprice.Visible = false;
                    lblmanufacturare.Visible = false;
                    lblretailprice.Visible = false;
                    lblsupplier.Visible = false;
                    if (textBox1.Text != "" && txtcostprice.Text != "" && txtretailprice.Text != "" && float.Parse(textBox4.Text) > 0 && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && checkBox1.Text != "")
                    {
                        var con = Configuration.getInstance().getConnection();
                        SqlCommand cmd = new SqlCommand("Select Count(*) From Products Where Name = @name AND ProductID != @Productid", con);
                        cmd.Parameters.AddWithValue("@Productid", ProductID);
                        cmd.Parameters.AddWithValue("@name", textBox1.Text);
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Product with Same Name already existed");
                        }
                        else
                        {
                            int narcotics;
                            if (checkBox1.Checked)
                            {
                                narcotics = 1;
                            }
                            else
                            {
                                narcotics = 0;
                            }
                            SqlCommand cmd1 = new SqlCommand("Update Products SET UpdatedAt = @UpdatedAt, Company = @Company,Supplier = @Supplier,Name = @Name,Type = @Type,CostPrice = @CostPrice,RetailPrice = @RetailPrice,Margin = @Margin,ConversionalUnit = @ConversionalUnit,Narcotic = @Narcotic Where ProductID = @pdid", con);
                            cmd1.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                            cmd1.Parameters.AddWithValue("@pdid", ProductID);
                            cmd1.Parameters.AddWithValue("@Company", comboBox2.Text);
                            cmd1.Parameters.AddWithValue("@Supplier", comboBox1.Text);
                            cmd1.Parameters.AddWithValue("@Name", textBox1.Text);
                            cmd1.Parameters.AddWithValue("@Type", comboBox3.Text);
                            cmd1.Parameters.AddWithValue("@CostPrice", float.Parse(txtcostprice.Text));
                            cmd1.Parameters.AddWithValue("@RetailPrice", float.Parse(txtretailprice.Text));
                            cmd1.Parameters.AddWithValue("@Margin", float.Parse(textBox4.Text));
                            cmd1.Parameters.AddWithValue("@ConversionalUnit", int.Parse(numericUpDown1.Text));
                            cmd1.Parameters.AddWithValue("@Narcotic", narcotics);
                            cmd1.ExecuteScalar();
                            MessageBox.Show("Item Updated Successfully");
                            textBox1.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            comboBox1.Items.Clear();
                            comboBox2.Items.Clear();
                            comboBox3.Items.Clear();
                            numericUpDown1.ResetText();
                            checkBox1.Refresh();
                            this.Close();
                        }
                    }
                    if (textBox1.Text == "")
                    {
                        lblname.Visible = true;

                    }
                    if (textBox4.Text != "")
                    {
                        float margin = float.Parse(textBox4.Text);
                        if (margin <= 0)
                        {
                            MessageBox.Show("Reatil Price must be greater than Cost Price");
                        }
                    }
                    if (txtcostprice.Text == "")
                    {
                        lblcostprice.Visible = true;
                    }
                    if (txtretailprice.Text == "")
                    {
                        lblretailprice.Visible = true;
                    }
                    if (comboBox1.Text == "")
                    {
                        lblsupplier.Visible = true;
                    }
                    if (comboBox3.Text == "")
                    {
                        lblcategory.Visible = true;
                    }
                    if (comboBox2.Text == "")
                    {
                        lblmanufacturare.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                MessageBox.Show("An error occurred while adding the item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle","Update function");
                cmd.Parameters.AddWithValue("@LogClass", "ADD_Item");
                cmd.Parameters.AddWithValue("@LogFunction", "ADD_Item_UpdateProblem");
                cmd.ExecuteNonQuery();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            numericUpDown1.ResetText();
            checkBox1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
