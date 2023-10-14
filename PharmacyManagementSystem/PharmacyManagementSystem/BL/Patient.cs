using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PharmacyManagementSystem.BL
{
    class Patient : ParentI
    {
        private int PatientId;
        private string nic;
        private int InvoiceId;
        public Patient():base()
        {

        }
        public Patient(DateTime CreatedAt , DateTime UpdatedAt , string Active ,int PatientId, string nic, int PersonID, string Name, string Address, string phoneNo, string Email, string loggedUser) : base(CreatedAt, UpdatedAt , Active, PersonID, Name, Address, phoneNo, Email, loggedUser)
        {
            this.PatientId = PatientId;
            this.nic = nic;

        }
        public int GetPersonId()
        {
            return this.PersonId;
        }
        public string GetUsername()
        {
            return this.name;
        }
        public string GetAddress()
        {
            return this.address;
        }

        public void SetAddress(string add)
        {
            this.address = add;
        }
        public string GetCNIC()
        {
            return this.nic;
        }

        public void SetCNIC(string nic)
        {
            this.nic = nic;
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
            return this.Email;
        }

        public void SetEmail(string Email)
        {
            this.Email = Email;
        }
        public int GetID()
        {
            return this.PatientId;
        }

        public string GetPhoneNo()
        {
            return this.PhoneNo;
        }

        public string GetUserLogg()
        {
            return this.logUser;
        }

        public DateTime getCreateAt()
        {
            return this.CreatedAt;
        }

        public  void SetUpdatedAt(DateTime UpdatedTime)
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
        public void SetStatus(string Status)
        {
            this.Active = Status;
        }
        public void SetInvoiceId(int id )
        {
            this.InvoiceId = id;
        }
        public int GetInvoiceId()
        {
           return  this.InvoiceId ;
        }
    }
}
