using AutoMapper;
using CoAutoWeb.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoAutoWeb.Controllers
{
    public class AluguelController : Controller
    {
        private readonly IAluguelService _aluguelService;
        private readonly IMapper _mapper;

        public AluguelController(IAluguelService aluguelService, IMapper mapper)
        {
            _aluguelService = aluguelService;
            _mapper = mapper;
        }

        // GET: AluguelController
        public ActionResult Index()
        {
            var listaAluguel = _aluguelService.GetAll();
            var listaAluguelModel = _mapper.Map<List<AluguelViewModel>>(listaAluguel);
            return View(listaAluguelModel);
        }

        // GET: AluguelController/Details/5
        public ActionResult Details(int id)
        {
            var aluguel = _aluguelService.Get(id);
            var AluguelModel = _mapper.Map<AluguelViewModel>(aluguel);
            return View(AluguelModel);
        }

        // GET: AluguelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AluguelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AluguelViewModel AluguelModel)
        {
            if (ModelState.IsValid)
            {
                var aluguel = _mapper.Map<Aluguel>(AluguelModel);
                _aluguelService.Create(aluguel);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AluguelController/Edit/5
        public ActionResult Edit(int id)
        {
            Aluguel aluguel = _aluguelService.Get(id);
            AluguelViewModel AluguelModel = _mapper.Map<AluguelViewModel>(aluguel);
            return View(AluguelModel);
        }

        // POST: AluguelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AluguelViewModel AluguelModel)
        {
            if (ModelState.IsValid)
            {
                var aluguel = _mapper.Map<Aluguel>(AluguelModel);
                _aluguelService.Edit(aluguel);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AluguelController/Delete/5
        public ActionResult Delete(int id)
        {
            Aluguel aluguel = _aluguelService.Get(id);
            AluguelViewModel AluguelModel = _mapper.Map<AluguelViewModel>(aluguel);
            return View(AluguelModel);
        }

        // POST: AluguelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection colletion)
        {
            _aluguelService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
