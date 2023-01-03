using BudgetManagementMvc.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        
        public async Task<IActionResult> Edit(int? Id)
        {
            var obj = await _expenseServices.FindByIdAsync(Id.Value);

            return View(obj);

        }

        /*
        [HttpPost]
        public async Task<IActionResult> Edit(Id)
        {
            return View();
        }
        */
    }
}
