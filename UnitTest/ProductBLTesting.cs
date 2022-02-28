using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using PokeBL;
using PokeDL;
using PokeModel;
using Xunit;

namespace ProductTest
{
    public class ProductTest
    {
        public void Should_Get_All_Product()
        {
            //Arrange
            int productID = 1;
            string productName = "Leash";
            string productDescription = "Nylon";
            int productPrice = 20;

            Product _prod = new Product()
            {

                ID = productID,
                Name = productName,
                Description = productDescription,
                Price = productPrice

            };

            List<Product> _expectedListProduct = new List<Product>();

            _expectedListProduct.Add(_prod);

            Mock<IProductRepo> _mockRepo = new Mock<IProductRepo>();

            _mockRepo.Setup(repo => repo.GetAllProduct()).Returns(_expectedListProduct);

            IProductBL _prodBL = new ProductBL(_mockRepo.Object);

            List<Product> _actualListOfProduct = _prodBL.GetAllProducts();

            //Assert
            Assert.Same(_expectedListProduct, _actualListOfProduct);
            Assert.Equal(productID, _actualListOfProduct[0].ID);
            Assert.Equal(productName, _actualListOfProduct[0].Name);
            Assert.Equal(productPrice, _actualListOfProduct[0].Price);


        }
    }
}