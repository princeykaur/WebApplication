using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ClaimsController : ApiController
    {
        [Route("Claims/GetClaims")]
        public List<ClaimsModel> GetClaims()
        {
            ReadDataFromCSV obj = new ReadDataFromCSV();
            var memberData = obj.GetMemberData();
            var claimData = obj.GetClaimData();

            var data = (from m in memberData
                        join c in claimData on m.MemberID equals c.MemberID
                        select new ClaimsModel
                        {
                            MemberID = m.MemberID,
                            EnrollmentDate = m.EnrollmentDate,
                            FirstName = m.FirstName,
                            LastName = m.LastName,
                            ClaimDetails = c
                        }).ToList();

            return data;
        }
    }
}
