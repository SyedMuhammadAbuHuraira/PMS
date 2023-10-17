using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using PharmacyManagementSystem.BL;
using PharmacyManagementSystem.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PharmacyManagementSystem.Forms
{
    public partial class CreateInvoice : Form
    {
        public CreateInvoice()
        {
            InitializeComponent();
        }

      
        private void iconButton7_Click(object sender, EventArgs e)
        {
            Form frm = new Add_Item();
            frm.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {


                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();

                DataTable dt = new DataTable();
                dt.Columns.Add("Name");
                dt.Columns.Add("Price");
                dt.Columns.Add("Pack");
                dt.Columns.Add("Type");
                dt.Columns.Add("Stock ID");
                dt.Columns.Add("Batch ID");
                dt.Columns.Add("Avail Quantity");
                dt.Columns.Add("Discount");

                foreach (AddItemForInvoice item in AddItemForInvoiceDL.GetItems())
                {
                    dt.Rows.Add(item.name, item.price, item.pack, item.type, item.stockID, item.batchID, item.Quantity , 0);
                }

                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Name";
                dataGridView1.Columns[1].HeaderText = "Price";
                dataGridView1.Columns[2].HeaderText = "Pack";
                dataGridView1.Columns[3].HeaderText = "Type";
                dataGridView1.Columns[4].HeaderText = "Stock ID";
                dataGridView1.Columns[5].HeaderText = "Batch ID";
                
                dataGridView1.Columns[6].HeaderText = "Avail Quantity";
                dataGridView1.Columns[7].HeaderText = "Discount";
                
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.Columns[5].ReadOnly = true;
                dataGridView1.Columns[6].ReadOnly = false;
                dataGridView1.Columns[7].ReadOnly = false;

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.AllowUserToOrderColumns = false;
                    dataGridView1.AllowUserToResizeRows = false;

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
                    decimal totalPrice = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string quantityString = row.Cells["Avail Quantity"].Value.ToString();
                        int quantity = int.Parse(quantityString);

                        string priceString = row.Cells["Price"].Value.ToString();
                        decimal price = decimal.Parse(priceString);
                        decimal subtotal = (price * quantity);
                        totalPrice += subtotal;
                    }
                    UpdateGrandTotal();
                    domainUpDown1.Text = "0";
                    domainUpDown1_SelectedItemChanged(null, null);
                    label7.Text = totalPrice.ToString("0.00");
                }
                else
                {
                    MessageBox.Show("Items not found!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving the items: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", ex.Message);
                cmd.Parameters.AddWithValue("@LogClass", "CreateInvoice");
                cmd.Parameters.AddWithValue("@LogFunction", "LoadItemInGrid");
                cmd.ExecuteNonQuery();
            }

        }
        private void UpdateGrandTotal()
        {
            try
            {


                decimal grandTotal = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string quantityString = row.Cells["Avail Quantity"].Value.ToString();
                    int quantity = int.Parse(quantityString);

                    string priceString = row.Cells["Price"].Value.ToString();
                    decimal price = decimal.Parse(priceString);

                    string discountString = row.Cells["Discount"].Value.ToString();
                    decimal discount = decimal.Parse(discountString);

                    decimal subtotal = (price * quantity);
                    decimal dis = discount / 100;
                    subtotal = subtotal - (subtotal * dis);
                    grandTotal += subtotal;
                }

                label8.Text = grandTotal.ToString("0.00");
                label9.Text = grandTotal.ToString("0.00");
            }
            catch(Exception ex)
            {
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", ex.Message);
                cmd.Parameters.AddWithValue("@LogClass", "CreateInvoice");
                cmd.Parameters.AddWithValue("@LogFunction", "UpdateGrandTotal");
                cmd.ExecuteNonQuery();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                int counter = 0;
                if (e.ColumnIndex == 8 && e.RowIndex >= 0)
                {
                    if (counter == 0)
                    {

                        string quantityString = dataGridView1.Rows[e.RowIndex].Cells["Avail Quantity"].Value.ToString();
                        int quantity = int.Parse(quantityString);
                        string priceString = dataGridView1.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                        decimal price = decimal.Parse(priceString);
                        string discountString = dataGridView1.Rows[e.RowIndex].Cells["Discount"].Value.ToString();
                        decimal discount = decimal.Parse(discountString);
                        decimal subtotal = (price * quantity);

                        decimal s = decimal.Parse(label8.Text);
                        s = s - subtotal;


                        label8.Text = s.ToString("0.00");
                        label9.Text = s.ToString("0.00");
                        label7.Text = s.ToString("0.00");
                        counter = 1;
                        AddItemForInvoiceDL.RemoveItem(e.RowIndex);
                        dataGridView1.Rows.RemoveAt(e.RowIndex);


                        // Call the SelectedItemChanged event to recalculate the discount


                        // Call the iconButton1_Click event to refresh the DataGridView
                        iconButton1_Click(null, null);
                        domainUpDown1_SelectedItemChanged(null, null);
                    }
                }
            }
            catch(Exception ex)
            {
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", ex.Message);
                cmd.Parameters.AddWithValue("@LogClass", "CreateInvoice");
                cmd.Parameters.AddWithValue("@LogFunction", "DataGridViewCellClick");
                cmd.ExecuteNonQuery();
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (e.ColumnIndex == dataGridView1.Columns["Avail Quantity"].Index ||
                    e.ColumnIndex == dataGridView1.Columns["Discount"].Index)
                {

                    string availQuantity = AddItemForInvoiceDL.getQuantity(e.RowIndex);


                    if (dataGridView1.Columns[e.ColumnIndex].Name == "Avail Quantity")
                    {

                        string quantityValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();


                        if (!int.TryParse(quantityValue, out int quantity) || quantity > int.Parse(availQuantity))
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
                    }
                    else if (dataGridView1.Columns[e.ColumnIndex].Name == "Discount")
                    {

                        string discountValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();


                        if (!double.TryParse(discountValue, out double discount) || discount < 0 || discount > 100)
                        {

                            MessageBox.Show("Discount must be a number between 0 and 100.", "Invalid Discount", MessageBoxButtons.OK, MessageBoxIcon.Error);


                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;


                            return;
                        }
                    }
                    decimal totalPrice = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string quantityString = row.Cells["Avail Quantity"].Value.ToString();
                        int quantity = int.Parse(quantityString);

                        string priceString = row.Cells["Price"].Value.ToString();
                        decimal price = decimal.Parse(priceString);
                        decimal subtotal = (price * quantity);
                        totalPrice += subtotal;
                    }

                    label7.Text = totalPrice.ToString("0.00");
                    // label9.Text = totalPrice.ToString("0.00");
                    UpdateGrandTotal();
                }
            }
            catch(Exception exp)
            {
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", exp.Message);
                cmd.Parameters.AddWithValue("@LogClass", "CreateInvoice");
                cmd.Parameters.AddWithValue("@LogFunction", "DataCellValueChanged");
                cmd.ExecuteNonQuery();
            }
        }



        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                string grandTotalStr = label8.Text;
                if (decimal.TryParse(grandTotalStr, out decimal grandTotal))
                {
                    // grandTotal is valid, continue with the calculation
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
                else
                {
                    // grandTotal is not valid, display an error message
                    MessageBox.Show("Invalid input. The grand total must be a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                cmd.Parameters.AddWithValue("@LogClass", "CreateInvoice");
                cmd.Parameters.AddWithValue("@LogFunction", "SelectedItemChanged");
                cmd.ExecuteNonQuery();
            }


        }

        private void domainUpDown1_Enter(object sender, EventArgs e)
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        
        private void saveInvoice(object sender, EventArgs e)
        {
            try
            {

                int loggedID =  UsersDL.GetLoggedId();
                var con = Configuration.getInstance().getConnection();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                


                string TotalDiscount = domainUpDown1.Text;
                decimal total = decimal.Parse(label7.Text);
                string formattedTotal = total.ToString("0.00");

                decimal grandTotal = decimal.Parse(label8.Text);
                string formattedGrandTotal = grandTotal.ToString("0.00");

                decimal payment = decimal.Parse(label9.Text);
                string formattedPayment = payment.ToString("0.00");

                string totalDiscountStr = domainUpDown1.Text;
                int invoiceOrderId = 0;

                // Check if the CNIC already exists in the Patient table
                string cnic = SearchId.Text;
                string email = "", address = "", phoneno = "", name = "";
                int PatientId = -1, PersonId = -1; 
                bool flag = false;
                DateTime CreateAt= DateTime.Now;
                Patient oo = new Patient() ;
                if (SearchId.Text !="")
                {
                    SqlCommand checkCnicCmd = new SqlCommand("SELECT COUNT(*) FROM Patient WHERE CNIC=@CNIC", con);
                    checkCnicCmd.Parameters.AddWithValue("@CNIC", cnic);
                    int count = (int)checkCnicCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        foreach (Patient o in PatientDL.GetPatientList())
                        {
                            if (o.GetCNIC() == cnic)
                            {
                                email = o.GetEmail();
                                address = o.GetAddress();
                                phoneno = o.GetPhoneNo();
                                name = o.GetUsername();
                                PersonId= o.GetPersonId();
                                PatientId = o.GetID();
                                CreateAt = o.getCreateAt();
                                flag = true;
                                oo = o;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("A patient with this CNIC not exists. FirstAdd in patientTable ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
          
                if (decimal.TryParse(totalDiscountStr, out decimal totalDiscount))
                {
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO Invoice (CreatedAt,UpdatedAt,Active,InvoiceDate, LoggedID, TotalDiscount, Total, GrandTotal, Payment) OUTPUT INSERTED.InvoiceID VALUES (@CreatedAt,@UpdatedAt,@Active, @InvoiceDate, @LoggedID, @TotalDiscount, @Total, @GrandTotal, @Payment)", con);
                    cmd2.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                    cmd2.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    cmd2.Parameters.AddWithValue("@Active", "Active");
                    cmd2.Parameters.AddWithValue("@InvoiceDate", DateTime.Now);
                    cmd2.Parameters.AddWithValue("@LoggedID", loggedID);
                    cmd2.Parameters.AddWithValue("@Total", formattedTotal);
                    cmd2.Parameters.AddWithValue("@TotalDiscount", totalDiscountStr);
                    cmd2.Parameters.AddWithValue("@GrandTotal", formattedGrandTotal);
                    cmd2.Parameters.AddWithValue("@Payment", formattedPayment);

                    invoiceOrderId = (int)cmd2.ExecuteScalar();

                    SqlCommand cmd5 = new SqlCommand("INSERT INTO TotalInvoices (CreatedAt,UpdatedAt,Active,InvoiceID, TotalPrice) VALUES (@CreatedAt,@UpdatedAt,@Active,@InvoiceID, @TotalPrice)", con);
                    cmd5.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                    cmd5.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    cmd5.Parameters.AddWithValue("@Active", "Active");
                    cmd5.Parameters.AddWithValue("@InvoiceID", invoiceOrderId);
                    cmd5.Parameters.AddWithValue("@TotalPrice", formattedPayment);
                    cmd5.ExecuteNonQuery();


                    if (flag == true )
                    {
                        //update in the person table 
                        cmd5 = new SqlCommand("UPDATE Person set UpdatedAt = @UpdatedAt , LoggedID =@LoggedID where Name = @Name and ID = @ID ", con);
                        cmd5.Parameters.AddWithValue("@ID", PersonId);
                        cmd5.Parameters.AddWithValue("@Name", name);
                        cmd5.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd5.Parameters.AddWithValue("@LoggedID", UsersDL.GetLoggedId());
                        cmd5.ExecuteNonQuery();

                        //update in the patient table 
                        cmd5 = new SqlCommand("UPDATE Patient set  UpdatedAt = @UpdatedAt ,InvoiceID = @InvoiceID where PersonID = @PersonID  ",con);
                        cmd5.Parameters.AddWithValue("@PersonID", PersonId);
                        cmd5.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd5.Parameters.AddWithValue("@InvoiceID", invoiceOrderId);
                        cmd5.ExecuteNonQuery();

                        // Patient Audit Table Query insert 
                        cmd5 = new SqlCommand("insert into PatientAudit values (@PatientId,@CreatedAt , @UpdatedAt , @Active, @CNIC ,@InvoiceID )", con);
                        cmd5.Parameters.AddWithValue("@PatientId", PatientId);
                        cmd5.Parameters.AddWithValue("@CreatedAt", CreateAt);
                        cmd5.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd5.Parameters.AddWithValue("@Active", "Active");
                        cmd5.Parameters.AddWithValue("@CNIC", cnic);
                        cmd5.Parameters.AddWithValue("@InvoiceID", invoiceOrderId);
                        int PatientAuditId = (int)cmd5.ExecuteNonQuery();

                        // PersonAudit Table Query  insert
                        cmd5 = new SqlCommand("insert into PersonAudit values (@CreatedAt , @UpdatedAt , @Active , @PersonId, @OldName ,@OldEmail , @OldAddress , @OldPhoneNo, @NewName ,@NewEmail , @NewAddress , @NewPhoneNo ,@LoggedID)", con);
                        cmd5.Parameters.AddWithValue("@CreatedAt", CreateAt);
                        cmd5.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd5.Parameters.AddWithValue("@Active", "Active");
                        cmd5.Parameters.AddWithValue("@OldName", name);
                        cmd5.Parameters.AddWithValue("@OldEmail", email);
                        cmd5.Parameters.AddWithValue("@OldAddress", address);
                        cmd5.Parameters.AddWithValue("@OldPhoneNo", phoneno);
                        cmd5.Parameters.AddWithValue("@PersonId", PersonId);
                        cmd5.Parameters.AddWithValue("@NewName", name);
                        cmd5.Parameters.AddWithValue("@NewEmail", email);
                        cmd5.Parameters.AddWithValue("@NewAddress", address);
                        cmd5.Parameters.AddWithValue("@NewPhoneNo", phoneno);
                        cmd5.Parameters.AddWithValue("@LoggedID", UsersDL.GetLoggedId());
                        int PersonAuditId = (int)cmd5.ExecuteNonQuery();

                        oo.SetInvoiceId(invoiceOrderId);
                        oo.SetUpdatedAt(DateTime.Now);
                        oo.SetUserLogg(UsersDL.GetLoggedUser());
                    }

                   
                }
                else
                {
                    MessageBox.Show("Invalid Total Discount value. Please enter a valid decimal number.");
                }


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string productName = row.Cells["Name"].Value.ToString();
                    int batchNo = int.Parse(row.Cells["Batch ID"].Value.ToString());
                    string batch = row.Cells["Batch ID"].Value.ToString();
                    string StockId = row.Cells["Stock ID"].Value.ToString();
                    int StockIdD = int.Parse(row.Cells["Stock ID"].Value.ToString());
                    int quantity = int.Parse(row.Cells["Avail Quantity"].Value.ToString());
                   

                    decimal discount = 0;
                    if (decimal.TryParse(row.Cells["Discount"].Value.ToString(), out decimal parsedDiscount))
                    {
                        string formattedDiscount = parsedDiscount.ToString("0.00");
                        decimal.TryParse(formattedDiscount, out discount);
                    }

                    AddItemForInvoice item = AddItemForInvoiceDL.AddItemForInvoices.Find(i => i.name == productName && i.batchID == batch && i.stockID == StockId);

                    if (item != null)
                    {
                        int productId = int.Parse(item.productID);

                        SqlCommand cmd = new SqlCommand("INSERT INTO Invoice_Order (CreatedAt,UpdatedAt,Active,  InvoiceOrderID, ProductID , StockID , Quantity, BatchNo, DiscountOnProduct) VALUES (@CreatedAt,@UpdatedAt,@Active, @InvoiceOrderID, @ProductID, @StockIdD , @Quantity, @BatchNo, @DiscountOnProduct)", con);
                        cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Active", "Active");
                        cmd.Parameters.AddWithValue("@InvoiceOrderID", invoiceOrderId); // set the unique InvoiceOrderID value for the current row
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        cmd.Parameters.AddWithValue("@StockIdD", StockIdD);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@BatchNo", batchNo);
                        cmd.Parameters.AddWithValue("@DiscountOnProduct", discount);

                        cmd.ExecuteNonQuery();

                        SqlCommand cmd2 = new SqlCommand("UPDATE StockItems SET UpdatedAt = @UpdatedAt, Quantity = Quantity - @quantity WHERE ProductID = @ProductID AND StockID = @stockIdD", con);
                        cmd2.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd2.Parameters.AddWithValue("@quantity", quantity);
                        cmd2.Parameters.AddWithValue("@ProductID", productId);
                        cmd2.Parameters.AddWithValue("@stockIdD", StockIdD);
                        cmd2.ExecuteNonQuery();


                    }
                }

                

                MessageBox.Show("Invoice saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AddItemForInvoiceDL.ClearItems();

                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                SearchId.Text = "";
                label7.Text = "";
                label8.Text = "";
                label9.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving invoice: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", ex.Message);
                cmd.Parameters.AddWithValue("@LogClass", "CreateInvoice");
                cmd.Parameters.AddWithValue("@LogFunction", "SaveInvoice");
                cmd.ExecuteNonQuery();
            }
        }


        private void iconButton8_Click(object sender, EventArgs e)
        {
            try
            {


                // Prompt the user for confirmation before clearing the data
                DialogResult result = MessageBox.Show("Are you sure you want to clear the data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Clear the data if the user confirms
                    AddItemForInvoiceDL.ClearItems();

                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    // Clear the text fields after successful insertion
                    SearchId.Text = "";

                }
            }
            catch (Exception ex)
            {
                SqlCommand cmd;
                var con = Configuration.getInstance().getConnection();
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", ex.Message);
                cmd.Parameters.AddWithValue("@LogClass", "CreateInvoice");
                cmd.Parameters.AddWithValue("@LogFunction", "ClearButton");
                cmd.ExecuteNonQuery();
            }
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            if(SearchId.Text.Length != 13)
            {
                MessageBox.Show("length is not correct");
                return; 
            }
            var con = Configuration.getInstance().getConnection();
            try
            {


                if (SearchId.Text != "")
                {
                    SqlCommand checkCnicCmd = new SqlCommand("SELECT COUNT(*) FROM Patient WHERE CNIC=@CNIC", con);
                    checkCnicCmd.Parameters.AddWithValue("@CNIC", SearchId.Text);
                    int count = (int)checkCnicCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("patient Find", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        MessageBox.Show("A patient with this CNIC not exists. FirstAdd in patientTable ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch(Exception ex)
            {
                SqlCommand cmd;
                cmd = new SqlCommand("insert into LOGS values (@CreatedAt , @LogTitle , @LogClass , @LogFunction)", con);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogTitle", ex.Message);
                cmd.Parameters.AddWithValue("@LogClass", "CreateInvoice");
                cmd.Parameters.AddWithValue("@LogFunction", "SearchButton");
                cmd.ExecuteNonQuery();
            }    
        }

        private void CreateInvoice_Load(object sender, EventArgs e)
        {

        }
    }
}
