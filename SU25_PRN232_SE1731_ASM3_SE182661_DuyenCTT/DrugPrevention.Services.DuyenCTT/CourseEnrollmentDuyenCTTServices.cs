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
        Task<PaginationResult<CourseEnrollmentDuyenCtt>> GetAllAsync(int page, int size);
        Task<CourseEnrollmentDuyenCtt> GetByIdAsync(int id);
        Task<PaginationResult<CourseEnrollmentDuyenCtt>> SearchAsync(string? enrollmentSource, double? score, string? certificateUrl, int page, int size);
        Task<int> CreateAsync(CourseEnrollmentDuyenCtt courseEnrollment);
        Task<int> UpdateAsync(CourseEnrollmentDuyenCtt courseEnrollment);
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
        public async Task<int> CreateAsync(CourseEnrollmentDuyenCtt courseEnrollment)
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

        public Task<PaginationResult<CourseEnrollmentDuyenCtt>> GetAllAsync(int page, int size)
        {
            return _unitOfWork.CourseEnrollmentDuyenCTTRepository.GetAllAsync(page, size);
        }

        public Task<CourseEnrollmentDuyenCtt> GetByIdAsync(int id)
        {
            return _unitOfWork.CourseEnrollmentDuyenCTTRepository.GetByIdAsync(id);
        }

        public Task<PaginationResult<CourseEnrollmentDuyenCtt>> SearchAsync(string? enrollmentSource, double? score, string? certificateUrl, int page, int size)
        {
            return _unitOfWork.CourseEnrollmentDuyenCTTRepository.SearchAsync(enrollmentSource, score, certificateUrl, page, size);
        }

        public async Task<int> UpdateAsync(CourseEnrollmentDuyenCtt courseEnrollment)
        {
            await _unitOfWork.CourseEnrollmentDuyenCTTRepository.UpdateAsync(courseEnrollment);
            return await _unitOfWork.SaveChangesWithTransactionAsync();
        }
    }
}
