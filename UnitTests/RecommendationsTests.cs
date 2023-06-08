using BusinessLogic;
using BusinessLogic.Interfaces;
using System.Linq;
using UnitTests.MockData;

namespace UnitTests
{
    [TestClass]
    public class RecommendationsTests
    {

        static IRecommendationsRepository recommendationsRepository = new RecommendationRepositoryTest();
        static IDestinationRepository destinationRepository = new DestinationRepositoryTest();
        static DestinationService d = new DestinationService(destinationRepository);
        RecommendationsService recs = new RecommendationsService(recommendationsRepository, d);

        [TestMethod]
        public void BestRatedDestinationsRecs()
        {
            recs.InitializeDictionary(null, null, "Rating");
            var bestRated = recs.iDictionary["Rating"].Invoke(recommendationsRepository);

            

            Assert.IsNotNull(bestRated);
            Assert.AreEqual(bestRated.Length, 2);
            Assert.IsTrue(bestRated[0].AvgRating == 5 && bestRated[1].AvgRating == 4.33);
        }

        [TestMethod]
        public void WantedRatingRecs()
        {
            recs.InitializeDictionary(null, "3", "Rating");
            var wantedRatingDes = recs.iDictionary["Rating"].Invoke(recommendationsRepository);

            Assert.IsNotNull(wantedRatingDes);
            Assert.AreEqual(wantedRatingDes.Length, 1);
            Assert.AreEqual(wantedRatingDes.FirstOrDefault().Name, "Stockholm");
        }

        [TestMethod]
        public void WantedClimateRecs()
        {
            recs.InitializeDictionary(null, "humid", "Climate");
            var wantedClimateDes = recs.iDictionary["Climate"].Invoke(recommendationsRepository);

            Assert.IsNotNull(wantedClimateDes);
            Assert.AreEqual(wantedClimateDes.Length, 1);
            Assert.AreEqual(wantedClimateDes.FirstOrDefault().Name, "Rome");
        }

        [TestMethod]
        public void MostVisitedClimateUserRecs()
        {
            recs.InitializeDictionary(2, null, "Climate");
            var mostVisitedClimateRecs = recs.iDictionary["Climate"].Invoke(recommendationsRepository);

            Assert.IsNotNull(mostVisitedClimateRecs);
            Assert.AreEqual(mostVisitedClimateRecs.Length, 1);
            Assert.AreEqual(mostVisitedClimateRecs.FirstOrDefault().Name, "Paris");
        }

    }
}
