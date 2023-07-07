using Infrastructure.Data.Context;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using API.DTOs;
using AutoMapper;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public ProductsController(IProductRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductToReturnDto>>> GetProducts(string? sort, string? brandName, string? typeName, string? search)
        {
            var products = await _repo.GetAllProducts(sort, brandName, typeName, search);
            return _mapper.Map<List<Product>, List<ProductToReturnDto>>(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var product = await _repo.GetProductById(id);
            return _mapper.Map<Product,ProductToReturnDto>(product);
            //return new ProductToReturnDto
            //{
            //    ProductId = productObj.ProductId,
            //    ProductName = productObj.ProductName,
            //    Description = productObj.Description,
            //    Price = productObj.Price,
            //    PictureUrl = productObj.PictureUrl,
            //    ProductType = productObj.ProductType?.ProductTypeName,
            //    ProductBrand = productObj.ProductBrand?.ProductBrandName
            //};
        }
    }
}
