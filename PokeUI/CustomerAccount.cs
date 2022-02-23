using PokeBL;
using PokeModel;

namespace PokeUI
{

    public class CustomerAccount : IMenu
    {

        public static Customer _newCustomer = new Customer();

        private IPokemonBL _pokeBL;

        // public CustomerAccount()
        // {
        // }

        public CustomerAccount(IPokemonBL c_pokeBl)//THis is supposed to be like a constructor so it needs to have the same name as the class
        {
            _pokeBL = c_pokeBl;
        }

        public void Display()
        {
            Console.WriteLine("Please enter your information!");
            Console.WriteLine("[1] Name - " + _newCustomer.Name);
            Console.WriteLine("[2] Address - " + _newCustomer.Address);
            Console.WriteLine("[3] Email - " + _newCustomer.Email);
            Console.WriteLine("[4] Save");
            Console.WriteLine("[5] Go back to MainMenu");
        }

        public string UserChoice()
        {

            string? userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Log.Information("Customer enter their name\n " + _newCustomer.Name);
                    Console.WriteLine("Please enter your name");
                    _newCustomer.Name = Console.ReadLine();
                    Log.Information("Entering Customer Name was succesful");

                    return "CustomerAccount";

                case "2":
                    Log.Information("Customer entering their address\n " + _newCustomer.Address);
                    Console.WriteLine("Please enter your street address!");
                    _newCustomer.Address = Console.ReadLine();
                    Log.Information("Entering Customer Address was succesful");
                    return "CustomerAccount";

                case "3":
                    Log.Information("Customer entering their email");
                    Console.WriteLine("Please enter your email address!");
                    _newCustomer.Email = Console.ReadLine();
                    Log.Information("Entering Customer email was succesful");
                    return "CustomerAccount";

                case "4":
                    try
                    {
                        Log.Information("Adding Customer Profile");
                        _pokeBL.AddCustomer(_newCustomer);
                        Log.Information("Customer Account creation succesful");
                    }
                    catch (System.Exception exc)
                    {
                        Log.Warning("Customer Account was not created");
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    }
                    Log.Information("User is returning to main menu after creating an account");
                    return "MainMenu";


                case "5":
                    Log.Information("Returning to Main Menu from Customer account menu");
                    return "MainMenu";

                default:
                    Console.WriteLine("Please enter a valid response");
                    return "MainMenu";


            }

        }
    }
}