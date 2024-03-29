﻿using System;
using System.IO;
using Newtonsoft.Json;

namespace PrecipitationPredictor
{
    class Program
    {
        // Declare date variable
        public static string date = "";


        static void Main(string[] args)
        {
            // Write instructions for user to console
            Console.WriteLine("Welcome to Precipitation Predictor!");
            Console.WriteLine("\nResults are based on historical precipitation data from the 27612 ZIP code.");
            Console.WriteLine("\nEnter any date in Month/day format (ex: 12/7) to find out the predicted\nprecipitation amount for that date.");
            Console.WriteLine("\n(press 'enter' to use today's date)\n");

            // Store user input in date variable
            date = Console.ReadLine();

            // If user pressed enter for current date, write current date in M/dd format to console
            if (date == "")
            {
                date = DateTime.Now.ToString("M/dd");

                // Write current date to console for appearance continuity, since no date was typed onto it.
                Console.WriteLine(date);
            }

            // Store PredictorResults in variable "prediction"
            string prediction = PredictorResults.PrecipAverage(date);

            Console.WriteLine(prediction);

        }
    }

    public static class PredictorResults
    {
        // Declare variable "averagePrecipitation" to store quotient for equation 
        public static double averagePrecipitation = 0;

        public static string PrecipAverage(string date)
        {
            // Read-in JSON file and store result in variable "contents"
            using (StreamReader precipResults = new StreamReader(@"parsed-precip-data.json"))
            {
                string contents = precipResults.ReadToEnd();

                // Deserialize "contents" and store results in variable "results"
                var results = JsonConvert.DeserializeObject<dynamic>(contents);

                // If user input leading zero for single-digit month, remove it
                string cleanDate = date.TrimStart('0');

                // Declare variable "runningSum" to store accumlated precipitation amounts
                double runningSum = 0;

                // Declare variable "count" to store number of objects with matching dates
                int count = 0;

                // Loop through objects of var "results"

                // Declare counter variable
                int i = 0;

                while (i < results.Count)
                {

                    // Check if parsedDate for each object in results matches cleaned date from user input
                    if (results[i].parsedDate == cleanDate)
                    {
                        // Write contents of matching objects to console to check accuracy
                        //Console.WriteLine(results[i]);

                        // Assign string version of precipitation amount to variable "strPRCP"
                        string strPRCP = results[i].PRCP;

                        // Convert string precipitation amount to a double data type to allow for calculation
                        double dblPRCP = Convert.ToDouble(strPRCP);

                        // Add precipitation amount to the running sum
                        runningSum += dblPRCP;

                        // Increase count by one for each object with matching date
                        count++;

                        // Check that runningSum and count are increasing accurately
                        //Console.WriteLine(runningSum);
                        //Console.WriteLine(count);

                        // Calculate average precipitation amount
                        averagePrecipitation = runningSum / count;

                    }

                    // Increase counter by one
                    i++;

                }

            }

            // Write average precipitation amount for given date to the console
            return "\nThe predicted precipitation amount on " + date + " is " + averagePrecipitation + " units.";

        }
                
    }
}
