﻿using KriniteWebShop.ProductCatalog.API.Entities;
using System.Linq.Expressions;

namespace KriniteWebShop.ProductCatalog.API.Repositories;

public interface IProductRepository
{
    Task<Product> GetProductById(Guid id);
    Task<IReadOnlyCollection<Product>> GetProducts();
    Task<IReadOnlyCollection<Product>> GetProductsWithFilter(Expression<Func<Product, bool>> filter);

    Task CreateProduct(Product product);
    Task<bool> UpdateProduct(Product product);
    Task<bool> DeleteProduct(Guid id);
}