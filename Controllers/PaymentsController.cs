using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace Datumation.Controllers
{
    
 

    [Route("api/[controller]")]
    public class PaymentsController : Controller
    {

        // from paymentform
                [HttpPost]
        [Route("Charge")]
        public IActionResult Charge(string  stripeEmail, string stripeToken)
{
    var customers = new CustomerService();
    var charges = new ChargeService();

    var customer = customers.Create(new CustomerCreateOptions {
      Email = stripeEmail,
      SourceToken = stripeToken
    });

    var charge = charges.Create(new ChargeCreateOptions {
      Amount = 500,

      Description = "Sample Charge",
      Currency = "usd",
      CustomerId = customer.Id
    });

// insert into table user subscriptions
// userid 
// stateName
// subscriptionEndOn

    return View();
}}
}