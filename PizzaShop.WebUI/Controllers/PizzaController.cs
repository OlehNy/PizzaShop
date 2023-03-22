using Microsoft.AspNetCore.Mvc;
using PizzaShop.Domain.Interfaces;
using PizzaShop.WebUI.Models;
using AutoMapper;

namespace PizzaShop.WebUI.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService _service;
        private readonly IMapper _mapper;

        public PizzaController(IPizzaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var pizzas = _service.GetPizzas();
            var models = pizzas.Select(pizza => _mapper.Map<PizzaViewModel>(pizza));
            return View(models);
        }

        public IActionResult Details(int id)
        {
            var pizza = _service.GetPizzas().FirstOrDefault(x => x.Id == id);
            var model = _mapper.Map<PizzaViewModel>(pizza);
            return View(model);
        }
    }
}
