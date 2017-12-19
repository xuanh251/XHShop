using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XHOnlineShop.Model.Models;
using XHOnlineShop.Data.Repositories;
using XHOnlineShop.Data.Infrastructure;
namespace XHOnlineShop.Service
{
    public interface IPostService
    {
        void Add(Post post);
        void Update(Post post);
        void Delete(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow);
        IEnumerable<Post> GetAllByCategoryPaging(int categoryID, int page, int pageSize, out int totalRow);
        Post GetById(int id);
        IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);
        void SaveChange();
    }
    public class PostService : IPostService
    {
        IPostRepository _postResponsitory;
        IUnitOfWork _unitOfWork;
        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postResponsitory = postRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Post post)
        {
            _postResponsitory.Add(post);
        }

        public void Delete(int id)
        {
            _postResponsitory.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postResponsitory.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByCategoryPaging(int categoryID, int page, int pageSize, out int totalRow)
        {
            return _postResponsitory.GetMultiPaging(s => s.Status && s.CategoryID == categoryID, out totalRow, page, pageSize, new string[] { "PostCatogory"});
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            return _postResponsitory.GetAllByTag(tag,page,pageSize, out totalRow);
        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _postResponsitory.GetMultiPaging(s => s.Status, out totalRow, page, pageSize);
        }

        public Post GetById(int id)
        {
            return _postResponsitory.GetSingleById(id);
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postResponsitory.Update(post);
        }

    }
}
