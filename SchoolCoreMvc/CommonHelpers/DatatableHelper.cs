using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCoreMvc.CommonHelpers
{
    public static  class DatatableHelper
    {
        public static DatatableParms GetDatatableParms(IFormCollection iFc)
        {
            string draw = iFc[nameof(DatatableParms.draw)].FirstOrDefault();
            string start = iFc[nameof(DatatableParms.start)].FirstOrDefault();
            string length = iFc[nameof(DatatableParms.length)].FirstOrDefault();

            string sortColumn = iFc[$"columns[{iFc["order[0][column]"].FirstOrDefault()}][name]"].FirstOrDefault();
            string sortColumnDirection = iFc["order[0][dir]"].FirstOrDefault();
            string searchValue = iFc["search[value]"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;

            return new DatatableParms
            {
                draw=draw,
                start=start ,
                length =length,
                sortColumn=sortColumn,
                pageSize = pageSize,
                searchValue = searchValue,
                skip =skip,
                sortColumnDirection = sortColumnDirection
            };
        }

    }
}
