using Microsoft.AspNetCore.Mvc;
using web_app.ViewModels;

namespace web_app.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult SubmitCreate(ProductViewModel model)
        {
            
            return View();
        }
        #endregion

        #region Edit
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult SubmitEdit()
        {
            return View();
        }
        #endregion

        #region Delete
        public IActionResult Delete()
        {
            return View();
        }
        #endregion
    }
}
