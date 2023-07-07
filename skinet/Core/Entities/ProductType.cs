﻿using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class ProductType
{
    public int ProductTypeId { get; set; }

    public string? ProductTypeName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
