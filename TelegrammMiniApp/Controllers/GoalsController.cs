using Microsoft.AspNetCore.Mvc;

namespace TelegrammMiniApp.Controllers
{
    public class GoalsController : Controller
    {
        public IActionResult Index() {
            return View();
        }     // показать все цели
    public IActionResult Details(int id)
        {
            return View();
        }// показать одну
    public IActionResult Create()    {     return View();
        }     // форма создания
    public IActionResult Delete(int id)
        {
            return View();
        }    // удалить
    }
}
