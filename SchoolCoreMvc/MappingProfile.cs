using AutoMapper;
using SchoolCoreMvc.Areas.Admin.ViewModels;
using SchoolCoreMvc.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCoreMvc
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Departments,DepartmentVM>();
            CreateMap<DepartmentVM, Departments>();
        }
    }
}
