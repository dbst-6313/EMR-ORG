using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class UserForListDto:IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public int UserOperationClaimId { get; set; }
        public int OperationClaimId { get; set; }
        public string ClaimName { get; set; }
    }
}
