using System.Text.Json;
using PokeModel;
namespace PokeDL
{
    public class ProductDL
    {
        private string _filepath = "../PokeDL/Database/";
        private string? _jsonString;
        //We make our list static so that it exist everywhere, which is helping us to 
        //save the data of previously created Leashess (Leashes accounts)
        //though when we try to use our list as a field we will lose the info any time
        //the program is restarted.
        //private static List<Leashes> listOfLeashess = new List<Leashes>();
        public Product AddProduct(Product c_product)
        {
            string path = _filepath + "CustLeashes.json";


            //Now rather than creating a new list of Leashess each time we are implementing 
            //the GetAllLeashess(); method which returns a list of type Leashes

            List<Product> listOfProduct = GetAllProduct(); //new List<Leashes>();
            //Here we are essentially saving the data of each new Leashes

            listOfProduct.Add(c_product);

            //I change the first parameter of the JsonSerializer.Serialize from c_Leashes to 
            //the listOfLeashess because we want to be able to retain more than one Leashes's info
            _jsonString = JsonSerializer.Serialize(listOfProduct, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(path, _jsonString);

            return c_product;
        }

        public List<Product> GetAllProduct()
        {
            //Grab info from Json file and store it in a string

            _jsonString = File.ReadAllText(_filepath + "CustLeashes.json");

            //Deserialize the jsonString and return it as a List<Leashes>(); object.
            return JsonSerializer.Deserialize<List<Product>>(_jsonString);

            //lets try the above and if exception is thrown catch and return a list<Leashes>


        }
    }
}