using ConsoleApp.Entities;
using ConsoleApp.Repositories;
using System.Diagnostics;

namespace ConsoleApp.Services;

public class RoleService(RoleReposirtory RoleRepository)
{
    
    private readonly RoleReposirtory _RoleRepository = RoleRepository;

    public bool CreateRole(string roleName)
    {
        try
        {
            var role = _RoleRepository.GetOne(x => x.RoleName == roleName);
            role ??= _RoleRepository.Creat(new RoleEntity { RoleName = roleName });

            var result = _RoleRepository.Creat(new RoleEntity
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
            });
            if (result != null)
                return true;

        }
        catch(Exception ex) { Debug.Write(ex.Message); }
        return false;
    }

    public IEnumerable<RoleEntity> GetRoles()
    {
        var roles = new List<RoleEntity>();
        try
        {
            var result = _RoleRepository.GetAll();
            foreach ( var role in result)
            {
                roles.Add(new RoleEntity
                {
                    RoleId= role.RoleId,
                    RoleName = role.RoleName,
                });
            }

        }
        catch(Exception ex) { Debug.WriteLine(ex.Message); }
        return roles;

    }

}
