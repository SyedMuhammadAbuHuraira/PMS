using FontAwesome.Sharp;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
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
using System.Windows.Forms;
using System.Xml.Linq;

namespace PharmacyManagementSystem.Forms
{
    public partial class SaleReturn : Form
    {
        public SaleReturn()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        string FinalAmount = "0";
        public class RowData
        {
            public int RowNumber { get; set; }
            public int Quantity { get; set; }
            public decimal Discount { get; set; }
        }
        List<RowData> rowDataList = new List<RowData>();
        private DataTable originalDataSource;


        private DataTable GetData()
        {
            DataTable dt = new DataTable();

            var con = Configuration.getInstance().getConnection();

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT  Invoice_Order.StockID , Invoice.InvoiceID, Products.ProductID,Invoice.InvoiceDate,Products.Name, Products.Company, Products.Type,  Products.RetailPrice / CAST(Products.ConversionalUnit AS decimal(10,2)) AS Price, Invoice_Order.Quantity,  Invoice_Order.BatchNo, Invoice_Order.DiscountOnProduct FROM Invoice INNER JOIN Invoice_Order ON Invoice.InvoiceID = Invoice_Order.InvoiceOrderID INNER JOIN Products ON Invoice_Order.ProductID = Products.ProductID   WHERE Invoice.InvoiceID LIKE '%' + @InvoiceOrderID + '%'", con);

            cmd.Parameters.AddWithValue("@InvoiceOrderID", textBox1.Text);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            

            return dt;
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            try {
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                var con = Configuration.getInstance().getConnection();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT  Invoice_Order.StockID , Invoice.InvoiceID, Products.ProductID,Invoice.InvoiceDate,Products.Name, Products.Company, Products.Type,  Products.RetailPrice / CAST(Products.ConversionalUnit AS decimal(10,2)) AS Price, Invoice_Order.Quantity,  Invoice_Order.BatchNo, Invoice_Order.DiscountOnProduct FROM Invoice INNER JOIN Invoice_Order ON Invoice.InvoiceID = Invoice_Order.InvoiceOrderID INNER JOIN Products ON Invoice_Order.ProductID = Products.ProductID   WHERE Invoice.InvoiceID LIKE '%' + @InvoiceOrderID + '%'", con);

                cmd.Parameters.AddWithValue("@InvoiceOrderID", textBox1.Text);
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
               
               dataGridView1.DataSource = dt;
                originalDataSource = GetData();
                dataGridView1.DataSource = originalDataSource;
                // dataGridView1.Columns[0].HeaderText = "InvoiceID";
                dataGridView1.Columns[0].HeaderText = "StockID";
                dataGridView1.Columns[1].HeaderText = "InvoiceID";
                dataGridView1.Columns[2].HeaderText = "ProductID";
                dataGridView1.Columns[3].HeaderText = "Date";
                dataGridView1.Columns[4].HeaderText = "ProductName";
                dataGridView1.Columns[5].HeaderText = "Company";
                dataGridView1.Columns[6].HeaderText = "Type";

              //  dataGridView1.Columns[5].HeaderText = "TotalDiscount";
              //  dataGridView1.Columns[6].HeaderText = "GrandTotal";
                dataGridView1.Columns[7].HeaderText = "Price";
                dataGridView1.Columns[8].HeaderText = "Quantity";
                dataGridView1.Columns[9].HeaderText = "Batch NO";
                dataGridView1.Columns[10].HeaderText = "Discount";
                dataGridView1.Columns[8].ReadOnly = false;
                dataGridView1.Columns[10].ReadOnly = true;
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.Columns[5].ReadOnly = true;
                dataGridView1.Columns[6].ReadOnly = true;
                dataGridView1.Columns[7].ReadOnly = true;
                dataGridView1.Columns[9].ReadOnly = true;
                dataGridView1.DataSource = dt;
               // DataTable originalDataSource = ((DataTable)dataGridView1.DataSource).Copy();

                decimal price = 0;

                SqlCommand cmd2 = new SqlCommand("SELECT  Total, GrandTotal, Payment, TotalDiscount FROM Invoice WHERE InvoiceID = @InvoiceOrderID", con);
                cmd2.Parameters.AddWithValue("@InvoiceOrderID", textBox1.Text);
                string grandtotal = "0";
                string Total = "0";
                string payment = "0";
                string totalDiscount = "0";
               
                SqlDataReader reader = cmd2.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Total = reader.GetString(0);
                    grandtotal = reader.GetString(1);
                    payment = reader.GetString(2);
                    totalDiscount = reader.GetString(3);
                    FinalAmount = reader.GetString(2);
                    // Use the total and payment values as needed
                }
                // close new SqlDataReader
                reader.Close();
                label7.Text = Total.ToString();
                label8.Text = grandtotal.ToString();
                label9.Text = payment.ToString();
                label14.Text = "0";
                domainUpDown1.Text = totalDiscount;
                domainUpDown1.ReadOnly = true;


                // Define a list to store the row data


                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];

