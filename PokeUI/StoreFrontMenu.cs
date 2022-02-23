using PokeBL;
using PokeModel;

namespace PokeUI
{
    public class StoreFrontMenu : IMenu
    {

        private IInventoryBL _inventory;
        private IOrderHistoryBL _orderhist;
        private IStoreHistory _storehist;
        private IStoreFrontBL _storeBL;
        //private IProductBL _prodBL;
        public StoreFrontMenu(IInventoryBL s_inventory, IOrderHistoryBL c_order, IStoreHistory s_storehist, IStoreFrontBL p_storeBL)
        {

            _inventory = s_inventory;
            _orderhist = c_order;
            _storehist = s_storehist;
            _storeBL = p_storeBL;
            //_prodBL = p_prodBL;
        }

        public static List<StoreOrder> storeHist = new List<StoreOrder>();


        public void Display()
        {

            //Console.WriteLine("Welcome to Bebop Place!");
            Console.WriteLine("Furr Babies Pet Supply's");
            Console.WriteLine("Please Select the option of your Desires!");
            Console.WriteLine("> 1: Search Store Fronts");
            Console.WriteLine("> 2: Search Store Inventory");
            Console.WriteLine("> 3: Search Stores Order History");
            Console.WriteLine("> 4: Add to Store Inventory");
            Console.WriteLine("> 5: Return To Main Menu");
        }

        public string UserChoice()
        {

            string userchoice = Console.ReadLine();

            switch (userchoice)
            {

                case "1":
                    Log.Information("User is Searching for store Fronts");
                    Console.WriteLine("Please enter the name of the store you would like to view!");
                    Console.WriteLine("Furr Babies - Bebop, Furr Babies - Swordfish, Furr Babies - Hammerhead");
                    string storeName = Console.ReadLine();
                    // List<StoreFront> listOfStoreFront = _store.SearchStoreFront(storeName)


                    List<StoreFront> listOfStoreFront = _storeBL.SearchStoreFront(storeName);
                    foreach (var store in listOfStoreFront)
                    {

                        Console.WriteLine(store);
                    }


                    Console.WriteLine("Please Press Enter to Continue");
                    Console.ReadLine();
                    Log.Information("Returning to store front menu");
                    return "StoreFrontMenu";

                case "2":
                    Log.Information("User is searching store front inventory by store ID");
                    Console.WriteLine("Please enter the ID of the Store you would like to view!");

                    int productID = Convert.ToInt32(Console.ReadLine());


                    List<Inventory> listOfProduct = _inventory.GetAllInventoryByStoreID(productID);
                    foreach (var prod in listOfProduct)
                    {
                        Console.WriteLine(prod);
                    }

                    Console.WriteLine("Please press enter to continue!");
                    Console.ReadLine();

                    return "StoreFrontMenu";



                case "3":
                    Log.Information("User is searching the store order history");
                    Console.WriteLine("Please enter the Store ID");
                    Console.WriteLine("Store ID's: Store 1, Store 2, Store 3");
                    int storeID = Convert.ToInt32(Console.ReadLine());

                    storeHist = _storehist.SearchStoreHistory(storeID);

                    foreach (var order in storeHist)
                    {
                        Console.WriteLine("============================");
                        Console.WriteLine(order);
                    }
                    Console.WriteLine("Please press enter to continue");
                    Console.ReadLine();

                    return "StoreFrontMenu";



                case "4":
                    Log.Information("User is adding an item to the inventory");
                    Console.WriteLine("Please enter the ID number for the product you would like to update!");

                    int prodID = Convert.ToInt32(Console.ReadLine());


                    try
                    {
                        _inventory.AddInventory(prodID);

                    }
                    catch (System.Exception exc)
                    {
                        Log.Warning("Failed to replenish inventory");
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press enter to continue");
                        Console.ReadLine();
                    }
                    return "StoreFrontMenu";

                case "5":
                    Log.Information("User is returning to main menu");
                    return "MainMenu";


                default:
                    Log.Information("User did not enter a valid option and is returning to store front menu");
                    return "StoreFrontMenu";
            }

        }




    }
}