using System.Globalization;

namespace DateTimeFormatInCSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var datetime = new DateTime(2017, 8, 4, 22, 35, 15, 18);
            Console.WriteLine(datetime.ToString("gg", CultureInfo.CreateSpecificCulture("en-US")));
        }
    }
}