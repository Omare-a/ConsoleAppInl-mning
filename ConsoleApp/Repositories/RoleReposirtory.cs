using ConsoleApp.Context;
using ConsoleApp.Entities;

namespace ConsoleApp.Repositories;

public class RoleReposirtory(DataContext context) : BaseRepository<RoleEntity>(context)
{
    private readonly DataContext _context = context;
}
