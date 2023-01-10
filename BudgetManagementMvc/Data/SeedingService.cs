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

            // Create Categories of Expenses
            Category c1 = new Category(1, "Debit");
            Category c2 = new Category(2, "Credit");

            // Create Expenses
            Expense e1 = new Expense(1, c1, "Mc Donnals - Foods and drinks", 38.9);
            Expense e2 = new Expense(2, c1, "Levis Cloath's - Shoes", 131.87);
            Expense e3 = new Expense(3, c1, "Liberdade Avenue - Cake and pasta", 249.16);
            Expense e4 = new Expense(4, c1, "Kalunga Inf. - Notebook", 672.94);
            Expense e5 = new Expense(5, c1, "Quebec Museum - Ticket", 19.46);
            Expense e6 = new Expense(6, c1, "Jonny Rockets - Food and ribs", 66.71);

            // adding Expenses on DB
            _context.Category.AddRange(c1,c2);
            _context.Expense.AddRange(e1, e2, e3, e4, e5, e6);

            // Execution saving data
            _context.SaveChanges();

        }

    }
}
