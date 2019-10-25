//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
//using PrecipitationPredictor;

//namespace PredictorTests
//{
//    [TestClass]
//    public class PrecipitationPredictorTests
//    {
//        [TestMethod]

//        // Test if date input NOT received from user
//        public void NoDateGiven()
//        {
//            string date = "";

//            string testOutput = "\nThe predicted precipitation amount on 10/25 is 0.2725.";

//            string predictedOutput = $"{PredictorResults.PrecipAverage(date)}";

//            Assert.AreEqual(testOutput, predictedOutput);
//        }

//        [TestMethod]

//        // Test if date input IS received from user
//        public void DateGiven()
//        {
//            string date = "1/15";

//            string testOutput = $"\nThe predicted precipitation amount on 1/15 is 0.015000000000000001.";

//            string predictedOutput = $"{PredictorResults.PrecipAverage(date)}";

//            Assert.AreEqual(testOutput, predictedOutput);
//        }
//    }
//}
