using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XHOnlineShop.Model.Models;
using XHOnlineShop.Service;

namespace XHOnlineShop.Web.Infrastructure.Core
{
    public class APIControllerBase : ApiController
    {
        private IErrorService _errorService;

        public APIControllerBase(IErrorService errorService)
        {
            this._errorService = errorService;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage, Func<HttpResponseMessage> func)
        {
            HttpResponseMessage response = null;
            try
            {
                response = func.Invoke();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var item in ex.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \"{item.Entry.Entity.GetType().Name}\" in state \"{item.Entry.State}\" has the following validation error:");
                    foreach (var item1 in item.ValidationErrors)
                    {
                        Trace.WriteLine($"-Property:\"{item1.PropertyName}\", Error: \"{item1.ErrorMessage}\"");
                    }
                }
                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (DbUpdateException dbEx)
            {
                LogError(dbEx);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbEx.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        //ghi lỗi vào database
        private void LogError(Exception ex)
        {
            try
            {
                ErrorLog err = new ErrorLog();
                err.CreatedDate = DateTime.Now;
                err.Message = ex.Message;
                err.StackTrace = ex.StackTrace;
                _errorService.Create(err);
                _errorService.Save();
            }
            catch
            {
            }
        }
    }
}