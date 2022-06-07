using App.Domain.Entity.prf;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.look
{
    public partial class ExpenseTypes
    {
        public ExpenseTypes()
        {
            DailyExpense = new HashSet<DailyExpense>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public string Pashto { get; set; }

        public virtual ICollection<DailyExpense> DailyExpense { get; set; }
    }
}
