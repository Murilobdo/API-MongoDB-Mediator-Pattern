using System.Collections.Generic;
using API.Interfaces;
using API.Models;
using API.Domain.Product.Command;
using MongoDB.Driver;
using System;
using MongoDB.Bson;

namespace API.Data.Repository
{
    public class ProductRepository : MongoDbContext, IProductRepository
    {
        public void AddProduct(ProductEntity product) => 
            ProductContext.InsertOne(product);
        public void UpdateProduct(ProductEntity product) => 
            ProductContext.ReplaceOne(p => p.Name == product.Name, product);
        public void DeleteProduct(ObjectId id) =>
            ProductContext.DeleteOne(p => p.Id == id);
        public bool IfExist(string productName) => 
            ProductContext.Find(p => p.Name == productName).Any();

        public List<ProductEntity> ToList()
        {
            return ProductContext.Find(new BsonDocument()).ToList();
        }
    }
}