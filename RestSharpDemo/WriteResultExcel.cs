using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo
{
    public class WriteResultExcel
    {
        public static void WriteRes(string[,] resultss)
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            try
            {
                //Start Excel and get Application object.
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oXL.Visible = true;

                oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                Microsoft.Office.Interop.Excel.Range chartRange;

                int rowCount = resultss.GetLength(0);
                int columnCount = resultss.GetLength(1);
                chartRange = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, 1]; //I have header info on row 1, so start row 2
                chartRange = chartRange.get_Resize(rowCount, columnCount);
                chartRange.set_Value(Microsoft.Office.Interop.Excel.XlRangeValueDataType.xlRangeValueDefault, resultss);
                oXL.Visible = false;
                oXL.UserControl = false;
                string outputFile = "Output_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

                oWB.SaveAs("c:\\chrome downloads\\" + outputFile, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                    false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                oWB.Close();
            }
            catch (Exception ex)
            {
                //...
            }
        }
    }
}
