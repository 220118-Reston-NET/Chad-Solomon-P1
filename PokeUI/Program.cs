// See https://aka.ms/new-console-template for more information
global using Serilog;
using Microsoft.Extensions.Configuration;
using PokeBL;
using PokeDL;
using PokeUI;


/************************** API stuff dotnet dev-certs https
https://localhost:7203/swagger/index.html
dotnet new webapi -o PokeApi creates the api
dotnet tool install -g dotnet-aspnet-codegenerator
Microsoft.VisualStudio.Web.CodeGeneration.Design

*/
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./log/user.txt")
    .CreateLogger();


bool repeat = true;
IMenu menu = new MainMenu();



var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsetting.json")
    .Build();

string _connectionStrings = configuration.GetConnectionString("Reference2DB");

/*
*****Originally, I was thinking of creating a pet supplies store. Which may still be a good Idea

*****I think it may be a bit simpler or just more fun to do a Mr. + Mrs. Potato head store for potatos.
>the store could sell all of the potato parts. 
>



***** Idea for the for the products Menus:
> Once a customer picks a product, we could try to suggest another product that would 
    go well with their origonal purchase.
    for instance....if a customer buys a leash we could suggest a new collar also!
                    or if they buy a toy, we could suggest some treats.

******* Idea for for functionality

> Once a customer picks a product form the category they chose I should ask what quantity they would like and show the price and description fo the item.


dotnet add package Serilog.Sinks.File
dotnet add package
dotnet add package Serilog


***** Validation Ideas for the Model
>We can add inventory as a model with the customer selecting a quantitiy of the item
    >and the validation would be that they atleast select 1 quantitiy 
> I could add a few more things for the customer to add when they create a profile
    >like a phone number

*/

while (repeat)
{

    Console.Clear();
    menu.Display();
    string ans = menu.UserChoice();

    switch (ans)
    {

        case "PlaceOrderMenu":
            Log.Information("Entering the Place Order Menu");
            menu = new PlaceOrderMenu(new CustomerBL(new SQLRepository(_connectionStrings)), new StoreFrontBL(new SQLStoreFrontRepo()));
            break;

        // case "StoreFrontMenu":
        //     menu = new StoreFrontMenu(new StoreFrontBL(new SQLStoreFrontRepo()));
        //     break;

        case "StoreFrontMenu":
            menu = new StoreFrontMenu(new InventoryBL(new SQLInventory(_connectionStrings)), new OrderHistoryBL(new OrderHistRepo(_connectionStrings)), new StoreHistoryBL(new SQLStoreHistory()), new StoreFrontBL(new SQLStoreFrontRepo()));
            break;


        case "CustomerAccount":
            Log.Information("Entering the Create Customer Account Menu");
            menu = new CustomerAccount(new CustomerBL(new SQLRepository(_connectionStrings)));
            break;

        case "MainMenu":
            Log.Information("Entering the Main Menu");
            menu = new MainMenu();
            break;


        case "SearchCustomerMenu":
            Log.Information("Entering the Search Customer Menu");
            menu = new SearchCustomerMenu(new CustomerBL(new SQLRepository(_connectionStrings)), new OrderBL(new SQLOrderRepository(_connectionStrings)));
            break;

        case "SearchProductMenu":
            Log.Information("Entering the Search Product Menu");
            menu = new SearchProductMenu(new ProductBL(new SQLProductRepository(_connectionStrings)));
            break;

        case "StoreFrontProductMenu":
            Log.Information("Entering the StoreFrontProductMenu");
            menu = new StoreFrontProductMenu(new ProductBL(new SQLProductRepository(_connectionStrings)), new InventoryBL(new SQLInventory(_connectionStrings)), new OrderBL(new SQLOrderRepository(_connectionStrings)));
            break;
        // case "OrderMenu":
        //     menu = new OrderMenu(new CustLeashesBL(new CustLeashesDL()));
        //     break;

        // case "CustomizeLeashMenu":
        //     menu = new CustomizeLeashMenu();
        //     break;

        default:
            Log.Information("User did not enter a valid option");
            Console.WriteLine("Page does not exist");
            break;
    }
}



