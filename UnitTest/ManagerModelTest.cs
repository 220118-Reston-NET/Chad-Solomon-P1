using Xunit;
using PokeModel;
namespace UnitTest
{
    public class ManagerModelTesting
    {

        [Fact]
        public void SetValidManagerID()
        {
            //Arrange
            Manager _man = new Manager();
            int validManagerID = 1;

            //Act
            _man.ManagerID = validManagerID;

            //Assert
            Assert.NotNull(_man.ManagerID);
            Assert.Equal(validManagerID, _man.ManagerID);
        }

        [Fact]
        public void SetValidStoreFrontID()
        {
            //Arrange
            Manager _man1 = new Manager();
            int validStoreFrontID = 1;

            //Act
            _man1.StoreFrontID = validStoreFrontID;

            //Assert
            Assert.NotNull(_man1.StoreFrontID);
            Assert.Equal(validStoreFrontID, _man1.StoreFrontID);
        }

        [Fact]
        public void SetValidManagerName()
        {
            //Arrange
            Manager _man2 = new Manager();
            string validManagerName = "Flash";

            //Act
            _man2.ManagerName = validManagerName;

            //Assert
            Assert.NotNull(_man2.ManagerName);
            Assert.Equal(validManagerName, _man2.ManagerName);
        }

        [Fact]
        public void SetValidManagerAddress()
        {
            //Arrange
            Manager _man2 = new Manager();
            string validManagerAddress = "123 Flash Lane";

            //Act
            _man2.ManagerAddress = validManagerAddress;

            //Assert
            Assert.NotNull(_man2.ManagerAddress);
            Assert.Equal(validManagerAddress, _man2.ManagerAddress);
        }

        [Fact]
        public void SetValidManagerEmail()
        {
            //Arrange
            Manager _man2 = new Manager();
            string validManagerEmail = "flash@gmail.com";

            //Act
            _man2.ManagerEmail = validManagerEmail;

            //Assert
            Assert.NotNull(_man2.ManagerEmail);
            Assert.Equal(validManagerEmail, _man2.ManagerEmail);
        }

        [Fact]
        public void SetValidManagerPassword()
        {
            //Arrange
            Manager _man2 = new Manager();
            string validManagerPassword = "FlashOne";

            //Act
            _man2.ManagerPassword = validManagerPassword;

            //Assert
            Assert.NotNull(_man2.ManagerPassword);
            Assert.Equal(validManagerPassword, _man2.ManagerPassword);
        }
    }

}