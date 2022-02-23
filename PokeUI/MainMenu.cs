namespace PokeUI
{
    public class MainMenu : IMenu
    {

        public void Display()
        {

            Console.WriteLine("Welcome to Furr Babies pet supplies store!");
            Console.WriteLine("Please select a number!");
            Console.WriteLine(" 1. Create an Account");
            Console.WriteLine(" 2. Pick A store location");
            Console.WriteLine(" 3. Search Customer Database");
            Console.WriteLine(" 4. Place Order");


        }

        public string UserChoice()
        {

            string? mainMenuSelection = Console.ReadLine();

            switch (mainMenuSelection)
            {
                case "1":
                    Log.Information("Entering the Create Customer Account Menu");
                    return "CustomerAccount";

                case "2":
                    Log.Information("Entering the Store Front Menu");
                    return "StoreFrontMenu";

                case "3":
                    Log.Information("Entering the Search Customer Menu");
                    return "SearchCustomerMenu";

                case "4":
                    Log.Information("Entering the Place Order Menu");
                    return "PlaceOrderMenu";
                default:
                    Log.Information("User did not enter a valid option from main menu");
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Please Enter to continue!");
                    Console.ReadLine();
                    return "MainMenu";
            }

        }
    }
}

//dotnet add package Moq --version 4.16.1 for mocking business layer unit test
