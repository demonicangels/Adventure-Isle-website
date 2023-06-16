using BusinessLogic;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.MockData;

namespace UnitTests
{
    [TestClass]
    public class CalculationServiceTests
    {
        static ICalculationsRepository calc = new Calculations();
        static IDestinationRepository destinationRepository = new DestinationRepositoryTest();
        static IReviewRepository reviewRepository = new ReviewRepositoryTest();
        static ReviewService r = new ReviewService(reviewRepository);
        static DestinationService d = new DestinationService(destinationRepository);
        CalculationService _calculator = new CalculationService(calc, d,r);

        [TestMethod]
        public void UserWithMostReviewWeightReturnsTrueWeight()
        {
            var reviews = _calculator.UserWithMostReviewWeight().ToList();
            int weight = 0;

            weight = calc.CalculateUserWeight(1, reviews);

            var expected = 3;

            Assert.IsNotNull(weight);
            Assert.AreEqual(expected, weight);
        }

        [TestMethod]
        public void UserWithMostReviewWeightReturnsTrueOrder()
        {
            var result = _calculator.UserWithMostReviewWeight();

            Assert.IsNotNull(result);
            Assert.IsTrue(result[0].UserId == 1);
        }

        [TestMethod]
        public void CalculateAvgWeightDestination()
        {
            var result = _calculator.CalculateAverageWeightDestination(3);
            double expected = 3;

            Assert.IsNotNull(result);
            Assert.AreEqual(result, expected);
        }
    }
}
