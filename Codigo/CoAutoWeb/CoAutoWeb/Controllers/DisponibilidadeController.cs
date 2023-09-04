using AutoMapper;
using CoAutoWeb.Models;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace CoAutoWeb.Controllers
{
    public class DisponibilidadeController : Controller
    {

        private readonly IDisponibilidadeService _disponibilidadeService;
        private readonly IMapper _mapper;



        public DisponibilidadeController(IDisponibilidadeService disponibilidadeService, IMapper mapper)
        {
            _disponibilidadeService = disponibilidadeService;
            _mapper = mapper;
        }





        // GET: DisponibilidadeController
        public ActionResult Index()
        {
            var listaDisponibilidades = _disponibilidadeService.GetAll();
            var listaDisponibilidadeModel = _mapper.Map<List<DisponibilidadeModel>>(listaDisponibilidades);
            return View(listaDisponibilidadeModel);
        }

        // GET: DisponibilidadeController/Details/5
        public ActionResult Details(int id)
        {
            var disponibilidade = _disponibilidadeService.GetAll();
            var disponibilidadeViewModel = _mapper.Map<List<disponibilidadeViewModel>>(disponibilidade);
            return View(disponibilidadeViewModel);
        }

        // GET: DisponibilidadeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DisponibilidadeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DisponibilidadeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DisponibilidadeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DisponibilidadeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DisponibilidadeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
