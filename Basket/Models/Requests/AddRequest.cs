﻿using Basket.Models.Dtos;

namespace Basket.Models.Requests
{
    public class AddRequest
    {
        public CatalogItemDto CatalogItem { get; set; } = null!;
        public int CountItems { get; set; }
    }
}
