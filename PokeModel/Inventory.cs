namespace PokeModel
{
    public class Inventory
    {
        private int _storeID;
        public int StoreID
        {
            get { return _storeID; }
            set { _storeID = value; }
        }

        private string _storeName;

        public string StoreName
        {

            get { return _storeName; }
            set { _storeName = value; }
        }
        private int _productID;
        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }




        private string _prodName;
        public string ProdName
        {

            get { return _prodName; }
            set { _prodName = value; }

        }

        private string _description;
        public string Description
        {

            get { return _description; }
            set { _description = value; }

        }

        private int _price;
        public int Price

        {
            get { return _price; }
            set { _price = value; }
        }

        private int _quantity;
        public int Quantity
        {

            get { return _quantity; }
            set { _quantity = value; }

        }


        public override string ToString()
        {
            return $"Store ID: {_storeID}\nProduct ID: {_productID}\nQuantity: {Quantity}\n";
            // return $"Store Name: {StoreName}\nProduct Name: {ProdName}\nProduct ID: {_productID}\nDescription: {Description}\nQuantity: {Quantity}\n";
        }


    }
}