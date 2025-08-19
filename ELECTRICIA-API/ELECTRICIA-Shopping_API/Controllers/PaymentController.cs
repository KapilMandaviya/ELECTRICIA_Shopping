using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
namespace ELECTRICIA_Shopping_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpPost("create-payment-intent")]
        public async Task<IActionResult> CreatePaymentIntent([FromBody] PaymentRequest request)
        {
             StripeConfiguration.ApiKey = "sk_test_51RqVynRoUqNHT9fckr1TorvVIArBXyq9NqXpBf31ya2jLpLjQj9XKM2JJS6XdKn2bsdOBIPnRqoLoJIdzc0ZBvjP00y0sM2oR8"; // your secret key

            var options = new PaymentIntentCreateOptions
            {
                //Amount = request.Amount * 100, // e.g. 5000 = $50.00
                Amount = request.Amount,
                Currency = "inr", // 👈 use INR for UPI
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true,
                },
            };

            var service = new PaymentIntentService();
            var intent = await service.CreateAsync(options);

            return Ok(new { clientSecret = intent.ClientSecret });
        }

        [HttpPost("create-checkout-session")]
        public ActionResult CreateCheckoutSession([FromBody] CreateCheckoutRequest request)
        {
            var options = new Stripe.Checkout.SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card","upi" },
                Mode = "payment",
                SuccessUrl = "http://localhost:4200/success",
                CancelUrl = "http://localhost:4200/cancel",
                LineItems = new List<Stripe.Checkout.SessionLineItemOptions>
        {
            new Stripe.Checkout.SessionLineItemOptions
            {
                PriceData = new Stripe.Checkout.SessionLineItemPriceDataOptions
                {
                    UnitAmount = (long)(request.Amount * 100),
                    Currency = "usd",
                    ProductData = new Stripe.Checkout.SessionLineItemPriceDataProductDataOptions
                    {
                        Name = "Test Product"
                    }
                },
                Quantity = 1
            }
        }
            };
            var service = new Stripe.Checkout.SessionService();
            var session = service.Create(options);

            return Ok(new { sessionId = session.Id });
        }

        public class CreateCheckoutRequest
        {
            public decimal Amount { get; set; }
        }

    }
}

public class PaymentRequest
{
    public long     Amount { get; set; }
}



