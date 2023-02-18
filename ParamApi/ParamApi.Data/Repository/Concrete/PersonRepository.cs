using Microsoft.EntityFrameworkCore;
using ParamApi.Data.Context;
using ParamApi.Data.Model;

namespace ParamApi.Data.Repository.Concrete
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext Context) : base(Context)
        {
        }

        
        public override async Task<Person> GetByIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<int> TotalRecordAsync()
        {
            return await Context.Person.CountAsync();
        }
    }
}
