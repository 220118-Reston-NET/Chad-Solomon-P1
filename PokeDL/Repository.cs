using PokeModel;
using System.Text.Json;

namespace PokeDL
{

    public class Repository
    {
        private string _filepath = "../PokeDL/Database/";
        private string? _jsonString;

        public Customer AddCustomer(Customer c_customer)
        {
            string path = _filepath + "Customer.json";




            List<Customer> listOfCustomers = GetAllCustomers();

            listOfCustomers.Add(c_customer);

            //I change the first parameter of the JsonSerializer.Serialize from c_customer to 
            //the listOfCustomers because we want to be able to retain more than one customer's info
            _jsonString = JsonSerializer.Serialize(listOfCustomers, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(path, _jsonString);

            return c_customer;
        }

        public List<Customer> GetAllCustomers()
        {
            //Grab info from Json file and store it in a string

            _jsonString = File.ReadAllText(_filepath + "Customer.json");

            //Deserialize the jsonString and return it as a List<Customer>(); object.
            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);

            //lets try the above and if exception is thrown catch and return a list<Customer>


        }
    }


}