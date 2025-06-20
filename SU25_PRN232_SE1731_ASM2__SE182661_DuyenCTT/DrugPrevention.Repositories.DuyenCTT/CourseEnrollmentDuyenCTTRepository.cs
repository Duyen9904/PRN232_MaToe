using DrugPrevention.Repositories.DuyenCTT.Basic;
using DrugPrevention.Repositories.DuyenCTT.DBContext;
using DrugPrevention.Repositories.DuyenCTT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Repositories.DuyenCTT
{
    public class CourseEnrollmentDuyenCTTRepository : GenericRepository<CourseEnrollment>
    {
        public CourseEnrollmentDuyenCTTRepository() => _context = new SE18_PRN232_SE1731_G2_MaToeContext();
        public CourseEnrollmentDuyenCTTRepository(SE18_PRN232_SE1731_G2_MaToeContext context) => _context = context;
        public async Task<List<CourseEnrollment>> GetAllAsync()
        {
            var courseEnrollments = await _context.CourseEnrollments
                .Include(ce => ce.Course)
                .Include(ce => ce.User)
                .ToListAsync();
            return courseEnrollments;
        }

        public async Task<CourseEnrollment> GetByIdAsync(int id)
        {
            var courseEnrollment = await _context.CourseEnrollments
                .Include(ce => ce.Course)
                .Include(ce => ce.User).ThenInclude(u => u.Role)
                .FirstOrDefaultAsync(ce => ce.EnrollmentId == id);
            return courseEnrollment ?? new CourseEnrollment();
        }

        //public async Task<List<CourseEnrollment>> SearchAsync(String enrollmentSource, decimal score, string title)
        //{
        //    var courseEnrollment = await _context.CourseEnrollments.Include(ce => ce.Course).Where(
        //        ce => ce.
        //        ).ToListAsync();


        //}
    }
}
