using System;

namespace XHOnlineShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        XHOnlineShopDbContext Init();
    }
}