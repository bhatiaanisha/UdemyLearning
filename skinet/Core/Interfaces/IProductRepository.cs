using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetAllProducts(string? sort, string? brandName, string? typeName, string? search);
        Task<Product?> GetProductById(int id);
    }
}
