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

        // public List<StoreFront> SearchStoreFrontById(StoreFront storeID)
        // {

        //     List<StoreFront> listOfStoreFront = new List<StoreFront>();

        //     string sqlQuery = @"select * from StoreFront where storeID = @storeID";

        //     using (SqlConnection con = new SqlConnection("Server=tcp:furrbabies.database.windows.net,1433;Initial Catalog=Furr-Babbies-Pet-Supply;Persist Security Info=False;User ID=FurrBabies;Password=RheaandLdog1$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
        //     {
        //         con.Open();

        //         SqlCommand command = new SqlCommand(sqlQuery, con);
        //         command.Parameters.AddWithValue("@storeID", storeID._storeID);

        //         SqlDataReader reader = command.ExecuteReader();

        //         while (reader.Read())
        //         {

        //             listOfStoreFront.Add(new StoreFront()
        //             {
        //                 _storeID = reader.GetInt32(0),
        //                 _storeName = reader.GetString(1),
        //                 StoreAddress = reader.GetString(3)


        //             });
        //         }

        //         // return listOfStoreFront[0];
        //     }
        //     return listOfStoreFront;

        // }


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





    }



}