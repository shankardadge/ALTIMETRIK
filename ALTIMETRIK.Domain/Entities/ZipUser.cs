using System;
using System.Collections.Generic;
using System.Text;

namespace ALTIMETRIK.Domain.Entities
{
    public partial class ZipUser
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Phone { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal MonthlyExpense { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
