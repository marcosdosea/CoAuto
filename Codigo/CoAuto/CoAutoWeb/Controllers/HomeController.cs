using AutoMapper;
using CoAutoWeb.Models;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoAutoWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IVeiculoService _veiculoService;
    private readonly IMapper _mapper;

    public HomeController(ILogger<HomeController> logger, IVeiculoService veiculoService, IMapper mapper)
    {
        _logger = logger;
        _veiculoService = veiculoService;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var veiculos = _veiculoService.GetAllSimpleVeiculos();

        var veiculosView = _mapper.Map<List<VeiculoListagemViewModel>>(veiculos);
        return View(veiculosView);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}