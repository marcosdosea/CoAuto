using AutoMapper;
using CoAutoWeb.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Service;

namespace CoAutoWeb.Controllers
{
    public class VeiculoController : Controller
    {
        IVeiculoService _VeiculoService;
        IMapper _mapper;

        // GET: VeiculoController
        public ActionResult Index()

        {
            var listaVeiculos = _VeiculoService.getAll();
            var listaVeiculosModel = _mapper.Map<List<VeiculoViewModel>>(listaVeiculos);
            return View(listaVeiculos);
        }

        // GET: VeiculoController/Details/5
        public ActionResult Details(int id)
        {
            var veiculo = _VeiculoService.get(id);
            var VeiculoModel = _mapper.Map<VeiculoViewModel>(veiculo);
            return View(VeiculoModel);
        }

        // GET: VeiculoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VeiculoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VeiculoViewModel VeiculoModel)
        {
            if (ModelState.IsValid)
            {
                var Veiculo = _mapper.Map<Veiculo>(VeiculoModel);
                _VeiculoService.create(Veiculo);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: VeiculoController/Edit/5
        public ActionResult Edit(int id)
        {
            Veiculo veiculo = _VeiculoService.get(id);
            VeiculoViewModel VeiculoModel = _mapper.Map<VeiculoViewModel>(veiculo);
            return View(VeiculoModel);
        }

        // POST: VeiculoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VeiculoViewModel VeiculoModel)
        {
            if (ModelState.IsValid)
            {
                var Veiculo = _mapper.Map<Veiculo>(VeiculoModel);
                _VeiculoService.edit(Veiculo);
            }
            return RedirectToAction(nameof(Index));
        }

    // GET: VeiculoController/Delete/5
    public ActionResult Delete(int id)
        {
            Veiculo veiculo = _VeiculoService.get(id);
            VeiculoViewModel VeiculoModel = _mapper.Map<VeiculoViewModel>(veiculo);
            return View(VeiculoModel);
        }

        // POST: VeiculoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, VeiculoViewModel VeiculoModel)
        {
            _VeiculoService.delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
