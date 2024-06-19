﻿using Microsoft.AspNetCore.Mvc;
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
        ProductViewModel model = new ProductViewModel
        {
            Units = _context.TbMUnits.ToList()
        };
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

        try
        {
            TbMUnit? newUnit = null;
            TbMProduct? newProduct = null;

            // Check if the unit exists
            var existingUnit = _context.TbMUnits.SingleOrDefault(u => u.Name.ToUpper() == model.UnitName!.ToUpper());
            if (existingUnit == null)
            {
                // Create a new unit
                newUnit = new TbMUnit
                {
                    Name = model.UnitName!.ToUpper(),
                    Guid = Guid.NewGuid(),
                    Isdelete = false
                };
                _context.TbMUnits.Add(newUnit);
                _context.SaveChanges();
            }

            // Check if the product exists
            var existingProduct = _context.TbMProducts.SingleOrDefault(p => p.BarcodeId.ToLower() == model.BarcodeId.ToLower());
            if (existingProduct == null)
            {
                newProduct = new TbMProduct
                {
                    Title = model.Title,
                    BarcodeId = model.BarcodeId,
                    Guid = Guid.NewGuid(),
                    Isdelete = false
                };
                _context.TbMProducts.Add(newProduct);
                _context.SaveChanges();
            }

            // Add Prices based on Product and Unit
            TbTrPrice price = new TbTrPrice
            {
                Guid = Guid.NewGuid(),
                Isdelete = false,
                ProductGuid = existingProduct?.Guid ?? newProduct?.Guid,
                UnitGuid = existingUnit?.Guid ?? newUnit?.Guid,
                Amount = (decimal)model.Price!
            };

            _context.TbTrPrices.Add(price);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        catch
        {
            // Log the error (not implemented)
            return RedirectToAction("Index");
        }
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
