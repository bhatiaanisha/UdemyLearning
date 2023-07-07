using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(SkiNetContext context) : base(context)
        {

        }

        public async Task<List<Product>> GetAllProducts(string? sort, string? brandName, string? typeName, string? search)
        {
            if(!string.IsNullOrEmpty(sort))
            {
                switch(sort) 
                {
                    case "priceAsc":
                        return await PriceLowToHigh();
                    case "priceDesc":
                        return await PriceHighToLow();
                    default:
                        return await OrderByName();
                }
            }
            if(!string.IsNullOrEmpty(brandName) || !string.IsNullOrEmpty(typeName)) 
            {
                if (!string.IsNullOrEmpty(brandName) && !string.IsNullOrEmpty(typeName))
                {
                    return await _context.Products.Include(p => p.ProductType).Include(p => p.ProductBrand).Where(x => x.ProductBrand.ProductBrandName == brandName && x.ProductType.ProductTypeName == typeName).ToListAsync();
                }
                else
                {
                    return await _context.Products.Include(p => p.ProductType).Include(p => p.ProductBrand).Where(x => x.ProductBrand.ProductBrandName == brandName || x.ProductType.ProductTypeName == typeName).ToListAsync();
                }
            }
            if(!string.IsNullOrEmpty(search))
            {
                return await _context.Products.Include(p => p.ProductType).Include(p => p.ProductBrand).Where(x => x.ProductName.Contains(search.ToLower())).ToListAsync();
            }
            return await _context.Products.Include(p => p.ProductType).Include(p => p.ProductBrand).ToListAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Products.Include(p => p.ProductType).Include(p => p.ProductBrand).FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<List<Product>> OrderByName()
        {
            return await _context.Products.Include(p => p.ProductType).Include(p => p.ProductBrand).OrderBy(x => x.ProductName).ToListAsync();
        }

        public async Task<List<Product>> PriceLowToHigh()
        {
            return await _context.Products.Include(p => p.ProductType).Include(p => p.ProductBrand).OrderBy(x => x.Price).ToListAsync();
        }

        public async Task<List<Product>> PriceHighToLow()
        {
            return await _context.Products.Include(p => p.ProductType).Include(p => p.ProductBrand).OrderByDescending(x => x.Price).ToListAsync();
        }
    }
}
