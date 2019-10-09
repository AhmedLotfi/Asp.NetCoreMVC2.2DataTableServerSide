using System;
using System.Collections.Generic;

namespace SchoolCoreMvc.Models.DataModel
{
    public partial class DepartmentMangers
    {
        public DepartmentMangers()
        {
            Departments = new HashSet<Departments>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Departments> Departments { get; set; }
    }
}
