using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ReadDataFromCSV
    {
        public List<Member> GetMemberData()
        {
            var csvData = new DataTable();

            using (var csvReader = new CsvReader(new StreamReader(File.OpenRead(@"C:\Users\Princey\Downloads\WebAPI-SampleProject\Member.csv"), true)))
            {
                csvData.Load(csvReader);
            }
            var data = csvData.AsEnumerable().Select(row =>
            new Member
            {
                MemberID = Convert.ToInt32(row.Field<object>("MemberID")),
                FirstName = Convert.ToString(row.Field<object>("FirstName")),
                LastName = Convert.ToString(row.Field<object>("LastName")),
                EnrollmentDate = Convert.ToDateTime(row.Field<object>("EnrollmentDate"))
            }).ToList();
            return data;
        }


        public List<Claim> GetClaimData()
        {
            var csvData = new DataTable();

            using (var csvReader = new CsvReader(new StreamReader(File.OpenRead(@"C:\Users\Princey\Downloads\WebAPI-SampleProject\Claim.csv"), true)))
            {
                csvData.Load(csvReader);
            }

            var data = csvData.AsEnumerable().Select(row =>
             new Claim
             {
                 MemberID = Convert.ToInt32(row.Field<object>("MemberID")),
                 ClaimAmount = Convert.ToDecimal(row.Field<object>("ClaimAmount")),
                 ClaimDate = Convert.ToDateTime(row.Field<object>("ClaimDate"))
             }).ToList();


            return data;
        }
    }
}