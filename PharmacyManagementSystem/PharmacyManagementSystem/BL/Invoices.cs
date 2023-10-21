using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.BL
{
    internal class Invoices
    {
        public string Date;
        public InvoiceOrder Orders;
        public string loggedUser;
        public string totalDiscount;
        public string GrandTotal;
    }
}
