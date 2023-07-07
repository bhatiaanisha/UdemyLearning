using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public string? PictureUrl { get; set; }

    public int? ProductTypeId { get; set; }

    public int? ProductBrandId { get; set; }

    public virtual ProductBrand? ProductBrand { get; set; }

    public virtual ProductType? ProductType { get; set; }
}
