using BusinessLogic;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        IDestinationRepository _destinationRepository = new DestinationRepositoryTest();
        IUserRepository _userRepository = new UserRepositoryTest();

        [TestMethod]
        public void GetUserByEmail()
        {
			var user1 = new UserDTO() { username = "demonic", email = "demonic@gmail.com", password = "123", userSince = DateTime.Parse("3/30/2023 4:12:44 PM"), birthday = DateTime.Parse("10/4/2002 4:20:00 PM"), Bio = "If you are not travelling then what are you doing?" };
			var user2 = new UserDTO() { username = "angel", email = "angel@gmail.com", password = "123", userSince = DateTime.Parse("3/30/2023 4:12:44 PM"), birthday = DateTime.Parse("10/4/2002 4:20:00 PM"), Bio = "If you are not travelling then what are you doing?" };
            _userRepository.InsertUser(user1);
            _userRepository.InsertUser(user2);

			var expectedUser = new UserDTO() { username = "angel", email = "angel@gmail.com", password = "123", userSince = DateTime.Parse("3/30/2023 4:12:44 PM"), birthday = DateTime.Parse("10/4/2002 4:20:00 PM"), Bio = "If you are not travelling then what are you doing?" };
			
            var actualUser = _userRepository.GetUserByEmail("angel@gmail.com");

            Assert.IsNotNull(actualUser);
            Assert.AreEqual(expectedUser.username, actualUser.username);
            Assert.AreEqual(expectedUser.email, actualUser.email);
            Assert.AreEqual(expectedUser.birthday, actualUser.birthday);
            Assert.AreEqual(expectedUser.Bio, actualUser.Bio);
            Assert.AreEqual(expectedUser.userSince.Date, actualUser.userSince.Date);
        }

        [TestMethod]
        public void DeleteUser()
        {
            var name = "test";
            var birthday = DateTime.Parse("10/4/2002 4:20:00 PM");
			var email = "test@gmail.com";
			UserDTO user = new UserDTO { username = name, email = email , password = "123", birthday = birthday, Bio = "Testing for bugs and eradicating them." };
            _userRepository.InsertUser(user);

            UserDTO expectedResult = null;

            _userRepository.DeleteUser(email);

            var actualResult = _userRepository.GetUserByEmail(email);

            Assert.IsNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void UserAuthentication()
        {
            var email = "demonic@gmail.com";
            var pass = "123";

            var credentials = new UserDTO() { email = email, password = pass };

            var expectedResult = true;
            var actualResult = _userRepository.Authentication(credentials);

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SearchDestination()
        {
            var search = "Pa";
            var d = new DestinationDTO() { Name = "Provence", Country = "France" };
            var expectedDes = new DestinationDTO() { Name = "Paris", Country = "France" };

            _destinationRepository.InsertDestination(expectedDes);
			_destinationRepository.InsertDestination(d);

			var actualDes = _destinationRepository.GetDestinationByName(search);

            Assert.IsNotNull(actualDes);
            Assert.AreEqual(expectedDes.Name, actualDes.Name);
            Assert.AreEqual(expectedDes.Country, actualDes.Country);
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

            var result = UserService.FromDTO(userDTO);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(User));
            Assert.AreEqual(userDTO.username, result.Username);
            Assert.AreEqual(userDTO.email, result.Email);
            Assert.AreEqual(userDTO.password, result.Password);
        }   
    }
}