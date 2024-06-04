using Microsoft.AspNetCore.Mvc;
using BankApp.Models;

namespace BankApp.Controllers
{
    public class HomeController : Controller
    {
       [Route("/")]
        public IActionResult Index()
        {
            Response.StatusCode = 200;
            return Content("Welcome to my banl account");
        }
        [Route ("/account-details")]
        public JsonResult Details()
        {
            Detalle  detalle = new()
            {
                AccountNumber =1001,
                AccountHolderName= "diana",
                CurrentBalance = 5000,
                    
            };
            return Json(detalle);
        }
        [Route("account-statement")]
        public VirtualFileResult Statement()
        {
            return File("CV Diana Estela Alonso López.pdf", "application/pdf");

        }

        [Route ("get - current - balance")]
        public IActionResult Balance()
        {
            if (!Request.Query.ContainsKey("accountNumber"))
            {
                return NotFound("account number is not supplied"); 
            }
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["accountNumber"])))
            {
                return BadRequest("account cant´n be null or empty");
            }
            int accountNum = Convert.ToUInt16(ControllerContext.HttpContext.Request.Query["accountNumber"]);

            if( accountNum != 1001)
            {
                return BadRequest("Account Number should be 1001");
            }
            return Content(accountNum.ToString());
        }


    }
}
