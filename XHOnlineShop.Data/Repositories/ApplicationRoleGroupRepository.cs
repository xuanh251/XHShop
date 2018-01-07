using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XHOnlineShop.Data.Infrastructure;
using XHOnlineShop.Model.Models;

namespace XHOnlineShop.Data.Repositories
{
    public interface IApplicationRoleGroupRepository : IRepository<ApplicationRoleGroup>
    {

    }
    public class ApplicationRoleGroupRepository : RepositoryBase<ApplicationRoleGroup>, IApplicationRoleGroupRepository
    {
        protected ApplicationRoleGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
