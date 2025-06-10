using DrugPrevention.Repositories.DuyenCTT;
using DrugPrevention.Repositories.DuyenCTT.ModelExtensions;
using DrugPrevention.Repositories.DuyenCTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.DuyenCTT
{
    public interface ICourseEnrollmentDuyenCTTServices
    {
        Task<PaginationResult<CourseEnrollmentDuyenCtt>> GetAllAsync(int pageIndex, int pageSize);
        Task<CourseEnrollmentDuyenCtt> GetByIdAsync(int id);

        Task<PaginationResult<CourseEnrollmentDuyenCtt>> SearchAsync(string? enrollmentSource, double? score, string? title, int pageIndex, int pageSize);

        Task<int> CreateAsync(CourseEnrollmentDuyenCtt courseEnrollment);
        Task<int> UpdateAsync(CourseEnrollmentDuyenCtt courseEnrollment);

        Task<bool> DeleteAsync(int id);
    }
    public class CourseEnrollmentDuyenCTTServices : ICourseEnrollmentDuyenCTTServices
    {
        private readonly CourseEnrollmentDuyenCTTRepository _repository;

        public CourseEnrollmentDuyenCTTServices() => _repository = new CourseEnrollmentDuyenCTTRepository();
        public CourseEnrollmentDuyenCTTServices(CourseEnrollmentDuyenCTTRepository repository)
        {
            _repository = repository;
        }

        public Task<int> CreateAsync(CourseEnrollmentDuyenCtt courseEnrollment)
        {
            return _repository.CreateAsync(courseEnrollment);

        }

        public Task<bool> DeleteAsync(int id)
        {
            var course = _repository.GetById(id);
            var result = _repository.RemoveAsync(course);
            return result;
        }

        public Task<PaginationResult<CourseEnrollmentDuyenCtt>> GetAllAsync(int pageIndex, int pageSize)
        {
            return _repository.GetAllAsync(pageIndex, pageSize);
        }

        public async Task<CourseEnrollmentDuyenCtt> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<PaginationResult<CourseEnrollmentDuyenCtt>> SearchAsync(string? enrollmentSource, double? score, string? title, int pageIndex, int pageSize)
        {
            return await _repository.SearchAsync(enrollmentSource, score, title, pageIndex, pageSize);
        }


        public async Task<int> UpdateAsync(CourseEnrollmentDuyenCtt courseEnrollment)
        {
            return await _repository.UpdateAsync(courseEnrollment);
        }
    }
}
