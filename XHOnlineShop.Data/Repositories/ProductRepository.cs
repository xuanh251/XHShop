using XHOnlineShop.Data.Infrastructure;
using XHOnlineShop.Model.Models;

namespace XHOnlineShop.Data.Repositories
{ 
    public interface IProductRepository : IRepository<Product>
    {
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}