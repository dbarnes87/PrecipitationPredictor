using System;

namespace PrecipitationPredictor
{
    class Program
    {
        public static string date = "";


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Precipitation Predictor!\nResults are based on historical precipitation data from the 27612 ZIP code.");
            Console.WriteLine("Enter any date in MM/DD format (ex: 12/25).");
            date = Console.ReadLine();
            Console.WriteLine(date);
        }
    }
}
