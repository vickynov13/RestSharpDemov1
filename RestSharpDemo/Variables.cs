using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo
{
    public class Variables
    {
        public static string meme = "text";
        public static string MType, Ridentifier, RusultToValidate, InputJson, RIdentifier2, OutputJson;


        public static void setdata(string currentMethodName, string[,] values)
        {
            int arrayrows = values.GetLength(0);
            int arraycolumn = values.GetLength(1);
            for (int i = 0; i < arrayrows; i++)
            {
                if (values[i, 0].Equals(currentMethodName))
                {
                    for (int j = 0; j < arraycolumn; j++)
                    {
                        if (values[0, j].Equals("MType"))
                        {
                            MType = values[i, j];
                        }
                        else if (values[0, j].Equals("Ridentifier"))
                        {
                            Ridentifier = values[i, j];
                        }
                        else if (values[0, j].Equals("RusultToValidate"))
                        {
                            RusultToValidate = values[i, j];
                        }
                        else if (values[0, j].Equals("InputJson"))
                        {
                            InputJson = values[i, j];
                        }
                        else if (values[0, j].Equals("RIdentifier2"))
                        {
                            RIdentifier2 = values[i, j];
                        }
                        else if (values[0, j].Equals("OutputJson"))
                        {
                            OutputJson = values[i, j];
                        }

                    }
                }
                else
                {
                    MType = null;
                    Ridentifier = null;
                    RusultToValidate = null;
                    InputJson = null; RIdentifier2 = null; OutputJson = null;
                }
            }
        }
    }
}
