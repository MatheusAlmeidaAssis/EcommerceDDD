using EcommerceDDD.Domain.Core.Entities;
using EcommerceDDD.Domain.Interfaces.Repositories;
using EcommerceDDD.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace EcommerceDDD.Domain.Services
{
    public class ServiceProduto : ServiceBase<Produto>, IProdutoService
    {
        public ServiceProduto(IRepositoryBase<Produto> repositoryBase) : base(repositoryBase)
        {
        }

        public override async Task<Produto> Add(Produto entity)
        {
            bool validaDescricao = entity.Valida(entity.Nome);
            bool validaValor = entity.Valida(entity.Valor);

            if (validaDescricao && validaValor)
            {
                entity.Estado = true;
                return await base.Add(entity);
            }
            return null;
        }

        public override async Task<Produto> Update(Produto entity)
        {
            bool validaDescricao = entity.Valida(entity.Nome);
            bool validaValor = entity.Valida(entity.Valor);

            if (validaDescricao && validaValor)
            {
                entity.Estado = true;
                return await base.Update(entity);
            }
            return null;
        }
    }
}