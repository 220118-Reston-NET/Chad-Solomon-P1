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

        public void AddOrder(int _orderLocation, int _custID, List<LineItems> _cart)
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
                command.Parameters.AddWithValue("@TotalPrice", TotalPrice(_cart));
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

        public async Task<List<Order>> GetAllOrder()
        {
            List<Order> listOfOrders = new List<Order>();

            // string sqlQuery = @"select * from Orders 
            //                     where custID = @custID
            //                     order by orderPrice ";
            string sqlQuery = @"select orderID, orderLocation, orderPrice, custID, OrderTime from Orders";


            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {

                await con.OpenAsync();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                //command.Parameters.AddWithValue("@custID", custID);
                // command.Parameters.AddWithValue("@custID", custID);
                // command.Parameters.AddWithValue("@custID", custID);
                // command.Parameters.AddWithValue("@custID", custID);
                // command.Parameters.AddWithValue("@custID", custID);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {

                    listOfOrders.Add(new Order()
                    {

                        OrderID = reader.GetInt32(0),
                        StoreID = reader.GetInt32(1),
                        TotalPrice = reader.GetInt32(2),
                        CustID = reader.GetInt32(3),
                        TimeStamp = reader.GetDateTime(4),
                        ShoppingCart = GetShoppingCartByOrderID(reader.GetInt32(0))


                    });
                }


            }
            return listOfOrders;

        }

        public async Task<List<Order>> GetStoreOrder()
        {
            List<Order> listStoreOrder = new List<Order>();

            string sqlQuery = @"select orderID, orderLocation, orderPrice, custID, OrderTime from Orders";
            /**/


            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                await con.OpenAsync();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                //command.Parameters.AddWithValue("@storeID", storeID);

                SqlDataReader reader = await command.ExecuteReaderAsync();


                while (reader.Read())
                {

                    listStoreOrder.Add(new Order()
                    {
                        OrderID = reader.GetInt32(0),
                        StoreID = reader.GetInt32(1),
                        TotalPrice = reader.GetInt32(2),
                        CustID = reader.GetInt32(3),
                        TimeStamp = reader.GetDateTime(4)

                    });
                }
            }
            return listStoreOrder;

        }


        //On your storefrontproductmenu we need to try and save the product ID and the quantity to enter into
        //alse we need to grab the order Id also.
        public void AddLineItems(int prodID, int orderID, int quantity)
        {

            string sqlQuery = @"insert into LineItems values (@prodID, @orderID, @Quantity)";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@prodID", prodID);
                command.Parameters.AddWithValue("@orderID", orderID);
                command.Parameters.AddWithValue("@Quantity", quantity);

                command.ExecuteNonQuery();


            }


        }

        public int TotalPrice(List<LineItems> _cart)
        {
            SQLProductRepository prodRepo = new SQLProductRepository(_connectionStrings);
            int _totalPrice = 0;
            int _price = 0;
            foreach (var item in _cart)
            {
                _price = prodRepo.GetAllProduct().Find(p => p.ID == item.Product).Price;
                _totalPrice += item.Quantity * _price;
            }
            return _totalPrice;
        }

        public List<LineItems> GetShoppingCartByOrderID(int p_orderID)
        {
            List<LineItems> _shoppingcart = new List<LineItems>();

            string sqlQuery = @"SELECT prodID, Quantity
                                 From LineItems
                                 where orderID = @orderID";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@orderID", p_orderID);

                //SqlDataReader is like the middle man between SQL and C#
                //Since SQL only understands table and c# only understands objects and classes

                SqlDataReader reader = command.ExecuteReader();
                //setting the condition of the while loop to say 
                //as long as there is data to still be read keep reading it
                while (reader.Read())
                {

                    _shoppingcart.Add(new LineItems()
                    {

                        Product = reader.GetInt32(0),
                        Quantity = reader.GetInt32(1)

                    });
                }
            }

            return _shoppingcart;
        }
    }
}