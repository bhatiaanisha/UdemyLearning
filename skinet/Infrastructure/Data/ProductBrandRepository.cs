using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductBrandRepository : GenericRepository<ProductBrand>, IProductBrandRepository
    {
        public ProductBrandRepository(SkiNetContext context) : base(context)
        {

        }
    }
}
