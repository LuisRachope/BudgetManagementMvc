using BudgetManagementMvc.Data;
using BudgetManagementMvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManagementMvc.Services
{
    public class CategoryServices
    {
        private readonly BudgetManagementMvcContext _context;

        public CategoryServices(BudgetManagementMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> FindAllAsync()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category> FindByIdAsync(int id)
        {

            Category category = await _context.Category.FirstOrDefaultAsync(x => x.Id == id);

            return category;
        }
    }
}
