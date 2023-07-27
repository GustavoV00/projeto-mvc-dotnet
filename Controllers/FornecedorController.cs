using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using MvcMovie.Services;
using MvcMovie.Services.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcMovie.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedorService _fornecedorService;
        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        public async Task<IActionResult> Index()
        {
            var fornecedors = await _fornecedorService.GetAllFornecedorsAsync();
            return View(fornecedors);
        }

        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _fornecedorService.GetFornecedorByIdAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Estado,Cidade,Contato,Endereco")] Fornecedor client)
        {
            if (ModelState.IsValid)
            {
                await _fornecedorService.AddNewFornecedorAsync(client);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _fornecedorService.FindIdAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Estado,Cidade,Contato,Endereco")] Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _fornecedorService.UpdateFornecedorAsync(fornecedor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var fornecedor_test = _fornecedorService.GetFornecedorByIdAsync(fornecedor.Id);
                    if (fornecedor_test == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fornecedor = await _fornecedorService.GetFornecedorByIdAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fornecedor = await _fornecedorService.FindIdAsync(id);
            if (fornecedor != null)
            {
                await _fornecedorService.DeleteFornecedorAsync(fornecedor);

            }

            return RedirectToAction(nameof(Index));
        }

    }
}