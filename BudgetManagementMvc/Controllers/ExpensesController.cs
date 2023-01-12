using BudgetManagementMvc.Models;
using BudgetManagementMvc.Models.ViewModels;
using BudgetManagementMvc.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManagementMvc.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ExpenseServices _expenseServices;
        private readonly CategoryServices _categoryServices;

        public ExpensesController(ExpenseServices expenseServices, CategoryServices categoryServices)
        {
            _expenseServices = expenseServices;
            _categoryServices = categoryServices;
        }


        public async Task<IActionResult> Index()
        {
            var expenses = await _expenseServices.FindAllAsync();
            var categories = await _categoryServices.FindAllAsync();

            List<Expense> list = new List<Expense>();
            foreach (var obj in expenses)
            {
                list.Add(new Expense(obj.Id,
                    categories.FirstOrDefault(x => x.Id == obj.CategoryId),
                    obj.Description,
                    obj.Amount
                    ));
            }

            return View(list);
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
                Category category = await _categoryServices.FindByIdAsync(1);
                Expense exp = new Expense(obj.Expense.Id, category, obj.Expense.Description, obj.Expense.Amount);
                ExpenseFormViewModel e = new ExpenseFormViewModel { Expense = exp };

                await _expenseServices.CreateAsync(e);
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
