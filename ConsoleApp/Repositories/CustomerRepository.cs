using ConsoleApp.Context;
using ConsoleApp.Entities;

namespace ConsoleApp.Repositories;

public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context)
{
    private readonly DataContext _context = context;
}
