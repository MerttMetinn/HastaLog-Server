using Microsoft.AspNetCore.Mvc;

namespace PatientLog.Controllers
{
    public class AppointmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
