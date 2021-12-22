using EcommerceDDD.Domain.Core.Entities;
using EcommerceDDD.Domain.Interfaces.Repositories;
using EcommerceDDD.Infrastructure.Data;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace EcommerceDDD.Infrastructure.Repositories
{
    public class RepositoryBase<Entity> : IRepositoryBase<Entity>, IDisposable where Entity : EntityBase
    {
        private IEnumerable<Entity> Entities => _contextBase.Set<Entity>()
                    .Where(p => !p.DataExclusao.HasValue)
                    .ToList();

        private bool _disposed = false;
        private readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private readonly ContextBase _contextBase;

        public RepositoryBase(ContextBase contextBase)
        {
            _contextBase = contextBase;
        }

        public async Task<Entity> Add(Entity entity)
        {
            try
            {
                await _contextBase.Set<Entity>().AddAsync(entity);
                await _contextBase.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Entity> Delete(int id)
        {
            try
            {
                Entity entity = Get(id);
                entity.DataExclusao = DateTime.Now;
                _contextBase.Set<Entity>().Update(entity);
                await _contextBase.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool diposing)
        {
            if (_disposed)
            {
                return;
            }

            if (diposing)
            {
                handle.Dispose();
            }

            _disposed = true;
        }

        public Entity Get(int id)
        {
            return _contextBase.Set<Entity>().FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Entity> Get()
        {
            return Entities;
        }

        public async Task<Entity> Update(Entity entity)
        {
            try
            {
                _contextBase.Set<Entity>().Update(entity);
                await _contextBase.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}