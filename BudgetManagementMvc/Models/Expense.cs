using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManagementMvc.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }

        public Expense()
        {
        }

        public Expense(int id, string type, string description, double amount)
        {
            Id = id;
            Type = type;
            Description = description;
            Amount = amount;
        }
    }
}
