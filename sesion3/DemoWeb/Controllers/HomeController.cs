using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoWeb.Models;

namespace DemoWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITodoService _todoService;

    public HomeController(ILogger<HomeController> logger, ITodoService todosvc)
    {
        _logger = logger;
        _todoService = todosvc;
    }

    public async Task<IActionResult> Index()
    {
        _logger.LogInformation("Index!!!");
        var tasks = await _todoService.GetPendingTodos();
        return View(tasks);
    }

    public async Task<IActionResult> MarkDone(int id) {
        await _todoService.MarkAsDone(id);
        return RedirectToAction("Index");
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
