using PokeModel;
using Xunit;
namespace UnitTest
{
    public class CustomerEmailTesting
    {
        [Fact]
        public void SetValidEmail()
        {
            //Arrange
            Customer cust = new Customer();
            string validEmail = "rhea@dogmail.com";

            //ACT
            cust.Email = validEmail;

            //Assert
            Assert.NotNull(cust.Email);
            Assert.Equal(validEmail, cust.Email);


        }




    }
}