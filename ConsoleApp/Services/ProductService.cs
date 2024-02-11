using ConsoleApp.Dto;
using ConsoleApp.Entities;
using ConsoleApp.Repositories;
using System.Diagnostics;

namespace ConsoleApp.Services;

public class ProductService(ProductRepository productRepository)
{
    private readonly ProductRepository _productRepository = productRepository;


    public bool CreatOrder(ProductDto product)
    {
        try
        {
            var productEntity = _productRepository.GetOne(x => x.ProductName == product.ProductName);
            productEntity ??= _productRepository.Creat(new ProductEntity { ProductName = product.ProductName });

            var result = _productRepository.Creat(new ProductEntity
            {
                ProductId = productEntity.ProductId,
                ProductName = productEntity.ProductName,
                Price = productEntity.Price,
            });
            if (result != null)
                return true;
        }
        catch(Exception ex) { Debug.WriteLine(ex.Message); }
        return false;

    }

    public IEnumerable<ProductDto> GetAllProducts() 
    {
        var products = new List<ProductDto>();
        try
        {
            var result = _productRepository.GetAll();

            foreach (var item in result)
                products.Add(new ProductDto
                {
                    ProductName = item.ProductName,
                    Price = item.Price,
                });

        }
        catch(Exception ex) { Debug.WriteLine(ex.Message); }
        return products;
    }
    


}
