using DrugPrevention.APIServices.BE.DuyenCTT.Mappers;
using DrugPrevention.GraphQLAPIServices.DuyenCTT.DTOs;
using DrugPrevention.Repositories.DuyenCTT.Models;
using DrugPrevention.Services.DuyenCTT;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DrugPrevention.GraphQLAPIServices.DuyenCTT.GraphQLs
{
    public class Mutation
    {
        private readonly IServiceProviders _serviceProvider;

        public Mutation(IServiceProviders serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // 🟢 Create (Add) CourseEnrollment
        public async Task<CourseEnrollmentDuyenCtt> AddCourseEnrollmentDuyenCtt(CreateCourseEnrollmentDuyenCttDto input)
        {
            try
            {
                if (input == null)
                {
                    throw new ArgumentNullException(nameof(input), "Input cannot be null");
                }
                var entity = input.ToEntity();
                var newId = await _serviceProvider.CourseEnrollmentService.CreateAsync(entity);
                return await _serviceProvider.CourseEnrollmentService.GetByIdAsync(newId);
            }
            catch (Exception)
            {
                return new CourseEnrollmentDuyenCtt(); // Optional: Add error logging
            }
        }

        // 🟡 Update CourseEnrollment
        public async Task<CourseEnrollmentDuyenCtt> UpdateCourseEnrollmentDuyenCtt(CreateCourseEnrollmentDuyenCttDto input)
        {
            try
            {
                var entity = input.ToEntity();
                await _serviceProvider.CourseEnrollmentService.UpdateAsync(entity);
                return await _serviceProvider.CourseEnrollmentService.GetByIdAsync(entity.EnrollmentDuyenCttid);
            }
            catch (Exception)
            {
                return new CourseEnrollmentDuyenCtt();
            }
        }


        // 🔴 Delete CourseEnrollment by Id
        public async Task<bool> DeleteCourseEnrollmentDuyenCtt(int id)
        {
            try
            {
                return await _serviceProvider.CourseEnrollmentService.DeleteAsync(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
