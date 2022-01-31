using EcommerceDDD.Application.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceDDD.Application.Interfaces
{
    public interface IAppServiceBase<Model> where Model : ModelBase
    {
        public Task<Model> Add(Model model);

        public Task<Model> Update(Model model);

        public Task<Model> Delete(int id);

        public Model Get(int id);

        public IEnumerable<Model> Get();
    }
}