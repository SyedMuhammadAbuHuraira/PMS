using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.BL
{
    internal class Manufacturer : ParentI
    {
        public Manufacturer(DateTime CreatedAt, DateTime UpdatedAt, string Active,   int Id ,int PersonId,string name , string address , string phonNo , string Email, string logUser) : base(CreatedAt,UpdatedAt,  Active,PersonId, name,  address,  phonNo, Email,  logUser)
        {
            this.Id = Id;
        }
        private int Id;

        public int GetID()
        {
            return this.Id;
        }
        public  string GetUsername()
        {
            return name;
        }
        public string GetAddress()
        {
            return address;
        }

        public  void SetAddress(string add)
        {
            this.address = add;
        }
        public  void SetPhoneNo(string contact)
        {
            this.PhoneNo = contact;
        }
        public void SetUserLogg(string logUser)
        {
            this.logUser = logUser;
        }
        public string GetUserLogg()
        {
           return  this.logUser ;
        }
        public string GetPhoneNo()
        {
            return this.PhoneNo;
        }

        public string GetEmail()
        {
            return Email;
        }

        public void SetEmail(string Email)
        {
            this.Email = Email;
        }
        public int GetPersonId()
        {
            return PersonId;
        }
        public void SetUpdatedAt(DateTime UpdatedTime)
        {
            this.UpdatedAt = UpdatedTime;
        }
        public DateTime GetUpdatedAt()
        {
            return this.UpdatedAt;
        }
        public string GetStatus()
        {
            return this.Active;
        }
        public DateTime GetCreateAt()
        {
            return this.CreatedAt;
        }
        public void SetStatus(string Status)
        {
            this.Active = Status;
        }
    }
}
