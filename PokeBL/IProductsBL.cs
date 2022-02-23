using PokeModel;
namespace PokeBL
{
    public interface IProductBL
    {
        Product AddProduct(Product c_product);

        List<Product> SearchProduct(string c_product);

        List<Product> GetAllProductByStoreID(int storeID);


    }
}