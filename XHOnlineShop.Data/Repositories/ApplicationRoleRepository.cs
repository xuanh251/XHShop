using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XHOnlineShop.Data.Infrastructure;
using XHOnlineShop.Model.Models;

namespace XHOnlineShop.Data.Repositories
{
    public interface IApplicationRoleRepository : IRepository<ApplicationRole>
    {

    }
    public class ApplicationRoleRepository : RepositoryBase<ApplicationRole>, IApplicationRoleRepository
    {
        protected ApplicationRoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
