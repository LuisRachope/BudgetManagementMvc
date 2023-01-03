using BudgetManagementMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManagementMvc.Data
{
    public class SeedingService
    {
        private BudgetManagementMvcContext _context;

        public SeedingService(BudgetManagementMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Expense.Any())
            {
                return; // DB has been seeded
            }

            // Creation data to migration on DB (Movie)

            // Create Expenses
            Expense e1 = new Expense(1, "Debit", "Mc Donnals - Foods and drinks", 38.9);
            Expense e2 = new Expense(2, "Debit", "Levis Cloath's - Shoes", 131.87);
            Expense e3 = new Expense(3, "Debit", "Liberdade Avenue - Cake and pasta", 249.16);
            Expense e4 = new Expense(4, "Debit", "Kalunga Inf. - Notebook", 672.94);
            Expense e5 = new Expense(5, "Debit", "Quebec Museum - Ticket", 19.46);
            Expense e6 = new Expense(6, "Debit", "Jonny Rockets - Food and ribs", 66.71);

            // adding Expenses on DB
            _context.Expense.AddRange(e1, e2, e3, e4, e5, e6);

            // Execution saving data
            _context.SaveChanges();

        }

    }
}
