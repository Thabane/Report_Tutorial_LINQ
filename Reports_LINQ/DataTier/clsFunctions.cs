using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class clsFunctions
    {
        public static List<authors> GetAllAuthors()
        {
            PubsEntities Context = new PubsEntities();
            return Context.authors.ToList();
        }
        
        public static List<Emp_Details> EmployeeDetailsReport(string pub_id)
        {
            PubsEntities Context = new PubsEntities();
            var Emp_data = from emp in Context.employee
                           join det in Context.jobs on emp.job_id equals det.job_id
                           join pub in Context.publishers on emp.pub_id equals pub.pub_id
                           where emp.pub_id == pub_id
                           select new Emp_Details
                           {
                               FirstName = emp.fname,
                               LastName = emp.lname,
                               JobDescription = det.job_desc,
                               Publisher = pub.pub_name
                           };
        }

        //Custom Object
        public class Emp_Details
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string JobDescription { get; set; }
            public string Publisher { get; set; }
        }
    }
}
