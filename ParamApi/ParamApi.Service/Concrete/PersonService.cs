using AutoMapper;
using ParamApi.Base;
using ParamApi.Data.Model;
using ParamApi.Data.Repository.Abstract;
using ParamApi.Data.Uow;
using ParamApi.Dto.Dtos;
using ParamApi.Service.Abstract;

namespace ParamApi.Service.Concrete
{
    public class PersonService : BaseService<PersonDto, Person>, IPersonService
    {
        private readonly IGenericRepository<Person> genericRepository;
        public PersonService(IGenericRepository<Person> genericRepository,IMapper mapper, IUnitOfWork unitOfWork) : base(genericRepository, mapper, unitOfWork)
        {
            this.genericRepository = genericRepository;
        }

        public override async Task<BaseResponse<PersonDto>> InsertAsync(PersonDto createPersonResource)
        {
            if (createPersonResource.StaffId == "9")
            {
                return new BaseResponse<PersonDto>("Id was 9");
            }

            return await base.InsertAsync(createPersonResource);
        }
    }
}
