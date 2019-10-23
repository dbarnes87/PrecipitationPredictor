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
            Console.WriteLine("Welcome to Precipitation Predictor!\nResults are based on historical precipitation data from the 27612 ZIP code.");
            Console.WriteLine("Enter any date in MM/DD format (ex: 12/25) to find out predicted precipitation total for that date.");
            date = Console.ReadLine();
            string result = PredictorResults.PrecipAverage(date);
            Console.WriteLine(result);

        }
    }

    public static class PredictorResults
    {
        public static string PrecipAverage(string date)
        {
            using(StreamReader precipResults = new StreamReader(@"/Users/davidbarnes/PrecipitationPredictor/PrecipitationPredictor/preciprecords.json"))
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
                    if (res[i].DATE == date)
                    {
                        Console.WriteLine(res[i]);
                        string strPRCP = res[i].PRCP;
                        double dblPRCP = Convert.ToDouble(strPRCP);


                        sum += dblPRCP;

                        count++;

                        Console.WriteLine(sum);

                        avg = sum / count;

                    }

                        if (res[i].DATE != date)
                    {
                        x++;
                    }
                }

                Console.WriteLine("The predicted precipitation amount on " + date + " is " + avg + ".");
            }

            return "0";
        }
                
    }
}
