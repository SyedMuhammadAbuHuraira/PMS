using PharmacyManagementSystem.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.DL
{
    class ManufacturerDL
    {


        private static List<Manufacturer> ManufacturerList = new List<Manufacturer>();

        public static void loadData()
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select m.CreatedAt ,m.UpdatedAt , m.Active, m.ID , p.ID , p.Name,p.Address,p.PhoneNo,p.Email,p.LoggedID from Manufacturer as m join Person as p on m.PersonID = p.ID", con);
            SqlDataReader reader = cmd.ExecuteReader();
            
            Manufacturer obj;
            string name = "";
            while (reader.Read())
            {
                foreach(Users s in UsersDL.GetUsersList())
                {
                    if(reader.GetInt32(9) == s.GetID())
                    {
                        name = s.GetUsername();
                    }
                }
                obj = new Manufacturer(reader.GetDateTime(0), reader.GetDateTime(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), name);
                addIntoList(obj);
            }
            reader.Close();
        }
        public static void addIntoList(Manufacturer ob)
        {
            ManufacturerList.Add(ob);
        }
        public static List<Manufacturer> GetManufacturerList()
        {
            return ManufacturerList;
        }

        public static bool isExistEmail(string email)
        {
            foreach (Manufacturer obj in ManufacturerDL.GetManufacturerList())
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
            foreach (Manufacturer obj in ManufacturerDL.GetManufacturerList())
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
        public static bool  isExist(string name)
        {
            foreach (Manufacturer obj in ManufacturerDL.GetManufacturerList())
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
        public static bool isExistEmail(string email , string name)
        {
            foreach (Manufacturer obj in ManufacturerDL.GetManufacturerList())
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
        public static bool isExistAddress(string address , string name)
        {
            foreach (Manufacturer obj in ManufacturerDL.GetManufacturerList())
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
