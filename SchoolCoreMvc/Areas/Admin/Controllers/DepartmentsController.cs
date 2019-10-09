using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolCoreMvc.Areas.Admin.ViewModels;
using SchoolCoreMvc.Interfaces;
using SchoolCoreMvc.Models.DataModel;

namespace SchoolCoreMvc.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class DepartmentsController : Controller
    {
        private readonly IDepartments _depBll;
        private readonly IMapper _mapper;

        public DepartmentsController(
            IDepartments dep,
            IMapper mapper)
        {
            _depBll = dep;
            _mapper = mapper;
        }

        public IActionResult Index() => View();

        public PartialViewResult DetparmtnetDetails() => PartialView();

        public async Task<PartialViewResult> DepartmentForm(long? id, string trigger = "add")
        {
            if (id == null && trigger == "add")
            {
                ViewBag.formType = "add";

                return PartialView();
            }
            else if (id != null && trigger == "edit")
            {
                ViewBag.formType = "edit";

                var current = await _depBll.GetOneAsync((long)id);

                var vm = _mapper.Map<DepartmentVM>(current);

                return PartialView(vm);
            }
            else if (id != null && trigger == "details")
            {
                ViewBag.formType = "details";

                var current = await _depBll.GetOneAsync((long)id);

                var vm = _mapper.Map<DepartmentVM>(current);

                return PartialView(vm);
            }

            return PartialView();
        }

        [HttpGet]
        public JsonResult LoadDataGrid()
        {

            var data = _depBll.GetAll()
                .Select(z => new
                {
                    z.Id,
                    z.Name,
                    ManagerName = z.Manager.Name
                })
                .OrderByDescending(z=>z.Id);

            return Json(data);
        }

        [HttpPost]
        public IActionResult PostDepartment(DepartmentVM vm)
        {
            try
            {
                var current = _mapper.Map<Departments>(vm);

                if (vm.Id == 0)
                {

                    int result = _depBll.Insert(current);

                    if(result !=1)
                        return Json(new { add = true, done = false , message = "Error in Save" });

                    return Json(new { add = true ,done = true , message = "Added Successfully"  });
                }
                else
                {
                    int result = _depBll.Update(current);

                    if (result != 1)
                        return Json(new { edit = true, done = false, message = "Error in Update" });

                    return Json(new { edit = true, done = true , message = "Updated Successfully" });
                }

            }
            catch (Exception x)
            {
                return Json(new {  done = false , message = $"{x.InnerException?.Message ?? x.Message}" });
            }
        }


        [HttpPost]
        public async Task<JsonResult> DeleteDep(int id)
        {
            try
            {
                var current = await _depBll.GetOneAsync(id);

                int result = _depBll.Remove(current);
                if(result !=1)
                    return Json(new { done = false, message = $"Error In Delete" });

                return Json(new { done = true, message = $"Deleted Successfully" });
            }
            catch (Exception x)
            {
                return Json(new { done=false,message = $"{x.InnerException?.Message ?? x.Message}" });
            }
        }

    }
}