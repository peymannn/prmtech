using AutoMapper;
using ParamApi.Data.Model;
using ParamApi.Data.Repository.Abstract;
using ParamApi.Data.Uow;
using ParamApi.Dto.Dtos;
using ParamApi.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamApi.Service.Concrete
{
    public class AccountService : BaseService<AccountDto, Account>, IAccountService
    {
        private readonly IGenericRepository<Account> genericRepository;
        public AccountService(IGenericRepository<Account> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(genericRepository, mapper, unitOfWork)
        {
            this.genericRepository= genericRepository;
        }
    }
}
