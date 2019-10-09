using System;
using System.Collections.Generic;

namespace SchoolCoreMvc.Models.DataModel
{
    public partial class Departments
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ManagerId { get; set; }
        public string Notes { get; set; }

        public virtual DepartmentMangers Manager { get; set; }
    }
}
