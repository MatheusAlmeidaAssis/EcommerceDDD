using EcommerceDDD.Application.Core.Models;
using EcommerceDDD.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceDDD.Presentation.Web.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly IProdutoAppService produtoService;

        public ProdutosController(IProdutoAppService produtoService)
        {
            this.produtoService = produtoService;
        }

        // GET: ProdutosController
        public IActionResult Index()
        {
            return View(produtoService.Get());
        }

        // GET: ProdutosController/Details/5
        public IActionResult Detalhes(int id)
        {
            return View(produtoService.Get(id));
        }

        // GET: ProdutosController/Create
        public ActionResult Adcionar()
        {
            return View();
        }

        // POST: ProdutosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adcionar(ProdutoModel produto)
        {
            try
            {
                await produtoService.Add(produto);
                if (produto.Errors.Any())
                {
                    foreach (var error in produto.Errors)
                    {
                        ModelState.AddModelError(error.NomeCampo, error.Mensagem);
                    }
                    return View(produto);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosController/Edit/5
        public IActionResult Editar(int id)
        {
            return View(produtoService.Get(id));
        }

        // POST: ProdutosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(ProdutoModel produto)
        {
            try
            {
                await produtoService.Update(produto);
                if (produto.Errors.Any())
                {
                    foreach (var error in produto.Errors)
                    {
                        ModelState.AddModelError(error.NomeCampo, error.Mensagem);
                    }
                    return View(produto);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosController/Delete/5
        public IActionResult Excluir(int id)
        {
            return View(produtoService.Get(id));
        }

        // POST: ProdutosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(ProdutoModel produto)
        {
            try
            {
                await produtoService.Delete(produto.Id);
                if (produto.Errors.Any())
                {
                    foreach (var error in produto.Errors)
                    {
                        ModelState.AddModelError(error.NomeCampo, error.Mensagem);
                    }
                    return View(produto);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}