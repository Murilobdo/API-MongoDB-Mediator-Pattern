using System.Collections.Generic;
using API.Models;
using API.Domain.Product.Command;
using MongoDB.Driver;
using System;
using MongoDB.Bson;

namespace API.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(ProductEntity command);
        bool IfExist(string productName);
        void DeleteProduct(ObjectId id);
        void UpdateProduct(ProductEntity productEntity);
        List<ProductEntity> ToList();
    }
}