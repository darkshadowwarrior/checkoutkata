using Checkout.Models;

namespace Checkout.Interfaces
{
    public interface IBasketService
    {
        void Scan(Item item);
        int GetItemCount();
        double GetTotal();
    }
}