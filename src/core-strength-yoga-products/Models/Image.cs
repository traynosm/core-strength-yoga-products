﻿namespace core_strength_yoga_products.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string Alt { get; set; }
        public string Path { get; set; }
        public int ProductId { get; set; }

    }
}
