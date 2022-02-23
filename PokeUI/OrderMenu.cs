// using PokeBL;
// using PokeModel;

// namespace PokeUI
// {
//     public class OrderMenu : Leashes, IMenu
//     {
//         //private static Order _newOrder;
//         // private static Leashes _newLeash = new Leashes();


//         private ICustLeashesBL _orderBL;
//         public OrderMenu(ICustLeashesBL c_order)
//         {
//             _orderBL = c_order;
//         }
//         public void Display()
//         {
//             Console.WriteLine("********Order Menu********");
//             Console.WriteLine("Thank you for shopping with FurrBabies!");
//             Console.WriteLine("Would you like to continue with placing your order?");
//             Console.WriteLine("> 1: Yes");
//             Console.WriteLine("> 1: No");
//             // Console.WriteLine("[2] Address - " + _newCustomer.Address);
//             // Console.WriteLine("[3] Email - " + _newCustomer.Email);
//             // Console.WriteLine("[1] Save");
//             // Console.WriteLine("[2] Go back to Products Menu");
//         }

//         public string UserChoice()
//         {
//             string? orderChoice = Console.ReadLine();

//             switch (orderChoice)
//             {
//                 case "1":
//                     // _newLeash = new Leashes();
//                     //Console.WriteLine("Please enter your name!");

//                     // try
//                     // {
//                     //     _orderBL.AddLeashes(_newLeash);
//                     // }
//                     // catch (System.Exception exc)
//                     // {
//                     //     Console.WriteLine(exc.Message);
//                     //     Console.WriteLine("Please press Enter to continue");
//                     //     Console.ReadLine();
//                     // }
//                     return "ProductsMenu";

//                 case "2":

//                     return "ProductsMenu";

//                 default:

//                     Console.WriteLine("Please enter a valid option");
//                     Console.WriteLine("Please press enter to continue");
//                     Console.ReadLine();
//                     return "ProductsMenu";

//             }
//         }
//     }
// }