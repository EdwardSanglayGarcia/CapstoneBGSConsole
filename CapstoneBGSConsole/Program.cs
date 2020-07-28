using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneBGSConsole
{

    using OfficeOpenXml;
    using OfficeOpenXml.Drawing;
    using OfficeOpenXml.Style;
    using System.Drawing;

    using System.IO;
    using System.Web;

    class Program
    {
        static void Main(string[] args)
        {
            DefaultData CallHelper = new DefaultData();

            Console.WriteLine("Group BGS Capstone II Gumagana ba?");
            Console.WriteLine("Group BGS Capstone II Gumagana ba?");
            Console.WriteLine("Group BGS Capstone II Gumagana ba?");
            Console.WriteLine("Group BGS Capstone II Gumagana ba?");

            DataProvider cmd = new DataProvider();

            //cmd.InsertUserType(3,"Hello World");
            //cmd.UpdateUserType(3, "woof woof arf arf bark bark");
            //cmd.DeleteUserType(3);


            //   cmd.InsertEnvironmentalConcern(3,"meow");
            //cmd.DeleteEnvironmentalConcern(3);
            // cmd.UpdateEnvironmentalConcern(3,"woof woof");
            //Where(x=>x.Description == "Submitted")
            //Where(x=>x.UpdatedStatus=="Accepted")

            //int uid = 6;
            //int ecid = 1;
            //int x = 100;
            //int y = 200;
            //string photo = "this is a path";
            //string location = "earth";
            cmd.DeleteUserInformation(14);
            //cmd.InsertUserInformation(1, "22121", "password", "a@yahoo.com", "Edz", "Sangs", "Garc");
            foreach (var users in cmd.GetUserInformation().ToList())
            {
                Console.WriteLine(users.Username + "\t" + users.UserInformationID);
            }
            //cmd.InsertCaseReport(uid,ecid,x,y,photo,location);

            //Console.WriteLine(cmd.LoginUserInformation("123", "password"));

            //Console.WriteLine(cmd.LoginUserInformation("AndresBonifacioAccount", "password"));
            //cmd.DeleteCaseReport(5);
            //Console.WriteLine("COLUMN 1\tCOLUMN 2");
            //foreach (var users in cmd.GetCaseReport().ToList())
            //{
            //    Console.WriteLine(users.UpdatedStatus+ "\t" + users.Notes);
            //}



            //    Directory.CreateDirectory(CallHelper.path);

            //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //    using (ExcelPackage excelPackage = new ExcelPackage())
            //    {
            //        //Set some properties of the Excel document
            //        excelPackage.Workbook.Properties.Author = "VDWWD";
            //        excelPackage.Workbook.Properties.Title = "Title of Document";
            //        excelPackage.Workbook.Properties.Subject = "EPPlus demo export data";
            //        excelPackage.Workbook.Properties.Created = DateTime.Now;
            //        ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add("Sheet 1");


            //        int rows = 2;
            //        foreach (var use in cmd.GetUserType().ToList())
            //        {
            //            ws.Cells[rows, 1].Value = use.Description;
            //            ws.Cells[rows, 2].Value = use.UserTypeID;
            //            ws.Cells[rows, 3].Value = use.Notes;
            //            rows++;
            //        }

            //        for (int i = 1; i <= 10; i++)
            //        {
            //            ws.Column(i).Width = 10;
            //        }

            //        string a = "A1:J1";
            //        ws.Cells["" + a + ""].Merge = true;
            //        ws.Cells["" + a + ""].Value = "Hello World";

            //        //Save your file
            //        FileInfo fi = new FileInfo(CallHelper.path + "/a.xlsx");
            //        excelPackage.SaveAs(fi);
            //    }
            Console.ReadLine();
        }
    }
}
