﻿using XHOnlineShop.Data.Infrastructure;
using XHOnlineShop.Model.Models;

namespace XHOnlineShop.Data.Repositories
{
    public interface IErrorLogRepository : IRepository<ErrorLog>
    {
    }

    public class ErrorLogRepository : RepositoryBase<ErrorLog>, IErrorLogRepository
    {
        public ErrorLogRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}