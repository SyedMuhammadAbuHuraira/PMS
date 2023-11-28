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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TotalIncome_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd;
            cmd = new SqlCommand("SELECT COUNT(*) FROM Users ", con);
            int Users = (int)cmd.ExecuteScalar();
            userlbl.Text = Users.ToString();

            cmd = new SqlCommand("SELECT COUNT(*) FROM Patient ", con);
            int Patients = (int)cmd.ExecuteScalar();
            patientlbl.Text = Patients.ToString();

            cmd = new SqlCommand("SELECT COUNT(*) FROM Manufacturer ", con);
            int Manufactureres = (int)cmd.ExecuteScalar();
            manufacturelbl.Text = Manufactureres.ToString();

            cmd = new SqlCommand("SELECT COUNT(*) FROM Supplier ", con);
            int Suppliers = (int)cmd.ExecuteScalar();
            supplierlbl.Text = Suppliers.ToString();

            cmd = new SqlCommand("SELECT COUNT(*) FROM Invoice ", con);
            int Invoices = (int)cmd.ExecuteScalar();
            invoiceslbl.Text = Invoices.ToString();

            cmd = new SqlCommand("SELECT COUNT(*) FROM StockItems where Quantity = 0 ", con);
            int OutOfStock = (int)cmd.ExecuteScalar();
            outofstocklblb.Text = OutOfStock.ToString();

            cmd = new SqlCommand("SELECT COUNT(*) FROM StockItems where ExpiredDate IS NOT NULL and ExpiredDate <= @date   ", con);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            int ExpiredProduct = (int)cmd.ExecuteScalar();
            expiryproductlbl.Text = ExpiredProduct.ToString();
           

            cmd = new SqlCommand("SELECT COUNT(*) FROM Stock ", con);
            int Products = (int)cmd.ExecuteScalar();
            productlbl.Text = Products.ToString();

            cmd = new SqlCommand("SELECT SUM(CAST(Payment AS DECIMAL(18, 2))) AS TotalPayment FROM Invoice WHERE TRY_CAST(Payment AS DECIMAL(18, 2)) IS NOT NULL", con);
            decimal TotalRevenue = (decimal)cmd.ExecuteScalar();
            TotalIncome.Text = "Rs: " + TotalRevenue.ToString("0.00") ;


        }
    }
}
