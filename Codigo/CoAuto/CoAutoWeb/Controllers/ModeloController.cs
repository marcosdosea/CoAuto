using AutoMapper;
using CoAutoWeb.Models;
using Core.Service;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoAutoWeb.Controllers
{
    public class ModeloController : Controller
    {
        private readonly IModeloService _modeloService;
        private readonly IMarcaService _marcaService;
        private readonly IMapper _mapper;
        public ModeloController(IModeloService modeloService, IMarcaService marcaService, IMapper mapper)
        {
            _modeloService = modeloService;
            _marcaService = marcaService;
            _mapper = mapper;
        }

        [HttpGet]
        /// <summary>
        /// Retorna todos os modelos da ViewModel
        /// </summary>
        /// <returns>View(modelos)</returns>
        public async Task<ActionResult> Index()
        {
            var modelos = await _modeloService.GetAll();

            if (modelos == null) return BadRequest();

            var marcas = await _marcaService.GetAll();
            var modeloModel = modelos.Select(modelo => new ModeloViewModel
            {
                Id = modelo.Id,
                IdMarca = modelo.IdMarca,
                Nome = modelo.Nome
            }).ToList();

            return View(modeloModel);
        }

        // GET: ModeloController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(uint id)
        {
            var modelo = await _modeloService.Get(id);

            if (modelo == null) return BadRequest();

            var marcas = await _marcaService.GetAll();
            var modeloModel = new ModeloViewModel
            {
                Id = modelo.Id,
                IdMarca = modelo.IdMarca,
                Nome = modelo.Nome
            };

            return View(modeloModel);
        }

        // GET: ModeloController/Create
        public async Task<ActionResult> Create()
        {
            var marcas = await _marcaService.GetAll();
            var items = marcas.Select(marca => new SelectListItem { Value = marca.Id.ToString(), Text = marca.Nome }).ToList();
            var selectList = new SelectList(items, "Value", "Text");
            ViewBag.MarcasSelectList = selectList;
            return View();
        }

        // POST: ModeloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ModeloViewModel modeloModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var modelo = _mapper.Map<Modelo>(modeloModel);
                    await _modeloService.Create(modelo);
                }
                catch
                {
                    return View(modeloModel);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(modeloModel);

        }

        // GET: ModeloController/Edit/5
        public async Task<ActionResult> Edit(uint id)
        {
            var modelo = await _modeloService.Get(id);

            var modeloModel = _mapper.Map<ModeloViewModel>(modelo);

            var marcas = await _marcaService.GetAll();
            var items = marcas.Select(marca => new SelectListItem { Value = marca.Id.ToString(), Text = marca.Nome }).ToList();
            var selectList = new SelectList(items, "Value", "Text");
            ViewBag.MarcasSelectList = selectList;

            return View(modeloModel);
        }

        // POST: ModeloController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(uint id, ModeloViewModel modeloModel)
        {
            if (id != modeloModel.Id) return NotFound();


            if (ModelState.IsValid)
            {
                try
                {
                    var modelo = _mapper.Map<Modelo>(modeloModel);
                    await _modeloService.Edit(modelo);
                }
                catch
                {
                    return BadRequest();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(modeloModel);

        }

        // GET: ModeloController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(uint? id)
        {
            if (id == null) return BadRequest();

            var modelo = await _modeloService.Get((uint)id);

            if (modelo == null) return NotFound();

            var marcas = await _marcaService.GetAll();
            var modeloModel = new ModeloViewModel
            {
                Id = modelo.Id,
                IdMarca = modelo.IdMarca,
                Nome = modelo.Nome
            };

            return View(modeloModel);
        }

        // POST: ModeloController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(uint id)
        {
            await _modeloService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
