namespace PokeModel
{

    public class Product
    {
        private string _productName;
        public string Name
        {
            get { return _productName; }

            set
            {
                if (value != "")
                {
                    _productName = value;
                }

            }
        }

        public int _prodID;
        public int ID
        {
            get { return _prodID; }

            set { _prodID = value; }
        }
        private int _productPrice;
        public int Price
        {
            get { return _productPrice; }

            set
            {
                if (value > 0)
                {
                    _productPrice = value;
                }

            }
        }



        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }

            set
            {
                if (value > 0)
                {
                    _quantity = value;
                }

            }
        }

        // private string _color;
        // public string Color
        // {
        //     get { return _color; }
        //     set
        //     {
        //         if (value != "")
        //         {
        //             _color = value;
        //         }
        //         else
        //         {
        //             Console.WriteLine("Please enter a valid response");
        //             Console.WriteLine("Options: Red, Green, Pink, Blue, Purple, Yellow, Black");
        //             Console.WriteLine("*******Please Press Enter to Continue******");
        //             Console.ReadLine();
        //         }
        //     }
        // }

        // private string? _size;
        // public string Size
        // {
        //     get { return _size; }
        //     set
        //     {
        //         if (value != "")
        //         {
        //             _size = value;
        //         }
        //         else
        //         {
        //             Console.WriteLine("Please enter a valid size");
        //             Console.WriteLine("Options: Small, Medium, Large");
        //             Console.WriteLine("*******Please Press Enter to Continue******");
        //             Console.ReadLine();
        //         }
        //     }
        // }

        public string _productDescription;
        public string Description
        {
            get { return _productDescription; }
            set
            {
                if (value != "")
                {

                    _productDescription = value;
                }

            }
        }









        // public string _productDescription { get; set; }
        // public string _productCategory { get; set; }


        // public Product(int ID, string Name, int Price, int Quantity)
        // {
        //     this.ID = ID;
        //     this.Name = Name;
        //     this.Price = Price;
        //     this.Quantity = Quantity;

        // }

    }


}