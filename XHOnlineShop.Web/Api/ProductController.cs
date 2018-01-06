using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using XHOnlineShop.Model.Models;
using XHOnlineShop.Service;
using XHOnlineShop.Web.Infrastructure.Core;
using XHOnlineShop.Web.Infrastructure.Extensions;
using XHOnlineShop.Web.Models;

namespace XHOnlineShop.Web.Api
{
    [RoutePrefix("api/product")]
    [Authorize]
    public class ProductController : APIControllerBase
    {
        IProductService _productService;
        public ProductController(IErrorService errorService, IProductService productService) : base(errorService)
        {
            _productService = productService;
        }
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage requestMessage, ProductViewModel productViewModel)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage responseMessage = null;
                if (!ModelState.IsValid)
                {
                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    Product product = new Product();
                    product.UpdateProduct(productViewModel);
                    product.CreatedDate = DateTime.Now;
                    product.CreatedBy = User.Identity.Name;
                    _productService.Add(product);
                    _productService.Save();
                    var responseData = Mapper.Map<Product, ProductViewModel>(product);
                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return responseMessage;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage requestMessage, ProductViewModel productViewModel)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage responseMessage = null;
                if (!ModelState.IsValid)
                {
                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    Product product = _productService.GetById(productViewModel.ID);
                    product.UpdateProduct(productViewModel);
                    product.UpdatedDate = DateTime.Now;
                    product.UpdatedBy = User.Identity.Name;
                    _productService.Update(product);
                    _productService.Save();
                    var responseData = Mapper.Map<Product, ProductViewModel>(product);
                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return responseMessage;
            });
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage requestMessage, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                var totalRow = 0;
                var model = _productService.GetAll(keyword);
                totalRow = model.Count();
                var query = model.OrderByDescending(s => s.CreatedDate).Skip(page * pageSize).Take(pageSize);
                var responseData = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(query);

                var paginationSet = new PaginationSet<ProductViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalPage = (int)Math.Ceiling((decimal)totalRow / pageSize),
                    TotalCount = totalRow
                };
                var response = requestMessage.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }
        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage requestMessage)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                var model = _productService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(model);
                var response = requestMessage.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage requestMessage, int id)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage responseMessage = null;
                if (!ModelState.IsValid)
                {
                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldData = _productService.Delete(id);
                    _productService.Save();
                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.Created, oldData);
                }
                return responseMessage;
            });
        }
        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage requestMessage, string listId)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage responseMessage = null;
                if (!ModelState.IsValid)
                {
                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var ids = new JavaScriptSerializer().Deserialize<List<int>>(listId);
                    foreach (var id in ids)
                    {
                        _productService.Delete(id);
                    }
                    _productService.Save();

                    responseMessage = requestMessage.CreateResponse(HttpStatusCode.Created, ids.Count);
                }
                return responseMessage;
            });
        }
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage requestMessage, int id)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                var model = _productService.GetById(id);
                var responseData = Mapper.Map<Product, ProductViewModel>(model);
                var response = requestMessage.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

    }
}
