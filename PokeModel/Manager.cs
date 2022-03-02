namespace PokeModel
{
    public class Manager
    {


        public int _managerID { get; set; }
        public int ManagerID
        {
            get { return _managerID; }

            set
            {
                if (value > 0)
                {

                    _managerID = value;
                }
                else
                {

                    Console.WriteLine("ID must not be empty");
                    Console.WriteLine("Please press enter!");
                    Console.ReadLine();

                }

            }
        }

        private bool _isManager;
        public bool IsManager
        {
            get { return _isManager; }
            set { _isManager = value; }
        }


        private int _storeID;
        public int StoreFrontID

        {
            get { return _storeID; }
            set
            {
                if (value > 0)
                {
                    _storeID = value;
                }

            }
        }

        private string? _managerName; //{ get; set; }
        public string? ManagerName
        {
            get { return _managerName; }

            set
            {
                if (value != "")
                {

                    _managerName = value;
                }
                else
                {
                    Console.WriteLine("Name cannot be empty");
                }

            }
        }



        private string? _managerAddress; //{ get; set; }
        public string? ManagerAddress
        {
            get { return _managerAddress; }

            set
            {

                if (value != "")
                {

                    _managerAddress = value;
                }
                else
                {
                    Console.WriteLine("Address must not be empty");
                    Console.WriteLine("Please press enter!");
                    Console.ReadLine();

                }
            }

        }
        private string? _managerEmail;
        public string? ManagerEmail
        {
            get { return _managerEmail; }

            set
            {

                if (value != "")
                {

                    _managerEmail = value;
                }
                else
                {
                    Console.WriteLine("Email must not be empty!");
                    Console.WriteLine("Please press enter to continue");
                    Console.ReadLine();

                }
            }

        }

        private string? _managerPassword;
        public string? ManagerPassword
        {
            get { return _managerPassword; }

            set
            {

                if (value != "")
                {

                    _managerPassword = value;
                }
                else
                {
                    Console.WriteLine("Password must not be empty!");
                    Console.WriteLine("Please press enter to continue");
                    Console.ReadLine();

                }
            }

        }





        // public override string ToString()
        // {
        //     return $"Name: {Name}\nAddress: {Address}\nEmail: {Email}\nPassword {Password}\n";
        // }


    }
}
