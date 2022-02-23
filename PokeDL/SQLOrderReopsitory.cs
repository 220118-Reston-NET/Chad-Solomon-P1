using System.Data.SqlClient;
using PokeModel;


namespace PokeDL
{
    public class SQLOrderRepository : IOrderRepo
    {
        private readonly string _connectionStrings;
        public SQLOrderRepository(string p_connectionStrings)
        {

            _connectionStrings = p_connectionStrings;
        }

        public void AddOrder(int _orderLocation, int _price, int _custID, List<LineItems> _cart)
        {

            //First we need setup a sqlQuery
            // and establish a connection

            //SQL like query statement we want to insert into the order table these values
            string sqlQuery = @"insert into Orders 
                                values (@storeID, @TotalPrice, @custID, @TimeStamp);
                                select scope_identity();";

            string sqlQuery1 = @"insert into LineItems 
                                values (@prodID, @orderID, @Quantity)";

            string sqlQuery2 = @"update StoreInventory 
                                set Quantity = Quantity - @Quantity
                                where storeID = @storeID
                                and prodID = @prodID";


            Order _orderNew = new Order();
            _orderNew.TimeStamp = DateTime.Now;

            //To connect we use a using block
            //implementing the SqlConnection class
            //which connects us to the sql database
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                //this keeps the connection open
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@storeID", _orderLocation);
                command.Parameters.AddWithValue("@custID", _custID);
                command.Parameters.AddWithValue("@TotalPrice", _price);
                command.Parameters.AddWithValue("@TimeStamp", _orderNew.TimeStamp);


                int orderID = Convert.ToInt32(command.ExecuteScalar());

                //SqlCommand command2 = new SqlCommand(sqlQuery1, con);
                // SqlCommand command3 = new SqlCommand(sqlQuery2, con);
                foreach (var item in _cart)
                {
                    command = new SqlCommand(sqlQuery1, con);
                    command.Parameters.AddWithValue("@prodID", item.Product);
                    command.Parameters.AddWithValue("@orderID", orderID);
                    command.Parameters.AddWithValue("@Quantity", item.Quantity);
                    command.ExecuteNonQuery();

                    command = new SqlCommand(sqlQuery2, con);
                    command.Parameters.AddWithValue("@Quantity", item.Quantity);
                    command.Parameters.AddWithValue("@storeID", _orderLocation);
                    command.Parameters.AddWithValue("@prodID", item.Product);
                    command.ExecuteNonQuery();

                    // command3.ExecuteNonQuery();

                    //**********Add a subtract inventory method here that ill make in inventory repo
                }

            }


        }

        public List<Order> GetAllOrder(int custID)
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




        //public int Calculate

        // public List<Order> SearchOrder(int custID)
        // {
        //     List<Order> listOfOrder = GetOrder();

        //     string sqlQuery = @"select * from Orders where custID = @custID";

        //     using (SqlConnection con = new SqlConnection("Server=tcp:furrbabies.database.windows.net,1433;Initial Catalog=Furr-Babbies-Pet-Supply;Persist Security Info=False;User ID=FurrBabies;Password=RheaandLdog1$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
        //     {

        //         con.Open();

        //         SqlCommand command = new SqlCommand(sqlQuery, con);
        //         command.Parameters.AddWithValue("@custID", custID);


        //         command.ExecuteNonQuery();
        //     }


        //     return listOfOrder;

        // }

        public List<Order> GetOrder()
        {
            List<Order> listOfOrder = new List<Order>();

            string sqlQuery = @"select * from Orders";

            using (SqlConnection con = new SqlConnection("Server=tcp:furrbabies.database.windows.net,1433;Initial Catalog=Furr-Babbies-Pet-Supply;Persist Security Info=False;User ID=FurrBabies;Password=RheaandLdog1$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {

                SqlCommand command = new SqlCommand(sqlQuery, con);

                //SqlDataReader is like the middle man between SQL and C#
                //Since SQL only understands table and c# only understands objects and classes

                SqlDataReader reader = command.ExecuteReader();
                //setting the condition of the while loop to say 
                //as long as there is data to still be read keep reading it
                while (reader.Read())
                {

                    listOfOrder.Add(new Order()
                    {

                        OrderID = reader.GetInt32(0),
                        _storeID = reader.GetInt32(1),
                        TotalPrice = reader.GetInt32(2),
                        _custID = reader.GetInt32(3)
                    });
                }
            }

            return listOfOrder;

        }


        //On your storefrontproductmenu we need to try and save the product ID and the quantity to enter into
        //alse we need to grab the order Id also.
        public void AddLineItems(int prodID, int orderID, int quantity)
        {

            string sqlQuery = @"insert into LineItems values (@prodID, @orderID, @Quantity)";

            using (SqlConnection con = new SqlConnection("Server=tcp:furrbabies.database.windows.net,1433;Initial Catalog=Furr-Babbies-Pet-Supply;Persist Security Info=False;User ID=FurrBabies;Password=RheaandLdog1$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@prodID", prodID);
                command.Parameters.AddWithValue("@orderID", orderID);
                command.Parameters.AddWithValue("@Quantity", quantity);

                command.ExecuteNonQuery();


            }
        }

    }
}