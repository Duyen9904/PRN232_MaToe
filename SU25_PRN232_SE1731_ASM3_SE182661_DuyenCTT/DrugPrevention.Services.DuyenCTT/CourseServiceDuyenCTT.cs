using DrugPrevention.Repositories.DuyenCTT;
using DrugPrevention.Repositories.DuyenCTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.DuyenCTT
{

    public interface ICourseDuyenCTTService
    {
        Task<List<CourseDuyenCtt>> GetAllAsync();
        Task<CourseDuyenCtt> GetByIdAsync(int id);
        Task<int> CreateAsync(CourseDuyenCtt course);
        Task<int> UpdateAsync(CourseDuyenCtt course);
        Task<bool> DeleteAsync(int id);
    }
    public class CourseDuyenCTTService : ICourseDuyenCTTService
    {
        // private readonly CourseDuyenCTTRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        // Old constructor using direct instantiation
        // public CourseService() => _repository = new CourseDuyenCTTRepository();

        // Old constructor using direct repository injection
        // public CourseService(CourseDuyenCTTRepository repository)
        // {
        //     _repository = repository;
        // }

        // New constructor using UnitOfWork
        public CourseDuyenCTTService() => _unitOfWork = new UnitOfWork();
        public async Task<int> CreateAsync(CourseDuyenCtt course)
        {
            await _unitOfWork.CourseDuyenCTTRepository.CreateAsync(course);
            return await _unitOfWork.SaveChangesWithTransactionAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _unitOfWork.CourseDuyenCTTRepository.GetByIdAsync(id);
            if (course == null)
            {
                return false;
            }

            var result = await _unitOfWork.CourseDuyenCTTRepository.RemoveAsync(course);
            await _unitOfWork.SaveChangesWithTransactionAsync();
            return result;
        }

        public async Task<List<CourseDuyenCtt>> GetAllAsync()
        {
            return await _unitOfWork.CourseDuyenCTTRepository.GetAllAsync();
        }

        public async Task<CourseDuyenCtt> GetByIdAsync(int id)
        {
            return await _unitOfWork.CourseDuyenCTTRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(CourseDuyenCtt course)
        {
            var existingCourse = await _unitOfWork.CourseDuyenCTTRepository.GetByIdAsync(course.CourseDuyenCttid);
            if (existingCourse == null)
            {
                return 0;
            }

            await _unitOfWork.CourseDuyenCTTRepository.UpdateAsync(course);
            return await _unitOfWork.SaveChangesWithTransactionAsync();
        }
    }
}
