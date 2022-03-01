using System.Data.SqlClient;
using PokeModel;
namespace PokeDL
{
    public class SQLStoreFrontRepo : IStoreFrontRepo
    {

        private readonly string _connectionStrings;
        public SQLStoreFrontRepo(string p_connectionStrings)
        {

            _connectionStrings = p_connectionStrings;
        }
        public StoreFront AddStoreFront(StoreFront s_name)
        {

            string sqlQuery = @"insert into StoreFront values (@storeName, @storeAddress)";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@storeName", s_name.StoreName);
                command.Parameters.AddWithValue("@storeAddress", s_name.StoreAddress);

                //command.Parameters.AddWithValue("@custName", c_customer);

                command.ExecuteNonQuery();

                return s_name;
            }

        }




        public List<StoreFront> GetAllStoreFronts()
        {

            List<StoreFront> listOfStoreFront = new List<StoreFront>();

            string sqlQuery = @"select * from StoreFront";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {

                    listOfStoreFront.Add(new StoreFront()
                    {
                        StoreID = reader.GetInt32(0),
                        StoreName = reader.GetString(1),
                        StoreAddress = reader.GetString(2)

                    });
                }
            }

            return listOfStoreFront;

        }

        public List<Manager> GetAllManagers()
        {

            List<Manager> _listOfManager = new List<Manager>();

            string sqlQuery = @"select * from Manager";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {

                    _listOfManager.Add(new Manager()
                    {
                        ManagerID = reader.GetInt32(0),
                        ManagerName = reader.GetString(1),
                        ManagerAddress = reader.GetString(2),
                        ManagerEmail = reader.GetString(3),
                        ManagerPassword = reader.GetString(4),
                        IsManager = reader.GetBoolean(5)


                    });
                }
            }


            return _listOfManager;

        }

        public Inventory AddInventory(Inventory _inv, string _email, string _managerPassword)
        {


            string sqlQuery = @"update StoreInventory 
                                set Quantity = @Quantity
                                where prodID = @prodID and storeID = @StoreID";

            // string sqlQuery = @"insert into sf.storeName, p.prodName, si.Quantity from StoreFront sf 
            //     inner join StoreInventory si on sf.storeID = si.storeID 
            //     inner join Product p on p.prodID = si.prodID";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@prodID", _inv.ProductID);
                command.Parameters.AddWithValue("@Quantity", _inv.Quantity);
                command.Parameters.AddWithValue("@StoreID", _inv.StoreID);


                command.ExecuteNonQuery();




            }

            return _inv;
        }





    }



}