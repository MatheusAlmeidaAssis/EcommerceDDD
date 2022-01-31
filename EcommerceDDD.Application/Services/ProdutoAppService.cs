using EcommerceDDD.Application.Core.Models;
using EcommerceDDD.Application.Interfaces;
using EcommerceDDD.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceDDD.Application.Services
{
    public class ProdutoAppService : AppServiceBase<ProdutoModel>, IProdutoAppService
    {
        private readonly IProdutoService produtoService;

        public ProdutoAppService(IProdutoService produtoService)
        {
            this.produtoService = produtoService;
        }

        public override async Task<ProdutoModel> Add(ProdutoModel model)
        {
            bool validaDescricao = model.Valida(model.Descricao);
            bool validaValor = model.Valida(model.Valor);

            if (validaDescricao && validaValor)
            {
                model.Estado = true;
                return new ProdutoModel(await produtoService.Add(model.ToEntity()));
            }
            return null;
        }

        public override async Task<ProdutoModel> Delete(int id)
        {
            return new ProdutoModel(await produtoService.Delete(id));
        }

        public override ProdutoModel Get(int id)
        {
            return new ProdutoModel(produtoService.Get(id));
        }

        public override IEnumerable<ProdutoModel> Get()
        {
            return produtoService.Get().Select(p => new ProdutoModel(p));
        }

        public override async Task<ProdutoModel> Update(ProdutoModel model)
        {
            bool validaDescricao = model.Valida(model.Descricao);
            bool validaValor = model.Valida(model.Valor);

            if (validaDescricao && validaValor)
                return new ProdutoModel(await produtoService.Update(model.ToEntity()));
            return null;
        }
    }
}