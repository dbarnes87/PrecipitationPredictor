using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using PrecipitationPredictor;

namespace PredictorTests
{
    [TestClass]
    public class PrecipitationPredictorTests
    {
        [TestMethod]
        public void NoDateGiven()
        {
            /* No Input */
            string date = "";

            /* Expected Output */
            string testOutput = "\nThe predicted precipitation amount on 10/24 is 0.5909090909090909.";

            /* Predicted Output */
            string predictedOutput = $"{PredictorResults.PrecipAverage(date)}";

            /* Check to see if equal */
            Assert.AreEqual(testOutput, predictedOutput);
        }

        [TestMethod]
        public void DateGiven()
        {
            /* No Input */
            string date = "1/15";

            /* Expected Output */
            string testOutput = $"\nThe predicted precipitation amount on 1/15 is 0.015000000000000001.";

            /* Predicted Output */
            string predictedOutput = $"{PredictorResults.PrecipAverage(date)}";

            /* Check to see if equal */
            Assert.AreEqual(testOutput, predictedOutput);
        }
    }
}
