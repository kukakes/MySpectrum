using System;

namespace MySpectrum.Core.Models
{
    public abstract class ProductBase
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}