using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Globalization;
using System.Data;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CountryReader
{
    public static class XmlTools
    {

        public static List<Cd> GetCdsFromXml(string urlString, bool eng) 
        {
            List<Cd> cDlist = new List<Cd>();
            CultureInfo cultureInfo = (eng) ? new CultureInfo("en") : new CultureInfo("da");

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(urlString);

            XmlNodeList nodeList= xmlDoc.SelectNodes(".//CD");

            foreach (XmlNode cd in nodeList)
            {
                Cd c = new Cd()
                {
                    Title = cd["TITLE"].InnerText,
                    Artist = cd["ARTIST"].InnerText,
                    Country = cd["COUNTRY"].InnerText,
                    Company = cd["COMPANY"].InnerText,
                    Price = double.Parse(cd["PRICE"].InnerText, cultureInfo),
                    Year = Convert.ToInt32(cd["YEAR"].InnerText)

                };
                cDlist.Add(c);
            }
            return cDlist;
        }


        public static XmlDocument GetXmlFromCsv(string csvFilePath)
        {
            XmlDocument xmlDocument = new XmlDocument();
           
            string[] csvLines = File.ReadAllLines(csvFilePath);

            string allLines=String.Join("", csvLines);

            xmlDocument.LoadXml(allLines);

            xmlDocument.Save("xmlDocument.xml");

            return xmlDocument;
        }

        public static XDocument GetXmlFromListOfCds(List<Cd> cdList)
        {
            XDocument xDocument = new XDocument();
            XElement catalogTag= new XElement("CATALOG");

          foreach (Cd cd in cdList)
            {
                XElement cdTag = new XElement("CD");
                XElement titleTag = new XElement("TITLE", $"{cd.Title}");
                XElement artistTag = new XElement("ARTIST", $"{cd.Artist}");
                XElement countryTag = new XElement("USA", $"{cd.Country}");
                XElement companyTag = new XElement("COMPANY", $"{cd.Company}");
                XElement priceTag = new XElement("PRICE", $"{cd.Price}");
                XElement yearTag = new XElement("YEAR", $"{cd.Year}");

                cdTag.Add(titleTag);
                cdTag.Add(artistTag);
                cdTag.Add(countryTag);
                cdTag.Add(companyTag);
                cdTag.Add(priceTag);
                cdTag.Add(yearTag);

                catalogTag.Add(cdTag);
            }

            xDocument.Add(catalogTag);

            xDocument.Save("cdxml.xml");

            return xDocument;
        }

        public static XDocument GetXmlFromListOfCds_2(List<Cd> cdList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Cd>));

            TextWriter writer = new StreamWriter("cdxml2.xml");
            serializer.Serialize(writer, cdList);

            writer.Close();

            XDocument xml = XDocument.Load("cdxml2.xml");

            return xml;
        }


        public static string GetStringFromListOfCds(List<Cd> cdList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Cd>));

            StringWriter stringWriter = new StringWriter();

            using (XmlWriter writer = XmlWriter.Create(stringWriter))
            {
                serializer.Serialize(writer, cdList);
            }
            string res = stringWriter.ToString();

            return res;

        }

        public static string ObjectToXML<T>(T value)
        {
            StringWriter stringWriter = new StringWriter();
            XmlSerializer xmlserializer = new XmlSerializer(typeof(T));

            using (XmlWriter writer = XmlWriter.Create(stringWriter))
            {
                xmlserializer.Serialize(writer, value);
            }
            string respont = stringWriter.ToString();
            return respont;
        }

    }
}
