using DrugPrevention.Repositories.DuyenCTT;
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
        Task<List<CourseEnrollmentDuyenCtt>> GetAllAsync();
        Task<CourseEnrollmentDuyenCtt> GetByIdAsync(int id);

        Task<CourseEnrollmentDuyenCtt> SearchAsync(String enrollmentSource, decimal score, string title);

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
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            var course = _repository.GetById(id);
            var result = _repository.RemoveAsync(course);
            return result;
        }

        public Task<List<CourseEnrollmentDuyenCtt>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public async Task<CourseEnrollmentDuyenCtt> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public Task<CourseEnrollmentDuyenCtt> SearchAsync(string enrollmentSource, decimal score, string title)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(CourseEnrollmentDuyenCtt courseEnrollment)
        {
            return await _repository.UpdateAsync(courseEnrollment);
        }
    }
}
