using System.Collections.Generic;
using API.Models;
using MediatR;

namespace API.Domain.Product.Command
{
    public class ListProductCommand : IRequest<List<ListProductCommand>>
    {
         public string Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
    }
}