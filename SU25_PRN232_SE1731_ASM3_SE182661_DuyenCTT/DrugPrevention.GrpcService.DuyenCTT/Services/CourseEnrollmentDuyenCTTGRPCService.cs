using Grpc.Core;
using DrugPrevention.GrpcService.DuyenCTT;
using DrugPrevention.Services.DuyenCTT;
using DrugPrevention.Repositories.DuyenCTT.Models;
using DrugPrevention.Repositories.DuyenCTT.Basic;

namespace DrugPrevention.GrpcService.DuyenCTT.Services
{
    public class CourseEnrollmentDuyenCTTGRPCService : CourseEnrollmentDuyenCTTGRPC.CourseEnrollmentDuyenCTTGRPCBase
    {
        private readonly IServiceProvider _serviceProvider;

        public CourseEnrollmentDuyenCTTGRPCService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private static CourseEnrollmentDuyenCtt ToEntity(CourseEnrollmentDuyenCTT grpc)
        {
            return new CourseEnrollmentDuyenCtt
            {
                //EnrollmentDuyenCttid = grpc.EnrollmentId,
                UserId = grpc.UserId,
                CourseId = grpc.CourseId,
                EnrolledAt = DateTime.TryParse(grpc.EnrolledAt, out var enrolledAt) ? enrolledAt : (DateTime?)null,
                CompletedAt = DateTime.TryParse(grpc.CompletedAt, out var completedAt) ? completedAt : (DateTime?)null,
                Score = (decimal)grpc.Score,
                CertificateUrl = grpc.CertificateUrl,
                IsCertified = grpc.IsCertified,
                EnrollmentSource = grpc.EnrollmentSource,
                Progress = grpc.Progress
            };
        }

        /*
         * 
         * public override async Task<MutationResult> UpdateAsync(TransactionCashDepositSlip request, ServerCallContext context)
{
    try
    {
 
        var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

 
        var protoJsonString = JsonSerializer.Serialize(request, opt);

 
        var item = JsonSerializer.Deserialize<zPayment.Repositories.VuLNS.Models.TransactionCashDepositSlip>(protoJsonString, opt);

        var result = await _serviceProviders.TransactionCashDepositSlipService.UpdateAsync(item);

        return new MutationResult() { Result = result };
    }
    catch (Exception ex) { }

    return new MutationResult() { Result = 0 };
}
         * 
         * 
         */


        private static CourseEnrollmentDuyenCTT ToGrpc(CourseEnrollmentDuyenCtt entity)
        {
            return new CourseEnrollmentDuyenCTT
            {
                //EnrollmentId = entity.EnrollmentDuyenCttid,
                UserId = entity.UserId ?? 0,
                CourseId = entity.CourseId ?? 0,
                EnrolledAt = entity.EnrolledAt?.ToString("o") ?? "",
                CompletedAt = entity.CompletedAt?.ToString("o") ?? "",
                Score = (double)(entity.Score ?? 0),
                CertificateUrl = entity.CertificateUrl ?? "",
                IsCertified = entity.IsCertified ?? false,
                EnrollmentSource = entity.EnrollmentSource ?? "",
                Progress = entity.Progress ?? 0
            };
        }

        public override async Task<CourseEnrollmentDuyenCTTGRPCList> GetAllAsync(EmptyRequest request, ServerCallContext context)
        {
            var service = _serviceProvider.GetRequiredService<ICourseEnrollmentDuyenCTTServices>();
            var result = await service.GetAllAsync(1, 10);

            var list = new CourseEnrollmentDuyenCTTGRPCList();
            list.Items.AddRange(result.Items.Select(ToGrpc));
            return list;
        }

        public override async Task<CourseEnrollmentDuyenCTT> GetByIdAsync(CourseEnrollmentDuyenCTTIdRequest request, ServerCallContext context)
        {
            var service = _serviceProvider.GetRequiredService<ICourseEnrollmentDuyenCTTServices>();
            var entity = await service.GetByIdAsync(request.CourseEnrollmentDuyenCTTId);
            if (entity == null)
                throw new RpcException(new Status(StatusCode.NotFound, "Not found"));

            return ToGrpc(entity);
        }

        public override async Task<Int32Value> CreateAsync(CourseEnrollmentDuyenCTT request, ServerCallContext context)
        {
            var service = _serviceProvider.GetRequiredService<ICourseEnrollmentDuyenCTTServices>();
            var entity = ToEntity(request);
            var id = await service.CreateAsync(entity);
            return new Int32Value { Value = id };
        }

        public override async Task<Int32Value> UpdateAsync(CourseEnrollmentDuyenCTT request, ServerCallContext context)
        {
            var service = _serviceProvider.GetRequiredService<ICourseEnrollmentDuyenCTTServices>();
            var entity = ToEntity(request);
            var id = await service.UpdateAsync(entity);
            return new Int32Value { Value = id };
        }

        public override async Task<BoolValue> DeleteAsync(CourseEnrollmentDuyenCTTIdRequest request, ServerCallContext context)
        {
            var service = _serviceProvider.GetRequiredService<ICourseEnrollmentDuyenCTTServices>();
            var result = await service.DeleteAsync(request.CourseEnrollmentDuyenCTTId);
            return new BoolValue { Value = result };
        }
    }

}
