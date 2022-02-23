namespace PokeModel
{

    public class LineItems
    {
        public int _orderID;
        private int _product;

        public int Product
        {
            get { return _product; }

            set
            {
                if (value > 0)
                {

                    _product = value;
                }
                else
                {
                    Console.WriteLine("None available");

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
                else
                {
                    Console.WriteLine("You must have atleast 1 product selected");
                }
            }
        }


        public override string ToString()
        {
            return $"Product ID: {Product}\nQuantity: {Quantity}\n";
        }

        // public LineItems()
        // {

        //     Product = "None";
        //     Quantity = 0;
        // }
    }
}