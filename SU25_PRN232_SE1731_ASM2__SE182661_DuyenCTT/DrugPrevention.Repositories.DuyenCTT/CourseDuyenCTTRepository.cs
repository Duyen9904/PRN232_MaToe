using DrugPrevention.Repositories.DuyenCTT.Basic;
using DrugPrevention.Repositories.DuyenCTT.DBContext;
using DrugPrevention.Repositories.DuyenCTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Repositories.DuyenCTT
{
    public class CourseDuyenCTTRepository : GenericRepository<Course>
    {
        public CourseDuyenCTTRepository() { }

        public CourseDuyenCTTRepository(SE18_PRN232_SE1731_G2_MaToeContext context) => _context = context;
    }
}
