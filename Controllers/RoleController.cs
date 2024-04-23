using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using web_app.Models;
using web_app.ViewModels;

namespace web_app.Controllers;

public class RoleController : Controller
{
	private readonly DbPosManagementContext _context;
	//private readonly IHttpContextAccessor _contextAccessor;
	private readonly ILogger<RoleController> _logger;

	public RoleController(DbPosManagementContext context, ILogger<RoleController> logger)
	{
		_context = context;
		//_contextAccessor = contextAccessor;
		_logger = logger;
	}

	public IActionResult Index()
	{
		try
		{
			List<TbMRole>? roles = new List<TbMRole>();
			List<RoleViewModel> rolesViewModel = new List<RoleViewModel>();
			roles = _context.TbMRoles.Where(data => data.Isdelete == false).ToList();

			foreach(var item in roles)
			{
				rolesViewModel.Add(new RoleViewModel
				{
					Guid = item.Guid,
					Name = item.Name,
				});
			}
			return View(rolesViewModel);

		}catch(Exception ex)
		{
			_logger.LogError(ex.ToString());
			return View();
		}
	}

	#region Create
	public IActionResult Create()
	{
		return View();
	}
	[HttpPost]
	public IActionResult SubmitCreate(RoleViewModel model)
	{
		try
		{
			using TransactionScope transactionScope = new TransactionScope();
			TbMRole role = new TbMRole
			{
				Guid = Guid.NewGuid(),
				Name = model.Name,
				Isdelete = false
			};
			_context.TbMRoles.Add(role);
            _context.SaveChanges();
            transactionScope.Complete();
			return RedirectToAction("Index");

		}catch(Exception ex)
		{
			ViewBag.ErrorMessage = "Failed to Create";
			_logger.LogError(ex.ToString());
			return RedirectToAction("Index");
		}
	}
	#endregion

	#region Edit
	public IActionResult Edit(Guid id)
	{
		try
		{
			TbMRole? role = _context.TbMRoles.Where(data => data.Guid == id).FirstOrDefault();
			RoleViewModel model = new RoleViewModel
			{
				Guid = role.Guid,
				Name = role.Name,
			};
			return View(model);

		}catch(Exception ex)
		{
			ViewBag.ErrorMessage = "Failed to Get Data";
			_logger.LogError(ex.ToString());
			return RedirectToAction("Index");
		}
	}
	[HttpPost]
	public IActionResult SubmitEdit(RoleViewModel model)
	{
		try
		{
			TbMRole? role = _context.TbMRoles.Where(data => data.Guid == model.Guid).FirstOrDefault();
			if(role != null)
			{
				using TransactionScope transactionScope = new TransactionScope();
				role.Name = model.Name;
				_context.Entry(role).State = EntityState.Modified;
                _context.SaveChanges();
                transactionScope.Complete();
			}
			else
			{
				ViewBag.ErrorMessage = "Theres no data";
			}
			return RedirectToAction("Index");
		}catch(Exception ex)
		{
			ViewBag.ErrorMessage = "Error on System";
			_logger.LogError(ex.ToString());
			return RedirectToAction("Index");
		}
	}
	#endregion

	#region View
	public IActionResult View(Guid id)
	{
		return View();
	}
	#endregion

	#region Delete
	public IActionResult Delete(Guid id)
	{
		try
		{
			TbMRole? role = _context.TbMRoles.Where(data => data.Guid == id).FirstOrDefault();
			if (role != null)
			{
				using TransactionScope transactionScope = new TransactionScope();
				role.Isdelete = true;
				_context.Entry(role).State = EntityState.Modified;
                _context.SaveChanges();
                transactionScope.Complete();
			}
			else
			{
				ViewBag.ErrorMessage = "Theres no data";
			}
			return RedirectToAction("Index");
		}
		catch (Exception ex)
		{
			ViewBag.ErrorMessage = "Error on System";
			_logger.LogError(ex.ToString());
			return RedirectToAction("Index");
		}
	}
	#endregion
}
