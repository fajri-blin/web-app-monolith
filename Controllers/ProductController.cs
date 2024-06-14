using Microsoft.AspNetCore.Mvc;
using web_app.Models;
using web_app.ViewModels;

namespace web_app.Controllers;

public class ProductController : Controller
{
    private readonly DbPosManagementContext _context;
    private readonly ILogger<ProductController> _logger;

    public ProductController(DbPosManagementContext context, ILogger<ProductController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    #region Create
    public IActionResult Create()
    {
        ProductViewModel model = new ProductViewModel();
        model.Units = _context.TbMUnits.ToList();

        return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SubmitCreate(ProductViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Units = _context.TbMUnits.ToList();
            return View("Create", model);
        }

        // Check if the unit exists
        var existingUnit = _context.TbMUnits.SingleOrDefault(u => u.Name.ToLower() == model.Unit!.Name.ToLower());

        if (existingUnit == null)
        {
            // Create a new unit
            var newUnit = new TbMUnit { Name = model.Unit!.Name };
            newUnit.Guid = Guid.NewGuid();
            _context.TbMUnits.Add(newUnit);
            _context.SaveChanges();
            existingUnit = newUnit;
        }

        // Use the existing or new unit's Id
        var product = new TbMProduct
        {
            Guid = Guid.NewGuid(),
            BarcodeId = model.BarcodeId,
            Title = model.Title,
            Isdelete = false,
            //UnitId = existingUnit.Id,
            //PriceAmount = decimal.Parse(model.PriceAmount) // Ensure this conversion works correctly
        };
        _context.TbMProducts.Add(product);
        _context.SaveChanges();

        // Add Prices based on Product and Unit ????

        return RedirectToAction("Index");
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
