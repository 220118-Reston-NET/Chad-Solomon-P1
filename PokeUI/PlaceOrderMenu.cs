/*To help you guys a little bit if some of you guys still stuck at how we can do the PlaceOrder method. So the logic should be:
- List all the customer -> Get the customer information by asking user,
Save it to a public static Customer so we can use it in the whole application 
- After got the Customer, we need to get Which store they want to shop at. So we list all the stores and ask them again which store they want to, save that store information to a Public static StoreFront 
-> So now we have Customer, and StoreFront
-> after get the StoreFront, we load all the Product of that store, and ask the customer to buy it:
Here we need:
List<LineItems> _cart;
To save all the product, quantity
-> When customer choose to PlaceOrder
We just need to use the method PlaceOrder and pass the CustomerID, StoreID and the _cart to that method*/
using PokeBL;
using PokeDL;
using PokeModel;
namespace PokeUI
{

    public class PlaceOrderMenu : IMenu
    {

        private IPokemonBL _pokeBL;
        private IStoreFrontBL _storeBL;
        // private IInventoryBL _inventory;
        // private IProductBL _orderBL;
        // private IOrderBL _orderRepo;
        // private IStoreFrontRepo i_store;
        private static List<Customer> listOfCust = new List<Customer>();
        private static List<StoreFront> listStoreFront = new List<StoreFront>();

        public PlaceOrderMenu(IPokemonBL c_pokeBL, IStoreFrontBL s_store)
        {

            _pokeBL = c_pokeBL;
            _storeBL = s_store;
            listOfCust = _pokeBL.GetAllCustomer();
            listStoreFront = _storeBL.GetAllStoreFronts();
            // _inventory = i_inventory;
            // _orderRepo = c_order;

            //i_store = i_storerepo;
            // _orderBL = p_orderBL;

        }
        public static Customer _selectedCust = new Customer();
        public static StoreFront _selectedStoreFront = new StoreFront();
        //public LineItems _cart = new LineItems();
        // public static Order _order = new Order();
        // public static SQLInventory inventory = new SQLInventory();

        // public static Inventory _storeInv = new Inventory();





        public void Display()
        {
            Console.WriteLine("*******************Order Menu*******************");
            Console.WriteLine("Would you like to continue with placing your order?");
            Console.WriteLine("> 1. Enter Customer ID");
            Console.WriteLine("> 2. Pick A Store Location");
            Console.WriteLine("> 3. Start shopping");
            Console.WriteLine("> 0. Go back to Main Menu");

        }

        public string UserChoice()
        {

            string? order = Console.ReadLine();

            switch (order)
            {

                case "1":
                    Log.Information("User is entering a customer ID to shop by");
                    Console.WriteLine("Please provide the ID on your Customer Account");
                    int inputCustomerID = Convert.ToInt32(Console.ReadLine());
                    while (listOfCust.All(p => p._custID != inputCustomerID))
                    {

                        Console.WriteLine("The ID was not correct, Please try again!");
                        inputCustomerID = Convert.ToInt32(Console.ReadLine());
                    }

                    _selectedCust = listOfCust.Find(p => p._custID == inputCustomerID);

                    return "PlaceOrderMenu";




                case "2":

                    Log.Information("User is selecting a store to shop at");
                    Console.WriteLine("Please pick a store By ID number!");
                    int inputStoreID = Convert.ToInt32(Console.ReadLine());

                    while (listStoreFront.All(p => p._storeID != inputStoreID))
                    {

                        Console.WriteLine("The Store ID was not correct, Pleas try again!");
                        inputStoreID = Convert.ToInt32(Console.ReadLine());
                    }
                    _selectedStoreFront = listStoreFront.Find(p => p._storeID == inputStoreID);

                    return "PlaceOrderMenu";


                case "3":


                    if (_selectedCust._custID != 0 && _selectedStoreFront._storeID != 0)
                    {
                        Log.Information("User succesfully navigated Store Front Product menu");
                        return "StoreFrontProductMenu";
                    }
                    Console.WriteLine("Please choose the customer ID and Store ID before shopping");
                    Console.WriteLine("Please press enter to continue");
                    Console.ReadLine();
                    Log.Information("user did not enter either a store ID or a customer ID");
                    return "PlaceOrderMenu";



                case "0":
                    Log.Information("user is returning to main menu from Place order menu");
                    return "MainMenu";

                default:
                    Log.Information("User is reverting back to the Place order menu because they did not choose a valid option");
                    return "PlaceOrderMenu";



            }


        }

    }

}