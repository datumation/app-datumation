using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace Datumation.Controllers
{
    [Route("api/[controller]")]
    public class ManageController: Controller
    {

            [Route("Register")]
            [AllowAnonymous]
           [HttpPost]
        public async Task<ResultVM> Register ([FromBody] RegisterVM model) {
            if (ModelState.IsValid) {
                IdentityResult result = null;
                var user = await _userManager.FindByNameAsync (model.UserName);

                if (user != null) {
                    return new ResultVM {
                    Status = Status.Error,
                    Message = "Invalid data",
                    Data = "<li>User already exists</li>"
                    };
                }

                user = new IdentityUser {
                    Id = Guid.NewGuid ().ToString (),
                    UserName = model.UserName,
                    Email = model.Email
                };

                result = await _userManager.CreateAsync (user, model.Password);

                if (result.Succeeded) {
                    if (model.StartFreeTrial) {
                        Claim trialClaim = new Claim ("Trial", DateTime.Now.ToString ());
                        await _userManager.AddClaimAsync (user, trialClaim);
                    } else if (model.IsAdmin) {
                        await _userManager.AddToRoleAsync (user, "Admin");
                    }

                    return new ResultVM {
                        Status = Status.Success,
                            Message = "User Created",
                            Data = user
                    };
                } else {
                    var resultErrors = result.Errors.Select (e => "<li>" + e.Description + "</li>");
                    return new ResultVM {
                        Status = Status.Error,
                            Message = "Invalid data",
                            Data = string.Join ("", resultErrors)
                    };
                }
            }

            var errors = ModelState.Keys.Select (e => "<li>" + e + "</li>");
            return new ResultVM {
                Status = Status.Error,
                    Message = "Invalid data",
                    Data = string.Join ("", errors)
            };
        }
    }
}