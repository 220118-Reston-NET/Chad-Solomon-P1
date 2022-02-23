using PokeModel;
namespace PokeDL
{
    public interface IOrderHistRepo
    {

        public List<Order> GetAllOrders(int custID);
    }



}