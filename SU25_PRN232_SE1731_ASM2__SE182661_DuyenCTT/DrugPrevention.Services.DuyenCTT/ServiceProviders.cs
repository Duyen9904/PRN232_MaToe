using System;

namespace DrugPrevention.Services.DuyenCTT
{
    public interface IServiceProviders
    {
        SystemUserAccountService UserAccountService { get; }
        ICourseEnrollmentDuyenCTTServices CourseEnrollmentService { get; }
        ICourseService CourseService { get; }
    }

    public class ServiceProviders : IServiceProviders
    {
        private SystemUserAccountService _systemUserAccountService;
        private ICourseEnrollmentDuyenCTTServices _courseEnrollmentDuyenCTTServices;
        private ICourseService _courseService;

        public SystemUserAccountService UserAccountService
        {
            get { return _systemUserAccountService ??= new SystemUserAccountService(); }
        }

        public ICourseEnrollmentDuyenCTTServices CourseEnrollmentService
        {
            get { return _courseEnrollmentDuyenCTTServices ??= new CourseEnrollmentDuyenCTTServices(); }
        }

        public ICourseService CourseService
        {
            get { return _courseService ??= new CourseService(); }
        }
    }
}
