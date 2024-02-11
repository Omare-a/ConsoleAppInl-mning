using ConsoleApp.Dto;
using ConsoleApp.Entities;
using ConsoleApp.Repositories;
using System.Diagnostics;

namespace ConsoleApp.Services;

public class OrderProductRowService(OrderProductRowRepositories repository, OrderRepository orderRepository, ProductRepository productRepository)
{
    private readonly OrderProductRowRepositories _orderProductRowRepository = repository;
    private readonly OrderRepository _orderRepository = orderRepository;
    private readonly ProductRepository _productRepository = productRepository;

    public bool CreatOrderProductRow(OrderProductRowDto orderProductRow)
    {
        try
        {
            if (!_orderProductRowRepository.Exists(x => x.RowId == orderProductRow.RowId))
            {
                var orderEntity = _orderRepository.GetOne(x => x.OrderId == orderProductRow.OrderId);
                orderEntity ??= _orderRepository.Creat(new OrderEntity { OrderId = orderProductRow.OrderId });

                var productEntity = _productRepository.GetOne(x => x.ProductName == orderProductRow.ProductName);
                productEntity ??= _productRepository.Creat(new ProductEntity { ProductName = orderProductRow.ProductName });

                var orderProductEnitity = new OrderProductRowEntity
                {
                    RowId = orderProductRow.RowId,
                    OrderId = orderEntity.OrderId,
                    ProductId = productEntity.ProductId,
                    Price = orderProductRow.Price,
                    
                };
                var result = _orderProductRowRepository.Creat(orderProductEnitity);
                if (result != null)
                    return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    public IEnumerable<OrderProductRowDto> GetOrderProductRow()
    {
        var orderRow = new List<OrderProductRowDto>();
        try
        {
            var result = _orderProductRowRepository.GetAll();
            foreach (var orderRows in result)
            {
                orderRow.Add(new OrderProductRowDto
                {
                    RowId=orderRows.RowId,
                    OrderId=orderRows.OrderId,
                    Price=orderRows.Price,
                    ProductName = orderRows.Product.ProductName
                    
                });
            }

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return orderRow;

    }

}
