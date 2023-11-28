using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PharmacyManagementSystem.DL;
using PharmacyManagementSystem.BL;
using System.Globalization;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;

namespace PharmacyManagementSystem.Forms
{
    public partial class AddStock : Form
    {
        public AddStock()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

   
        private void AddStock_Load(object sender, EventArgs e)
        {
            AdditemforstockDL.addstock.Clear();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Count(*) From Stock ", con);
            int count = (int)cmd.ExecuteScalar();
            if(count > 0 )
            {
                SqlCommand cmd1 = new SqlCommand("Select MAX(StockID) From Stock", con);
                int max = (int)cmd1.ExecuteScalar();
                max = max + 1;
                textBox1.Text = max.ToString();

            }
            else
            {
                textBox1.Text = 1000.ToString();
            }
            SqlDataReader reader;
            cmd = new SqlCommand("SELECT p.Name  from  Person as p join Supplier as s on s.PersonID = p.ID   ", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader["Name"]);
            }
            reader.Close();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ReadOnly= true;
            try
            {


                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                // Clear the grid before fetching new data
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 144, 255); // Set the selection color to a light blue shade

                string name = textBox2.Text;
                var con = Configuration.getInstance().getConnection();
                //SqlCommand cmd = new SqlCommand("SELECT Company, Type, Name, ConversionalUnit AS Quantity, RetailPrice / CAST(ConversionalUnit AS decimal(10,2)) AS Price FROM Products WHERE Name LIKE '%' + @name + '%'", con);
                SqlCommand cmd = new SqlCommand("SELECT Products.CreatedAt,Products.UpdatedAt,Products.Active,Products.ProductID,Products.Company, Products.Type, Products.Name, Products.ConversionalUnit AS PackQuantity, Products.RetailPrice / CAST(Products.ConversionalUnit AS decimal(10,2)) AS Price, Stock.BatchNo ,Stock.Quantity FROM Products INNER JOIN Stock ON Products.ProductID = Stock.ProductID WHERE Products.Name LIKE '%' + @name + '%'", con);
                // SqlCommand cmd = new SqlCommand("SELECT Products.Company, Products.Type, Products.Name, Products.ConversionalUnit AS Quantity, Products.RetailPrice / CAST(Products.ConversionalUnit AS decimal(10,2)) AS Price, Stock.BatchNo FROM Products INNER JOIN Stock ON Products.ProductID = Stock.ProductID WHERE Products.Name LIKE '%' + @name + '%'", con);

