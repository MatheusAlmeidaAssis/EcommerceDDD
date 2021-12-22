using EcommerceDDD.Domain.Core.Entities;
using EcommerceDDD.Domain.Interfaces.Repositories;
using EcommerceDDD.Infrastructure.Data;

namespace EcommerceDDD.Infrastructure.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ContextBase contextBase) : base(contextBase)
        {
        }
    }
}