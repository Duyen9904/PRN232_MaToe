using DrugPrevention.Repositories.DuyenCTT.ModelExtensions;
using DrugPrevention.Repositories.DuyenCTT.Models;
using DrugPrevention.Repositories.DuyenCTT.SoapModels;
using DrugPrevention.Services.DuyenCTT;
using System.ServiceModel;

namespace DrugPrevention.SoapApiServices.DuyenCTT.SoapServices
{
    [ServiceContract]
    public interface ICourseEnrollmentDuyenCTTSoapService
    {
        [OperationContract]
        Task<PaginationResultSoapModel<CourseEnrollmentDuyenCttSoapModel>> GetAllAsync(int page, int size);
        [OperationContract]
        Task<CourseEnrollmentDuyenCttSoapModel> GetByIdAsync(int id);
        [OperationContract]
        Task<PaginationResultSoapModel<CourseEnrollmentDuyenCttSoapModel>> SearchAsync(string? enrollmentSource, double? score, string? certificateUrl, int page, int size);
        [OperationContract]
        Task<int> CreateAsync(CourseEnrollmentDuyenCttSoapModel courseEnrollment);
        [OperationContract]
        Task<int> UpdateAsync(CourseEnrollmentDuyenCttSoapModel courseEnrollment);
        [OperationContract]
        Task<bool> DeleteAsync(int id);
    }

    public class CourseEnrollmentDuyenCTTSoapService : ICourseEnrollmentDuyenCTTSoapService
    {
        private readonly IServiceProviders _serviceProviders;

        public CourseEnrollmentDuyenCTTSoapService(IServiceProviders serviceProviders)
        {
            _serviceProviders = serviceProviders;
        }

        public async Task<PaginationResultSoapModel<CourseEnrollmentDuyenCttSoapModel>> GetAllAsync(int page, int size)
        {
            Console.WriteLine($"[DEBUG] Calling GetAllAsync with page={page}, size={size}");
            Console.WriteLine($"tesst");
            var result = await _serviceProviders.CourseEnrollmentService.GetAllAsync(page, size);
            Console.WriteLine($"[DEBUG] TotalItems returned: {result.TotalItems}");
            Console.WriteLine($"[DEBUG] PageIndex: {result.PageIndex}, PageSize: {result.PageSize}");
            Console.WriteLine($"[DEBUG] Items returned: {result.Items?.Count}");

            var soapItems = JsonMapper.Map<List<CourseEnrollmentDuyenCtt>, List<CourseEnrollmentDuyenCttSoapModel>>(result.Items);
            Console.WriteLine($"[DEBUG] SoapItems mapped: {soapItems?.Count}");

            // Optional: Log first few items
            for (int i = 0; i < Math.Min(soapItems.Count, 3); i++)
            {
                var item = soapItems[i];
                Console.WriteLine($"[DEBUG] Item {i}: EnrollmentId={item.EnrollmentDuyenCttid}, UserId={item.UserId}, CourseId={item.CourseId}");
            }
            Console.WriteLine($"Returning {soapItems.Count} items");
            return new PaginationResultSoapModel<CourseEnrollmentDuyenCttSoapModel>(
                soapItems,
                result.TotalItems,
                result.PageIndex,
                result.PageSize
            );
        }


        public async Task<CourseEnrollmentDuyenCttSoapModel> GetByIdAsync(int id)
        {
            var repoModel = await _serviceProviders.CourseEnrollmentService.GetByIdAsync(id);
            return JsonMapper.Map<CourseEnrollmentDuyenCtt, CourseEnrollmentDuyenCttSoapModel>(repoModel);
        }

        public async Task<PaginationResultSoapModel<CourseEnrollmentDuyenCttSoapModel>> SearchAsync(string? enrollmentSource, double? score, string? certificateUrl, int page, int size)
        {
            var result = await _serviceProviders.CourseEnrollmentService.SearchAsync(enrollmentSource, score, certificateUrl, page, size);
            var soapItems = JsonMapper.Map<List<CourseEnrollmentDuyenCtt>, List<CourseEnrollmentDuyenCttSoapModel>>(result.Items);

            return new PaginationResultSoapModel<CourseEnrollmentDuyenCttSoapModel>(
                soapItems,
                result.TotalItems,
                result.PageIndex,
                result.PageSize
            );
        }

        public async Task<int> CreateAsync(CourseEnrollmentDuyenCttSoapModel courseEnrollment)
        {
            var repoModel = JsonMapper.Map<CourseEnrollmentDuyenCttSoapModel, CourseEnrollmentDuyenCtt>(courseEnrollment);
            return await _serviceProviders.CourseEnrollmentService.CreateAsync(repoModel);
        }

        public async Task<int> UpdateAsync(CourseEnrollmentDuyenCttSoapModel courseEnrollment)
        {
            var repoModel = JsonMapper.Map<CourseEnrollmentDuyenCttSoapModel, CourseEnrollmentDuyenCtt>(courseEnrollment);
            return await _serviceProviders.CourseEnrollmentService.UpdateAsync(repoModel);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _serviceProviders.CourseEnrollmentService.DeleteAsync(id);
        }
    }
}
