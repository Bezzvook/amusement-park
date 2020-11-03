using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmusementPark.Controllers
{
    [Authorize]
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
