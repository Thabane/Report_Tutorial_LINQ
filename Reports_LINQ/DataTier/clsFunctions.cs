using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            var Emp_data = (from emp in Context.employee
                           join det in Context.jobs on emp.job_id equals det.job_id
                           join pub in Context.publishers on emp.pub_id equals pub.pub_id
                           where emp.pub_id == pub_id
                           select new Emp_Details
                           {
                               FirstName = emp.fname,
                               LastName = emp.lname,
                               JobDescription = det.job_desc,
                               Publisher = pub.pub_name
                           }).ToList();
            return Emp_data;
        }
        public static bool InsertEntry(string action)
        {
            string lastID = clsXmlConn.LogXML.Descendants("entry").Last().Element("id").Value;
            int ID = Convert.ToInt16(lastID);
            ID++;
            var newLogEntry = new XElement("entry",
                     new XElement("id", ID.ToString()),
                     new XElement("action", action),
                     new XElement("date", System.DateTime.Now.ToShortDateString()),
                     new XElement("time", System.DateTime.Now.ToShortTimeString()));

            clsXmlConn.LogXML.Element("Log").Add(newLogEntry);
            clsXmlConn.LogXML.Save(clsXmlConn.LogXmlPath);

            return true;
        }

        //Custom Object
        public class Emp_Details
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string JobDescription { get; set; }
            public string Publisher { get; set; }
        }
        //Xml Class Conn
        public class clsXmlConn
        {
            //public static string LogXmlPath = System.Web.HttpContext.Current.Server.MapPath("Log.xml");
            public static string LogXmlPath = System.AppDomain.CurrentDomain.BaseDirectory + "~/Log.xml";
            public static XDocument LogXML = XDocument.Load(LogXmlPath);

        }
    }
}
