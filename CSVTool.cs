using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryReader
{
    public class CSVTool
    {

        public static List<Country> ReadCsvFilePathAsDatatabel(string filePath)
        {
            List<Country> countries = new List<Country>();

            DataTable dt = new DataTable();

            using (StreamReader sr = new StreamReader(filePath))

            {
                string csvString = sr.ReadToEnd();

                GetDataTableFromCSV(csvString);

                string[] headers = sr.ReadLine().Split(';');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }

                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(';');
                    DataRow dr = dt.NewRow();


                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];

                    }

                    dt.Rows.Add(dr);

                    Country c = new Country()
                    {
                        ID = int.Parse(dr["ID"].ToString()),
                        Name = dr["Name"].ToString()
                    };
                    countries.Add(c);

                }
                return countries;
            }
        }

        public static DataTable GetDataTableFromCSV(string csvString)
        {
            DataTable dt = new DataTable();

            string[] splittedCsvString = csvString
               .Split(
                new string[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None);

            string[] headers = splittedCsvString[0].Split(';');
            foreach (string header in headers)
            {
                dt.Columns.Add(header, typeof(String));
            }

            for (int i = 1; i < splittedCsvString.Length-1; i++)
            {

                DataRow dr = dt.NewRow();

                string[] rowFields = splittedCsvString[i].ToString().Split(';');

                for (int j = 0; j < rowFields.Count(); j++)
                {

                    dr[j] = rowFields[j];
                }
                dt.Rows.Add(dr);
            }

          
            return dt;

        }

        public static string GetCsVFromDataTable(DataTable dataTable)
        {
            string output = "";

            foreach (var col in dataTable.Columns) 
            {
                output += col.ToString()+";";
            }
            
            for (int i = 0; i < dataTable.Rows.Count; i++)

            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    output = output + dataTable.Rows[i].ItemArray[j]+";";

                }

                output += Environment.NewLine;
            }
            return output;
        }



    }
}