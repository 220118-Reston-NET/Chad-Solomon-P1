using PokeDL;
using PokeModel;
namespace PokeBL
{

    public class ProductBL : IProductBL
    {

        //Dependency Injection

        private IProductRepo _orepo;
        public ProductBL(IProductRepo o_repo)
        {
            _orepo = o_repo;
        }

        public Product AddProduct(Product c_product)
        {
            return _orepo.AddProduct(c_product);

        }

        public List<Product> GetAllProductByStoreID(int storeID)
        {
            return _orepo.GetAllProductsByStoreID(storeID);
        }

        public List<Product> SearchProduct(string c_product)
        {
            List<Product> listOfProduct = _orepo.GetAllProduct();

            //LINQ Library
            //.Where() filters a sequence of values based on a predicate
            //.ToList used with .Where or other methods from the IEnumerable class to place the out from the IEnumerable into a list.
            return listOfProduct
                    .Where(prod => prod.Name.Contains(c_product))
                    .ToList();


        }


    }
}