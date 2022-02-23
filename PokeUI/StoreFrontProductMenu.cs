using System.Data.SqlClient;
using PokeBL;
using PokeModel;

namespace PokeUI
{
    public class StoreFrontProductMenu : IMenu
    {
        private IProductBL _prodBL;
        private IInventoryBL _inventoryBL;

        private IOrderBL _orderBL;

        private List<Product> listProducts = new List<Product>();

        private List<Inventory> listInventory = new List<Inventory>();

        public StoreFrontProductMenu(IProductBL p_prodBL, IInventoryBL p_inventoryBL, IOrderBL p_orderBL)
        {
            _prodBL = p_prodBL;
            _inventoryBL = p_inventoryBL;
            _orderBL = p_orderBL;
            listProducts = _prodBL.GetAllProductByStoreID(PlaceOrderMenu._selectedStoreFront._storeID);
            listInventory = _inventoryBL.GetAllInventoryByStoreID(PlaceOrderMenu._selectedStoreFront._storeID);

        }
        private static List<LineItems> _cart = new List<LineItems>();
        public void Display()
        {
            int prodID = 0;
            string productName = "";
            int prodQuantity = 0;
            string Description = "";
            Console.WriteLine("> View Store Inventory");
            foreach (var item in listInventory)
            {
                prodID = item._productID;
                productName = listProducts.Find(p => p.ID == prodID).Name;
                prodQuantity = item.Quantity;
                Description = listProducts.Find(p => p.ID == prodID).Description;
                Console.WriteLine($"ID: {prodID} - {productName} - {Description} - {prodQuantity} left: ");
            }
            Console.WriteLine("1. Please Choose A product ID to add to shopping cart");
            Console.WriteLine("2. Place Order");

            if (_cart.Count() != 0)
            {
                Console.WriteLine("*****************************************************************");
                Console.WriteLine("Shopping Cart: ");
                string productName2 = "";
                foreach (var item in _cart)
                {
                    productName2 = listProducts.Find(p => p.ID == item.Product).Name;
                    Console.WriteLine($"{productName2} - {item.Quantity}");
                }

            }
            Console.WriteLine("0. Go back to previous menu");

        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {

                case "1":

                    Log.Information("User is selecting a product by ID to add to the shopping cart");
                    Console.WriteLine("Please enter the product ID that you would like to purchase");
                    string inputproductID = Console.ReadLine();

                    while (inputproductID == "" || listInventory.All(p => p._productID != Convert.ToInt32(inputproductID)))
                    {

                        Console.WriteLine("Please enter the product ID that you would like to purchase");
                        inputproductID = Console.ReadLine();
                    }
                    Console.WriteLine("Please enter the quantity!");
                    string inputQuantity = Console.ReadLine();

                    while (!inputQuantity.All(Char.IsDigit) || inputQuantity == "")
                    {

                        Console.WriteLine("Please enter the quantity!");
                        inputQuantity = Console.ReadLine();
                    }
                    if (listInventory.Find(p => p._productID == Convert.ToInt32(inputproductID)).Quantity < Convert.ToInt32(inputQuantity))
                    {

                        Console.WriteLine("We Do not have enough quantity");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();

                        return "StoreFrontProductMenu";
                    }

                    if (_cart.Count() == 0)
                    {
                        _cart.Add(new LineItems()
                        {
                            Product = Convert.ToInt32(inputproductID),
                            Quantity = Convert.ToInt32(inputQuantity)
                        });
                    }
                    else
                    {
                        if (_cart.FindAll(p => p.Product == Convert.ToInt32(inputproductID)).Count() == 0)
                        {
                            _cart.Add(new LineItems()
                            {
                                Product = Convert.ToInt32(inputproductID),
                                Quantity = Convert.ToInt32(inputQuantity)
                            });

                        }
                        else
                        {
                            _cart.Find(p => p.Product == Convert.ToInt32(inputproductID)).Quantity += Convert.ToInt32(inputQuantity);
                        }
                    }

                    Console.WriteLine("Product add to shopping cart succesfully");

                    return "StoreFrontProductMenu";

                case "2":
                    Log.Information("User is attempting to place an order");
                    if (_cart.Count() == 0)
                    {
                        Log.Information("User did not add any items to their cart");
                        Console.WriteLine("The shopping cart is empty");
                        Console.WriteLine("press enter to continue");
                        Console.ReadLine();

                        goto default;
                    }


                    //Originally I was going to add the update lineitems here but I need the order id so it will have to be 
                    // done after the order is placed
                    try
                    {
                        _orderBL.AddOrder(PlaceOrderMenu._selectedStoreFront._storeID, TotalPrice(_cart), PlaceOrderMenu._selectedCust._custID, _cart);

                        Log.Information("User Succesfully placed their order");
                        Console.WriteLine("Place order was succesful!");
                        Console.WriteLine("press enter to return to the main menu");
                        Console.ReadLine();
                        return "MainMenu";
                    }
                    catch (SqlException odbcEx)
                    {
                        Log.Warning("User did not succesfully place their order");
                        Console.WriteLine("Please try to replace your order one item at a time");
                        Console.WriteLine("Please Press enter to continue");
                        Console.ReadLine();
                    }
                    // _orderBL.AddOrder(PlaceOrderMenu._selectedStoreFront._storeID, TotalPrice(_cart), PlaceOrderMenu._selectedCust._custID, _cart);

                    // Console.WriteLine("Place order was succesful!");
                    // Console.WriteLine("press enter to return to the main menu");
                    // Console.ReadLine();
                    Log.Information("User is returning to main menu from Store Front Product Menu");
                    return "MainMenu";

                case "0":
                    Log.Information("User is reverting back to the place order menu from the  Store Front product menu");
                    return "PlaceOrderMenu";

                default:
                    Log.Information("User did not enter a valid option and is returning to the store front product menu");
                    return "StoreFrontProductMenu";


            }


        }
        public int TotalPrice(List<LineItems> _cart)
        {
            int _totalPrice = 0;
            int _price = 0;
            foreach (var item in _cart)
            {
                _price = listProducts.Find(p => p.ID == item.Product).Price;
                _totalPrice += item.Quantity * _price;
            }
            return _totalPrice;
        }

    }


}