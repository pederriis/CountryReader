using CountryReader;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        Country ct1 = new Country()
        {
            Name = "YES",
            ID = 5
        };

        Country ct2 = new Country()
        {
            Name = "YES",
            ID = 5
        };

        if (ct1 == ct2) 
        { 
        }

        BusinessController.Run();

    }
}