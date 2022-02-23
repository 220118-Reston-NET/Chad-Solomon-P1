using PokeBL;
using PokeModel;

namespace PokeUI
{

    public class SearchCustomerMenu : IMenu
    {


        //private static Customer _newCustomer = new Customer();
        //Dependency injection
        private IPokemonBL _customerBL;
        private IOrderBL _orderBL;


        public SearchCustomerMenu(IPokemonBL c_customerBL, IOrderBL p_orderBL)
        {

            _customerBL = c_customerBL;
            _orderBL = p_orderBL;


        }
        public static List<Order> listOrders = new List<Order>();

        // public static Customer _cust = new Customer();
        // private ICustLeashesBL _orderBL;
        // public SearchCustomerMenu(ICustLeashesBL c_order)
        // {
        //     _orderBL = c_order;
        // }
        public void Display()
        {
            Console.WriteLine("===========Search Menu============");
            Console.WriteLine("Enter the Number of Your Desired Choice");
            Console.WriteLine("1. Search for Customer!");
            Console.WriteLine("2. Search Customer Order History!");
            Console.WriteLine("3. Return to Main Menu");
        }

        public string UserChoice()
        {
            string? searchCustInput = Console.ReadLine();

            switch (searchCustInput)
            {

                case "1":
                    Log.Information("Search the customer database.");
                    Console.WriteLine("Please Enter the ID of the Customer!");
                    int custID = Convert.ToInt32(Console.ReadLine());

                    List<Customer> listOfCustomer = _customerBL.SearchCustomer(custID);
                    foreach (var cust in listOfCustomer)
                    {
                        Console.WriteLine(cust);

                    }

                    //return "SearchCustomerMenu";



                    Console.WriteLine("Pleas press enter to continue");
                    Console.ReadLine();

                    return "SearchCustomerMenu";


                case "2":

                    Log.Information("Search the customer order history.");
                    Console.WriteLine("Please Enter the ID of the Customer!");
                    int custID1 = Convert.ToInt32(Console.ReadLine());

                    List<Order> listOrders = _orderBL.SearchOrder(custID1);
                    foreach (var cust in listOrders)
                    {
                        Console.WriteLine("****************");
                        Console.WriteLine(cust);

                    }
                    Console.WriteLine("Please press enter to continue.");
                    Console.ReadLine();

                    return "SearchCustomerMenu";

                case "3":
                    Log.Information("User Chose to return to main menu");
                    return "MainMenu";

                default:
                    Log.Information("User did not choose a valid option and is returning to Search Customer Menu");
                    Console.WriteLine("This customer may not exist in our database");
                    Console.WriteLine("Please press enter to search again");
                    Console.ReadLine();
                    return "SearchCustomerMenu";


            }

            /*
Unhandled exception. System.NullReferenceException: Object reference not set to an instance of an object.
at PokeBL.CustomerBL.SearchCustomer(String c_customer) in C:\Users\chadc\Documents\Revature\C#\Poke\PokeBL\PokemonBL.cs:line 40
   at PokeUI.SearchCustomerMenu.UserChoice() in C:\Users\chadc\Documents\Revature\C#\Poke\PokeUI\SearchCustomerMenu.cs:line 35    
   at Program.<Main>$(String[] args) in C:\Users\chadc\Documents\Revature\C#\Poke\PokeUI\Program.cs:line 48
   */



        }


    }
}