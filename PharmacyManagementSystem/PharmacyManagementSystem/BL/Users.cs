using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PharmacyManagementSystem.BL
{
   class Users
    {
        public Users(DateTime CreatedAt, DateTime UpdatedAt, string Active, int Id , string username ,string password, string role )
        {
            this.CreatedAt = CreatedAt;
            this.UpatedAt = UpdatedAt;
            this.Active = Active;
            this.Id = Id;
            this.username = username;
            this.password = password;
            this.role = role;
        }

        private DateTime CreatedAt;
        private DateTime UpatedAt;
        private string Active;
        private int Id;
        private string username;
        private string password;
        private string role;

        public string GetUsername()
        {
            return this.username;
        }
        public string GetPassword()
        {
            return this.password;
        }

        public string GetRole()
        {
            return this.role;
        }
        public int  GetID()
        {
            return this.Id;
        }
        public void SetUsername(string username)
        {
            this.username = username;
        }
        public void SetPassword(string pass)
        {
            this.password = pass;
        }
        public void SetRole(string role)
        {
            this.role = role;
        }

        public string GetStatus()
        {
            return this.Active;
        }
        public void SetStatus(string status)
        {
            this.Active = status;
        }

        public DateTime GetCreatedAt()
        {
            return this.CreatedAt;
        }
        public DateTime GetUpdatedAt()
        {
            return this.UpatedAt;    
        }
        public void SetUpdatedAt(DateTime Time)
        {
            this.UpatedAt = Time ;
        }
    }
}
