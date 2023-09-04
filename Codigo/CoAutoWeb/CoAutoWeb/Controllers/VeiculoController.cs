using AutoMapper;
using CoAutoWeb.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace CoAutoWeb.Controllers
{
    public class VeiculoController : Controller
    {

        IVeiculoService _VeiculoService;
        IMapper mapper;

        // GET: VeiculoController
        public ActionResult Index()

        {
            //Nenhum veículo adicionado por isso esse trecho comentado.
            //var listaVeiculos = _VeiculoService.getAll();
            //var listaVeiculosModel = mapper.Map<List<VeiculoViewModel>>(listaVeiculos);
            return View();
        }

        // GET: VeiculoController/Details/5
        public ActionResult Details(int id)
        {
            var Veiculo = _VeiculoService.get(id);
            var VeiculoModel = mapper.Map<VeiculoViewModel>(Veiculo);
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
        public ActionResult Create(VeiculoViewModel veiculoViewModel)
        {
           if (ModelState.IsValid)
            {
                var veiculo = mapper.Map<Veiculo>(veiculoViewModel);
                _VeiculoService.create(veiculo);

            }
           return RedirectToAction(nameof(Index));
        }

        // GET: VeiculoController/Edit/5
        public ActionResult Edit(int id)
        {
            var veiculo = _VeiculoService.get(id);
            var veiculoModel = mapper.Map<VeiculoViewModel>(veiculo);
            return View(veiculoModel);
        }

        // POST: VeiculoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VeiculoViewModel veiculoModel)
        {
            if (ModelState.IsValid)
            {
               var veiculo = mapper.Map<Veiculo>(veiculoModel);
               _VeiculoService.edit(veiculo);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: VeiculoController/Delete/5
        public ActionResult Delete(int id)
        {
            var veiculo = _VeiculoService.get(id);
            var veiculoModel = mapper.Map<VeiculoViewModel>(veiculo);
            return View(veiculoModel);
        }

        // POST: VeiculoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, VeiculoViewModel veiculoViewModel)
        {
            var veiculo = mapper.Map<Veiculo>(veiculoViewModel);
            _VeiculoService.delete(veiculo);
            return RedirectToAction(nameof(Index));
        }
    }
}
