using PokeModel;
namespace PokeDL
{

    public interface IProductRepo
    {

        Product AddProduct(Product c_product);

        List<Product> GetAllProduct();

        List<Product> GetAllProductsByStoreID(int storeID);
    }
}