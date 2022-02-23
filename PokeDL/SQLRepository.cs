using System.Data.SqlClient;
using PokeModel;
namespace PokeDL
{
    public class SQLRepository : IRepository
    {
        private readonly string _connectionStrings;
        public SQLRepository(string p_connectionStrings)
        {

            _connectionStrings = p_connectionStrings;
        }
        public Customer AddCustomer(Customer c_customer)
        {
            string sqlQuery = @"insert into Customer values (@custName, @custAddress, @custEmail, @custPassword)";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@custName", c_customer.Name);
                command.Parameters.AddWithValue("@custAddress", c_customer.Address);
                command.Parameters.AddWithValue("@custEmail", c_customer.Email);
                command.Parameters.AddWithValue("@custPassword", c_customer.Password);

                command.ExecuteNonQuery();

                return c_customer;
            }

        }






        public List<Customer> GetAllCustomers()
        {
            List<Customer> listOfCustomers = new List<Customer>();

            string sqlQuery = @"select * from Customer";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfCustomers.Add(new Customer()
                    {
                        _custID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2),
                        Email = reader.GetString(3),
                        Password = reader.GetString(4)
                    });


                }
            }
            return listOfCustomers;
        }


        public Customer UpdateCustomer(Customer p_cust)
        {

            string sqlQuery = @"update Customer
                                    set custName = @custName, custAddress = @custAddress, custEmail = @custEmail, @custPassword
                                    where custID = @id;";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                command.Parameters.AddWithValue("@custName", p_cust.Name);
                command.Parameters.AddWithValue("@custAddress", p_cust.Address);
                command.Parameters.AddWithValue("@custEmail", p_cust.Email);
                command.Parameters.AddWithValue("@custPassword", p_cust.Password);
                command.Parameters.AddWithValue("@id", p_cust._custID);

                command.ExecuteNonQuery();
            }

            return p_cust;
        }

    }
}