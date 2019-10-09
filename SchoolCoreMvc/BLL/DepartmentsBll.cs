using SchoolCoreMvc.Interfaces;
using SchoolCoreMvc.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCoreMvc
{
    public class DepartmentsBll : IDepartments
    {
        private readonly SchoolContext _context;

        public DepartmentsBll() => _context = new SchoolContext();

        public IQueryable<Departments> GetAll()
        {
            return _context.Set<Departments>();
        }

        public Departments GetOne(long id)
        {
            return _context.Set<Departments>().Find(id);
        }

        public async Task<Departments> GetOneAsync(long id)
        {
            return await _context.Set<Departments>().FindAsync(id);
        }

        public int Insert(Departments dep)
        {
            try
            {
                _context.Set<Departments>().Add(dep);

                return SaveChange();
            }
            catch (Exception x)
            {
                return -1;
            }
        }

        public int Update(Departments dep)
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

        public int Remove(Departments dep)
        {
            _context.Set<Departments>().Remove(dep);

            return SaveChange();
        }

        public int SaveChange()=> _context.SaveChanges();

        public async Task<int> SaveChangeAsync()=> await _context.SaveChangesAsync();
    }
}
