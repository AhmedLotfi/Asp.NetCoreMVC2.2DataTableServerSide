using Microsoft.EntityFrameworkCore;
using SchoolCoreMvc.Interfaces;
using SchoolCoreMvc.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SchoolCoreMvc.BLL
{
    public class DepartmentManagerBll : IDepartmentManager
    {
        private readonly SchoolContext _context;

        public DepartmentManagerBll() => _context = new SchoolContext();

        public IQueryable<DepartmentMangers> GetAll()
        {
            return _context.Set<DepartmentMangers>();
        }

        public DepartmentMangers GetOne(long id)
        {
            return _context.Set<DepartmentMangers>().Find(id);
        }

        public async Task<DepartmentMangers> GetOneAsync(long id)
        {
            return await _context.Set<DepartmentMangers>().FindAsync(id);
        }

        public int Insert(DepartmentMangers dep)
        {
            try
            {
                _context.Set<DepartmentMangers>().Add(dep);

                return SaveChange();
            }
            catch (Exception x)
            {
                return -1;
            }
        }

        public int Update(DepartmentMangers dep)
        {
            try
            {
                _context.Entry(dep).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                return SaveChange();
            }
            catch (Exception x)
            {
                return -1;
            }
        }

        public int Remove(DepartmentMangers dep)
        {
            _context.Set<DepartmentMangers>().Remove(dep);

            return SaveChange();
        }

        public int SaveChange() => _context.SaveChanges();

        public async Task<int> SaveChangeAsync() => await _context.SaveChangesAsync();

        public int GetCount(string search)
        {
            return _context.Set<DepartmentMangers>()
                .Where(z => 
                              string.IsNullOrEmpty(search) 
                           || z.Name.Contains(search)
                           || z.Address.Contains(search)
                       )
                .Count();
        }

        public IQueryable<DepartmentMangers> Find(Expression<Func<DepartmentMangers, bool>> predicate)
        {
          return  _context.Set<DepartmentMangers>().Where(predicate);
        }
    }
}