                cmd.Parameters.AddWithValue("@name", name);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                dataGridView1.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.AllowUserToOrderColumns = false;
                    dataGridView1.AllowUserToResizeRows = false;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.MultiSelect = false;
                    dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 53, 73);
                    dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
                    dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(237, 243, 255);
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 53, 73);
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);

                    DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                    editButton.HeaderText = "Add";
                    editButton.Text = "Add";
                    editButton.UseColumnTextForButtonValue = true;
                    editButton.DefaultCellStyle.BackColor = Color.FromArgb(72, 123, 237);
                    editButton.DefaultCellStyle.ForeColor = Color.White;
                    editButton.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    dataGridView1.Columns.Add(editButton);
                    dataGridView1.CellClick += dataGridView1_CellClick;
                    dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
                }
                else
                {
                    MessageBox.Show("Student not found!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Fill the grid with data
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", "error in the generic textbox ");
                cmd.Parameters.AddWithValue("@LogClass", "AddStock");
                cmd.Parameters.AddWithValue("@LogFunction", "GenericName");
                cmd.ExecuteNonQuery();
            }
        }

        private void Pharmacy_Click(object sender, EventArgs e)
        {
            Form frm = new Add_product_in_stock();
            frm.ShowDialog();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();

                DataTable dt = new DataTable();
                dt.Columns.Add("CreatedAt");
                dt.Columns.Add("UpdatedAt");
                dt.Columns.Add("Active");
                dt.Columns.Add("productID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Company");
                dt.Columns.Add("Supplier");
                dt.Columns.Add("Type");
                dt.Columns.Add("Cost Price");
                dt.Columns.Add("Retail Price");
                dt.Columns.Add("Margin");
                dt.Columns.Add("Batch ID");
                dt.Columns.Add("Conversionable Unit");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("Expiry Date");
                dt.Columns.Add("Sub Total");

                foreach (Additemforstock item in AdditemforstockDL.addstock)
                {
                    if (item != null)
                    {
                        dt.Rows.Add(item.CreatedAt,item.UpdatedAt,item.Active, item.productID, item.name, item.Company, item.Supplier, item.type, item.Costprice, item.Retailprice, item.Margin, item.batchID, item.Conversionableunit, item.Quantity, item.Expiry_Date, item.Sub_total);
                    }
                }

                if (dt.Rows.Count == 1)
                {
                    dataGridView1.DataSource = dt;
                }
                else if (dt.Rows.Count > 1)
                {
                    DateTimePicker dateTimePicker = new DateTimePicker();
                    dateTimePicker.Format = DateTimePickerFormat.Short;
                    dateTimePicker.Value = new DateTime(2000, 1, 1);

                    dataGridView1.DataSource = dt;

                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.ReadOnly = true;
                    }
                    dataGridView1.Columns["CreatedAt"].ReadOnly = false;
                    dataGridView1.Columns["UpdatedAt"].ReadOnly = false;
                    dataGridView1.Columns["Active"].ReadOnly = false;
                    dataGridView1.Columns["productID"].ReadOnly = false;
                    dataGridView1.Columns["Name"].ReadOnly = false;
                    dataGridView1.Columns["Company"].ReadOnly = false;
                    dataGridView1.Columns["Supplier"].ReadOnly = false;
                    dataGridView1.Columns["Type"].ReadOnly = false;
                    dataGridView1.Columns["Cost Price"].ReadOnly = false;
                    dataGridView1.Columns["Retail Price"].ReadOnly = false;
                    dataGridView1.Columns["Margin"].ReadOnly = false;
                    dataGridView1.Columns["Quantity"].ReadOnly = false;

                    dataGridView1.Columns["Expiry Date"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dataGridView1.Columns["Expiry Date"].DefaultCellStyle.NullValue = dateTimePicker.Value.ToString("dd/MM/yyyy");

                    dataGridView1.Columns["Sub Total"].DefaultCellStyle.Format = "N2";
                    dataGridView1.Columns["Sub Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle","error in the Load Button");
                cmd.Parameters.AddWithValue("@LogClass", "AddStock");
                cmd.Parameters.AddWithValue("@LogFunction", "LoadData");
                cmd.ExecuteNonQuery();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }
       
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 8)
                {
                    var con = Configuration.getInstance().getConnection();
                    float costprice = float.Parse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    int productid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    float retailprice = float.Parse(dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString());
                    if (costprice > retailprice)
                    {
                        MessageBox.Show("Cost Price must be less than retail price");
                        SqlCommand cmd3 = new SqlCommand("Select CostPrice From Products Where ProductID = @ProductIDs", con);
                        cmd3.Parameters.AddWithValue("@ProductIDs", productid);
                        dataGridView1.Rows[e.RowIndex].Cells[8].Value = cmd3.ExecuteScalar();
                    }
                    if (costprice <= 0)
                    {
                        MessageBox.Show("Cost Price must be Greater than zero");
                        SqlCommand cmd3 = new SqlCommand("Select CostPrice From Products Where ProductID = @ProductIDs", con);
                        cmd3.Parameters.AddWithValue("@ProductIDs", productid);
                        dataGridView1.Rows[e.RowIndex].Cells[8].Value = cmd3.ExecuteScalar();
                    }
                    if (costprice < retailprice && costprice > 0)
                    {
                        float result = ((retailprice - costprice) / retailprice) * 100;
                        dataGridView1.Rows[e.RowIndex].Cells[10].Value = result.ToString();
                        int quantity = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString());
                        float subtotal = quantity * costprice;
                        dataGridView1.Rows[e.RowIndex].Cells[15].Value = subtotal.ToString();
                        float total = 0;
                        int rowcount = dataGridView1.RowCount;
                        for (int x = 0; x < rowcount - 1; x++)
                        {
                            total = total + float.Parse(dataGridView1.Rows[x].Cells[15].Value.ToString()); ;
                        }
                        textBox9.Text = total.ToString();

                    }

                }
                if (e.ColumnIndex == 9)
                {
                    var con = Configuration.getInstance().getConnection();
                    float retailprice = float.Parse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    int productid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    float costprice = float.Parse(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
                    if (retailprice < costprice)
                    {
                        MessageBox.Show("Retail Price must be Greater than Cost price");
                        SqlCommand cmd3 = new SqlCommand("Select RetailPrice From Products Where ProductID = @ProductIDs", con);
                        cmd3.Parameters.AddWithValue("@ProductIDs", productid);
                        dataGridView1.Rows[e.RowIndex].Cells[9].Value = cmd3.ExecuteScalar();
                    }
                    if (retailprice <= 0)
                    {
                        MessageBox.Show("Retail Price must be Greater than zero");
                        SqlCommand cmd3 = new SqlCommand("Select RetailPrice  From Products Where ProductID = @ProductIDs", con);
                        cmd3.Parameters.AddWithValue("@ProductIDs", productid);
                        dataGridView1.Rows[e.RowIndex].Cells[9].Value = cmd3.ExecuteScalar();
                    }
                    if (retailprice > costprice && retailprice > 0)
                    {
                        float result = ((retailprice - costprice) / retailprice) * 100;
                        dataGridView1.Rows[e.RowIndex].Cells[10].Value = result.ToString();
                        float total1 = 0;
                        int rowcount = dataGridView1.RowCount;
                        for (int x = 0; x < rowcount - 1; x++)
                        {
                            total1 = total1 + ((float.Parse(dataGridView1.Rows[x].Cells[9].Value.ToString())) * (float.Parse(dataGridView1.Rows[x].Cells[13].Value.ToString()))); ;
                        }
                        textBox8.Text = total1.ToString();

                    }
                }

                if (e.ColumnIndex == 13)
                {

                    int quantity = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString());
                    if (quantity > 0)
                    {
                        float costprice1 = float.Parse(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
                        int quantity2 = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString());
                        float subtotal = quantity2 * costprice1;
                        dataGridView1.Rows[e.RowIndex].Cells[15].Value = subtotal.ToString();

                        float total = 0;
                        int rowcount = dataGridView1.RowCount;
                        for (int x = 0; x < rowcount - 1; x++)
                        {
                            total = total + (float.Parse(dataGridView1.Rows[x].Cells[15].Value.ToString())); ;
                        }
                        textBox9.Text = total.ToString();
                        float total3 = 0;
                        int rowcount1 = dataGridView1.RowCount;
                        for (int x = 0; x < rowcount1 - 1; x++)
                        {
                            total3 = total3 + ((float.Parse(dataGridView1.Rows[x].Cells[9].Value.ToString())) * (float.Parse(dataGridView1.Rows[x].Cells[13].Value.ToString()))); ;
                        }
                        textBox8.Text = total3.ToString();
                        int totalquantity = 0;
                        for (int x = 0; x < rowcount - 1; x++)
                        {
                            totalquantity = totalquantity + int.Parse(dataGridView1.Rows[x].Cells[13].Value.ToString());
                        }
                        textBox4.Text = totalquantity.ToString();
                    }
                    if (quantity <= 0)
                    {

                        MessageBox.Show("Quantity must be greater than zero");
                        dataGridView1.Rows[e.RowIndex].Cells[13].Value = 1.ToString();

                    }

                }
              

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", "error in the data grid value changed ");
                cmd.Parameters.AddWithValue("@LogClass", "AddStock");
                cmd.Parameters.AddWithValue("@LogFunction", "DataGridView1CellValueChanged");
                cmd.ExecuteNonQuery();
            }
        }

        
       
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Expiry_Date"))
                {
                    // Set the cell style to custom
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle();

                    // Create a new DateTimePicker control
                    DateTimePicker dtp = new DateTimePicker();

                    // Set the value of the DateTimePicker control based on the value of the cell
                    if (e.Value != null && e.Value != DBNull.Value)
                    {
                        dtp.Value = Convert.ToDateTime(e.Value);
                    }

                    // Set the location and size of the DateTimePicker control
                    dtp.Location = dataGridView1.GetCellDisplayRectangle(11, e.RowIndex, true).Location;


                    // Attach the DateTimePicker control to the DataGridView cell




                    // Set the value of the cell to the value of the DateTimePicker control
                    e.Value = dtp.Value;
                }
            }
            catch(Exception exp)
            {
                MessageBox.Show("Please Enter the Expiry Date in Correct Format'mm/dd/yyyy'");
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle();
                DateTimePicker dtp1 = new DateTimePicker();
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtp1.Value;
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", "Expiry date format data cell changed");
                cmd.Parameters.AddWithValue("@LogClass", "AddStock");
                cmd.Parameters.AddWithValue("@LogFunction", "DataGridViewCellFormating");
                cmd.ExecuteNonQuery();
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                int count = 0;
                int rowcount = dataGridView1.RowCount;
                for (int x = 0; x < rowcount-1; x++)
                {
                    if (dataGridView1.Rows[x].Cells[11].Value.ToString() == "")
                    {
                        count++;
                    }
                }
                for (int x = 0; x < rowcount-1; x++)
                {
                    if (dataGridView1.Rows[x].Cells[14].Value != null)
                    {
                        DateTime expiryDate;
                        if (!DateTime.TryParse(dataGridView1.Rows[x].Cells[14].Value.ToString(), out expiryDate))
                        {
                            MessageBox.Show("Invalid expiry date format in row " + (x + 1));
                            return;
                        }
                    }
                }
                if (count > 0)
                {
                    MessageBox.Show("Batch Number is Missing");
                }
                if (count == 0)
                {
                    if (comboBox1.Text == "")
                    {
                        MessageBox.Show("Please Select The Supplier");
                    }
                    if (comboBox1.Text != "")
                    {
                        string supplier = comboBox1.Text;
                        SqlCommand cmd3 = new SqlCommand("Select p1.ID From Supplier P1 JOIN Person P2 ON p1.PersonID = p2.ID Where Name = @Name", con);
                        cmd3.Parameters.AddWithValue("@Name", supplier);
                        int supplierid = (int)cmd3.ExecuteScalar();
                        int stockid = int.Parse(textBox1.Text);
                        DateTime datestock = dateTimePicker1.Value;
                        SqlCommand cmd1 = new SqlCommand("SET IDENTITY_INSERT Stock ON;Insert into Stock(CreatedAt,UpdatedAt,Active ,StockID,SupplierID,Date,LoggedID) Values(@CreatedAt,@UpdatedAt,@Active ,@StockID,@SupplierID,@Date,@LoggedID);SET IDENTITY_INSERT Stock ON;", con);
                        cmd1.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                        cmd1.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd1.Parameters.AddWithValue("@Active", "Active");
                        cmd1.Parameters.AddWithValue("@StockID", stockid);
                        cmd1.Parameters.AddWithValue("@SupplierID", supplierid);
                        cmd1.Parameters.AddWithValue("@Date", datestock);
                        cmd1.Parameters.AddWithValue("@LoggedID", 1);
                        cmd1.ExecuteNonQuery();
                        for (int x = 0; x < rowcount - 1; x++)
                        {
                            if (dataGridView1.Rows[x].Cells.Count > 0)
                            {
                                int ProductID = int.Parse(dataGridView1.Rows[x].Cells[3].Value.ToString());
                                float CostPrice = float.Parse(dataGridView1.Rows[x].Cells[8].Value.ToString());
                                float RetailPrice = float.Parse(dataGridView1.Rows[x].Cells[9].Value.ToString());
                                float Margin = float.Parse(dataGridView1.Rows[x].Cells[10].Value.ToString());
                                string BatchNO = dataGridView1.Rows[x].Cells[11].Value.ToString();
                                int Quantity = int.Parse(dataGridView1.Rows[x].Cells[13].Value.ToString());
                                int conversionableunit = int.Parse(dataGridView1.Rows[x].Cells[12].Value.ToString());
                                DateTime ExpiryDate = DateTime.Parse(dataGridView1.Rows[x].Cells[14].Value.ToString()); // Fetch value from Grid column name "Expiry Date"

                                SqlCommand cmd = new SqlCommand("Update Products Set UpdatedAt= @UpdatedAt, CostPrice = @CostPrice, RetailPrice = @RetailPrice, Margin = @Margin Where ProductID = @ProductID", con);
                                cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                cmd.Parameters.AddWithValue("@CostPrice", CostPrice);
                                cmd.Parameters.AddWithValue("@RetailPrice", RetailPrice);
                                cmd.Parameters.AddWithValue("@Margin", Margin);
                                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                                cmd.ExecuteNonQuery();

                                SqlCommand cmd4 = new SqlCommand("Insert into StockItems (CreatedAt,UpdatedAt,Active,StockID, ProductID, BatchNO, ExpiredDate, Quantity, conversionableunit) Values(@CreatedAt,@UpdatedAt,@Active,@StockID, @ProductID, @BatchNO, @ExpiredDate, @Quantity, @conversionableunit)", con);
                                cmd4.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                                cmd4.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                cmd4.Parameters.AddWithValue("@Active", "Active");
                                cmd4.Parameters.AddWithValue("@StockID", stockid);
                                cmd4.Parameters.AddWithValue("@ProductID", ProductID);
                                cmd4.Parameters.AddWithValue("@BatchNO", BatchNO);
                                cmd4.Parameters.AddWithValue("@ExpiredDate", ExpiryDate); // Use the value fetched from the grid column
                                cmd4.Parameters.AddWithValue("@Quantity", Quantity);
                                cmd4.Parameters.AddWithValue("@conversionableunit", conversionableunit);
                                cmd4.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Stock Added Successfully");
                        AdditemforstockDL.addstock.Clear();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", "Save button error");
                cmd.Parameters.AddWithValue("@LogClass", "AddStock");
                cmd.Parameters.AddWithValue("@LogFunction", "SaveStocks");
                cmd.ExecuteNonQuery();
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
