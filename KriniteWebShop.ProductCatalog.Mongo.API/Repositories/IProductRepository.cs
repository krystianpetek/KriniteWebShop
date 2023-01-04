﻿using KriniteWebShop.ProductCatalog.Mongo.API.Entities;
using System.Linq.Expressions;

namespace KriniteWebShop.ProductCatalog.Mongo.API.Repositories;

public interface IProductRepository
{
    Task<Product> GetProductById(string id);
    Task<IEnumerable<Product>> GetProducts();
    Task<IEnumerable<Product>> GetProductsWithFilter(Expression<Func<Product, bool>> filter);

    Task CreateProduct(Product product);
    Task<bool> UpdateProduct(Product product);
    Task<bool> DeleteProduct(string id);
}
