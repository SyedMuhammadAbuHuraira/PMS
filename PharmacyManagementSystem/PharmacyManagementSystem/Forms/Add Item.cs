using PharmacyManagementSystem.BL;
using PharmacyManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyManagementSystem.BL;
using PharmacyManagementSystem.DL;
using System.Windows.Forms;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;


namespace PharmacyManagementSystem.Forms
{
    public partial class Add_Item : Form
    {
        public Add_Item()
        {
            InitializeComponent();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                

                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                // Clear the grid before fetching new data
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 144, 255); // Set the selection color to a light blue shade
                
                string name = textBox10.Text;
                var con = Configuration.getInstance().getConnection();
                //SqlCommand cmd = new SqlCommand("SELECT Company, Type, Name, ConversionalUnit AS Quantity, RetailPrice / CAST(ConversionalUnit AS decimal(10,2)) AS Price FROM Products WHERE Name LIKE '%' + @name + '%'", con);
                SqlCommand cmd = new SqlCommand("SELECT StockItems.StockID, Products.ProductID,Products.Company, Products.Type, Products.Name, Products.ConversionalUnit AS PackQuantity, Products.RetailPrice / CAST(Products.ConversionalUnit AS decimal(6,4)) AS Price, StockItems.BatchNO ,StockItems.Quantity , StockItems.ExpiredDate  FROM Products INNER JOIN StockItems ON Products.ProductID = StockItems.ProductID WHERE Products.Name LIKE '%' + @name + '%'", con);
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

                   // dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                cmd.Parameters.AddWithValue("@LogTitle", ex.Message);
                cmd.Parameters.AddWithValue("@LogClass", "SaleReturn");
                cmd.Parameters.AddWithValue("@LogFunction", "GenericButton Add Item In CreateInvoice");
                cmd.ExecuteNonQuery();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int counter = 0;
            if (e.ColumnIndex == 10)
            {

                if (counter == 0)
                {
                    counter = 1;
                    try
                    {
                        DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                        AddItemForInvoice addItem = new AddItemForInvoice
                        {
                            stockID = selectedRow.Cells[0].Value.ToString(),
                            productID = selectedRow.Cells[1].Value.ToString(),
                            Company = selectedRow.Cells[2].Value.ToString(),
                            type = selectedRow.Cells[3].Value.ToString(),
                            name = selectedRow.Cells[4].Value.ToString(),
                            pack = selectedRow.Cells[5].Value.ToString(),
                            price = selectedRow.Cells[6].Value.ToString(),
                            batchID = selectedRow.Cells[7].Value.ToString(),
                            Quantity = selectedRow.Cells[8].Value.ToString(),
                        };
                        if (DateTime.TryParse(selectedRow.Cells[8].Value.ToString(), out DateTime expiredDate))
                        {
                            // Check if the expired date is less than the current date
                            if (expiredDate < DateTime.Now)
                            {
                                MessageBox.Show("This medicine has expired!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        // Check if the quantity is greater than 0 before proceeding with the addition of the item
                        if (int.TryParse(addItem.Quantity, out int quantity) && quantity > 0)
                        {
                            if (AddItemForInvoiceDL.AddItem(addItem))
                            {
                                MessageBox.Show("Item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Item already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("This Product is out of stock!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while adding the item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SqlCommand cmd;
                        var con = Configuration.getInstance().getConnection();
                        cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                        cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@LogTitle", ex.Message);
                        cmd.Parameters.AddWithValue("@LogClass", "Add Item");
                        cmd.Parameters.AddWithValue("@LogFunction", "data grid view add cell click");
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
