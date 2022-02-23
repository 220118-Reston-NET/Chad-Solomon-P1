namespace PokeModel
{


    public class StoreOrder
    {

        public int _orderID;
        public string? _custName;

        public string? _storeName;

        // private string _orderName;
        // public string Name
        // {

        //     get { return _orderName; }

        //     set
        //     {
        //         if (value != null)
        //         {
        //             _orderName = value;

        //         }
        //     }
        // }
        private string _lineItems;
        public string LineItems
        {

            get { return _lineItems; }

            set
            {
                if (value != null)
                {
                    _lineItems = value;

                }
            }
        }

        private string _storeFrontLocation;
        public string StoreLocation
        {
            get { return _storeFrontLocation; }
            set
            {
                _storeFrontLocation = value;
            }

        }

        public int _storeID;
        private decimal _totalPrice;
        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                if (value > 0)
                {
                    _totalPrice = value;
                }
            }
        }


        // public Order()
        // {
        //     _orderID = 0;
        //     _lineItems = new string()
        //     {
        //         new LineItems()
        //     };
        //     StoreLocation = "None";
        //     TotalPrice = 0;



        // }


        public override string ToString()
        {
            return $"Store ID: {_storeID}\nOrder ID: {_orderID}\n";
        }




    }
}