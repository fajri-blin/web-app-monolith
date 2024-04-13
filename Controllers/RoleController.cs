using Microsoft.AspNetCore.Mvc;

namespace web_app.Controllers;

public class RoleController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
