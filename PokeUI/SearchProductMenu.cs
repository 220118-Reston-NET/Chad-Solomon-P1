using PokeBL;
using PokeModel;

namespace PokeUI
{

    public class SearchProductMenu : IMenu
    {
        //private static Customer _newCustomer = new Customer();
        //Dependency injection
        // private IPokemonBL _customerBL;

        // public SearchCustomerMenu(IPokemonBL c_customerBL)
        // {

        //     _customerBL = c_customerBL;

        // }

        private IProductBL _orderBL;
        public SearchProductMenu(IProductBL c_order)
        {
            _orderBL = c_order;
        }
        public void Display()
        {
            Console.WriteLine("===========Search Menu============");
            Console.WriteLine("Enter the Number of Your Desired Choice");
            Console.WriteLine("1. Search for !");
            Console.WriteLine("2. Go to Products Menu!");
            Console.WriteLine("3. Return to Main Menu!");
        }

        public string UserChoice()
        {
            string? ProductMenut = Console.ReadLine();

            switch (ProductMenut)
            {

                case "1":
                    Console.WriteLine("Please Enter the Name of the Product!");
                    // Console.WriteLine("ProductMenue = styleProductMenu                    string ProductMenu = Console.ReadLine();

                    // List<listOfProduct> _orderBL.SearchProduct);
                    // foreach (var ProductMenulistOfProductMenu   {
                    //     Console.WriteLine(ProductMenu                   
                    //     }

                    Console.WriteLine("Pleas press enter to continue");
                    Console.ReadLine();
                    return "SearchProductMenu";


                case "2":

                    return "ProductsMenu";

                case "3":
                    return "MainMenu";

                default:

                    Console.WriteLine("This ProductMenuer may not exist in our database");
                    Console.WriteLine("Please press enter to search again");
                    Console.ReadLine();
                    return "SearchCustomerMenu";


            }






        }


    }
}