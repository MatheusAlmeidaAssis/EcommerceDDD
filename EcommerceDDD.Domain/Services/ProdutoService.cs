using EcommerceDDD.Domain.Core.Entities;
using EcommerceDDD.Domain.Interfaces.Repositories;
using EcommerceDDD.Domain.Interfaces.Services;

namespace EcommerceDDD.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        public ProdutoService(IRepositoryBase<Produto> repositoryBase) : base(repositoryBase)
        {
        }
    }
}