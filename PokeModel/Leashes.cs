// namespace PokeModel
// {
//     public class Leashes
//     {

//         //public static Product _leash = new Leashes();
//         private string _color;
//         public string Color
//         {
//             get { return _color; }
//             set
//             {
//                 if (value != "")
//                 {
//                     _color = value;
//                 }
//                 else
//                 {
//                     Console.WriteLine("Please enter a valid response");
//                     Console.WriteLine("Options: Red, Green, Pink, Blue, Purple, Yellow, Black");
//                     Console.WriteLine("*******Please Press Enter to Continue******");
//                     Console.ReadLine();
//                 }

//                 // if (_newLeash.Color.Equals("Red"))
//                 //     {
//                 //         _newLeash.ID += 1;
//                 //     }
//                 //     else if (_newLeash.Color.Equals("Blue"))
//                 //     {
//                 //         _newLeash.ID += 2;
//                 //     }
//                 //     else if (_newLeash.Color.Equals("Pink"))
//                 //     {
//                 //         _newLeash.ID += 3;
//                 //     }
//                 //     else if (_newLeash.Color.Equals("Black"))
//                 //     {
//                 //         _newLeash.ID += 4;
//                 //     }
//                 //     else if (_newLeash.Color.Equals("Purple"))
//                 //     {
//                 //         _newLeash.ID += 5;
//                 //     }
//                 //     else if (_newLeash.Color.Equals("Yellow"))
//                 //     {
//                 //         _newLeash.ID += 6;
//                 //     }
//             }
//         }
//         private string? _size;
//         public string Size
//         {
//             get { return _size; }
//             set
//             {
//                 if (value != "")
//                 {
//                     _size = value;
//                 }
//                 else
//                 {
//                     Console.WriteLine("Please enter a valid size");
//                     Console.WriteLine("Options: Small, Medium, Large");
//                     Console.WriteLine("*******Please Press Enter to Continue******");
//                     Console.ReadLine();
//                 }
//             }
//         }

//         private int _price;
//         public int Price
//         {
//             get { return _price; }
//             set
//             {
//                 if (value > 0)
//                 {

//                     _price = value;
//                 }

//             }
//         }

//         public string _style;
//         public string Style
//         {
//             get { return _style; }
//             set
//             {
//                 if (value != "")
//                 {

//                     _style = value;
//                 }
//                 //  if (_newLeash.Style.Equals("Nylon"))
//                 //     {
//                 //         _newLeash.ID = 100;
//                 //     }
//                 //     else if (_newLeash.Style.Equals("Rope"))
//                 //     {
//                 //         _newLeash.ID = 200;
//                 //     }
//                 //     else if (_newLeash.Style.Equals("Pericord"))
//                 //     {
//                 //         _newLeash.ID = 300;
//                 //     }
//                 //     else if (_newLeash.Style.Equals("Retractable"))
//                 //     {
//                 //         _newLeash.ID = 400;
//                 //     }

//             }
//         }

//         // private int _quantity;
//         // public int Quantity
//         // {
//         //     get { return _quantity; }

//         //     set
//         //     {
//         //         if (value > 0)
//         //         {
//         //             _quantity = value;
//         //         }

//         //     }
//         // }

//         public int _prodID;
//         // public int ID
//         // {
//         //     get { return _prodID; }

//         //     set
//         //     {
//         //         if (value > 0)
//         //         {
//         //             _prodID = value;
//         //         }

//         //     }
//         // }

//         private string? _productName;
//         public string? Name
//         {
//             get { return _productName; }

//             set
//             {
//                 _productName = value;

//             }
//         }

//         public Leashes()
//         {
//             _prodID = 0;
//             Name = "No Name";
//             Price = 0;
//             // Quantity = 0;
//             Color = "No Color";
//             Size = "No Size";
//             Style = "No Style";

//         }


//         // public Leashes(int ID, string Name, int Price, int Quantity)
//         // {
//         //     this.ID = ID;
//         //     this.Name = Name;
//         //     this.Price = Price;
//         //     this.Quantity = Quantity;
//         // }

//         public override string ToString()
//         {
//             return $"Name: {Name}\nColor: {Color}\nStyle: {Style}\nPrice: {Price}";
//         }
//     }
// }