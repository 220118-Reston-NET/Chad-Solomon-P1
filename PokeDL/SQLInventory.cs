using PokeModel;
using System.Data.SqlClient;
namespace PokeDL
{
    public class SQLInventory : IInventoryRepo
    {

        private readonly string _connectionStrings;
        public SQLInventory(string p_connectionStrings)
        {

            _connectionStrings = p_connectionStrings;
        }

        public void AddInventory(int prodID)
        {

            string sqlQuery = @"update StoreInventory set Quantity = Quantity + 10 where prodID = @prodID";

            // string sqlQuery = @"insert into sf.storeName, p.prodName, si.Quantity from StoreFront sf 
            //     inner join StoreInventory si on sf.storeID = si.storeID 
            //     inner join Product p on p.prodID = si.prodID";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@prodID", prodID);
                //command.Parameters.AddWithValue("@Quantity", _quantity);

                command.ExecuteNonQuery();

                // return s_inventory;


            }
        }

        public List<Inventory> GetAllInventory()
        {


            List<Inventory> listOfProduct = new List<Inventory>();

            //string sqlQuery = @"select * from StoreInventory si";

            // string sqlQuery = @"select sf.storeName, p.prodName, p.prodID, p.prodDescription, si.Quantity from StoreFront sf inner join StoreInventory si on sf.storeID = si.storeID inner join Product p on p.prodID = si.prodID";

            string sqlQuery = @"select sf.storeID, sf.storeName, p.prodID, p.prodName, p.prodDescription, p.prodPrice, si.Quantity from StoreFront sf 
                inner join StoreInventory si on sf.storeID = si.storeID 
                inner join Product p on p.prodID = si.prodID";

            // string sqlQuery = @"select sf.storeName, p.prodName, si.Quantity from StoreFront sf 
            //     inner join StoreInventory si on sf.storeID = si.storeID 
            //     inner join Product p on p.prodID = si.prodID";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();



                SqlCommand command = new SqlCommand(sqlQuery, con);



                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfProduct.Add(new Inventory()
                    {
                        // _storeID = reader.GetInt32(0),
                        // _productID = reader.GetInt32(1),
                        StoreID = reader.GetInt32(0),
                        StoreName = reader.GetString(1),
                        ProductID = reader.GetInt32(2),
                        ProdName = reader.GetString(3),
                        Description = reader.GetString(4),
                        Price = reader.GetInt32(5),
                        Quantity = reader.GetInt32(6)

                    });

                }

            }

            return listOfProduct;
        }


    }


}