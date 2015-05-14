using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataTier;
using Excel = Microsoft.Office.Interop.Excel;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblDisplay.Text = clsOther.TheString();
    }
    protected void btnSimple_Click(object sender, EventArgs e)
    {
        Excel.Application xlApp = new Excel.Application();
        Excel.Workbook xlBooks = xlApp.Workbooks.Add(1);
        Excel.Worksheet xlSheet = (Excel.Worksheet)xlBooks.Sheets[1];

        xlSheet.Cells[1, 3] = "Author Report";
        xlSheet.Cells[3, 1] = "Author ID";
        xlSheet.Cells[3, 2] = "First Name";
        xlSheet.Cells[3, 3] = "Last Name";
        xlSheet.Cells[3, 4] = "Phone";
        xlSheet.Cells[3, 5] = "Address";

        List<authors> getReport = clsFunctions.GetAllAuthors();
        int counter = 5;
        int TotalAuthors = 0;
        foreach (authors item in getReport)
        {
            xlSheet.Cells[counter, 1] = item.au_id;
            xlSheet.Cells[counter, 2] = item.au_lname;
            xlSheet.Cells[counter, 3] = item.au_fname;
            xlSheet.Cells[counter, 4] = item.phone;
            xlSheet.Cells[counter, 5] = item.address;
            counter++;
            TotalAuthors++;

        }
        xlSheet.Cells[counter + 4, 3] = "Total Records is" + " " + counter;
        xlApp.Visible = true;

        clsFunctions.InsertEntry("Generated Simple Report");

    }
    protected void btnGrouped_Click(object sender, EventArgs e)
    {
        Excel.Application xlApp = new Excel.Application();
        Excel.Workbook xlBooks = xlApp.Workbooks.Add(1);
        Excel.Worksheet xlSheet = (Excel.Worksheet)xlBooks.Sheets[1];

        xlSheet.Cells[1, 3] = "Post VS Users Report";

        //DataTable dtGroup = new DataTable("t");

        List<clsFunctions.Emp_Details> groupedReport = new List<clsFunctions.Emp_Details>();
        
        int intCount = 4;
        int intGroup = 0;
        //dtGroup.Rows[0]["UserID"].ToString();
        string temp = groupedReport.First().JobDescription;

        foreach (clsFunctions.Emp_Details item in groupedReport)
        {
            if (item.JobDescription == temp)
            {
                xlSheet.Cells[intCount, 1] = item.FirstName;
                xlSheet.Cells[intCount, 2] = item.LastName;
                xlSheet.Cells[intCount, 3] = item.JobDescription;
                xlSheet.Cells[intCount, 4] = item.Publisher;
                intCount++;
                intGroup++;
            }
            else
            {
                xlSheet.Cells[intCount, 1] = item.FirstName;
                xlSheet.Cells[intCount, 2] = item.LastName;
                xlSheet.Cells[intCount, 3] = item.JobDescription;
                xlSheet.Cells[intCount, 4] = item.Publisher;
               xlSheet.Cells[intCount + 1, 4] ="Total authors are "+ intGroup;
               intGroup = 0;

               temp = item.JobDescription;
               

                xlSheet.Cells[intCount + 3, 4] = temp;
                intCount=  intCount + 2;


            }
        }
        
        //int i = 0;
        
        //for ( i = 0; i <dtGroup.Rows.Count; i++)
        //    {
        //        if (dtGroup.Rows[i]["UserID"].ToString().Equals(temp))
        //        {
        //            xlSheets.Cells[intCount, 1] = dtGroup.Rows[i][0];
        //            xlSheets.Cells[intCount, 2] = dtGroup.Rows[i][1];
        //            xlSheets.Cells[intCount, 3] = dtGroup.Rows[i][2];
        //            xlSheets.Cells[intCount, 4] = dtGroup.Rows[i][3];
        //            xlSheets.Cells[intCount, 5] = dtGroup.Rows[i][4];
        //            xlSheets.Cells[intCount, 6] = dtGroup.Rows[i][5];
        //            xlSheets.Cells[intCount, 7] = dtGroup.Rows[i][6];
        //            xlSheets.Cells[intCount, 8] = dtGroup.Rows[i][7];
        //            intCount++;
        //            intGroup++;

        //        }
        //        else
        //        {
        //            xlSheets.Cells[intCount + 1, 4] ="Total Post is "+ intGroup;
        //            intGroup = 0;

        //            temp = dtGroup.Rows[i]["UserID"].ToString();
        //            i--;

        //            xlSheets.Cells[intCount + 3, 4] = temp;
        //          intCount=  intCount + 2;

        //        }
        //    }
        //    xlSheets.Cells[intCount + 4] ="Total Posts is "+ intGroup;
        //    xlApps.Visible = true;       



        clsFunctions.InsertEntry("Generated Grouped Report");
    }
}