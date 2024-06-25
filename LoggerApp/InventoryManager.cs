using devProChallenge.Models;

namespace devProChallenge.LoggerApp
{
    public static class InventoryManager
    {
        public static List<Product> SortProducts(this List<Product> products, string sortKey, bool ascending)
        {
            Func<Product, object> keySelector = sortKey.ToLower() switch
            {
                "name" => p => p.Name,
                "price" => p => p.Price,
                "stock" => p => p.Stock,
                _ => throw new ArgumentException("Invalid sort key")
            };

            return ascending
                ? products.OrderBy(keySelector).ToList()
                : products.OrderByDescending(keySelector).ToList();
        }
    }
}
