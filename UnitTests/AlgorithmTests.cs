using BusinessLogic;
using UnitTests.MockData;

namespace UnitTests
{
    [TestClass]
    public class AlgorithmTests
    {
        CalculationsService al = new CalculationsService();

        [TestMethod]
        public void BestRatedDestinations()
        {
            var destinations = new List<DestinationsTest>()
            {
                new DestinationsTest("Pernik","","",0),
                new DestinationsTest("Berlin","","",0),
                new DestinationsTest("Eindhoven","","", 4.5),
                new DestinationsTest("Madrid","","",5)
            };

            var bestRated = destinations[0];
            List<DestinationsTest> bestDestinations = new List<DestinationsTest>();
            for (int i = 0; i < destinations.Count; i++)
            {
                
                if (destinations[0].AvgRating > 0 && destinations[i].AvgRating >= 4)
                {
                    if (destinations[i].AvgRating >= bestRated.AvgRating)
                    {
                        bestRated = destinations[i];
                    }
                    bestDestinations.Add(bestRated);
                    destinations.Remove(bestRated);
                    i--;
                }
                else if (destinations[i].AvgRating == 0 || destinations[i].AvgRating < 4)
                {
                    destinations.Remove(destinations[i]);
                    i--;
                }
                else
                {
                    continue;
                }
            }
            bestDestinations = bestDestinations.OrderByDescending(d => d.AvgRating).ToList();

            Assert.AreEqual(2, bestDestinations.Count);
            Assert.IsTrue(bestDestinations[0].AvgRating > bestDestinations[1].AvgRating);
            Assert.IsTrue(bestDestinations[0].AvgRating > 0 && bestDestinations[1].AvgRating > 0);
        }

        [TestMethod]
        public void CalvulateAverageRating()
        {
            var rating1 = 5;
            var rating2 = 3;
            var rating3 = 5;
            var des = new Destination();
            des.ratingList.Add(rating1);
            des.ratingList.Add(rating2);
            des.ratingList.Add(rating3);

            var expected = 4.33;

            var actual = des.CalculateAverage();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
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

        [TestMethod]
        public void UserWithMostWeight()
        {
            var reviews = new List<ReviewsTest>
            {
                new ReviewsTest(1, ""),
                new ReviewsTest(1, ""),
                new ReviewsTest(1, ""),
                new ReviewsTest(1, ""),
                new ReviewsTest(2, ""),
                new ReviewsTest(2, ""),
            };

            var userId = 1;
            
            var result = reviews.Count(r => r.UserId == userId);

            reviews = reviews.OrderBy(r => result).ToList();

            Assert.IsTrue(result == 4);
            Assert.AreEqual(1,reviews[0].UserId);
        }
    }
}
