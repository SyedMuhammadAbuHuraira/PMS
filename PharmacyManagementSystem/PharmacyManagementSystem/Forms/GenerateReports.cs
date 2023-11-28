using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using OfficeOpenXml.Style;

namespace PharmacyManagementSystem.Forms
{
    public partial class GenerateReports : Form
    {
        public GenerateReports()
        {
            InitializeComponent();
           
            
        }

        private void SalesReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                {
                    // Code to be executed only during design-time
                }
                else
                {
                    // Code to be executed during run-time
                }

                var con = Configuration.getInstance().getConnection();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                DateTime startDate = dateTimePicker1.Value;
                DateTime endDate = dateTimePicker2.Value;

                // Construct the parameterized SQL query
                SqlCommand cmd2 = new SqlCommand("SELECT \r\n    Products.Name, \r\n    Products.Type, \r\n    CAST(Products.RetailPrice / CAST(Products.ConversionalUnit AS decimal(5,2)) AS decimal(18,2)) AS ActualPrice, \r\n    CAST(Invoice.Payment AS decimal(18,2)) AS Payment, \r\n    CAST(Invoice.GrandTotal AS decimal(18,2)) AS GrandTotal, \r\n    CAST(Invoice.TotalDiscount AS decimal(18,2)) AS Discount, \r\n    CAST(Invoice.Total AS decimal(18,2)) AS Total \r\nFROM \r\n    Invoice \r\n    INNER JOIN Invoice_Order ON Invoice.InvoiceID = Invoice_Order.InvoiceOrderID \r\n    INNER JOIN Products ON Invoice_Order.ProductID = Products.ProductID \r\nWHERE \r\n    Invoice.InvoiceDate BETWEEN @StartDate AND @EndDate\r\n", con);
                cmd2.Parameters.AddWithValue("@StartDate", startDate);
                cmd2.Parameters.AddWithValue("@EndDate", endDate);

                // Execute the query and create a DataTable to hold the results
                SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

               
                // Create a new Excel workbook and worksheet
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sales Report");
                    // Set the big header "Sales Report"
                    worksheet.Cells["A1"].Value = "Sales Report";
                    worksheet.Cells["A1:H8"].Merge = true;
                    worksheet.Cells["A1"].Style.Font.Size = 24;
                    worksheet.Cells["A1"].Style.Font.Bold = true;
                    worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells["A1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    // Set the subtitle "Start Date - End Date"
                    worksheet.Cells["A9"].Value = "Start Date:";
                    worksheet.Cells["B9"].Value = startDate.ToString("yyyy-MM-dd");
                    worksheet.Cells["C9"].Value = "End Date:";
                    worksheet.Cells["D9"].Value = endDate.ToString("yyyy-MM-dd");

                    // Add two empty rows
                    worksheet.Cells["A10:H11"].Merge = true;

                    // Write the column headers to the worksheet
                    for (int i = 1; i <= dataTable.Columns.Count; i++)
                    {
                        worksheet.Cells[12, i].Value = dataTable.Columns[i - 1].ColumnName;
                    }

                    // Write the data rows to the worksheet
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 13, j + 1].Value = dataTable.Rows[i][j].ToString();
                        }
                    }

                    // Calculate the total sales
                    decimal totalSales = 0;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        totalSales += Convert.ToDecimal(row["Payment"]);
                    }

                    // Add an empty row
                    worksheet.Cells[dataTable.Rows.Count + 14, 1].Value = "";

                    // Write the total sales to the worksheet
                    worksheet.Cells[dataTable.Rows.Count + 15, dataTable.Columns.Count - 1].Value = "Total Sales";
                    worksheet.Cells[dataTable.Rows.Count + 15, dataTable.Columns.Count].Value = totalSales;

                    // Auto-fit the columns
                    worksheet.Cells.AutoFitColumns();
                    // Save the Excel file to disk and open it
                    string fileName = "SalesReport.xlsx";
                    string savePath = @"C:\Users\MUHAMMAD BURHAN\OneDrive\Desktop\Semester 5\SE LAB\BURHAN\" + fileName;
                    FileInfo fileInfo = new FileInfo(savePath);
                    excelPackage.SaveAs(fileInfo);

                    MessageBox.Show("Sales report generated successfully and saved as " + fileName);
                    System.Diagnostics.Process.Start(savePath);
                        
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching the Sales Report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                {
                    // Code to be executed only during design-time
                }
                else
                {
                    // Code to be executed during run-time
                }

                var con = Configuration.getInstance().getConnection();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                
                DateTime startDate = dateTimePicker1.Value;
                DateTime endDate = dateTimePicker2.Value;

                // Construct the parameterized SQL query
                SqlCommand cmd2 = new SqlCommand("SELECT \r\n    Products.Name, \r\n    Products.Type, \r\n    Products.Supplier as SupplierName, \r\n    StockItems.StockID, \r\n    StockItems.ExpiredDate \r\nFROM \r\n    StockItems \r\n    INNER JOIN Products ON Products.ProductID = StockItems.ProductID \r\nWHERE \r\n    StockItems.ExpiredDate BETWEEN @StartDate AND @EndDate\r\n", con);
                cmd2.Parameters.AddWithValue("@StartDate", startDate);
                cmd2.Parameters.AddWithValue("@EndDate", endDate);


                // Execute the query and create a DataTable to hold the results
                SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);


                // Create a new Excel workbook and worksheet
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Dead Stock Report");
                    // Set the big header "Sales Report"
                    worksheet.Cells["A1"].Value = "DEAD STOCK REPROT";
                    worksheet.Cells["A1:H8"].Merge = true;
                    worksheet.Cells["A1"].Style.Font.Size = 24;
                    worksheet.Cells["A1"].Style.Font.Bold = true;
                    worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells["A1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    // Set the subtitle "Start Date - End Date"
                    worksheet.Cells["A9"].Value = "Start Date:";
                    worksheet.Cells["B9"].Value = startDate.ToString("yyyy-MM-dd");
                    worksheet.Cells["C9"].Value = "End Date:";
                    worksheet.Cells["D9"].Value = endDate.ToString("yyyy-MM-dd");

                    // Add two empty rows
                    worksheet.Cells["A10:H11"].Merge = true;

                    // Write the column headers to the worksheet
                    for (int i = 1; i <= dataTable.Columns.Count; i++)
                    {
                        worksheet.Cells[12, i].Value = dataTable.Columns[i - 1].ColumnName;
                    }

                    // Write the data rows to the worksheet
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 13, j + 1].Value = dataTable.Rows[i][j].ToString();
                        }
                    }

                  

                    // Add an empty row
                    worksheet.Cells[dataTable.Rows.Count + 14, 1].Value = "";

                   
                    // Auto-fit the columns
                    worksheet.Cells.AutoFitColumns();
                    // Save the Excel file to disk and open it
                    string fileName = "DeadStockReport.xlsx";
                    string savePath = @"C:\Users\MUHAMMAD BURHAN\OneDrive\Desktop\Semester 5\SE LAB\BURHAN\" + fileName;
                    FileInfo fileInfo = new FileInfo(savePath);
                    excelPackage.SaveAs(fileInfo);

                    MessageBox.Show("DeadStock report generated successfully and saved as " + fileName);
                    System.Diagnostics.Process.Start(savePath);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching the Sales Report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
