using DrugPrevention.Repositories.DuyenCTT.Basic;
using DrugPrevention.Repositories.DuyenCTT.DBContext;
using DrugPrevention.Repositories.DuyenCTT.ModelExtensions;
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
        public async Task<PaginationResult<CourseEnrollmentDuyenCtt>> GetAllAsync(int pageIndex, int pageSize)
        {
            Console.WriteLine($"[DEBUG] Fetching enrollments: pageIndex={pageIndex}, pageSize={pageSize}");

            var totalItems = await _context.CourseEnrollmentDuyenCtts.CountAsync();
            Console.WriteLine($"[DEBUG] Total items in DB: {totalItems}");

            var items = await _context.CourseEnrollmentDuyenCtts
                .Include(ce => ce.Course)
                .Include(ce => ce.User)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            Console.WriteLine($"[DEBUG] Retrieved {items.Count} items from DB");

            foreach (var item in items)
            {
                Console.WriteLine($"[DEBUG] EnrollmentID: {item.EnrollmentDuyenCttid}, UserID: {item.UserId}, CourseID: {item.CourseId}, EnrolledAt: {item.EnrolledAt}");
                if (item.Course != null)
                {
                    Console.WriteLine($"  └─ Course Title: {item.Course.Title ?? "null"}");
                }
                if (item.User != null)
                {
                    Console.WriteLine($"  └─ User Name: {item.User.FullName ?? "null"}");
                }
            }

            return new PaginationResult<CourseEnrollmentDuyenCtt>(items, totalItems, pageIndex, pageSize);
        }

        public async Task<CourseEnrollmentDuyenCtt> GetByIdAsync(int id)
        {
            var courseEnrollment = await _context.CourseEnrollmentDuyenCtts
                .Include(ce => ce.Course)
                .Include(ce => ce.User).ThenInclude(u => u.Role)
                .FirstOrDefaultAsync(ce => ce.EnrollmentDuyenCttid == id);
            return courseEnrollment ?? new CourseEnrollmentDuyenCtt();
        }

        public async Task<PaginationResult<CourseEnrollmentDuyenCtt>> SearchAsync(string? enrollmentSource, double? score, string? certificateUrl, int pageIndex, int pageSize)
        {
            var query = _context.CourseEnrollmentDuyenCtts
                .Include(ce => ce.Course)
                .Include(ce => ce.User)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(enrollmentSource))
                query = query.Where(ce => ce.EnrollmentSource.Contains(enrollmentSource));

            if (score.HasValue)
                query = query.Where(ce => ce.Score >= (decimal)score.Value);

            if (!string.IsNullOrWhiteSpace(certificateUrl))
                query = query.Where(ce => ce.CertificateUrl.Contains(certificateUrl));

            var totalItems = await query.CountAsync();

            var items = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginationResult<CourseEnrollmentDuyenCtt>(items, totalItems, pageIndex, pageSize);
        }
    }
}
