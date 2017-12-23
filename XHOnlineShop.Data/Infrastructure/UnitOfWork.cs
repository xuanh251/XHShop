namespace XHOnlineShop.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private XHOnlineShopDbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public XHOnlineShopDbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}