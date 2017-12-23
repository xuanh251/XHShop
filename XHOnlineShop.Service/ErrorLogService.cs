using XHOnlineShop.Data.Infrastructure;
using XHOnlineShop.Data.Repositories;
using XHOnlineShop.Model.Models;

namespace XHOnlineShop.Service
{
    public interface IErrorService
    {
        ErrorLog Create(ErrorLog error);

        void Save();
    }

    public class ErrorLogService : IErrorService
    {
        private IErrorLogRepository _errorRepository;
        private IUnitOfWork _unitOfWork;

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