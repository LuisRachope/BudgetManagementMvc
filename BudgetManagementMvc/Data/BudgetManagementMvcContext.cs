using BudgetManagementMvc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManagementMvc.Data
{
    public class BudgetManagementMvcContext : IdentityDbContext
    {
        public BudgetManagementMvcContext(DbContextOptions<BudgetManagementMvcContext> options)
          : base(options)
        {
        }

        public DbSet<Expense> Expense { get; set; }

    }
}
