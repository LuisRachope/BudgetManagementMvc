using BudgetManagementMvc.Data;
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


    }
}
