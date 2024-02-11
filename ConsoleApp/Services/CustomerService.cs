using ConsoleApp.Dto;
using ConsoleApp.Entities;
using ConsoleApp.Repositories;
using System.Data;
using System.Diagnostics;

namespace ConsoleApp.Services;

public class CustomerService(CustomerRepository customerRepository, RoleReposirtory roleReposirtory)
{
    private readonly CustomerRepository _customerRepository = customerRepository;
    private readonly RoleReposirtory _roleRepository = roleReposirtory;

    public bool CreatCustomer(CustomerDto customer)
    {
        try
        {
            if (!_customerRepository.Exists(x => x.CustomerId == customer.CustomerId))
            {
                var roleEntity = _roleRepository.GetOne(x => x.RoleName == customer.RoleName);
                roleEntity ??= _roleRepository.Creat(new RoleEntity { RoleName = customer.RoleName });

                var customerEntity = new CustomerEntity 
                {
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PostalCode = customer.PostalCode,
                    Country = customer.Country,
                    RoleId = roleEntity.RoleId
                };
                var result = _customerRepository.Creat(customerEntity);
                if (result != null)
                    return true;
            }
        }
        catch(Exception ex) { Debug.WriteLine(ex.Message); }
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
                    CustomerId=customer.CustomerId,
                    FirstName=customer.FirstName,
                    LastName=customer.LastName,
                    PostalCode=customer.PostalCode,
                    Country = customer.Country,
                    RoleName = customer.Role.RoleName
                });
            }

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return customers;

    }


}
