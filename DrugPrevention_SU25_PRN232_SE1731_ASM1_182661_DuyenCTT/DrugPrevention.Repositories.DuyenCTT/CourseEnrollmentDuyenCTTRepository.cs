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
        public async Task<PaginationResult<CourseEnrollmentDuyenCtt>> GetAllAsync(int pageIndex, int pageSize, string sortField = null, string sortOrder = "asc")
        {
            var query = _context.CourseEnrollmentDuyenCtts
                .Include(ce => ce.Course)
                .Include(ce => ce.User)
                .AsQueryable();

            // Apply sorting dynamically
            if (!string.IsNullOrEmpty(sortField))
            {
                bool ascending = sortOrder.ToLower() == "asc";

                query = sortField switch
                {
                    "EnrolledAt" => ascending ? query.OrderBy(e => e.EnrolledAt) : query.OrderByDescending(e => e.EnrolledAt),
                    "Progress" => ascending ? query.OrderBy(e => e.Progress) : query.OrderByDescending(e => e.Progress),
                    "CompletedAt" => ascending ? query.OrderBy(e => e.CompletedAt) : query.OrderByDescending(e => e.CompletedAt),
                    "Score" => ascending ? query.OrderBy(e => e.Score) : query.OrderByDescending(e => e.Score),
                    "CertificateUrl" => ascending ? query.OrderBy(e => e.CertificateUrl) : query.OrderByDescending(e => e.CertificateUrl),
                    "IsCertified" => ascending ? query.OrderBy(e => e.IsCertified) : query.OrderByDescending(e => e.IsCertified),
                    "EnrollmentSource" => ascending ? query.OrderBy(e => e.EnrollmentSource) : query.OrderByDescending(e => e.EnrollmentSource),
                    "Course.Title" => ascending ? query.OrderBy(e => e.Course.Title) : query.OrderByDescending(e => e.Course.Title),
                    "User.UserId" => ascending ? query.OrderBy(e => e.User.UserId) : query.OrderByDescending(e => e.User.UserId),
                    _ => query
                };
            }
            Console.WriteLine($"Query: {query.ToQueryString()}");

            var totalItems = await query.CountAsync();

            var items = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            Console.WriteLine($"Total Items: {totalItems}, Page Index: {pageIndex}, Page Size: {pageSize}");

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
