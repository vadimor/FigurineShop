﻿namespace MVC.ViewModels
{
    public class BasketData
    {
        public Dictionary<CatalogItem, int> Data { get; set; } = new Dictionary<CatalogItem, int>();
    }
}
