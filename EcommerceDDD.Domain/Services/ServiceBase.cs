using EcommerceDDD.Domain.Core.Entities;
using EcommerceDDD.Domain.Interfaces.Repositories;
using EcommerceDDD.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceDDD.Domain.Services
{
    public class ServiceBase<Entity> : IServiceBase<Entity> where Entity : EntityBase
    {
        protected readonly IRepositoryBase<Entity> _repositoryBase;

        public ServiceBase(IRepositoryBase<Entity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public virtual async Task<Entity> Add(Entity entity)
        {
            return await _repositoryBase.Add(entity);
        }

        public virtual async Task<Entity> Delete(int id)
        {
            return await _repositoryBase.Delete(id);
        }

        public virtual async Task<Entity> Get(int id)
        {
            return await _repositoryBase.Get(id);
        }

        public virtual async Task<List<Entity>> Get()
        {
            return await _repositoryBase.Get();
        }

        public virtual async Task<Entity> Update(Entity entity)
        {
            return await _repositoryBase.Update(entity);
        }
    }
}