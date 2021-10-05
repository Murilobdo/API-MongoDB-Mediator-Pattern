using System;
using MongoDB.Bson;

namespace API.Models
{
    public class ProductEntity 
    {
        public ProductEntity()
        {
            this.Active = true;
        }

        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public bool Active { get; set; }
    }
}