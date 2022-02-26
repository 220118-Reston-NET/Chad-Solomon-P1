namespace PokeModel
{


    public class Order
    {

        private int _orderID;
        public int OrderID
        {

            get { return _orderID; }

            set
            {
                if (value > 0)
                {
                    _orderID = value;

                }
            }
        }
        public string? _custName;

        private int _custID;
        public int CustID

        {
            get { return _custID; }
            set { _custID = value; }
        }


        private string? _storeName;
        public string StoreName
        {

            get { return _storeName; }

            set
            {
                if (value != "")
                {
                    _storeName = value;

                }
                else
                {
                    Console.WriteLine("must not be empty");
                }
            }
        }
        public string _listOfProducts;
        private List<LineItems> _lineItems;
        public List<LineItems> LineItems
        {

            get { return _lineItems; }

            set
            {
                _lineItems = value;
            }
        }

        private string _storeFrontLocation;
        public string StoreLocation
        {
            get { return _storeFrontLocation; }
            set
            {
                if (_storeFrontLocation != "")
                {

                    _storeFrontLocation = value;
                }
                else
                {
                    Console.WriteLine("Must not be empty");
                }
            }

        }

        private int _storeID;
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
                    Console.WriteLine("Order ID must be greater than 0");
                }


            }
        }

        private int _totalPrice;
        public int TotalPrice
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

        private DateTime _timeStamp;
        public DateTime TimeStamp

        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
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
            return $"Order ID: {_orderID}\nStore ID: {_storeID}\nOrder Price: {TotalPrice}\nTime Stamp: {TimeStamp}\n";
        }




    }
}