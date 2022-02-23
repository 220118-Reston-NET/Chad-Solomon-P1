using System.Data.SqlClient;
using PokeModel;
namespace PokeDL
{
    public class OrderHistRepo : IOrderHistRepo
    {

        private readonly string _connectionStrings;
        public OrderHistRepo(string p_connectionStrings)
        {

            _connectionStrings = p_connectionStrings;
        }
        public List<Order> GetAllOrders(int custID)
        {

            List<Order> listOfOrders = new List<Order>();

            string sqlQuery = @"select * from Orders
                                    where custID = @custID";


            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@custID", custID);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    listOfOrders.Add(new Order()
                    {

                        OrderID = reader.GetInt32(0),
                        _storeID = reader.GetInt32(1),
                        TotalPrice = reader.GetInt32(2),
                        _custID = reader.GetInt32(3)


                    });
                }


            }
            return listOfOrders;

        }

    }


}