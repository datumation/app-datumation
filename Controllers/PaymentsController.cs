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

      public class ChargeModel
      {
        public string token {get;set;}
        public string email {get;set;}
        public string user {get;set;}
        public long amount {get;set;}
        public string product {get;set;}
        public string description {get;set;}
        
        // form has button for one time download
        // and another to subscribee
        // public bool? subscription {get;set;}
        
      }
      public class ChargeResponseModel
      {
        public string Message {get;set;}
      }

        // from paymentform
        [HttpPost]
        [Route("Charge")]
        public IActionResult Charge([FromBody] ChargeModel chargeModel)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = chargeModel.email,
                SourceToken = chargeModel.token
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = chargeModel.amount,

                Description = chargeModel.description,
                Currency = "usd",
                CustomerId = customer.Id
            });

            // insert into table user subscriptions
            // userid 
            // stateName
            // subscriptionEndOn

            return View();
        }
    }
}