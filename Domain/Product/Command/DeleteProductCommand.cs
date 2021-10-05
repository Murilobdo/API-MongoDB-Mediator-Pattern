using System.Globalization;
using System;
using MediatR;
using MongoDB.Bson;

namespace API.Domain.Product.Command
{
    public class DeleteProductCommand : IRequest<string>
    {
        public string Id { get; set; }

        public DeleteProductCommand()
        {
            
        }

        public DeleteProductCommand(string Id)
        {
            this.Id = Id;
        }
    }
}