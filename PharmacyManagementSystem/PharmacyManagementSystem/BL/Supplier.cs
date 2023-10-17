using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.BL
{
    class Supplier:ParentI
    {
        public  Supplier(DateTime CreatedAt, DateTime UpdatedAt, string Active,int SupplierId ,int PersonID, string Name ,  string Address , string phoneNo, string Email, string loggedUser) : base(CreatedAt, UpdatedAt, Active,PersonID, Name, Address, phoneNo, Email, loggedUser)
        {
            this.SupplierID = SupplierId;
        }

        private int SupplierID;
        public string GetUsername()
        {
            return name;
        }
        public string GetAddress()
        {
            return address;
        }

        public void SetAddress(string add)
        {
            this.address = add;
        }
        public void SetPhoneNo(string contact)
        {
            this.PhoneNo = contact;
        }
        public void SetUserLogg(string logUser)
        {
            this.logUser = logUser;
        }

        public string GetEmail()
        {
            return Email;
        }

        public void SetEmail(string Email)
        {
            this.Email = Email;
        }

        public int GetID()
        {
            return this.SupplierID;
        }

        public string GetPhoneNo()
        {
            return this.PhoneNo;
        }

        public string GetUserLogg()
        {
            return this.logUser;
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
        public int GetPersonId()
        {
            return PersonId;
        }
    }
}
