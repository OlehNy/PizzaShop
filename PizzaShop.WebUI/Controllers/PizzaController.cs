using Microsoft.AspNetCore.Mvc;
using PizzaShop.Domain.Interfaces;
using PizzaShop.Domain.Enum;
using AutoMapper;
using PizzaShop.WebUI.Models.PizzaModels;

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

        public IActionResult Index([FromQuery] Category? category)
        {
            if (category != null)
			{
                var filterdPizzas = _service.GetPizzasByCategory(category)
                    .Select(pizza => _mapper.Map<PizzaViewModel>(pizza));
                
                return PartialView("_PizzaList", filterdPizzas);
            }

            var pizzas = _service.GetPizzas();
            var models = pizzas.Select(pizza => _mapper.Map<PizzaViewModel>(pizza));
            return View(models);
        }

        public async Task<IActionResult> Details(int id)
        {
            var pizza = await _service.GetPizzaByIdAsync(id);
            var model = _mapper.Map<PizzaViewModel>(pizza);
            return View(model);
        }
    }
}
