using System;
using System.IO;
using Newtonsoft.Json;

namespace PrecipitationPredictor
{
    class Program
    {
        public static string date = "";


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Precipitation Predictor!");
            Console.WriteLine("\nResults are based on historical precipitation data from the 27612 ZIP code.");
            Console.WriteLine("\nEnter any date in M/DD format (ex: 12/25 or 7/4) to find out predicted\nprecipitation total for that date.");
            Console.WriteLine("\n(press 'enter' to use today's date)");
            date = Console.ReadLine();
            string result = PredictorResults.PrecipAverage(date);
            Console.WriteLine(result);

        }
    }

    public static class PredictorResults
    {
        public static string PrecipAverage(string date)
        {
            using(StreamReader precipResults = new StreamReader(@"/Users/davidbarnes/PrecipitationPredictor/PrecipitationPredictor/parsed-precip-data.json"))
            {
                        string contents = precipResults.ReadToEnd();

                var res = JsonConvert.DeserializeObject<dynamic>(contents);

                if (date == "")
                {
                    date = DateTime.Now.ToString("M/dd");
                }

                //Console.WriteLine(res[0]);
                //Console.WriteLine(res[0].DATE);


                double sum = 0;

                int count = 0;

                double avg = 0;

                int x = 0;

                for (int i = 0; i < 4492; i++)
                {
                    if (res[i].parsedDate == date)
                    {
                        //Console.WriteLine(res[i]);
                        string strPRCP = res[i].PRCP;
                        double dblPRCP = Convert.ToDouble(strPRCP);


                        sum += dblPRCP;

                        count++;

                        //Console.WriteLine(sum);

                        avg = sum / count;

                    }

                        if (res[i].parsedDate != date)
                    {
                        x++;
                    }
                }

                Console.WriteLine("The predicted precipitation amount on " + date + " is " + avg + ".");
            }

            return "\nThanks for using the Precipitation Predictor.";
        }
                
    }
}
