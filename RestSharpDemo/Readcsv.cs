﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo
{
    class Readcsv
    {
        internal static string[,] Loadcsv1(string filename)
        {
            // Get the file's text.
            string whole_file = System.IO.File.ReadAllText(filename);

            // Split into lines.
            //whole_file = whole_file.Replace('\n', '\r');
            whole_file = whole_file.Replace(",|,", "|");
            string[] lines = whole_file.Split(new string[] { @",end\r\n" },
                StringSplitOptions.RemoveEmptyEntries);

            // See how many rows and columns there are.
            int num_rows = lines.Length;
            int num_cols = lines[0].Split('|').Length;

            // Allocate the data array.
            string[,] values = new string[num_rows, num_cols];
            
            // Load the array.
            for (int r = 0; r < num_rows; r++)
            {
                string[] line_r = lines[r].Split('|');
                for (int c = 0; c < num_cols; c++)
                {
                    values[r, c] = line_r[c];
                    Console.Write("\n next value same line \n");
                    Console.Write(values[r, c]);
                }
            }

            // Return the values.
            return values;
            throw new NotImplementedException();
        }

    }
}
