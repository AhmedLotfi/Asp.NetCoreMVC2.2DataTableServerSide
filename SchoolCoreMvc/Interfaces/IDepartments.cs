using SchoolCoreMvc.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCoreMvc.Interfaces
{
    public interface IDepartments
    {
        IQueryable<Departments> GetAll();

        Departments GetOne(long id);
        
        Task<Departments> GetOneAsync(long id);

        int Insert(Departments dep);

        int Update(Departments dep);

        int Remove(Departments dep);

    }
}
