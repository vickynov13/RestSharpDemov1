using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace RestSharpDemo
{
    class ReadExcel
    {
        public static string[,] getExcelFile(string dexpath, StringBuilder log)
        {

            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbooks xlWorkbooks = xlApp.Workbooks;
            dexpath = string.Concat(dexpath, "data\\testdata.xlsx");
            log.Append("\n" + dexpath);
            Excel.Workbook xlWorkbook = xlWorkbooks.Open(dexpath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int l = 0, m = 0;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            string[,] values = new string[rowCount, colCount];
            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    //new line
                    if (j == 1)
                    {
                        Console.Write("\r\n");
                    }
                    l = i - 1;
                    m = j - 1;
                    //write the value to the console
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    {
                        values[l, m] = xlRange.Cells[i, j].Value2.ToString();
                        //---------notreq------Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");
                        //Console.Write("i = " + l + " j = " + m + " --> array value = " + values[l, m] + "\n");
                    } else if (xlRange.Cells[i, j] == null || xlRange.Cells[i, j].Value2 == null)
                    {
                        values[l, m] = null;
                        //Console.Write("i = " + l + " j = " + m + "--> array value = " + values[l, m] + "\n");
                    }
                }
            }

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            return values;
        }
    }
}
