using PharmacyManagementSystem.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.BL
{
    internal class Stock
    {
        public int StockID;
        public Product products;
        public Supplier Supplier;
        public int BatchNo;
        public int Quantity;
        public string loggedUser;
        public string Address;
        public string PhoneNo;

    }
}
