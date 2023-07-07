using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class ProductBrand
{
    public int ProductBrandId { get; set; }

    public string? ProductBrandName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
