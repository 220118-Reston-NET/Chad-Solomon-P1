namespace PokeModel
{
    public class OrderDetails
    {

        public int OrderID { get; set; }
        public string CustName { get; set; }
        public string StoreName { get; set; }
        public List<ProductDetails> ShoppingCart { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderTime { get; set; }

        public OrderDetails()
        {

            ShoppingCart = new List<ProductDetails>();
        }

    }
}