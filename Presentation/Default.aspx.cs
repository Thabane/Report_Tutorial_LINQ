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


    }
}