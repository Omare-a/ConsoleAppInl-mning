using ConsoleApp.Context;
using ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace ConsoleApp.Repositories;

public class OrderRepository(DataContext context) : BaseRepository<OrderEntity>(context)
{
    private readonly DataContext _context = context;

    public override IEnumerable<OrderEntity> GetAll()
    {
        try
        {
            return _context.Orders.Include(a => a.CustomerId).ToList();
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public override OrderEntity GetOne(Expression<Func<OrderEntity, bool>> predicate)
    {
        try
        {
            return _context.Orders.Include(a => a.CustomerId).FirstOrDefault(predicate, null!);
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }
}
