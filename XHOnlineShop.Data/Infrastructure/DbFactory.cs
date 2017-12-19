namespace XHOnlineShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private XHOnlineShopDbContext dbContext;

        public XHOnlineShopDbContext Init()
        {
            return dbContext ?? (dbContext = new XHOnlineShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}