using ParamApi.Data.Model;
using ParamApi.Data.Repository.Abstract;

namespace ParamApi.Data.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Account> AccountRepository { get; }


        Task CompleteAsync();
    }
}
