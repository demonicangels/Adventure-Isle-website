using BusinessLogic;
using BusinessLogic.Interfaces;
using UnitTests.MockData;

namespace UnitTests
{
    [TestClass]
    public class AlgorithmTests
    {
        CalculationsRepo al = new CalculationsRepo();
        
		static IDestinationRepository _destinationRepository = new DestinationRepositoryTest();
		static DestinationService desService = new DestinationService(_destinationRepository);

        static IRecommendationsRepository recommendationsRepository = new RecommendationRepoTest();

        RecommendationsService recs = new RecommendationsService(recommendationsRepository, desService);

		

        [TestMethod]
        public void BestRatedDestinations()
        {
            var destinations = new List<DestinationDTO>()
            {
                new DestinationDTO(){Name = "Pernik", AvgRating = 0},
				new DestinationDTO(){Name = "Berlin", AvgRating = 0},
				new DestinationDTO(){Name = "Eindhoven", AvgRating = 4.5},
				new DestinationDTO(){Name = "Madrid", AvgRating = 5},
            };

            
            
            
        }

        [TestMethod]
        public void CalvulateAverageRating()
        {
            //var rating1 = 5;
            //var rating2 = 3;
            //var rating3 = 5;
            //var des = new Destination();
            //des.ratingList.Add(rating1);
            //des.ratingList.Add(rating2);
            //des.ratingList.Add(rating3);
            //
            //var expected = 4.33;
            //
            //var actual = des.CalculateAverage(2);
            //
            //Assert.IsNotNull(actual);
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Recommendations()
        {
            List<DestinationsTest> thesame = new List<DestinationsTest>();
            List<DestinationsTest> recommendation = new List<DestinationsTest>();

            List<DestinationsTest> destinations = new List<DestinationsTest>()
            {
                new DestinationsTest("Paris","", "moderate", null),
                new DestinationsTest("Rome", "", "moderate", null),
                new DestinationsTest("Spain","", "hot", null),
                new DestinationsTest("Italy","", "moderate", null),
                new DestinationsTest("Barcelona","", "hot", null),
                new DestinationsTest("Bulgaria","", "moderate", null),
            };

            List<DestinationsTest> userDes = new List<DestinationsTest>()
            {
                new DestinationsTest("Paris","", "moderate", null),
                new DestinationsTest("Rome","", "moderate", null),
                new DestinationsTest("Macedonia","", "moderate", null),
                new DestinationsTest("Spain","", "hot", null),
                new DestinationsTest("Arruba","", "hot", null),
            };

            var duplicates = userDes.GroupBy(c => c.Climate)
                .Where(g => g.Count() > 1)
                .Select(y => new { Name = y.Key, Count = y.Count() })
                .ToList();

            var mostVisitedC = duplicates.OrderByDescending(c => c.Count).FirstOrDefault();
            
            var matchingDestinations = destinations
                .Where(d => !userDes.Any(ud => ud.Name == d.Name) && d.Climate == mostVisitedC.Name).ToArray();
            recommendation.AddRange(matchingDestinations);

            Assert.AreEqual(2, matchingDestinations.Length);
            Assert.AreEqual("moderate", mostVisitedC.Name);
            Assert.AreEqual(2, recommendation.Count);
        }

        //[TestMethod]
        //public void UserWithMostWeight()
        //{
        //    var reviews = new List<Review>
        //    {
        //        new Review(1, ""),
        //        new ReviewsTest(1, ""),
        //        new ReviewsTest(1, ""),
        //        new ReviewsTest(1, ""),
        //        new ReviewsTest(2, ""),
        //        new ReviewsTest(2, ""),
        //    };
        //
        //    var userId = 1;
        //    
        //    var result = reviews.Count(r => r.UserId == userId);
        //
        //    reviews = reviews.OrderBy(r => result).ToList();
        //
        //    Assert.IsTrue(result == 4);
        //    Assert.AreEqual(1,reviews[0].UserId);
        //}
    }
}