                    // Get the quantity and discount values from the current row
                    int quantity = Convert.ToInt32(row.Cells[8].Value);
                    decimal discount = Convert.ToDecimal(row.Cells[10].Value);

                    // Add the row data to the list
                    rowDataList.Add(new RowData { RowNumber = i, Quantity = quantity, Discount = discount });
                }

                /*  foreach (DataGridViewRow row in dataGridView1.Rows)
                  {
                      if (row != null && row.Cells["GrandTotal"] != null && !string.IsNullOrEmpty(row.Cells["GrandTotal"].Value?.ToString()))
                      {
                          string priceString = row.Cells["GrandTotal"].Value.ToString();
                          price += decimal.Parse(priceString);
                      }
                  } */

                //  label8.Text = price.ToString();
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;

                    // dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.AllowUserToOrderColumns = false;
                    dataGridView1.AllowUserToResizeRows = false;
                    //dataGridView1.ReadOnly = true;
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
                    editButton.HeaderText = "DELETE";
                    editButton.Text = "DELETE";
                    editButton.UseColumnTextForButtonValue = true;
                    editButton.DefaultCellStyle.BackColor = Color.FromArgb(72, 123, 237);
                    editButton.DefaultCellStyle.ForeColor = Color.White;
                    editButton.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    dataGridView1.Columns.Add(editButton);
                     dataGridView1.CellClick += dataGridView1_CellClick;
                    dataGridView1.CellValueChanged += dataGridView1_CellValueChanged_1;
                }
                else
                {
                    MessageBox.Show("Invoice not found!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                cmd.Parameters.AddWithValue("@LogFunction", "InvoiceOrder");
                cmd.ExecuteNonQuery();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                decimal grandTotal = decimal.Parse(label8.Text);
                decimal discountPercentage = decimal.Parse(domainUpDown1.Text);
                if (grandTotal >= 0 && discountPercentage >= 0 && discountPercentage <= 100)
                {
                    decimal discountAmount = grandTotal * discountPercentage / 100;
                    decimal discountedTotal = grandTotal - discountAmount;
                    label9.Text = discountedTotal.ToString("0.00");
                }
                else
                {
                    MessageBox.Show("Invalid discount percentage. Discount percentage must be between 0 and 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while calculating the discount: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", ex.Message);
                cmd.Parameters.AddWithValue("@LogClass", "SaleReturn");
                cmd.Parameters.AddWithValue("@LogFunction", "domainUpDown1_SelectedItemChanged");
                cmd.ExecuteNonQuery();
            }
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            try
            {

                int count = 0;
                int loggedID = UsersDL.GetLoggedId();
                var con = Configuration.getInstance().getConnection();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                List<int> changedRows = new List<int>();

                // Compare the original data source with the current data source
                foreach (DataRow currentRow in ((DataTable)dataGridView1.DataSource).Rows)
                {
                    // Get the row index of the current row
                    int rowIndex = ((DataTable)dataGridView1.DataSource).Rows.IndexOf(currentRow);

                    // Get the corresponding row in the original data source
                    DataRow originalRow = originalDataSource.Rows[rowIndex];

                    // Check if the current row is different from the original row
                    bool rowChanged = false;
                    int columnCount = ((DataTable)dataGridView1.DataSource).Columns.Count;
                    for (int i = 0; i < columnCount; i++)
                    {
                        if (!currentRow[i].Equals(originalRow[i]))
                        {
                            rowChanged = true;
                            break;
                        }
                    }

                    if (rowChanged)
                    {
                        changedRows.Add(rowIndex);
                    }
                }

                // Process the changed rows
                foreach (int rowIndex in changedRows)
                {
                    DataGridViewRow row = dataGridView1.Rows[rowIndex];


                    int invoiceID = Convert.ToInt32(row.Cells["InvoiceID"].Value.ToString());
                    int productID = Convert.ToInt32(row.Cells["ProductID"].Value.ToString());
                    int StockIdD = Convert.ToInt32(row.Cells["StockID"].Value.ToString());

                    int updateQuantity = Convert.ToInt32(row.Cells["Quantity"].Value.ToString());
                    int quantity = rowDataList[rowIndex].Quantity;
                    // count = count + 1;
                    // Check if product exists with given productID
                    string query1 = "SELECT * FROM Products WHERE ProductID = @productID";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.Parameters.AddWithValue("@productID", productID);
                    SqlDataReader reader1 = cmd1.ExecuteReader();

                    if (reader1.HasRows)
                    {
                        reader1.Close();




                        // Update quantity in Stock table for given productID
                        int newQuantity = quantity - updateQuantity;


                        string query3 = "UPDATE StockItems SET UpdatedAt = @UpdatedAt, Quantity = Quantity + @newQuantity WHERE ProductID = @ProductID AND StockID = @stockIdD";
                        SqlCommand cmd3 = new SqlCommand(query3, con);
                        cmd3.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd3.Parameters.AddWithValue("@productID", productID);
                        cmd3.Parameters.AddWithValue("@newQuantity", newQuantity);
                        cmd3.Parameters.AddWithValue("@stockIdD", StockIdD);
                        cmd3.ExecuteNonQuery();

                        // Add the record to the Returns table
                        string query4 = "INSERT INTO Returns (CreatedAt,UpdatedAt,Active,  InvoiceID, Amount, Quantity, LoggedID, Date, ProductID , StockID ) " +
                                        "VALUES (@CreatedAt,@UpdatedAt,@Active,@invoiceID, @amount, @quantity, @loggedID, @date, @ProductID,@StockIdD)";
                        SqlCommand cmd4 = new SqlCommand(query4, con);
                        cmd4.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                        cmd4.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd4.Parameters.AddWithValue("@Active", "Active");
                        cmd4.Parameters.AddWithValue("@invoiceID", invoiceID);
                        cmd4.Parameters.AddWithValue("@amount", label14.Text.ToString());
                        cmd4.Parameters.AddWithValue("@quantity", updateQuantity);
                        cmd4.Parameters.AddWithValue("@loggedID", loggedID);
                        cmd4.Parameters.AddWithValue("@date", DateTime.Now);
                        cmd4.Parameters.AddWithValue("@ProductID", productID);
                        cmd4.Parameters.AddWithValue("@stockIdD", StockIdD);
                        cmd4.ExecuteNonQuery();



                        int q = quantity - updateQuantity;
                        string query6 = "UPDATE Invoice_Order SET UpdatedAt = @UpdatedAt,Quantity = Quantity - @quantity WHERE InvoiceOrderID = @invoiceID AND ProductID = @productID  AND StockID = @stockIdD  ";
                        SqlCommand cmd6 = new SqlCommand(query6, con);
                        cmd6.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd6.Parameters.AddWithValue("@invoiceID", invoiceID);
                        cmd6.Parameters.AddWithValue("@productID", productID);
                        cmd6.Parameters.AddWithValue("@stockIdD", StockIdD);
                        cmd6.Parameters.AddWithValue("@quantity", q);
                        cmd6.ExecuteNonQuery();



                        string query7 = "SELECT Payment FROM Invoice WHERE InvoiceID = @invoiceID";
                        SqlCommand cmd7 = new SqlCommand(query7, con);
                        cmd7.Parameters.AddWithValue("@invoiceID", invoiceID);
                        string payment = cmd7.ExecuteScalar().ToString();

                        decimal amount = decimal.Parse(label14.Text.ToString());
                        decimal newPayment = decimal.Parse(payment) - amount;

                        string query8 = "UPDATE Invoice SET UpdatedAt = @UpdatedAt,  Payment = @newPayment WHERE InvoiceID = @invoiceID";
                        SqlCommand cmd8 = new SqlCommand(query8, con);
                        cmd8.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd8.Parameters.AddWithValue("@invoiceID", invoiceID);
                        cmd8.Parameters.AddWithValue("@newPayment", newPayment.ToString());
                        cmd8.ExecuteNonQuery();

                        int quantityy = 0;
                        decimal totalAmount = 0;
                        decimal totalDiscountAmount = 0;
                        string query = "SELECT Quantity, DiscountOnProduct FROM Invoice_Order WHERE InvoiceOrderID = @InvoiceOrderID   AND StockID = @stockIdD  ";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@InvoiceOrderID", invoiceID);
                        cmd.Parameters.AddWithValue("@stockIdD", StockIdD);
                        SqlDataReader reader = cmd.ExecuteReader();
                        String connectionString = @"Data Source=(local);Initial Catalog=PharmacyPMS;Integrated Security=True"; 
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                quantityy = Convert.ToInt32(reader["Quantity"]);
                                decimal discountOnProduct = reader.GetDecimal(reader.GetOrdinal("DiscountOnProduct"));
                                decimal retailPrice = 0;
                                decimal conversionUnit = 0;
                                decimal total = 0;

                                string query9 = "SELECT RetailPrice, ConversionalUnit FROM Products WHERE ProductID = @productID";
                                using (SqlConnection con2 = new SqlConnection(connectionString))
                                {
                                    con2.Open();
                                    SqlCommand cmd9 = new SqlCommand(query9, con2);
                                    cmd9.Parameters.AddWithValue("@productID", productID);
                                    SqlDataReader reader2 = cmd9.ExecuteReader();

                                    if (reader2.HasRows)
                                    {
                                        reader2.Read();
                                        retailPrice = Convert.ToDecimal(reader2["RetailPrice"]);
                                        conversionUnit = Convert.ToDecimal(reader2["ConversionalUnit"]);
                                    }
                                    reader2.Close();
                                }

                                total = (retailPrice / conversionUnit) * quantityy;
                                decimal discountAmount = (total / 100) * discountOnProduct;
                                totalDiscountAmount += total - discountAmount;
                                totalAmount += (retailPrice / conversionUnit) * quantityy;
                            }
                        }
                        reader.Close();

                        if (totalDiscountAmount > 0)
                        {
                            string query99 = "SELECT TotalDiscount FROM Invoice WHERE InvoiceID = @invoiceID";
                            using (SqlConnection con3 = new SqlConnection(connectionString))
                            {
                                con3.Open();
                                SqlCommand cmd99 = new SqlCommand(query99, con3);
                                cmd99.Parameters.AddWithValue("@invoiceID", invoiceID);
                                SqlDataReader reader3 = cmd99.ExecuteReader();

                                if (reader3.HasRows)
                                {
                                    reader3.Read();
                                    decimal discount = Convert.ToDecimal(reader3["TotalDiscount"]);
                                    decimal value = (totalDiscountAmount / 100) * discount;
                                    totalDiscountAmount = totalDiscountAmount - value;
                                }
                                reader3.Close();

                                if (totalAmount > 0)
                                {

                                    string formattedTotal = totalAmount.ToString("0.00");
                                    string totalDiscountAmountt = totalDiscountAmount.ToString("0.00");
                                    string query10 = "UPDATE Invoice SET UpdatedAt = @UpdatedAt, Total = @totalAmount, GrandTotal = @GrandTotal WHERE InvoiceID = @invoiceID ";
                                    SqlCommand cmd10 = new SqlCommand(query10, con3);
                                    cmd10.Parameters.AddWithValue("@invoiceID", invoiceID);
                                    cmd10.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                    cmd10.Parameters.AddWithValue("@GrandTotal", totalDiscountAmountt);
                                    cmd10.Parameters.AddWithValue("@totalAmount", formattedTotal);
                                    cmd10.ExecuteNonQuery();
                                }
                            }
                        }

                        MessageBox.Show("Record Succesfully updated..");
                        dataGridView1.Columns.Clear();
                        dataGridView1.DataSource = null;
                        dataGridView1.Rows.Clear();
                        //this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No matching record found in Invoice_Order table.");

                    }

                    // TODO: Do something with the data (e.g. update a database)
                }


            }
            catch(Exception exp)
            {
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", exp.Message);
                cmd.Parameters.AddWithValue("@LogClass", "SaleReturn");
                cmd.Parameters.AddWithValue("@LogFunction", "SaveButtonFunctionLogic");
                cmd.ExecuteNonQuery();
            }
            

           /* foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int invoiceID = Convert.ToInt32(row.Cells["InvoiceID"].Value.ToString());
                int productID = Convert.ToInt32(row.Cells["ProductID"].Value.ToString());
                int updateQuantity = Convert.ToInt32(row.Cells["Quantity"].Value.ToString());
                int quantity = rowDataList[count].Quantity;
                count = count + 1;


                // Check if product exists with given productID
                string query1 = "SELECT * FROM Products WHERE ProductID = @productID";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@productID", productID);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                if (reader1.HasRows)
                {
                    reader1.Close();




                    // Update quantity in Stock table for given productID
                    int newQuantity = quantity - updateQuantity;
                    string query3 = "UPDATE Stock SET Quantity = Quantity + @newQuantity WHERE ProductID = @productID";
                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    cmd3.Parameters.AddWithValue("@productID", productID);
                    cmd3.Parameters.AddWithValue("@newQuantity", newQuantity);
                    cmd3.ExecuteNonQuery();

                    // Add the record to the Returns table
                    string query4 = "INSERT INTO Returns (InvoiceID, Amount, Quantity, LoggedID, Date, ProductID) " +
                                    "VALUES (@invoiceID, @amount, @quantity, @loggedID, @date, @ProductID)";
                    SqlCommand cmd4 = new SqlCommand(query4, con);
                    cmd4.Parameters.AddWithValue("@invoiceID", invoiceID);
                    cmd4.Parameters.AddWithValue("@amount", label14.Text.ToString());
                    cmd4.Parameters.AddWithValue("@quantity", updateQuantity);
                    cmd4.Parameters.AddWithValue("@loggedID", 1);
                    cmd4.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd4.Parameters.AddWithValue("@ProductID", productID);
                    cmd4.ExecuteNonQuery();



                    int q = quantity - updateQuantity;
                    string query6 = "UPDATE Invoice_Order SET Quantity = Quantity - @quantity WHERE InvoiceOrderID = @invoiceID AND ProductID = @productID";
                    SqlCommand cmd6 = new SqlCommand(query6, con);
                    cmd6.Parameters.AddWithValue("@invoiceID", invoiceID);
                    cmd6.Parameters.AddWithValue("@productID", productID);
                    cmd6.Parameters.AddWithValue("@quantity", q);
                    cmd6.ExecuteNonQuery();



                    string query7 = "SELECT Payment FROM Invoice WHERE InvoiceID = @invoiceID";
                    SqlCommand cmd7 = new SqlCommand(query7, con);
                    cmd7.Parameters.AddWithValue("@invoiceID", invoiceID);
                    string payment = cmd7.ExecuteScalar().ToString();

                    decimal amount = decimal.Parse(label14.Text.ToString());
                    decimal newPayment = decimal.Parse(payment) - amount;

                    string query8 = "UPDATE Invoice SET Payment = @newPayment WHERE InvoiceID = @invoiceID";
                    SqlCommand cmd8 = new SqlCommand(query8, con);
                    cmd8.Parameters.AddWithValue("@invoiceID", invoiceID);
                    cmd8.Parameters.AddWithValue("@newPayment", newPayment.ToString());
                    cmd8.ExecuteNonQuery();

                    int quantityy = 0;
                    decimal totalAmount = 0;
                    decimal totalDiscountAmount = 0;
                    string query = "SELECT Quantity, DiscountOnProduct FROM Invoice_Order WHERE InvoiceOrderID = @InvoiceOrderID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@InvoiceOrderID", invoiceID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    String connectionString = @"Data Source=(local);Initial Catalog=Pharmacy;Integrated Security=True";
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            quantityy = Convert.ToInt32(reader["Quantity"]);
                            decimal discountOnProduct = reader.GetDecimal(reader.GetOrdinal("DiscountOnProduct"));
                            decimal retailPrice = 0;
                            decimal conversionUnit = 0;
                            decimal total = 0;

                            string query9 = "SELECT RetailPrice, ConversionalUnit FROM Products WHERE ProductID = @productID";
                            using (SqlConnection con2 = new SqlConnection(connectionString))
                            {
                                con2.Open();
                                SqlCommand cmd9 = new SqlCommand(query9, con2);
                                cmd9.Parameters.AddWithValue("@productID", productID);
                                SqlDataReader reader2 = cmd9.ExecuteReader();

                                if (reader2.HasRows)
                                {
                                    reader2.Read();
                                    retailPrice = Convert.ToDecimal(reader2["RetailPrice"]);
                                    conversionUnit = Convert.ToDecimal(reader2["ConversionalUnit"]);
                                }
                                reader2.Close();
                            }

                            total = retailPrice / conversionUnit * quantityy;
                            decimal discountAmount = (total / 100) * discountOnProduct;
                            totalDiscountAmount += total - discountAmount;
                            totalAmount += retailPrice / conversionUnit * quantityy;
                        }
                    }
                    reader.Close();

                    if (totalDiscountAmount > 0)
                    {
                        string query99 = "SELECT TotalDiscount FROM Invoice WHERE InvoiceID = @invoiceID";
                        using (SqlConnection con3 = new SqlConnection(connectionString))
                        {
                            con3.Open();
                            SqlCommand cmd99 = new SqlCommand(query99, con3);
                            cmd99.Parameters.AddWithValue("@invoiceID", invoiceID);
                            SqlDataReader reader3 = cmd99.ExecuteReader();

                            if (reader3.HasRows)
                            {
                                reader3.Read();
                                decimal discount = Convert.ToDecimal(reader3["TotalDiscount"]);
                                totalDiscountAmount = (totalDiscountAmount / 100) * discount;
                            }
                            reader3.Close();

                            if (totalAmount > 0)
                            {
                                string query10 = "UPDATE Invoice SET Total = @totalAmount, GrandTotal = @GrandTotal WHERE InvoiceID = @invoiceID ";
                                SqlCommand cmd10 = new SqlCommand(query10, con3);
                                cmd10.Parameters.AddWithValue("@invoiceID", invoiceID);

                                cmd10.Parameters.AddWithValue("@GrandTotal", totalDiscountAmount);
                                cmd10.Parameters.AddWithValue("@totalAmount", totalAmount);
                                cmd10.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Record Succesfully updated..");
                }
                else
                {
                    MessageBox.Show("No matching record found in Invoice_Order table.");
                
                }
            
        } */ 
        }
        private void dataGridView1_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.ColumnIndex == dataGridView1.Columns["Quantity"].Index || e.ColumnIndex == dataGridView1.Columns["Discount"].Index)
                {
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "Quantity")
                    {
                        string quantityValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        if (!int.TryParse(quantityValue, out int quantity))
                        {
                            MessageBox.Show("Quantity must be a whole number.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = rowDataList[e.RowIndex].Quantity;
                            return;
                        }
                        int availQuantity = rowDataList[e.RowIndex].Quantity;
                        if (quantity > availQuantity)
                        {
                            MessageBox.Show("Entered quantity is greater than the available quantity.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = availQuantity;
                            return;
                        }
                        else if (quantity < 0)
                        {
                            MessageBox.Show("Entered quantity cannot be negative.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                            return;
                        }
                     //   rowDataList[e.RowIndex].Quantity = quantity;
                    }
                    else if (dataGridView1.Columns[e.ColumnIndex].Name == "Discount")
                    {
                        string discountValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        if (!decimal.TryParse(discountValue, out decimal discount) || discount < 0 || discount > 100)
                        {
                            MessageBox.Show("Discount must be a number between 0 and 100.", "Invalid Discount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = rowDataList[e.RowIndex].Discount;
                            return;
                        }
                       // rowDataList[e.RowIndex].Discount = discount;
                    }

                    decimal totalPrice = 0;
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        Console.WriteLine(col.Name);
                    }
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        int quantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                        string priceString = row.Cells["Price"].Value.ToString();


                        
                   
                      
                        
                        decimal price = decimal.Parse(priceString);
                        decimal discountPercentage = decimal.Parse(row.Cells[10].Value.ToString());

                        decimal discount = price * quantity * discountPercentage / 100;
                        decimal subtotal = (price * quantity) - discount;
                        totalPrice += subtotal;
                    }

                    label8.Text = totalPrice.ToString("0.00");
                    label14.Text = (decimal.Parse(FinalAmount) - decimal.Parse(label8.Text)).ToString();

                    domainUpDown1_SelectedItemChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while calculating the discount: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", ex.Message);
                cmd.Parameters.AddWithValue("@LogClass", "SaleReturn");
                cmd.Parameters.AddWithValue("@LogFunction", "dataGridView1_CellValueChanged_1");
                cmd.ExecuteNonQuery();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int loggedID = UsersDL.GetLoggedId();
                int counter = 0;
                var con = Configuration.getInstance().getConnection();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                if (e.ColumnIndex == 11 && e.RowIndex >= 0)
                {
                    if (counter == 0)
                    {
                        counter = 1;
                        DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        // If the user clicks "Yes", execute the code to delete the item
                        if (result == DialogResult.Yes)
                        {
                            List<int> changedRows = new List<int>();

            // Compare the original data source with the current data source
            foreach (DataRow currentRow in ((DataTable)dataGridView1.DataSource).Rows)
            {
                // Get the row index of the current row
                int rowIndex = ((DataTable)dataGridView1.DataSource).Rows.IndexOf(currentRow);

                // Get the corresponding row in the original data source
                DataRow originalRow = originalDataSource.Rows[rowIndex];

                // Check if the current row is different from the original row
                bool rowChanged = false;
                int columnCount = ((DataTable)dataGridView1.DataSource).Columns.Count;
                for (int i = 0; i < columnCount; i++)
                {
                    if (!currentRow[i].Equals(originalRow[i]))
                    {
                        rowChanged = true;
                        break;
                    }
                }

                if (rowChanged)
                {
                    changedRows.Add(rowIndex);
                }
            }

            // Process the changed rows
            foreach (int rowIndex in changedRows)
            {
                DataGridViewRow row = dataGridView1.Rows[rowIndex];


                int invoiceID = Convert.ToInt32(row.Cells["InvoiceID"].Value.ToString());
                int productID = Convert.ToInt32(row.Cells["ProductID"].Value.ToString());
                int updateQuantity = Convert.ToInt32(row.Cells["Quantity"].Value.ToString());


                int StockIdD = Convert.ToInt32(row.Cells["Stock Num"].Value.ToString());





                                int quantity = rowDataList[rowIndex].Quantity;
                // count = count + 1;
                // Check if product exists with given productID
                string query1 = "SELECT * FROM Products WHERE ProductID = @productID AND StockID = @stockIdD";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                                cmd1.Parameters.AddWithValue("@stockIdD", StockIdD);
                                cmd1.Parameters.AddWithValue("@productID", productID);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                if (reader1.HasRows)
                {
                    reader1.Close();




                    // Update quantity in Stock table for given productID
                    int newQuantity = quantity - updateQuantity;

                    string query3 = "UPDATE StockItems SET UpdatedAt = @UpdatedAt, Quantity = Quantity + @newQuantity WHERE ProductID = @productID  AND StockID = @stockIdD";
                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    cmd3.Parameters.AddWithValue("@productID", productID);
                                    cmd3.Parameters.AddWithValue("@stockIdD", StockIdD);
                                    cmd3.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                    cmd3.Parameters.AddWithValue("@newQuantity", newQuantity);
                    cmd3.ExecuteNonQuery();

                                    // Add the record to the Returns table
                                    string query4 = "INSERT INTO Returns (CreatedAt,UpdatedAt,Active, InvoiceID, Amount, Quantity, LoggedID, Date, ProductID , StockID ) " +
                                                  "VALUES (@CreatedAt,@UpdatedAt,@Active,@invoiceID, @amount, @quantity, @loggedID, @date, @ProductID,@StockIdD)";
                                    SqlCommand cmd4 = new SqlCommand(query4, con);
                                    cmd4.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                                    cmd4.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                    cmd4.Parameters.AddWithValue("@Active", "Active");
                                    cmd4.Parameters.AddWithValue("@invoiceID", invoiceID);
                                    cmd4.Parameters.AddWithValue("@amount", label14.Text.ToString());
                                    cmd4.Parameters.AddWithValue("@quantity", updateQuantity);
                                    cmd4.Parameters.AddWithValue("@loggedID", loggedID);
                                    cmd4.Parameters.AddWithValue("@date", DateTime.Now);
                                    cmd4.Parameters.AddWithValue("@ProductID", productID);
                                    cmd4.Parameters.AddWithValue("@stockIdD", StockIdD);
                                    cmd4.ExecuteNonQuery();



                                    int q = quantity - updateQuantity;
                    string query6 = "UPDATE Invoice_Order SET  UpdatedAt = @UpdatedAt, Quantity = Quantity - @quantity WHERE InvoiceOrderID = @invoiceID AND ProductID = @productID  AND StockID = @stockIdD";
                    SqlCommand cmd6 = new SqlCommand(query6, con);
                    cmd6.Parameters.AddWithValue("@invoiceID", invoiceID);
                                    cmd6.Parameters.AddWithValue("@stockIdD", StockIdD);
                                    cmd6.Parameters.AddWithValue("@productID", productID);
                                    cmd6.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                    cmd6.Parameters.AddWithValue("@quantity", q);
                    cmd6.ExecuteNonQuery();



                    string query7 = "SELECT Payment FROM Invoice WHERE InvoiceID = @invoiceID";
                    SqlCommand cmd7 = new SqlCommand(query7, con);
                    cmd7.Parameters.AddWithValue("@invoiceID", invoiceID);
                    string payment = cmd7.ExecuteScalar().ToString();

                    decimal amount = decimal.Parse(label14.Text.ToString());
                    decimal newPayment = decimal.Parse(payment) - amount;

                    string query8 = "UPDATE Invoice SET  UpdatedAt = @UpdatedAt,Payment = @newPayment WHERE InvoiceID = @invoiceID";
                    SqlCommand cmd8 = new SqlCommand(query8, con);
                    cmd8.Parameters.AddWithValue("@invoiceID", invoiceID);
                                    cmd8.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                    cmd8.Parameters.AddWithValue("@newPayment", newPayment.ToString());
                    cmd8.ExecuteNonQuery();

                    int quantityy = 0;
                    decimal totalAmount = 0;
                    decimal totalDiscountAmount = 0;
                    string query = "SELECT Quantity, DiscountOnProduct FROM Invoice_Order WHERE InvoiceOrderID = @InvoiceOrderID AND StockID = @stockIdD";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@InvoiceOrderID", invoiceID);
                    cmd.Parameters.AddWithValue("@stockIdD", StockIdD);
                     SqlDataReader reader = cmd.ExecuteReader();
                    String connectionString = @"Data Source=(local);Initial Catalog=PharmacyPMS;Integrated Security=True";
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            quantityy = Convert.ToInt32(reader["Quantity"]);
                            decimal discountOnProduct = reader.GetDecimal(reader.GetOrdinal("DiscountOnProduct"));
                            decimal retailPrice = 0;
                            decimal conversionUnit = 0;
                            decimal total = 0;

                            string query9 = "SELECT RetailPrice, ConversionalUnit FROM Products WHERE ProductID = @productID";
                            using (SqlConnection con2 = new SqlConnection(connectionString))
                            {
                                con2.Open();
                                SqlCommand cmd9 = new SqlCommand(query9, con2);
                                cmd9.Parameters.AddWithValue("@productID", productID);
                                SqlDataReader reader2 = cmd9.ExecuteReader();

                                if (reader2.HasRows)
                                {
                                    reader2.Read();
                                    retailPrice = Convert.ToDecimal(reader2["RetailPrice"]);
                                    conversionUnit = Convert.ToDecimal(reader2["ConversionalUnit"]);
                                }
                                reader2.Close();
                            }

                            total = (retailPrice / conversionUnit) * quantityy;
                            decimal discountAmount = (total / 100) * discountOnProduct;
                            totalDiscountAmount += total - discountAmount;
                            totalAmount += (retailPrice / conversionUnit) * quantityy;
                        }
                    }
                    reader.Close();

                    if (totalDiscountAmount > 0)
                    {
                        string query99 = "SELECT TotalDiscount FROM Invoice WHERE InvoiceID = @invoiceID";
                        using (SqlConnection con3 = new SqlConnection(connectionString))
                        {
                            con3.Open();
                            SqlCommand cmd99 = new SqlCommand(query99, con3);
                            cmd99.Parameters.AddWithValue("@invoiceID", invoiceID);
                            SqlDataReader reader3 = cmd99.ExecuteReader();

                            if (reader3.HasRows)
                            {
                                reader3.Read();
                                decimal discount = Convert.ToDecimal(reader3["TotalDiscount"]);
                                decimal value = (totalDiscountAmount / 100) * discount;
                                totalDiscountAmount = totalDiscountAmount - value;
                            }
                            reader3.Close();

                            if (totalAmount > 0)
                            {

                                string formattedTotal = totalAmount.ToString("0.00");
                                string totalDiscountAmountt = totalDiscountAmount.ToString("0.00");
                                string query10 = "UPDATE Invoice SET UpdatedAt=@UpdatedAt, Total = @totalAmount, GrandTotal = @GrandTotal WHERE InvoiceID = @invoiceID ";
                                SqlCommand cmd10 = new SqlCommand(query10, con3);
                                cmd10.Parameters.AddWithValue("@invoiceID", invoiceID);
                                cmd10.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                                cmd10.Parameters.AddWithValue("@GrandTotal", totalDiscountAmountt);
                                cmd10.Parameters.AddWithValue("@totalAmount", formattedTotal);
                                cmd10.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Record Succesfully updated..");
                                    dataGridView1.Columns.Clear();
                                    dataGridView1.DataSource = null;
                                    dataGridView1.Rows.Clear();
                                }
                else
                {
                    MessageBox.Show("No matching record found in Invoice_Order table.");

                }

                // TODO: Do something with the data (e.g. update a database)
            }



            

                                                    }
                        else
                        {
                            MessageBox.Show("No matching record found in Products table.");
                            // reader1.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while calculating the discount: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", ex.Message);
                cmd.Parameters.AddWithValue("@LogClass", "SaleReturn");
                cmd.Parameters.AddWithValue("@LogFunction", "DataGridViewCell1");
                cmd.ExecuteNonQuery();
            }
        }
        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            try
            {

                var con = Configuration.getInstance().getConnection();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                DateTime startDate = dateTimePicker1.Value;
                DateTime endDate = dateTimePicker2.Value;

                // Construct the parameterized SQL query
                SqlCommand cmd2 = new SqlCommand("SELECT Person.Name as Supplier, Person.PhoneNo, Returns.Amount, Returns.Quantity as GivenQuantity, Returns.Date, \r\nProducts.Name, Products.Type \r\nFROM Returns \r\nINNER JOIN Products ON Returns.ProductID = Products.ProductID \r\nINNER JOIN StockItems ON Products.ProductID = StockItems.ProductID  AND Returns.StockID = StockItems.StockID \r\nInner join Stock on Stock.StockID = StockItems.StockID \r\nINNER JOIN Supplier ON Stock.SupplierID = Supplier.ID \r\nINNER JOIN Person ON Supplier.PersonID = Person.ID \r\nWHERE Returns.Date BETWEEN @StartDate AND @EndDate\r\n", con);
                cmd2.Parameters.AddWithValue("@StartDate", startDate);
                cmd2.Parameters.AddWithValue("@EndDate", endDate);
                // Clear the panel before drawing new rows
                // Clear the panel before drawing new rows
                panel2.Controls.Clear();

                // Execute the query and draw the results in a DataGridView
                SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                DataGridView dataGridView1 = new DataGridView();
                dataGridView1.Dock = DockStyle.Fill;
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
                dataGridView1.DataSource = dataTable;


                



                panel2.Controls.Add(dataGridView1);
                // Close the reader

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching the data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", ex.Message);
                cmd.Parameters.AddWithValue("@LogClass", "SaleReturn");
                cmd.Parameters.AddWithValue("@LogFunction", "StartOrEndDateSearch");
                cmd.ExecuteNonQuery();
            }
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton8_Click(object sender, EventArgs e)
        {

        }
    }
}
