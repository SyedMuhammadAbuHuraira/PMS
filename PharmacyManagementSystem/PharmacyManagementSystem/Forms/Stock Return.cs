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

namespace PharmacyManagementSystem.Forms
{
   
    public partial class Stock_Return : Form
    {
        public static int quantity;
       
        public Stock_Return()
        {
            InitializeComponent();
            dataGridView1.Columns[1].ReadOnly = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Stock_Return_Load(object sender, EventArgs e)
        {

        }

        private void iconButton8_Click(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            try
            {


                if (textBox8.Text == "")
                {
                    MessageBox.Show("Please Enter the Stock ID or Document number");

                }
                if (textBox8.Text != "")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Select Count(*) From Stock where StockID = @stockid", con);
                    cmd.Parameters.AddWithValue("@stockid", textBox8.Text);
                    int count = (int)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        MessageBox.Show("No stock Entered with the provided StockID or Document Number");
                    }
                    if (count > 0)
                    {
                        textBox8.ReadOnly = true;
                        SqlCommand cmd1 = new SqlCommand("SELECT p1.Name FROM Person p1 JOIN Supplier p2 ON p1.ID = p2.PersonID JOIN Stock p3 ON p2.ID = p3.SupplierID WHERE p3.StockID = @stockids", con);
                        cmd1.Parameters.AddWithValue("@stockids", textBox8.Text);
                        string Name = cmd1.ExecuteScalar().ToString();
                        textBox1.Text = Name;

                        SqlCommand cmd4 = new SqlCommand("Select P2.Name,P2.Company,p2.Type,P2.CostPrice,p2.RetailPrice,p2.Margin,p1.Quantity,p2.ConversionalUnit,p1.BatchNO,p1.ExpiredDate From StockItems p1 JOIN Products p2 ON P1.ProductID = P2.ProductID Where p1.StockID = @idp", con);
                        cmd4.Parameters.AddWithValue("@idp", int.Parse(textBox8.Text.ToString()));
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
                                dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;






                            }
                        }



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
                cmd.Parameters.AddWithValue("@LogTitle", "Store in grid");
                cmd.Parameters.AddWithValue("@LogClass", "StockReturn");
                cmd.Parameters.AddWithValue("@LogFunction", "Store Data in grid ");
                cmd.ExecuteNonQuery();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                if (e.ColumnIndex == 0)
                {
                    int rowcount = dataGridView1.RowCount;
                    int currentrow = e.RowIndex;
                    for (int x = 0; x < rowcount - 1; x++)
                    {
                        if (x != currentrow)
                        {
                            dataGridView1.Rows[x].Cells[8].ReadOnly = true;
                        }
                    }
                    if (e.RowIndex < rowcount - 1)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[1].ReadOnly = false;
                        quantity = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
                        MessageBox.Show("Enter the Return Quantity");
                    }
                    if (e.RowIndex >= rowcount)
                    {
                        MessageBox.Show("Empty row");
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
                cmd.Parameters.AddWithValue("@LogTitle", "cell changed quantity 0");
                cmd.Parameters.AddWithValue("@LogClass", "StockReturn");
                cmd.Parameters.AddWithValue("@LogFunction", "cell changed quantity 0");
                cmd.ExecuteNonQuery();
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    int returnquantity = 0;
                    int stockquantity = 0;
                    float totalcostreturn = 0;
                    float stockcost = 0;
                    float temp;
                    if (dataGridView1.RowCount - 1 != 0)
                    {
                        int quantity = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
                        if (int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) < 0 || int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()) > quantity)
                        {
                            dataGridView1.Rows[e.RowIndex].Cells[1].Value = 0.ToString();
                            MessageBox.Show("Returned Value Must be Greater than 0 and less than stock Quantity");
                        }
                        for (int x = 0; x < dataGridView1.RowCount - 1; x++)
                        {
                            totalcostreturn = totalcostreturn + ((int.Parse(dataGridView1.Rows[x].Cells[1].Value.ToString())) * float.Parse(dataGridView1.Rows[x].Cells[5].Value.ToString()));
                            stockquantity = stockquantity + (int.Parse(dataGridView1.Rows[x].Cells[8].Value.ToString()) - int.Parse(dataGridView1.Rows[x].Cells[1].Value.ToString()));
                            returnquantity = returnquantity + (int.Parse(dataGridView1.Rows[x].Cells[1].Value.ToString()));
                            temp = float.Parse(dataGridView1.Rows[x].Cells[5].Value.ToString()) * (int.Parse(dataGridView1.Rows[x].Cells[8].Value.ToString()));
                            stockcost = stockcost + (temp - ((int.Parse(dataGridView1.Rows[x].Cells[1].Value.ToString())) * float.Parse(dataGridView1.Rows[x].Cells[5].Value.ToString())));
                        }
                        textBox2.Text = stockquantity.ToString();
                        textBox4.Text = returnquantity.ToString();
                        textBox9.Text = totalcostreturn.ToString();
                        textBox3.Text = stockcost.ToString();
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
                cmd.Parameters.AddWithValue("@LogTitle", "cell changed quantity 1");
                cmd.Parameters.AddWithValue("@LogClass", "Stock Return");
                cmd.Parameters.AddWithValue("@LogFunction", "cell value changed 1");
                cmd.ExecuteNonQuery();
            }
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                if (dataGridView1.RowCount - 1 > 0)
                {
                    int stockid = int.Parse(textBox8.Text);
                    for (int x = 0; x < dataGridView1.RowCount - 1; x++)
                    {
                        int quantity = int.Parse(dataGridView1.Rows[x].Cells[8].Value.ToString()) - int.Parse((dataGridView1.Rows[x].Cells[1].Value.ToString()));
                        SqlCommand cmd = new SqlCommand("Select ProductID From Products where Name = @name", con);
                        cmd.Parameters.AddWithValue("@name", dataGridView1.Rows[x].Cells[2].Value.ToString());
                        int productid = (int)cmd.ExecuteScalar();
                        SqlCommand cmd1 = new SqlCommand("Update StockItems SET UpdatedAt=@UpdatedAt, Quantity = @quantity where StockID = @StockID AND ProductID = @ProductID", con);
                        cmd1.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd1.Parameters.AddWithValue("@quantity", quantity);
                        cmd1.Parameters.AddWithValue("@StockID", stockid);
                        cmd1.Parameters.AddWithValue("@ProductID", productid);
                        cmd1.ExecuteNonQuery();
                    }
                    MessageBox.Show("Stock Returned Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", "Stock Return save error");
                cmd.Parameters.AddWithValue("@LogClass", "StockReturn");
                cmd.Parameters.AddWithValue("@LogFunction", "UpdateStockReturnQuantitySaveButton");
                cmd.ExecuteNonQuery();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}