using System.Text.Json;

namespace ServerShopTask.Services
{
    public class ProductService(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync("https://fakestoreapi.com/products");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<IEnumerable<Product>>(content);

            return products ?? [];
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"https://fakestoreapi.com/products/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var product = JsonSerializer.Deserialize<Product>(content);

            return product;
        }
    }

public class Product
{
    public int id { get; set; }

    public string? title { get; set; }
    public decimal price { get; set; }
    public string? description { get; set; }
    public string? category { get; set; }
    public string? image { get; set; }
    public Rating? rating { get; set; }
}

public class Rating
{
    public decimal rate { get; set; }
    public int count { get; set; }
}
}
