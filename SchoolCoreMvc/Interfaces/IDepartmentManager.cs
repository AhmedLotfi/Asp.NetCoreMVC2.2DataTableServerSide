using SchoolCoreMvc.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SchoolCoreMvc.Interfaces
{
    public interface IDepartmentManager
    {
        IQueryable<DepartmentMangers> GetAll();

        int GetCount(string search);

        DepartmentMangers GetOne(long id);

        Task<DepartmentMangers> GetOneAsync(long id);

        int Insert(DepartmentMangers dep);

        int Update(DepartmentMangers dep);

        int Remove(DepartmentMangers dep);

        IQueryable<DepartmentMangers> Find(Expression<Func<DepartmentMangers, bool>> predicate);
    }
}
