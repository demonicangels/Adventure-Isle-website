using BusinessLogic.Entities;
using DAL.DTOs;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        private string connectionStr = "Data Source=mssqlstud.fhict.local;User ID=dbi482269_aas2;Password=Ior7dh8Nrr;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        [TestMethod]
        public void GetUserByEmail()
        {
            var email = "demonic@gmail.com";
            var created_at = DateTime.Parse("3/30/2023 4:12:44 PM");
            var birthday = DateTime.Parse("10/4/2002 4:20:00 PM");
            var expectedUser = new User { Username = "demonic", Email = email, Password = "123", UserSince = created_at, Birthday = birthday, Bio = "If you are not travelling then what are you doing?" };

            var actualUser = User.GetUserByEmail(email);

            Assert.IsNotNull(actualUser);
            Assert.AreEqual(expectedUser.Username, actualUser.Username);
            Assert.AreEqual(expectedUser.Email, actualUser.Email);
            Assert.AreEqual(expectedUser.Birthday, actualUser.Birthday);
            Assert.AreEqual(expectedUser.Bio, actualUser.Bio);
            Assert.AreEqual(expectedUser.UserSince.Date, actualUser.UserSince.Date);
        }

        [TestMethod]
        public void DeleteUser()
        {
            var name = "test";
            var birthday = DateTime.Parse("10/4/2002 4:20:00 PM");
            UserDTO user = new UserDTO { username = name, email = "test@gmail.com", password = "123", birthday = birthday, Bio = "Testing for bugs and eradicating them." };
            User.InsertUser(user);
            var email = "test@gmail.com";


            User.DeleteUser(email);

            var deletedUser = new User();
            try
            {
                deletedUser = User.GetUserByName(name);
            }
            catch { }

            Assert.IsNotNull(deletedUser);
        }
        [TestMethod]
        public void UserAuthentication()
        {
            var email = "demonic@gmail.com";
            var pass = "123";

            var credentials = new User { Email = email, Password = pass };

            var expectedResult = true;
            var actualResult = User.Authenticate(credentials);

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
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
        public void CreateUserInstanceFromDTO()
        {
            var userDTO = new UserDTO
            {
                username = "test",
                email = "test@gmail.com",
                password = "123"
            };

            var result = User.FromDTO(userDTO);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(User));
            Assert.AreEqual(userDTO.username, result.Username);
            Assert.AreEqual(userDTO.email, result.Email);
            Assert.AreEqual(userDTO.password, result.Password);
        }

    }
}