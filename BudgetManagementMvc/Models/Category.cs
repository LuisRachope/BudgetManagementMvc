using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManagementMvc.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Category()
        {
        }

        public Category(int id, string title)
        {
            Title = title;
        }
    }
}
