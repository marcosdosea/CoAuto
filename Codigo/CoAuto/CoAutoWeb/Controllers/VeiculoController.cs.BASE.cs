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
        private readonly IVeiculoService _veiculoService;
        private readonly IMapper _mapper;

        public VeiculoController(IVeiculoService veiculoService, IMapper mapper)
        {
            _veiculoService = veiculoService;
            _mapper = mapper;
        }

        // GET: VeiculoController
        public ActionResult Index()
        {
            var listaVeiculo = _veiculoService.GetAll();
            var listaVeiculoModel = _mapper.Map<List<VeiculoViewModel>>(listaVeiculo);
            return View(listaVeiculoModel);
        }

        // GET: VeiculoController/Details/5
        public ActionResult Details(int id)
        {
            var veiculo = _veiculoService.Get(id);
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
                var veiculo = _mapper.Map<Veiculo>(VeiculoModel);
                _veiculoService.Create(veiculo);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: VeiculoController/Edit/5
        public ActionResult Edit(int id)
        {
            Veiculo veiculo = _veiculoService.Get(id);
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
                var veiculo = _mapper.Map<Veiculo>(VeiculoModel);
                _veiculoService.Edit(veiculo);
            }
            return RedirectToAction(nameof(Index));
        }

    // GET: VeiculoController/Delete/5
    public ActionResult Delete(int id)
        {
            Veiculo veiculo = _veiculoService.Get(id);
            VeiculoViewModel VeiculoModel = _mapper.Map<VeiculoViewModel>(veiculo);
            return View(VeiculoModel);
        }

        // POST: VeiculoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection colletion)
        {
            _veiculoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
