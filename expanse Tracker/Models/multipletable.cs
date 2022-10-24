using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace expanse_Tracker.Models
{
    public class multipletable
    {
        public IList<Expense_Category> Expense_Categories { get; set; }
        public IList<Expanses> Expanses { get; set; }
    }
}
