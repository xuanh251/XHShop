using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XHOnlineShop.Data.Infrastructure;
using XHOnlineShop.Data.Repositories;
using XHOnlineShop.Model.Models;
using XHOnlineShop.Common;

namespace XHOnlineShop.Service
{
    public interface IProductService
    {
        Product Add(Product Product);

        void Update(Product Product);

        Product Delete(int id);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAll(string keyword);

        Product GetById(int id);

        void Save();
    }

    public class ProductService : IProductService
    {
        private IProductRepository _ProductRepository;
        private IUnitOfWork _unitOfWork;
        private ITagRepository _tagRepository;
        private IProductTagRepository _productTagRepository;

        public ProductService(IProductRepository ProductRepository, IUnitOfWork unitOfWork, ITagRepository tagRepository, IProductTagRepository productTagRepository)
        {
            _ProductRepository = ProductRepository;
            _unitOfWork = unitOfWork;
            _tagRepository = tagRepository;
            _productTagRepository = productTagRepository;
        }

        public Product Add(Product Product)
        {
            var product = _ProductRepository.Add(Product);
            Save();
            if (!string.IsNullOrEmpty(Product.Tags))
            {
                string[] ListTags = Product.Tags.Split(',');
                foreach (var item in ListTags)
                {
                    var TagID = StringHelper.ToUnsignString(item);
                    if (_tagRepository.Count(s => s.ID == TagID) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = TagID;
                        tag.Name = item;
                        tag.Type = CommonConstants.ProductTag;
                        _tagRepository.Add(tag);
                    }
                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = Product.ID;
                    productTag.TagID = TagID;
                    _productTagRepository.Add(productTag);
                }
            }
            return product;
        }
        public void Update(Product Product)
        {
            _ProductRepository.Update(Product);
            if (!string.IsNullOrEmpty(Product.Tags))
            {
                string[] ListTags = Product.Tags.Split(',');
                foreach (var item in ListTags)
                {
                    var TagID = StringHelper.ToUnsignString(item);
                    if (_tagRepository.Count(s => s.ID == TagID) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = TagID;
                        tag.Name = item;
                        tag.Type = CommonConstants.ProductTag;
                        _tagRepository.Add(tag);
                    }
                    _productTagRepository.DeleteMulti(s => s.ProductID == Product.ID);
                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = Product.ID;
                    productTag.TagID = TagID;
                    _productTagRepository.Add(productTag);
                }
            }
        }
        public Product Delete(int id)
        {
            return _ProductRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _ProductRepository.GetAll();
        }

        public IEnumerable<Product> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _ProductRepository.GetMulti(s => s.Name.Contains(keyword) || s.Description.Contains(keyword) || s.Alias.Contains(keyword));
            }
            else
            {
                return _ProductRepository.GetAll();
            }

        }

        public Product GetById(int id)
        {
            return _ProductRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

       
    }
}
