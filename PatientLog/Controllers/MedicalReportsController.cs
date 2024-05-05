using Microsoft.AspNetCore.Mvc;

namespace PatientLog.Controllers
{
    public class MedicalReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
