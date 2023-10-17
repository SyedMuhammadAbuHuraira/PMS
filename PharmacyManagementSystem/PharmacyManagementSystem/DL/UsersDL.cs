using PharmacyManagementSystem.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.DL
{
    class UsersDL
    {
           private static string temp;
        private static int tempId;
        private static  List<Users> UsersInfo = new List<Users>();
        public  static void addIntoList(Users obj)
        {
            UsersInfo.Add(obj);

        }
        public static void SetLoggedUser(string Id)
        {
            temp = Id;
        }

        public static string GetLoggedUser()
        {
           return temp;
        }

         public static void SetLoggedId(int Id)
        {
            tempId = Id;
        }

        public static int GetLoggedId()
        {
            return tempId;
        }
        public static int GetID()
        {
            return tempId;
        }
        public static List<Users> GetUsersList()
    {
        return UsersInfo;
    }

        public static void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * from Users", con);
            SqlDataReader reader = cmd.ExecuteReader();
            Users obj;
            while (reader.Read())
            {
                 obj = new Users(reader.GetDateTime(0), reader.GetDateTime(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                 addIntoList(obj);

            }
            reader.Close();
        }
        public static bool isExistRole(string role )
        {
            foreach (Users obj in UsersDL.GetUsersList())
            {
                if (obj.GetRole() == role )
                {
                    return true;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }
        public static bool isExistRolee(string role, string name)
        {
            foreach (Users obj in UsersDL.GetUsersList())
            {
                if (obj.GetRole() == role && obj.GetUsername() != name)
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
        public static bool isExistPassword(string pass)
        {
            foreach (Users obj in UsersDL.GetUsersList())
            {
                if (obj.GetPassword() == pass )
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
        public static bool isExistPasswordd(string pass , string name)
        {
            foreach (Users obj in UsersDL.GetUsersList())
            {
                if (obj.GetPassword() == pass && obj.GetUsername() != name)
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
        public static bool isExistUsername(string name)
        {
            foreach (Users obj in UsersDL.GetUsersList())
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

    }
}
