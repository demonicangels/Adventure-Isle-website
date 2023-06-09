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
        static ICalculationsRepository calc = new CalculationsRepositoryTest();
        static IDestinationRepository destinationRepository = new DestinationRepositoryTest();
        static IReviewRepository reviewRepository = new ReviewRepositoryTest();
        static ReviewService r = new ReviewService(reviewRepository);
        static DestinationService d = new DestinationService(destinationRepository);
        CalculationService _calculator = new CalculationService(calc, d,r);

        [TestMethod]
        public void UserWithMostReviewWeightReturnsTrueWeight()
        {
            var weight = calc.CalculateUserWeight(1,r.GetReviews().ToList());

            var expected = 3;

            Assert.IsNotNull(weight);
            Assert.AreEqual(expected, weight);
        }

        [TestMethod]
        public void UserWithMostReviewWeightReturnsTrueOrder()
        {
            var result = calc.UserWithMostReviewWeight(r.GetReviews().ToList());

            Assert.IsNotNull(result);
            Assert.IsTrue(result[0].UserId == 1);
        }

        [TestMethod]
        public void CalculateAvgWeightDestination()
        {
            var result = calc.CalculateAverageWeightDestination(3, r.GetReviews().ToList());
            double expected = 3;

            Assert.IsNotNull(result);
            Assert.AreEqual(result, expected);
        }
    }
}
