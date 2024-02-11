using ConsoleApp.Dto;
using ConsoleApp.Entities;
using ConsoleApp.Repositories;
using System.Diagnostics;

namespace ConsoleApp.Services;

public class OrderService(OrderRepository orderRepository, CustomerRepository customerRepository)
{
    private readonly OrderRepository _orderRepository = orderRepository;
    private readonly CustomerRepository _customerRepository = customerRepository;

    public bool CreatOrder(int orderId, int customerId)
    {
        try
        {
            if (!_orderRepository.Exists(x => x.OrderId == orderId))
            {
                var customerEntity = _customerRepository.GetOne(x => x.CustomerId == customerId);
                customerEntity ??= _customerRepository.Creat(new CustomerEntity { CustomerId = customerId });

                var orderEntity = new OrderEntity
                {
                    OrderId = orderId,
                    CustomerId = customerEntity.CustomerId
                };
                var result = _orderRepository.Creat(orderEntity);
                if (result != null)
                    return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    public IEnumerable<CustomerDto> GetCustomer()
    {
        var customers = new List<CustomerDto>();
        try
        {
            var result = _customerRepository.GetAll();
            foreach (var customer in result)
            {
                customers.Add(new CustomerDto
                {
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PostalCode = customer.PostalCode,
                    Country = customer.Country,
                    RoleName = customer.Role.RoleName
                });
            }

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return customers;

    }

}
