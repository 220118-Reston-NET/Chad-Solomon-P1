using PokeModel;
using System.Data.SqlClient;

namespace PokeDL
{
    public class SQLStoreHistory : ISQLStoreHistory
    {


        private readonly string _connectionStrings;

        public SQLStoreHistory(string p_connectionStrings)
        {

            _connectionStrings = p_connectionStrings;
        }

        public List<StoreOrder> GetStoreOrder()
        {
            List<StoreOrder> listStoreOrder = new List<StoreOrder>();

            string sqlQuery = @"select * from Store_Order 
                                where storeID = @storeID";
            /**/


            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                //command.Parameters.AddWithValue("@storeID", storeID);

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



