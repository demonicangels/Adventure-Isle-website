using BusinessLogic;
using BusinessLogic.Interfaces;
using System.Linq;
using UnitTests.MockData;

namespace UnitTests
{
    [TestClass]
    public class RecommendationsTests
    {

        static IRecommendationsRepository recommendationsRepository = new Recommendations();
        static IDestinationRepository destinationRepository = new DestinationRepositoryTest();
        static DestinationService d = new DestinationService(destinationRepository);
        RecommendationsService recs = new RecommendationsService(recommendationsRepository, d);

        [TestMethod]
        public void BestRatedDestinationsRecs()
        {
            recs.InitializeDictionary(null, null);
            var bestRated = recs.Recommendations("Rating");

            
            Assert.IsNotNull(bestRated);
            Assert.AreEqual(bestRated.Length, 3);
            Assert.IsTrue(bestRated[0].AvgRating == 5 && bestRated[2].AvgRating == 3 );
        }

        [TestMethod]
        public void WantedRatingRecs()
        {
            recs.InitializeDictionary(null, "3");
            var wantedRatingDes = recs.Recommendations("Rating");

            Assert.IsNotNull(wantedRatingDes);
            Assert.AreEqual(wantedRatingDes.Length, 1);
            Assert.AreEqual(wantedRatingDes.FirstOrDefault().Name, "Stockholm");
        }

        [TestMethod]
        public void WantedClimateRecs()
        {
            recs.InitializeDictionary(null, "humid");
            var wantedClimateDes = recs.Recommendations("Climate");

            Assert.IsNotNull(wantedClimateDes);
            Assert.AreEqual(wantedClimateDes.Length, 1);
            Assert.AreEqual(wantedClimateDes.FirstOrDefault().Name, "Rome");
        }

        [TestMethod]
        public void MostVisitedClimateUserRecs()
        {
            recs.InitializeDictionary(234, null);
            var mostVisitedClimateRecs = recs.Recommendations("Climate");

            Assert.IsNotNull(mostVisitedClimateRecs);
            Assert.AreEqual(mostVisitedClimateRecs.Length, 2);
            Assert.AreEqual(mostVisitedClimateRecs.FirstOrDefault().Name, "Plovdiv");
        }

    }
}
