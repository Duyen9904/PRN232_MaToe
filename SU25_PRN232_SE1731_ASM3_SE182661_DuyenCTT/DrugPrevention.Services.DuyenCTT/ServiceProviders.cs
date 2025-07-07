using System;

namespace DrugPrevention.Services.DuyenCTT
{
    public interface IServiceProviders
    {
        SystemUserAccountService UserAccountService { get; }
        ICourseEnrollmentDuyenCTTServices CourseEnrollmentService { get; }
        ICourseDuyenCTTService CourseService { get; }
    }

    public class ServiceProviders : IServiceProviders
    {
        private SystemUserAccountService _systemUserAccountService;
        private ICourseEnrollmentDuyenCTTServices _courseEnrollmentDuyenCTTServices;
        private ICourseDuyenCTTService _courseService;

        public SystemUserAccountService UserAccountService
        {
            get { return _systemUserAccountService ??= new SystemUserAccountService(); }
        }

        public ICourseEnrollmentDuyenCTTServices CourseEnrollmentService
        {
            get { return _courseEnrollmentDuyenCTTServices ??= new CourseEnrollmentDuyenCTTServices(); }
        }

        public ICourseDuyenCTTService CourseService
        {
            get { return _courseService ??= new CourseDuyenCTTService(); }
        }
    }
}
