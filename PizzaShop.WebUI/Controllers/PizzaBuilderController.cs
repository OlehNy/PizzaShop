using Microsoft.AspNetCore.Mvc;
using PizzaShop.Domain.Interfaces;
using PizzaShop.Domain.Entities;

namespace PizzaShop.WebUI.Controllers
{
    public class PizzaBuilderController : BaseController
    {
        private readonly IOrderService _orderService;
        private readonly IPizzaService _pizzaService;
        private readonly IIngredientService _ingredientService;

        public PizzaBuilderController(IOrderService orderService,
            IIngredientService ingredientService,
			IPizzaService pizzaService)
		{
			_orderService = orderService;
			_ingredientService = ingredientService;
			_pizzaService = pizzaService;
		}

		public IActionResult Index()
        {
            var ingredients = _ingredientService.GetIngredients().ToList();

            ViewBag.Ingredients = ingredients;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Build(string[] ingredientsNames, int quantity, decimal totalCost)
        {
            var ingredients = _ingredientService.GetIngredientsByNames(ingredientsNames.ToList());
            var customPizza = new CustomPizza()
            {
                Price = totalCost,
            };

            await _pizzaService.AddIngredientToPizza(customPizza, ingredients);
            await _orderService.AddOrderItemAsync(UserId.ToString(), customPizza, quantity);

            return RedirectToAction(nameof(Index), "Order");
        }
    }
}
