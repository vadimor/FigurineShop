﻿namespace Catalog.Models.Requests
{
    public class UpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
