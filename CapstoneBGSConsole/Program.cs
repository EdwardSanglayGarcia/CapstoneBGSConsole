using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneBGSConsole
{
    using System.Globalization;
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

            DataProvider cmd = new DataProvider();


            string savePath = @"C:\Users\pc\Desktop\Capstone Generated Document\";
            DateTimeFormatInfo mfi = new DateTimeFormatInfo();
            int year = 2020;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                //Set some properties of the Excel document
                excelPackage.Workbook.Properties.Author = "VDWWD";
                excelPackage.Workbook.Properties.Title = "Title of Document";
                excelPackage.Workbook.Properties.Subject = "EPPlus demo export data";
                excelPackage.Workbook.Properties.Created = DateTime.Now;
                ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add("Summarized "+year+" Report");


                try
                {

                    int height = 230;
                    int width = 230;

                    string DENRLogo = @"C:\Users\pc\Desktop\DENRLogo.png";
                    Image DENRLOGO = Image.FromFile(DENRLogo);
                    ExcelPicture picDENR = ws.Drawings.AddPicture("DENR", DENRLOGO);
                    picDENR.SetPosition(0, 0, 0, 0);//5,3
                    picDENR.SetSize(height, width);

                    string PHLogo = @"C:\Users\pc\Desktop\PHLogo.png";
                    Image PHILIPPINELOGO = Image.FromFile(PHLogo);
                    ExcelPicture picPH = ws.Drawings.AddPicture("PH", PHILIPPINELOGO);
                    picPH.SetPosition(0, 0, 10, 0);//5,3
                    picPH.SetSize(height, width);


                }

                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
                //Resize the columns A-M
                ws.Column(1).Width = 24;
                for (int startColumns = 2; startColumns <= 13; startColumns++)
                {
                    ws.Column(startColumns).Width = 12;
                }

                //Resize the row 1-7
                ws.Row(1).Height = 40;
                ws.Row(2).Height = 35;
                ws.Row(3).Height = 25;
                ws.Row(4).Height = 25;
                ws.Row(5).Height = 20;
                ws.Row(6).Height = 20;

                //Merging
                for (int mergeHeader = 1; mergeHeader <= 7; mergeHeader++)
                {
                    ws.Cells[mergeHeader, 1, mergeHeader, 13].Merge = true;
                }

                //Adding Descriptive Values
                ws.Cells[1, 1, 1, 13].Value = "Republic of the Philippines";
                ws.Cells[2, 1, 2, 13].Value = "Department of Environment and National Resources";
                ws.Cells[3, 1, 3, 13].Value = "Environmental Management Bureau";
                ws.Cells[4, 1, 4, 13].Value = "Environmental Monitoring and Enforcement Division";
                ws.Cells[5, 1, 5, 13].Value = "National Ecology Center Compound East Avenue Diliman Quezon City";
                ws.Cells[6, 1, 6, 13].Value = "Tel/Email: 8931-3506 | 8931-2684 | RecordsNCR@emb.gov.ph";

                //Changing Font Size
                ws.Cells[1, 1, 1, 13].Style.Font.Size = 30;
                ws.Cells[2, 1, 2, 13].Style.Font.Size = 25;
                ws.Cells[3, 1, 3, 13].Style.Font.Size = 20;
                ws.Cells[4, 1, 4, 13].Style.Font.Size = 20;
                ws.Cells[5, 1, 5, 13].Style.Font.Size = 16;
                ws.Cells[6, 1, 6, 13].Style.Font.Size = 16;

                //Change the Font Style of the Header
                ws.Cells[1, 1, 6, 13].Style.Font.Name = "Times New Roman";

                //Align to center the header
                ws.Cells[1, 1, 6, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 6, 13].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //Secondary Header for Data
                ws.Cells[8, 1, 9, 13].Merge = true;
                ws.Cells[8, 1, 9, 13].Value = "Summarized Yearly "+year+" Report";
                ws.Cells[8, 1, 9, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[8, 1, 9, 13].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[8, 1, 9, 13].Style.Border.BorderAround(ExcelBorderStyle.Double);
                ws.Cells[8, 1, 9, 13].Style.Font.Name = "Arial Narrow";
                ws.Cells[8, 1, 9, 13].Style.Font.Bold = true;
                ws.Cells[8, 1, 9, 13].Style.Font.Size = 15;

                //Main Header
                ws.Cells[10, 1, 11, 1].Merge = true;
                ws.Cells[10, 1, 11, 1].Value = "Month";
                ws.Cells[10, 1, 11, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[10, 1, 11, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[10, 1, 11, 1].Style.Border.BorderAround(ExcelBorderStyle.Double);
                ws.Cells[10, 1, 11, 1].Style.Font.Name = "Arial Narrow";
                ws.Cells[10, 1, 11, 1].Style.Font.Bold = true;
                ws.Cells[10, 1, 11, 1].Style.Font.Size = 15;

                for (int dataHeader = 2; dataHeader <= 13; dataHeader++)
                {
                    ws.Cells[11, dataHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[11, dataHeader].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[11, dataHeader].Style.Border.BorderAround(ExcelBorderStyle.Double);
                    ws.Cells[11, dataHeader].Style.Font.Name = "Arial Narrow";
                    ws.Cells[11, dataHeader].Style.Font.Size = 12;
                }

                //L - W - TOTAL + header

                for (int L = 2; L <= 13; L += 3)
                {
                    ws.Cells[11, L].Value = "L";
                    ws.Cells[11, L + 1].Value = "W";
                    ws.Cells[11, L + 2].Value = "TOTAL";
                    ws.Cells[10, L, 10, L + 2].Merge = true;
                    ws.Cells[10, L, 10, L + 2].Style.Border.BorderAround(ExcelBorderStyle.Double);
                }
                ws.Cells[10, 2, 11, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[10, 2, 11, 13].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[10, 2, 11, 13].Style.Font.Bold = true;
                ws.Cells[10, 2, 11, 13].Style.Font.Name = "Arial Narrow";
                ws.Cells[10, 2, 11, 13].Style.Font.Size = 12;
                ws.Cells[10, 2].Value = "Submitted";
                ws.Cells[10, 5].Value = "Rejected";
                ws.Cells[10, 8].Value = "Accepted";
                ws.Cells[10, 11].Value = "Completed";

                //DATA SECTION

                ws.Cells[12, 1].Value = "January";
                ws.Cells[13, 1].Value = "February";
                ws.Cells[14, 1].Value = "March";
                ws.Cells[15, 1].Value = "April";
                ws.Cells[16, 1].Value = "May";
                ws.Cells[17, 1].Value = "June";
                ws.Cells[18, 1].Value = "July";
                ws.Cells[19, 1].Value = "August";
                ws.Cells[20, 1].Value = "September";
                ws.Cells[21, 1].Value = "October";
                ws.Cells[22, 1].Value = "November";
                ws.Cells[23, 1].Value = "December";
                ws.Cells[24, 1].Value = "TOTAL";

                ws.Cells[12, 1, 24, 1].Style.Font.Bold = true;

                for (int rowData = 12; rowData <= 24; rowData++)
                {
                    for (int colData = 1; colData <= 13; colData++)
                    {
                        ws.Cells[rowData, colData].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[rowData, colData].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        ws.Cells[rowData, colData].Style.Border.BorderAround(ExcelBorderStyle.Double);
                        ws.Cells[rowData, colData].Style.Font.Name = "Arial Narrow";
                        ws.Cells[rowData, colData].Style.Font.Size = 12;
                    }
                }

                for (int rowDataColor = 11; rowDataColor <= 24; rowDataColor++)
                {
                    for (int LWH = 2; LWH <= 13; LWH += 3)
                    {
                        //L
                        ws.Cells[rowDataColor, LWH].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[rowDataColor, LWH].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 242, 204));
                        //W
                        ws.Cells[rowDataColor, LWH + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[rowDataColor, LWH + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247));
                        //H
                        ws.Cells[rowDataColor, LWH + 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[rowDataColor, LWH + 2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(226, 239, 218));
                    }
                }

                int DataRowStart = 12;
                //DATA SECTION
                for (int mainData = 1; mainData <= 12; mainData++)
                {
                    foreach (var data in cmd.GetMonthlyTotals(mainData,year))
                    {
                        Console.WriteLine(mainData+" - "+year);
                        ws.Cells[DataRowStart, 2].Value = data.L_Submitted;
                        ws.Cells[DataRowStart, 3].Value = data.W_Submitted;
                        ws.Cells[DataRowStart, 4].Formula = "SUM(" + ws.Cells[DataRowStart, 2] + ":" + ws.Cells[DataRowStart, 3] + ")";

                        ws.Cells[DataRowStart, 5].Value = data.L_Rejected;
                        ws.Cells[DataRowStart, 6].Value = data.W_Rejected;
                        ws.Cells[DataRowStart, 7].Formula = "SUM(" + ws.Cells[DataRowStart, 5] + ":" + ws.Cells[DataRowStart, 6] + ")";

                        ws.Cells[DataRowStart, 8].Value = data.L_Accepted;
                        ws.Cells[DataRowStart, 9].Value = data.W_Accepted;
                        ws.Cells[DataRowStart, 10].Formula = "SUM(" + ws.Cells[DataRowStart, 8] + ":" + ws.Cells[DataRowStart, 9] + ")";

                        ws.Cells[DataRowStart, 11].Value = data.L_Completed;
                        ws.Cells[DataRowStart, 12].Value = data.W_Completed;
                        ws.Cells[DataRowStart, 13].Formula = "SUM(" + ws.Cells[DataRowStart, 11] + ":" + ws.Cells[DataRowStart, 12] + ")";
                        DataRowStart++;
                    }
                }
                int totalRowStart = ws.Dimension.End.Row;

                for (int totalMainData = 2; totalMainData <= 13; totalMainData++)
                {
                    ws.Cells[totalRowStart, totalMainData].Formula = "SUM(" + ws.Cells[totalRowStart - 1, totalMainData] + ":" + ws.Cells[totalRowStart - 12, totalMainData] + ")";
                }

                int marginMake = ws.Dimension.End.Row + 2;

                ws.Cells[marginMake, 1, marginMake + 1, 13].Merge = true;
                ws.Cells[marginMake, 1, marginMake + 1, 13].Style.Border.BorderAround(ExcelBorderStyle.Double);
                ws.Cells[marginMake, 1, marginMake + 1, 13].Style.Font.Name = "Arial Narrow";
                ws.Cells[marginMake, 1, marginMake + 1, 13].Style.Font.Size = 15;
                ws.Cells[marginMake, 1, marginMake + 1, 13].Style.Font.Bold = true;
                ws.Cells[marginMake, 1, marginMake + 1, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[marginMake, 1, marginMake + 1, 13].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[marginMake, 1, marginMake + 1, 13].Value = year+" Summarized Report per City / Municipality";

                int subDataHeaderStart = ws.Dimension.End.Row + 2;

                //  Console.WriteLine(ws.Dimension.End.Row); //27
                //START OF SUB DATA


                for (int repeatMonth = 1; repeatMonth <= 12; repeatMonth++)
                {
                    // ws.Cells[subDataHeaderStart + 1, 1].Value = "Record for month num" +repeatMonth;

                    ws.Cells[subDataHeaderStart, 1, subDataHeaderStart + 1, 1].Merge = true;
                    ws.Cells[subDataHeaderStart, 2, subDataHeaderStart, 4].Merge = true;
                    ws.Cells[subDataHeaderStart, 5, subDataHeaderStart, 7].Merge = true;
                    ws.Cells[subDataHeaderStart, 8, subDataHeaderStart, 10].Merge = true;
                    ws.Cells[subDataHeaderStart, 11, subDataHeaderStart, 13].Merge = true;

                    ws.Cells[subDataHeaderStart, 1, subDataHeaderStart + 1, 1].Style.Border.BorderAround(ExcelBorderStyle.Double);
                    ws.Cells[subDataHeaderStart, 2, subDataHeaderStart, 4].Style.Border.BorderAround(ExcelBorderStyle.Double);
                    ws.Cells[subDataHeaderStart, 5, subDataHeaderStart, 7].Style.Border.BorderAround(ExcelBorderStyle.Double);
                    ws.Cells[subDataHeaderStart, 8, subDataHeaderStart, 10].Style.Border.BorderAround(ExcelBorderStyle.Double);
                    ws.Cells[subDataHeaderStart, 11, subDataHeaderStart, 13].Style.Border.BorderAround(ExcelBorderStyle.Double);

                    ws.Cells[subDataHeaderStart, 1, subDataHeaderStart + 1, 1].Value = mfi.GetMonthName(repeatMonth).ToString() + " Breakdown City/Municipality";
                    ws.Cells[subDataHeaderStart, 1, subDataHeaderStart + 1, 1].Style.WrapText = true;

                    ws.Cells[subDataHeaderStart, 2, subDataHeaderStart, 4].Value = "Submitted";
                    ws.Cells[subDataHeaderStart, 5, subDataHeaderStart, 7].Value = "Rejected";
                    ws.Cells[subDataHeaderStart, 8, subDataHeaderStart, 10].Value = "Accepted";
                    ws.Cells[subDataHeaderStart, 11, subDataHeaderStart, 13].Value = "Completed";

                    for (int L = 2; L <= 13; L += 3)
                    {
                        ws.Cells[subDataHeaderStart + 1, L].Value = "L";
                        ws.Cells[subDataHeaderStart + 1, L].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[subDataHeaderStart + 1, L].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 242, 204));
                        ws.Cells[subDataHeaderStart + 1, L + 1].Value = "W";
                        ws.Cells[subDataHeaderStart + 1, L + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[subDataHeaderStart + 1, L + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247));
                        ws.Cells[subDataHeaderStart + 1, L + 2].Value = "TOTAL";
                        ws.Cells[subDataHeaderStart + 1, L + 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[subDataHeaderStart + 1, L + 2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(226, 239, 218));

                        ws.Cells[subDataHeaderStart + 1, L].Style.Border.BorderAround(ExcelBorderStyle.Double);
                        ws.Cells[subDataHeaderStart + 1, L + 1].Style.Border.BorderAround(ExcelBorderStyle.Double);
                        ws.Cells[subDataHeaderStart + 1, L + 2].Style.Border.BorderAround(ExcelBorderStyle.Double);
                    }

                    ws.Cells[subDataHeaderStart, 1, subDataHeaderStart + 1, 13].Style.Font.Name = "Arial Narrow";
                    ws.Cells[subDataHeaderStart, 1, subDataHeaderStart + 1, 13].Style.Font.Size = 12;
                    ws.Cells[subDataHeaderStart, 1, subDataHeaderStart + 1, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[subDataHeaderStart, 1, subDataHeaderStart + 1, 13].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[subDataHeaderStart, 1, subDataHeaderStart + 1, 13].Style.Border.BorderAround(ExcelBorderStyle.Double);
                    ws.Cells[subDataHeaderStart, 1, subDataHeaderStart + 1, 13].Style.Font.Bold = true;


                    //List<int> monthsInsert = new List<int>();

                    //if (cmd.GetAreaDetailsPerMonthYear(repeatMonth, year).Count() > 0)
                    //{
                    //    //Console.WriteLine(repeatMonth + " - " + year);
                    //    //monthsInsert.Add(repeatMonth);
                    //}
                    //else
                    //{
                    //    Console.WriteLine("No value for " + repeatMonth + " - " + year);
                    //}



                    foreach (var getData in cmd.GetAreaDetailsPerMonthYear(repeatMonth, year))
                    {
                        for (int L = 2; L <= 13; L += 3)
                        {
                            ws.Cells[subDataHeaderStart + 2, L].Value = "L";
                            ws.Cells[subDataHeaderStart + 2, L].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[subDataHeaderStart + 2, L].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 242, 204));

                            ws.Cells[subDataHeaderStart + 2, L + 1].Value = "W";
                            ws.Cells[subDataHeaderStart + 2, L + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[subDataHeaderStart + 2, L + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247));

                            ws.Cells[subDataHeaderStart + 2, L + 2].Value = "TOTAL";
                            ws.Cells[subDataHeaderStart + 2, L + 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[subDataHeaderStart + 2, L + 2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(226, 239, 218));
                        }

                        ws.Cells[subDataHeaderStart + 2, 1].Value = getData.CaseLocation;
                        ws.Cells[subDataHeaderStart + 2, 2].Value = getData.L_Submitted;
                        ws.Cells[subDataHeaderStart + 2, 3].Value = getData.W_Submitted;
                        ws.Cells[subDataHeaderStart + 2, 4].Formula = "SUM(" + ws.Cells[subDataHeaderStart + 2, 2] + ":" + ws.Cells[subDataHeaderStart + 2, 3] + ")";

                        ws.Cells[subDataHeaderStart + 2, 5].Value = getData.L_Rejected;
                        ws.Cells[subDataHeaderStart + 2, 6].Value = getData.W_Rejected;
                        ws.Cells[subDataHeaderStart + 2, 7].Formula = "SUM(" + ws.Cells[subDataHeaderStart + 2, 5] + ":" + ws.Cells[subDataHeaderStart + 2, 6] + ")";

                        ws.Cells[subDataHeaderStart + 2, 8].Value = getData.L_Accepted;
                        ws.Cells[subDataHeaderStart + 2, 9].Value = getData.W_Accepted;
                        ws.Cells[subDataHeaderStart + 2, 10].Formula = "SUM(" + ws.Cells[subDataHeaderStart + 2, 8] + ":" + ws.Cells[subDataHeaderStart + 2, 9] + ")";

                        ws.Cells[subDataHeaderStart + 2, 11].Value = getData.L_Completed;
                        ws.Cells[subDataHeaderStart + 2, 12].Value = getData.W_Completed;
                        ws.Cells[subDataHeaderStart + 2, 13].Formula = "SUM(" + ws.Cells[subDataHeaderStart + 2, 11] + ":" + ws.Cells[subDataHeaderStart + 2, 12] + ")";
                        ws.Cells[subDataHeaderStart + 2, 1, subDataHeaderStart + 2, 13].Style.Font.Name = "Arial Narrow";
                        ws.Cells[subDataHeaderStart + 2, 1, subDataHeaderStart + 2, 13].Style.Font.Size = 12;
                        ws.Cells[subDataHeaderStart + 2, 1, subDataHeaderStart + 2, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[subDataHeaderStart + 2, 1, subDataHeaderStart + 2, 13].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                        ws.Cells[subDataHeaderStart + 2, 1].Style.Border.BorderAround(ExcelBorderStyle.Double);

                        ws.Cells[subDataHeaderStart + 2, 2].Style.Border.BorderAround(ExcelBorderStyle.Double);
                        ws.Cells[subDataHeaderStart + 2, 3].Style.Border.BorderAround(ExcelBorderStyle.Double);
                        ws.Cells[subDataHeaderStart + 2, 4].Style.Border.BorderAround(ExcelBorderStyle.Double);

                        ws.Cells[subDataHeaderStart + 2, 5].Style.Border.BorderAround(ExcelBorderStyle.Double);
                        ws.Cells[subDataHeaderStart + 2, 6].Style.Border.BorderAround(ExcelBorderStyle.Double);
                        ws.Cells[subDataHeaderStart + 2, 7].Style.Border.BorderAround(ExcelBorderStyle.Double);

                        ws.Cells[subDataHeaderStart + 2, 8].Style.Border.BorderAround(ExcelBorderStyle.Double);
                        ws.Cells[subDataHeaderStart + 2, 9].Style.Border.BorderAround(ExcelBorderStyle.Double);
                        ws.Cells[subDataHeaderStart + 2, 10].Style.Border.BorderAround(ExcelBorderStyle.Double);

                        ws.Cells[subDataHeaderStart + 2, 11].Style.Border.BorderAround(ExcelBorderStyle.Double);
                        ws.Cells[subDataHeaderStart + 2, 12].Style.Border.BorderAround(ExcelBorderStyle.Double);
                        ws.Cells[subDataHeaderStart + 2, 13].Style.Border.BorderAround(ExcelBorderStyle.Double);

                        subDataHeaderStart++;
                    }


                    subDataHeaderStart += 5;


                }



                //Save your file
                FileInfo fi = new FileInfo(savePath + "/gg.xlsx");
                excelPackage.SaveAs(fi);

                Console.ReadLine();

            }
        }
    }
}
/*
                     //28,1


                    ws.Cells[subDataHeaderStart , 1, subDataHeaderStart  + 1, 1].Value = mfi.GetMonthName(subData).ToString() + " Breakdown City/Municipality";
                    ws.Cells[subDataHeaderStart , 1, subDataHeaderStart  + 1, 1].Style.WrapText = true;
                    ws.Cells[subDataHeaderStart , 2, subDataHeaderStart , 4].Value = "Submitted";
                    ws.Cells[subDataHeaderStart , 5, subDataHeaderStart , 7].Value = "Rejected";
                    ws.Cells[subDataHeaderStart , 8, subDataHeaderStart , 10].Value = "Accepted";
                    ws.Cells[subDataHeaderStart , 11, subDataHeaderStart , 13].Value = "Completed";

                    for (int L = 2; L <= 13; L += 3)
                    {
                        ws.Cells[subDataHeaderStart  + 1, L].Value = "L";
                        ws.Cells[subDataHeaderStart  + 1, L + 1].Value = "W";
                        ws.Cells[subDataHeaderStart  + 1, L + 2].Value = "TOTAL";
                        ws.Cells[subDataHeaderStart  + 1, L].Style.Border.BorderAround(ExcelBorderStyle.Double);
                        ws.Cells[subDataHeaderStart  + 1, L + 1].Style.Border.BorderAround(ExcelBorderStyle.Double);
                        ws.Cells[subDataHeaderStart  + 1, L + 2].Style.Border.BorderAround(ExcelBorderStyle.Double);
                    }
                    ws.Cells[subDataHeaderStart , 1, subDataHeaderStart  + 1, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[subDataHeaderStart , 1, subDataHeaderStart  + 1, 13].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[subDataHeaderStart , 1, subDataHeaderStart  + 1, 13].Style.Font.Name = "Arial Narrow";
                    ws.Cells[subDataHeaderStart , 1, subDataHeaderStart  + 1, 13].Style.Font.Size = 12;
                    ws.Cells[subDataHeaderStart , 1, subDataHeaderStart , 13].Style.Font.Bold = true;
 */

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
//cmd.DeleteUserInformation(14);
////cmd.InsertUserInformation(1, "22121", "password", "a@yahoo.com", "Edz", "Sangs", "Garc");
//foreach (var users in cmd.GetUserInformation().ToList())
//{
//    Console.WriteLine(users.Username + "\t" + users.UserInformationID);
//}
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