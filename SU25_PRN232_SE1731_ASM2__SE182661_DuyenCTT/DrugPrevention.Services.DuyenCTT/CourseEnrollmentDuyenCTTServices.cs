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
        Task<List<CourseEnrollment>> GetAllAsync();
        Task<CourseEnrollment> GetByIdAsync(int id);

        Task<CourseEnrollment> SearchAsync(String enrollmentSource, decimal score, string title);

        Task<int> CreateAsync(CourseEnrollment courseEnrollment);
        Task<int> UpdateAsync(CourseEnrollment courseEnrollment);

        Task<bool> DeleteAsync(int id);
    }
    public class CourseEnrollmentDuyenCTTServices : ICourseEnrollmentDuyenCTTServices
    {
        // private readonly CourseEnrollmentDuyenCTTRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        // Old constructor using direct repository instantiation
        // public CourseEnrollmentDuyenCTTServices() => _repository = new CourseEnrollmentDuyenCTTRepository();

        // Old constructor using repository injection
        // public CourseEnrollmentDuyenCTTServices(CourseEnrollmentDuyenCTTRepository repository)
        // {
        //     _repository = repository;
        // }

        // New constructor using UnitOfWork

        public CourseEnrollmentDuyenCTTServices() => _unitOfWork = new UnitOfWork();
        public async Task<int> CreateAsync(CourseEnrollment courseEnrollment)
        {
            await _unitOfWork.CourseEnrollmentDuyenCTTRepository.CreateAsync(courseEnrollment);
            return await _unitOfWork.SaveChangesWithTransactionAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _unitOfWork.CourseEnrollmentDuyenCTTRepository.GetByIdAsync(id);
            var result = await _unitOfWork.CourseEnrollmentDuyenCTTRepository.RemoveAsync(course);
            await _unitOfWork.SaveChangesWithTransactionAsync();
            return result;
        }

        public Task<List<CourseEnrollment>> GetAllAsync()
        {
            return _unitOfWork.CourseEnrollmentDuyenCTTRepository.GetAllAsync();
        }

        public Task<CourseEnrollment> GetByIdAsync(int id)
        {
            return _unitOfWork.CourseEnrollmentDuyenCTTRepository.GetByIdAsync(id);
        }

        public Task<CourseEnrollment> SearchAsync(string enrollmentSource, decimal score, string title)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(CourseEnrollment courseEnrollment)
        {
            await _unitOfWork.CourseEnrollmentDuyenCTTRepository.UpdateAsync(courseEnrollment);
            return await _unitOfWork.SaveChangesWithTransactionAsync();
        }
    }
}
