using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.BL
{
    class ParentI
    {
        public ParentI() { }
        public ParentI(DateTime CreatedAt , DateTime UpdatedAt , String Active ,int PersonId, string name, string address, string phonNo, string Email, string logUser) 
        {
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.Active = Active;
            this.PersonId = PersonId;
            this.name = name;
            this.address = address;
            this.PhoneNo = phonNo;
            this.Email = Email;
            this.logUser = logUser;
        }
        protected DateTime CreatedAt;
        protected DateTime UpdatedAt;
        protected string Active;
        protected int PersonId;
        protected string name;
        protected string address;
        protected string PhoneNo;
        protected string Email;
        protected string logUser;
    }
}
