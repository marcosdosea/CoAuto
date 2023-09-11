using AutoMapper;
using CoAutoWeb.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoAutoWeb.Controllers
{
    public class DevolucaoController : Controller
    {
        private readonly IDevolucaoService _devolucaoService;
        private readonly IMapper _mapper;
        public DevolucaoController(IDevolucaoService devolucaoService, IMapper mapper)
        {
            _devolucaoService = devolucaoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todas as devoluções da ViewModel
        /// </summary>
        /// <returns>View(devoluções)</returns>
        public async Task<ActionResult> Index()
        {
            var devolucaos = await _devolucaoService.GetAll();

            if (devolucaos == null) return BadRequest();

            var devolucaoModel = _mapper.Map<List<DevolucaoViewModel>>(devolucaos);

            return View(devolucaoModel);
        }

        // GET: DevolucaoController/Details/5
        public async Task<ActionResult> Details(uint? id)
        {
            var devolucao = await _devolucaoService.Get((uint)id);

            if (devolucao == null) return BadRequest();

            var devolucaoModel = _mapper.Map<DevolucaoViewModel>(devolucao);

            return View(devolucaoModel);
        }

        // GET: DevolucaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DevolucaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DevolucaoViewModel devolucaoModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var devolucao = _mapper.Map<Devolucao>(devolucaoModel);
                    await _devolucaoService.Create(devolucao);
                }
                catch
                {
                    return View(devolucaoModel);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(devolucaoModel);
        }

        // GET: DevolucaoController/Edit/5
        public async Task<ActionResult> Edit(uint id)
        {
            var devolucao = await _devolucaoService.Get(id);

            var devolucaoModel = _mapper.Map<DevolucaoViewModel>(devolucao);

            return View(devolucaoModel);
        }

        // POST: DevolucaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(uint id, DevolucaoViewModel devolucaoModel)
        {
            if (id != devolucaoModel.Id) return NotFound();


            if (ModelState.IsValid)
            {
                try
                {
                    var devolucao = _mapper.Map<Devolucao>(devolucaoModel);
                    await _devolucaoService.Edit(devolucao);
                }
                catch
                {
                    return BadRequest();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(devolucaoModel);

        }

        // GET: DevolucaoController/Delete/5
        public async Task<ActionResult> Delete(uint? id)
        {
            if (id == null) return BadRequest();

            var devolucao = await _devolucaoService.Get((uint)id);

            if (devolucao == null) return NotFound();

            var devolucaoModel = _mapper.Map<DevolucaoViewModel>(devolucao);

            return View(devolucaoModel);
        }

        // POST: DevolucaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(uint id)
        {
            await _devolucaoService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
