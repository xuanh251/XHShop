using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XHOnlineShop.Model.Models;
using XHOnlineShop.Data.Infrastructure;
using XHOnlineShop.Data.Repositories;
namespace XHOnlineShop.Service
{
    public interface IErrorService
    {
        ErrorLog Create(ErrorLog error);
        void Save();
    }
    public class ErrorLogService : IErrorService
    {
        IErrorLogRepository _errorRepository;
        IUnitOfWork _unitOfWork;
        public ErrorLogService(IErrorLogRepository errorLogRepository, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorLogRepository;
            this._unitOfWork = unitOfWork;
        }
        public ErrorLog Create(ErrorLog error)
        {
            return _errorRepository.Add(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
