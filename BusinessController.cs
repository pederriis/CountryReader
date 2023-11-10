using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CountryReader
{
    public static class BusinessController
    {

        public static void Run()
        {
            GetCoutryXMLFromObjects();
        }

        public static void ReadCsvFilePathAsDatatabel(string filePath) 
        {
            CSVTool.ReadCsvFilePathAsDatatabel(filePath);
        }

        public static DataTable GetCGetDataTableFromCSVsVFromDataTable(string csvString)
        {
            return CSVTool.GetDataTableFromCSV(csvString);
        }

        public static string GetCsVFromDataTable(DataTable dataTable) 
        
        { 
            return  CSVTool.GetCsVFromDataTable(dataTable);
        }
        public static XmlDocument GetXmlFromCsv(string urlString)
        {

            return XmlTools.GetXmlFromCsv(urlString);
        }
        public static List<Cd> GetCdsFromXml(string urlString, bool eng)
        {
            return XmlTools.GetCdsFromXml(urlString, eng);
        }

        public static XDocument GetXmlFromListOfCds()
        {

            List<Cd> cdList = new List<Cd>
            { new Cd()
                {
                    Title = "Empire Burlesque",
                    Artist = "Bob Dylan",
                    Country = "USA",
                    Company= "Columbia",
                    Price = 20.91,
                    Year = 1985,
                },
                new Cd
                {
                    Title = "Hide your heart",
                    Artist = "Bonnie Tyler",
                    Country = "UK",
                    Company = "CBS Records",
                    Price = 9.90,
                    Year = 1988,
                },
                new Cd
                {
                    Title = "Greatest Hits",
                    Artist = "Dolly Parton",
                    Country = "USA",
                    Company = "RCA",
                    Price = 10.20,
                    Year = 193,
                }
            };

            var pap = XmlTools.ObjectToXML(cdList);

            return XmlTools.GetXmlFromListOfCds_2(cdList);
        }

        public static void GetCoutryXMLFromObjects()
        {
            var countries = new List<Country>
            {
                new Country() { ID = 1, Name = "Danmark" },
                new Country() { ID = 2, Name = "Polen" },
                new Country() { ID = 3, Name = "Tyskland" }
            };

            var res = XmlTools.ObjectToXML(countries);

        }
    }
}
