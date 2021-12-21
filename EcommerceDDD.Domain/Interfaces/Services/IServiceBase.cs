using EcommerceDDD.Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceDDD.Domain.Interfaces.Services
{
    public interface IServiceBase<Entity> where Entity : EntityBase
    {
        public Task<Entity> Add(Entity entity);

        public Task<Entity> Update(Entity entity);

        public Task<Entity> Delete(int id);

        public Task<Entity> Get(int id);

        public Task<List<Entity>> Get();
    }
}