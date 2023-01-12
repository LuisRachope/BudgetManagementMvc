using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManagementMvc.Models.ViewModels
{
    public class ExpenseFormViewModel
    {
        public Expense Expense { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<Category> Cartegories { get; set; }

    }
}
