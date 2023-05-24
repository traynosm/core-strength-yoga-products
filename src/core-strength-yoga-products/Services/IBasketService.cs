using core_strength_yoga_products.Models;

namespace core_strength_yoga_products.Services
{
    public interface IBasketService
    {
        Task<BasketItem?> CalculateItemTotal(BasketItem basketItem);
        Task<decimal> CalculateTotalBasketCost(IEnumerable<BasketItem> basketItems);
    }
}
