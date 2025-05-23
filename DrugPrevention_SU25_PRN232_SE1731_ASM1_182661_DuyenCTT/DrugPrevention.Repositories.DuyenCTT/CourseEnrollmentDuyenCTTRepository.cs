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
    public class CourseEnrollmentDuyenCTTRepository : GenericRepository<CourseEnrollmentDuyenCtt>
    {
        public CourseEnrollmentDuyenCTTRepository() => _context = new SE18_PRN232_SE1731_G2_MaToeContext();
        public CourseEnrollmentDuyenCTTRepository(SE18_PRN232_SE1731_G2_MaToeContext context) => _context = context;
        public async Task<List<CourseEnrollmentDuyenCtt>> GetAllAsync()
        {
            var courseEnrollments = await _context.CourseEnrollmentDuyenCtts
                .Include(ce => ce.Course)
                .Include(ce => ce.User)
                .ToListAsync();
            return courseEnrollments;
        }

        public async Task<CourseEnrollmentDuyenCtt> GetByIdAsync(int id)
        {
            var courseEnrollment = await _context.CourseEnrollmentDuyenCtts
                .Include(ce => ce.Course)
                .Include(ce => ce.User).ThenInclude(u => u.Role)
                .FirstOrDefaultAsync(ce => ce.EnrollmentDuyenCttid == id);
            return courseEnrollment ?? new CourseEnrollmentDuyenCtt();
        }

        public async Task<List<CourseEnrollmentDuyenCtt>> SearchAsync(String enrollmentSource, decimal score, string certificateUrl)
        {
            var courseEnrollment = await _context.CourseEnrollmentDuyenCtts
                   .Include(q => q.Course)
                   .Where(q =>
                       (string.IsNullOrEmpty(enrollmentSource) || q.EnrollmentSource.Contains(enrollmentSource))
                       && (string.IsNullOrEmpty(certificateUrl) || q.CertificateUrl.Contains(certificateUrl))
                       && (q.Score == score || score == null || score == 0)
                   ).ToListAsync();


            return courseEnrollment;
        }
    }
}
