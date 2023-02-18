using ParamApi.Data.Context;
using ParamApi.Data.Model;
using ParamApi.Data.Repository.Concrete;

namespace ParamApi.Data.Repository.Concrete
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext Context) : base(Context)
        {

        }       
    }
}
