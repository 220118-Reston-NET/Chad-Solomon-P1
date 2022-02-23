using System.Data.SqlClient;
using PokeModel;
namespace PokeDL
{
    public class SQLProductRepository : IProductRepo
    {
        private readonly string _connectionStrings;
        public SQLProductRepository(string p_connectionStrings)
        {

            _connectionStrings = p_connectionStrings;
        }
        public Product AddProduct(Product c_product)
        {
            string sqlQuery = @"insert into Product values (@prodName, @Description, @prodPrice)";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@prodName", c_product.Name);
                command.Parameters.AddWithValue("@prodDescription", c_product.Description);
                command.Parameters.AddWithValue("@prodPrice", c_product.Price);

                command.ExecuteNonQuery();

                return c_product;
            }



        }

        public List<Product> GetAllProduct()
        {
            List<Product> listOfProduct = new List<Product>();

            string sqlQuery = @"select * from Product";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfProduct.Add(new Product()
                    {
                        _prodID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        Price = reader.GetInt32(3)
                    });


                }
            }
            return listOfProduct;
        }

        public List<Product> GetAllProductsByStoreID(int storeID)
        {
            string sqlQuery = @"select p.prodID, p.prodName, p.prodDescription, p.prodPrice  
                                from Product p, StoreInventory s 
                                where p.prodID = s.prodID and s.storeID = @storeID";

            List<Product> listProducts = new List<Product>();

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                command.Parameters.AddWithValue("@storeID", storeID);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    listProducts.Add(new Product()
                    {

                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        Price = reader.GetInt32(3)


                    });
                }
            }

            return listProducts;
        }
    }
}