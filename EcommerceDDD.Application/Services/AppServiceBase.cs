using EcommerceDDD.Application.Core.Models;
using EcommerceDDD.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceDDD.Application.Services
{
    public abstract class AppServiceBase<Model> : IAppServiceBase<Model> where Model : ModelBase
    {
        public abstract Task<Model> Add(Model model);

        public abstract Task<Model> Delete(int id);

        public abstract Model Get(int id);

        public abstract IEnumerable<Model> Get();

        public abstract Task<Model> Update(Model model);
    }
}