using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GoogleSSOTrial.Controllers
{
    [RequireHttps]
    public class GoogleAuthController : Controller
    {

        private readonly ILogger<GoogleAuthController> _logger;

        public GoogleAuthController(ILogger<GoogleAuthController> logger)
        {
            this._logger = logger;
        }


        [HttpPost]
        public IActionResult SignInToken([FromBody] PostModel postModel)
        {
            GoogleJsonWebSignature.Payload payload = GoogleJsonWebSignature.ValidateAsync(postModel.SignInToken).GetAwaiter().GetResult();

            return Json(payload);
        }
    }


    public class PostModel
    {
        public string SignInToken { get; set; }
    }

}
