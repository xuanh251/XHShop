﻿using XHOnlineShop.Data.Infrastructure;
using XHOnlineShop.Model.Models;

namespace XHOnlineShop.Data.Repositories
{
    public interface IOrderRepository  : IRepository<Order>
    {
    }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}