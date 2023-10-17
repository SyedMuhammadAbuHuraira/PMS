using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.BL
{
    class Additemforstock
    {
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
        public string Active;
        public string productID;
        public string Company;
        public string Supplier;
        public string name;
        public string type;
        public string Costprice;
        public string Retailprice;
        public string batchID;
        public string Expiry_Date;
        public string Quantity;
        public string Conversionableunit;
        public string Margin;
        public string Sub_total;

        public  Additemforstock(DateTime CreatedAt, DateTime UpdatedAt , String Active ,  string ProductID,string Company,string Supplier,string Name,String Type, string costprice,string retailprice,string Margin,string Conversionableunit,string Sub_total)
        {
            this.CreatedAt= CreatedAt;
            this.UpdatedAt= UpdatedAt;
            this.Active= Active;
            this.productID = ProductID;
            this.Company = Company;
            this.Supplier = Supplier;
            this.name = Name;
            this.type = Type;
            this.Costprice = costprice;
            this.Retailprice = retailprice;
            this.Margin = Margin;
            this.Conversionableunit = Conversionableunit;
            this.Quantity = 1.ToString();
            this.Sub_total = Sub_total;


        }
    }
}
