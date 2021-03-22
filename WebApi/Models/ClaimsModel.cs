using System;
using WebApi.Models;

namespace WebApi.Models
{
    public class ClaimsModel
    {
        public int MemberID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Claim ClaimDetails { get; set; }
    }
}
