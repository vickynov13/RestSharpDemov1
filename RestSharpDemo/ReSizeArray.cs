using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo
{
    public class ReSizeArray
    {
        public static string[,] AddRow(string[,] resultss)
        {
            int inputarrrow = resultss.GetLength(0);
            int inputarrcol = resultss.GetLength(1);
            string[,] resultss1 = new string[inputarrrow + 1, inputarrcol];
            for (int i=0; i< inputarrrow; i++)
            {
                for(int j=0; j<inputarrcol; j++)
                {
                    resultss1[i, j] = resultss[i, j];
                }
            }
            return resultss1;
        }

        public static string[,] Addresultrow(string[,] resultss, string[] statusarr)
        {
            int resarrrow = resultss.GetLength(0);
            int teststatarr = statusarr.GetLength(0);
            resultss = ReSizeArray.AddRow(resultss);
            for (int i = 0; i < teststatarr; i++)
            {
                resultss[resarrrow, i] = statusarr[i];
            }
            return resultss;
        }
    }
}
