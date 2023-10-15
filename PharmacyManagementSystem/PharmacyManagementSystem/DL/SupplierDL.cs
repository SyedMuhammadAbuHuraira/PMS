using PharmacyManagementSystem.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PharmacyManagementSystem.DL
{
    class SupplierDL
    {
        private static List<Supplier> SupplierInfo = new List<Supplier>();

        public static void loadData()
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select s.CreatedAt ,s.UpdatedAt , s.Active,  s.ID , p.ID , p.Name,p.Address,p.PhoneNo,p.Email,p.LoggedID from Supplier as s join Person as p on s.PersonID = p.ID", con);
            SqlDataReader reader = cmd.ExecuteReader();
            Supplier obj;
            string name = "";
            SqlCommand cmmd;
            while (reader.Read())
            {
                foreach (Users s in UsersDL.GetUsersList())
                {
                    if (reader.GetInt32(9) == s.GetID())
                    {
                        name = s.GetUsername();
                    }
                }
                obj = new Supplier(reader.GetDateTime(0) , reader.GetDateTime(1),reader.GetString(2),reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), name);
                addIntoList(obj);
            }
            reader.Close();
        }
        public static void addIntoList(Supplier ob)
        {
            SupplierInfo.Add(ob);
        }
        public static List<Supplier> GetSupplierList()
        {
            return SupplierInfo;
        }

        public static bool isExistEmail(string email)
        {
            foreach (Supplier obj in SupplierDL.GetSupplierList())
            {
                if (obj.GetEmail() == email)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }
        public static bool isExistAddress(string address)
        {
            foreach (Supplier obj in SupplierDL.GetSupplierList())
            {
                if (obj.GetAddress() == address)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }
        public static bool isExist(string name)
        {
            foreach (Supplier obj in SupplierDL.GetSupplierList())
            {
                if (obj.GetUsername() == name)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }
        public static bool isValid(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (regex.IsMatch(email))
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        public static bool isExistEmail(string email, string name)
        {
            foreach (Supplier obj in SupplierDL.GetSupplierList())
            {
                if (obj.GetUsername() != name && obj.GetEmail() == email)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }
        public static bool isExistAddress(string address, string name)
        {
            foreach (Supplier obj in SupplierDL.GetSupplierList())
            {
                if (obj.GetUsername() != name && obj.GetAddress() == address)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }
    }
}
