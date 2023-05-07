using Microsoft.AspNetCore.Mvc;
using PizzaShop.Domain.Interfaces;
using Stripe;

namespace PizzaShop.WebUI.Controllers
{
    public class CheckoutController : BaseController
    {
        [TempData]
        public string TotalAmount { get; set; }
        private readonly IOrderService _orderService;

        public CheckoutController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var order = _orderService.GetAllOrders(UserId.ToString())
                .FirstOrDefault(x => !x.IsPaid);

            ViewBag.TotalAmount = order.TotalPrice;
            TotalAmount = order.TotalPrice.ToString();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Processing(string stripeToken, string stripeEmail)
        {
            var optionsCust = new CustomerCreateOptions
            {
                Email = stripeEmail,
                Name = "Test"
            };

            var serviceCust = new CustomerService();
            Customer customer = serviceCust.Create(optionsCust);
            var optionsCharge = new ChargeCreateOptions
            {
                Amount = Convert.ToInt32(TempData["TotalAmount"]),
                Source = stripeToken,
                Currency = "NZD",
                ReceiptEmail = stripeEmail,
                Description = "Selling Pizza",
            };


            var serviceCharge = new ChargeService();
            Charge charge = serviceCharge.Create(optionsCharge);
            if (charge.Status  == "succeeded")
            {
                var order = _orderService.GetAllOrders(UserId.ToString())
                    .FirstOrDefault(x => !x.IsPaid);

                await _orderService.PayOrder(order.Id, "Lviv");

                ViewBag.AmountPaid = Convert.ToDecimal(charge.Amount) % 100 / 100 + (charge.Amount) / 100;
                ViewBag.Customer = customer.Name;
                ViewBag.ShippingAddress = "Lviv";
            }

            return View();  
        }
    }
}
