using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManagementMvc.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [Display(Name = "Type")]
        public Category Type { get; set; }
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Amount { get; set; }

        public Expense()
        {
        }

        public Expense(int id, Category type, string description, double amount)
        {
            Id = id;
            Type = type;
            Description = description;
            Amount = amount;
        }
    }
}
