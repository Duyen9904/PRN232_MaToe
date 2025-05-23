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
    public class CourseServiceDuyenCTT : ICourseDuyenCTTService
    {
        private readonly CourseDuyenCTTRepository _repository;

        public CourseServiceDuyenCTT() => _repository = new CourseDuyenCTTRepository();
        public CourseServiceDuyenCTT(CourseDuyenCTTRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateAsync(CourseDuyenCtt course)
        {
            return await _repository.CreateAsync(course);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _repository.GetByIdAsync(id);
            if (course == null)
            {
                return false;
            }
            return await _repository.RemoveAsync(course);
        }
        public async Task<List<CourseDuyenCtt>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CourseDuyenCtt> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<int> UpdateAsync(CourseDuyenCtt course)
        {
            var existingCourse = await _repository.GetByIdAsync(course.CourseDuyenCttid);
            if (existingCourse == null)
            {
                return 0;
            }
            return await _repository.UpdateAsync(course);
        }
    }
}
