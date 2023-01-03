using BudgetManagementMvc.Data;
using BudgetManagementMvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManagementMvc.Services
{
    public class ExpenseServices
    {
        private readonly BudgetManagementMvcContext _context;

        public ExpenseServices(BudgetManagementMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Expense>> FindAllAsync()
        {
            return await _context.Expense.ToListAsync();
        }

        public async Task<Expense> FindByIdAsync(int id)
        {

            Expense expense = await _context.Expense.FirstOrDefaultAsync(x => x.Id == id);

            return expense;
        }

    }
}
