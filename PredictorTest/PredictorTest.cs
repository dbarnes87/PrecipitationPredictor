using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using PrecipitationPredictor;

namespace PredictorTests
{
    [TestClass]
    public class PrecipitationPredictorTests
    {

        [TestMethod]

        // Test if date input IS received from user
        public void DateGiven()
        {
            string date = "1/15";

            string testOutput = $"\nThe predicted precipitation amount on 1/15 is 0.015000000000000001 units.";

            string predictedOutput = $"{PredictorResults.PrecipAverage(date)}";

            Assert.AreEqual(testOutput, predictedOutput);
        }
    }
}
