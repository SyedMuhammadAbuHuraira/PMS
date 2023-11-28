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

namespace PharmacyManagementSystem.Forms
{
    public partial class Add_product_in_stock : Form
    {
        public Add_product_in_stock()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int counter = 0;
                if (e.ColumnIndex == 13)
                {

                    if (counter == 0)
                    {
                        counter = 1;                        
                        DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                        string Create = selectedRow.Cells[0].Value.ToString();
                        string Update = selectedRow.Cells[1].Value.ToString();
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

                        string active = selectedRow.Cells[2].Value.ToString();
                        string productID = selectedRow.Cells[3].Value.ToString();
                        string Company = selectedRow.Cells[4].Value.ToString();
                        string Supplier = selectedRow.Cells[5].Value.ToString();
                        string Name = selectedRow.Cells[6].Value.ToString();
                        string Type = selectedRow.Cells[7].Value.ToString();
                        string Costprice = selectedRow.Cells[8].Value.ToString();
                        string Retail = selectedRow.Cells[9].Value.ToString();
                        string Margin = selectedRow.Cells[10].Value.ToString();
                        string conversionalunit = selectedRow.Cells[11].Value.ToString();
                        float costy = float.Parse(selectedRow.Cells[12].Value.ToString());
                        string Sub_total = (costy * 1).ToString();
                        Additemforstock addItem = new Additemforstock(CreatedAt, UpdatedAt, active, productID, Company, Supplier, Name, Type, Costprice, Retail, Margin, conversionalunit, Sub_total);
                        AdditemforstockDL.addstock.Add(addItem);
                        this.Close();
                        // Check if the quantity is greater than 0 before proceeding with the addition of the item

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", "AddProductInStocks _ DataGridViewCellClick");
                cmd.Parameters.AddWithValue("@LogClass", "AddProductInStocks");
                cmd.Parameters.AddWithValue("@LogFunction", "DataGridViewCellClick");
                cmd.ExecuteNonQuery();
            }
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
                SqlCommand cmd = new SqlCommand("SELECT * From Products WHERE Products.Name LIKE '%' + @name + '%'", con);
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
                }
                else
                {
                    MessageBox.Show("Product not found!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                cmd.Parameters.AddWithValue("@LogTitle", "AddStockinProducts _ GenericName");
                cmd.Parameters.AddWithValue("@LogClass", "AddStockinProducts");
                cmd.Parameters.AddWithValue("@LogFunction", "GenericName");
                cmd.ExecuteNonQuery();
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
