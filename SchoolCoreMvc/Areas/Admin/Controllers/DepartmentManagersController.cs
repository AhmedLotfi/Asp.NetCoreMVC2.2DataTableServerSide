using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolCoreMvc.BLL;
using SchoolCoreMvc.CommonHelpers;
using SchoolCoreMvc.Interfaces;
using SchoolCoreMvc.Models.DataModel;

namespace SchoolCoreMvc.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class DepartmentManagersController : Controller
    {
        private readonly IDepartmentManager _depManageBll;

        public DepartmentManagersController(IDepartmentManager departmentManager)
        {
            _depManageBll = departmentManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult LoadData()
        {
            try
            {
                var parms = DatatableHelper.GetDatatableParms(Request.Form);

                int recordsTotal = 0;

                var data = _depManageBll.Find(z =>
                              string.IsNullOrEmpty(parms.searchValue)
                           || z.Name.Contains(parms.searchValue)
                           || z.Address.Contains(parms.searchValue));

                recordsTotal = data.Count();

                var list = data
                            .Skip(parms.skip)
                            .Take(parms.pageSize)
                            .ToList();

                if (!string.IsNullOrEmpty(parms.sortColumn))
                {
                    bool isDesc = parms.sortColumnDirection == "desc";

                    list = OrderDynamicaly.OrderByDynamic<DepartmentMangers>(list.AsQueryable(), parms.sortColumn, isDesc).ToList();
                }

                return Json(new { parms.draw, recordsFiltered = recordsTotal, recordsTotal, data = list });
            }
            catch (Exception x)
            {
                return Json(new { draw = 0, recordsFiltered = 0, recordsTotal = 0, data = string.Empty });
            }
        }
    }
}