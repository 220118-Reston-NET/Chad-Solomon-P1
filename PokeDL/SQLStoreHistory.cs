using PokeModel;
using System.Data.SqlClient;

namespace PokeDL
{
    public class SQLStoreHistory : ISQLStoreHistory
    {


        // public List<StoreFront> SearchStoreById(int storeID)
        // {

        //     List<StoreFront> listOfStoreFront = GetStore
        // }

        public List<StoreOrder> GetStoreOrder(int storeID)
        {
            List<StoreOrder> listStoreOrder = new List<StoreOrder>();

            string sqlQuery = @"select * from Store_Order 
                                where storeID = @storeID";
            /**/


            using (SqlConnection con = new SqlConnection("Server=tcp:furrbabies.database.windows.net,1433;Initial Catalog=Furr-Babbies-Pet-Supply;Persist Security Info=False;User ID=FurrBabies;Password=RheaandLdog1$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@storeID", storeID);

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {

                    listStoreOrder.Add(new StoreOrder()
                    {


                        _storeID = reader.GetInt32(0),
                        _orderID = reader.GetInt32(1)

                    });
                }
            }
            return listStoreOrder;

        }





    }


}



