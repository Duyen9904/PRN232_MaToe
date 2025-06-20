using DrugPrevention.Repositories.DuyenCTT.ModelExtensions;
using DrugPrevention.Repositories.DuyenCTT.Models;
using DrugPrevention.Services.DuyenCTT;

namespace DrugPrevention.GraphQLAPIServices.DuyenCTT.GraphQLs
{
    public class CourseEnrollmentDuyenCTTQueries
    {

        private readonly IServiceProviders _serviceProvider;

        public CourseEnrollmentDuyenCTTQueries(IServiceProviders serviceProvider) => _serviceProvider = serviceProvider;
        public async Task<PaginationResult<CourseEnrollmentDuyenCtt>> GetCourseEnrollmentDuyenCtts(int page, int size)
        {
            try
            {
                var result = await _serviceProvider.CourseEnrollmentService.GetAllAsync(page, size);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] GetCourseEnrollmentDuyenCtts failed: {ex.Message}");
                Console.WriteLine(ex.StackTrace);

                return new PaginationResult<CourseEnrollmentDuyenCtt>(
                    new List<CourseEnrollmentDuyenCtt>(), 0, page, size
                );
            }
        }

        public async Task<CourseEnrollmentDuyenCtt> GetCourseEnrollmentDuyenCttById(int id)
        {
            try
            {
                var result = await _serviceProvider.CourseEnrollmentService.GetByIdAsync(id);
                return result ?? new CourseEnrollmentDuyenCtt();
            }
            catch (Exception ex)
            {
                return new CourseEnrollmentDuyenCtt();
            }
        }

        public async Task<PaginationResult<CourseEnrollmentDuyenCtt>> SearchCourseEnrollmentDuyenCtts(
        string? enrollmentSource,
        double? score,
        string? certificateUrl,
        int page,
        int size)
        {
            try
            {
                var result = await _serviceProvider.CourseEnrollmentService.SearchAsync(
                    enrollmentSource, score, certificateUrl, page, size);
                return result;
            }
            catch (Exception)
            {
                return new PaginationResult<CourseEnrollmentDuyenCtt>(
                    new List<CourseEnrollmentDuyenCtt>(), 0, page, size
                );
            }
        }
    }
}