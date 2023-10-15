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
    class PatientDL
    {
        public static List<Patient> PatientInfo = new List<Patient>();

        public static void loadData()
        {

             var con = Configuration.getInstance().getConnection();
             SqlCommand cmd = new SqlCommand("select pp.CreatedAt ,pp.UpdatedAt , pp.Active,pp.ID ,pp.CNIC, p.ID , p.Name,p.Address,p.PhoneNo,p.Email,p.LoggedID from Patient as pp join Person as p on pp.PersonID = p.ID", con);
             SqlDataReader reader = cmd.ExecuteReader();
             Patient obj;
             string name = "";
             SqlCommand cmmd;
             while (reader.Read())
             {
                 foreach (Users s in UsersDL.GetUsersList())
                 {
                     if (reader.GetInt32(10) == s.GetID())
                     {
                         name = s.GetUsername();
                     }
                 }
                 obj = new Patient(reader.GetDateTime(0), reader.GetDateTime(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), name);
                 addIntoList(obj);
             }
             reader.Close();
        }
        public static void addIntoList(Patient ob)
        {
            PatientInfo.Add(ob);
        }
        public static List<Patient> GetPatientList()
        {
            return PatientInfo;
        }

        public static bool isExistEmail(string email)
        {
            foreach (Patient obj in PatientDL.GetPatientList())
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
        public static bool isExistCNIC(string CNIC)
        {
            foreach (Patient obj in PatientDL.GetPatientList())
            {
                if (obj.GetCNIC() == CNIC)
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
        public static bool isExist(string name , string CNIC) 
        {
            foreach (Patient obj in PatientDL.GetPatientList())
            {
                if (obj.GetUsername() == name && obj.GetCNIC() == CNIC)
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
            foreach (Patient obj in PatientDL.GetPatientList())
            {
                if (obj.GetUsername() != name && obj.GetEmail() == email)
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
        /*public static bool isExistAddress(string address, string name)
        {
            foreach (Patient obj in PatientDL.GetPatientList())
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
        }*/
    }
}
