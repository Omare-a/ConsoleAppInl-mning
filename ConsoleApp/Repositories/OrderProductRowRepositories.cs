using ConsoleApp.Context;
using ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace ConsoleApp.Repositories;

public class OrderProductRowRepositories(DataContext context) : BaseRepository<OrderProductRowEntity>(context)
{
    private readonly DataContext _context = context;

    public override IEnumerable<OrderProductRowEntity> GetAll()
    {
        try
        {
            return _context.OrderProductRow.Include(a => new { a.OrderId, a.ProductId }).ToList();
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public override OrderProductRowEntity GetOne(Expression<Func<OrderProductRowEntity, bool>> predicate)
    {
        try
        {
            return _context.OrderProductRow.Include(a => new { a.OrderId, a.ProductId }).FirstOrDefault(predicate, null!);
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }
}
