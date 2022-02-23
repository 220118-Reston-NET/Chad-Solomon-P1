namespace PokeModel
{
    public class Customer
    {


        public int _custID { get; set; }
        // public int CustID
        // {
        //     get { return _custID; }

        //     set
        //     {
        //         if (value > 0)
        //         {

        //             _custID = value;
        //         }
        //         else
        //         {

        //             Console.WriteLine("ID must not be empty");
        //             Console.WriteLine("Please press enter!");
        //             Console.ReadLine();

        //         }

        //     }
        // }
        private string? _name; //{ get; set; }
        public string? Name
        {
            get { return _name; }

            set
            {
                if (value != "")
                {

                    _name = value;
                }
                else
                {
                    Console.WriteLine("Name cannot be empty");
                }

            }
        }



        private string? _address; //{ get; set; }
        public string? Address
        {
            get { return _address; }

            set
            {

                if (value != "")
                {

                    _address = value;
                }
                else
                {
                    Console.WriteLine("Address must not be empty");
                    Console.WriteLine("Please press enter!");
                    Console.ReadLine();

                }
            }

        }
        private string? _email;
        public string? Email
        {
            get { return _email; }

            set
            {

                if (value != "")
                {

                    _email = value;
                }
                else
                {
                    Console.WriteLine("Email must not be empty!");
                    Console.WriteLine("Please press enter to continue");
                    Console.ReadLine();

                }
            }

        }

        private string? _password;
        public string? Password
        {
            get { return _password; }

            set
            {

                if (value != "")
                {

                    _password = value;
                }
                else
                {
                    Console.WriteLine("Password must not be empty!");
                    Console.WriteLine("Please press enter to continue");
                    Console.ReadLine();

                }
            }

        }



        // private List<Order> _custOrders;
        // //Above is a field and below is the property
        // public List<Order> Orders
        // {
        //     get { return _custOrders; }

        //     set
        //     {
        //         if (value != null)
        //         {

        //             _custOrders = value;
        //         }
        //         else
        //         {
        //             Console.WriteLine("No orders have been placed.");
        //         }

        //     }
        // }

        // private List<Leashes> _custLeashess;
        // //Above is a field and below is the property
        // public List<Leashes> Leashess
        // {
        //     get { return _custLeashess; }

        //     set
        //     {

        //         _custLeashess = value;

        //     }
        // }



        public Customer()
        {

            Name = "No Name";
            Address = "No Address";
            Email = "No Email";
            _custID = 0;
            // Orders = new List<Order>();
            // Leashess = new List<Leashes>();


        }

        public override string ToString()
        {
            return $"Name: {Name}\nAddress: {Address}\nEmail: {Email}\nPassword {Password}\n";
        }



        // public override string ToString()
        // {
        //     return $"Name: {Name}\nAddress: {Address}\nEmail: {Email}\nOrders: {Orders}\nLeashess: {Leashess}";
        // }
    }
}
