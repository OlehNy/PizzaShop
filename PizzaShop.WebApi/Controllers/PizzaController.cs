using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaShop.Domain.Interfaces;
using PizzaShop.Domain.Entities;

namespace PizzaShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        /// <summary>
        /// Gets the list of pizzas
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /expanse
        /// </remarks>
        /// <returns>Returns Pizza</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Pizza>> GetAll()
            => Ok(_pizzaService.GetPizzas());


    }
}
