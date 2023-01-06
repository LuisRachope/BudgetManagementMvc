using BudgetManagementMvc.Models;
using BudgetManagementMvc.Models.ViewModels;
using BudgetManagementMvc.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManagementMvc.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ExpenseServices _expenseServices;

        public ExpensesController(ExpenseServices expenseServices)
        {
            _expenseServices = expenseServices;
        }


        public async Task<IActionResult> Index()
        {
            var obj = await _expenseServices.FindAllAsync();
            return View(obj);
        }

        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _expenseServices.FindByIdAsync(Id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExpenseFormViewModel obj)
        {
            if (ModelState.IsValid)
            {
                await _expenseServices.CreateAsync(obj);
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _expenseServices.FindByIdAsync(Id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Expense expense)
        {
            if (ModelState.IsValid)
            {
                await _expenseServices.UpdateAsync(expense);

            }

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            var obj = await _expenseServices.FindByIdAsync(Id.Value);

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Expense expense)
        {
            if (ModelState.IsValid)
            {
                await _expenseServices.DeleteAsync(expense);
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
