using Microsoft.EntityFrameworkCore;
using ParamApi.Data.Context;
using ParamApi.Data.Repository.Abstract;

namespace ParamApi.Data.Repository.Concrete
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {

        protected readonly AppDbContext Context;
        private DbSet<Entity> entities;


        public GenericRepository(AppDbContext dbContext)
        {
            this.Context = dbContext;
            this.entities = Context.Set<Entity>();
        }


        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await entities.AsNoTracking().ToListAsync();
        }

        public virtual async Task<Entity> GetByIdAsync(int entityId)
        {
            return await entities.FindAsync(entityId);
            //return await entities.Where(entity => EF.Property<int>(entity, "CustomerNumber").Equals(entityId)).SingleOrDefaultAsync();
        }

        public async Task InsertAsync(Entity entity)
        {
            await entities.AddAsync(entity);     
        }

        public void RemoveAsync(Entity entity)
        {
            var column = entity.GetType().GetProperty("IsDeleted");
            if (column is not null)
            {
                entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
            }
            else
            {
                entities.Remove(entity);
            }
        }
            
        public void Update(Entity entity)
        {
            entities.Update(entity);
        }
    }
}
