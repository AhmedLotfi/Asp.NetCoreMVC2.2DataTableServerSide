using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCoreMvc.Areas.Admin.ViewModels
{
    public class DepartmentVM
    {

        public long Id { get; set; }


        [Display(Name = "Department Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Manager Name")]
        [Required]
        public long ManagerId { get; set; }

        public string Notes { get; set; }
    }
}
