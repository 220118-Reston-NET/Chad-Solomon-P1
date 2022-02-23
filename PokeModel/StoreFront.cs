
namespace PokeModel
{

    public class StoreFront
    {

        public int _storeID;
        public int StoreID
        {
            get { return _storeID; }

            set
            {

                if (value > 0)
                {
                    _storeID = value;
                }
                else
                {
                    Console.WriteLine("value must be greater than 1");
                }

            }
        }
        private string? _storeName;
        public string? StoreName
        {
            get { return _storeName; }

            set
            {

                if (value != "")
                {
                    _storeName = value;
                }

            }
        }
        private string _storeAddress;
        public string StoreAddress
        {
            get { return _storeAddress; }

            set
            {
                if (value != "")
                {

                    _storeAddress = value;
                }
                else
                {
                    Console.WriteLine("must not be empty");
                }
            }
        }

        // private List<Product> _storeInventory;
        // public List<Product> Inventory
        // {

        //     get { return _storeInventory; }

        //     set
        //     {

        //         if (value != null)
        //         {

        //             _storeInventory = value;
        //         }
        //     }
        // }
        // private List<Order> _custOrders;
        // public List<Order> CustomerOrder
        // {

        //     get { return _custOrders; }

        //     set
        //     {

        //         if (value != null)
        //         {

        //             _custOrders = value;
        //         }
        //     }
        // }

        // public StoreFront()
        // {
        //     _storeName = "Furr Babies";
        //     StoreAddress = "321 Bepop Place, East Tennessee 33345";
        //     _storeInventory = new List<Product>()
        //     {
        //         new Product()
        //     };

        //     _custOrders = new List<Order>()
        //     {
        //     new Order()
        //     };
        // }
        // public StoreFront()
        // {

        //     _storeID = 0;
        // }

        public override string ToString()
        {
            return $"Store ID: {_storeID}\nName: {StoreName}\nAddress: {StoreAddress}";
        }


    }
}