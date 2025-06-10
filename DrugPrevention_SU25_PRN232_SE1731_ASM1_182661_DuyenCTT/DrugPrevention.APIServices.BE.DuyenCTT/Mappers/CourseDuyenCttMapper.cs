using DrugPrevention.APIServices.BE.DuyenCTT.DTOs;
using DrugPrevention.Repositories.DuyenCTT.Models;

namespace DrugPrevention.APIServices.BE.DuyenCTT.Mappers
{
    public static class CourseDuyenCttMapper
    {
        public static CourseDuyenCttDto ToDto(this CourseDuyenCtt course)
        {
            if (course == null) return null;

            return new CourseDuyenCttDto
            {
                CourseDuyenCttid = course.CourseDuyenCttid,
                Title = course.Title,
                Description = course.Description,
                TargetGroup = course.TargetGroup,
                IsActive = course.IsActive
            };
        }

        public static CourseDuyenCtt ToEntity(this CourseDuyenCttDto courseDto)
        {
            if (courseDto == null) return null;
            return new CourseDuyenCtt
            {
                CourseDuyenCttid = courseDto.CourseDuyenCttid,
                Title = courseDto.Title,
                Description = courseDto.Description,
                TargetGroup = courseDto.TargetGroup,
                IsActive = courseDto.IsActive
            };
        }


        public static CourseEnrollmentDuyenCttDto ToDto(this CourseEnrollmentDuyenCtt enrollment)
        {
            if (enrollment == null) return null;

            return new CourseEnrollmentDuyenCttDto
            {
                EnrollmentDuyenCttid = enrollment.EnrollmentDuyenCttid,
                UserId = enrollment.UserId,
                CourseId = enrollment.CourseId,
                EnrolledAt = enrollment.EnrolledAt,
                Progress = enrollment.Progress,
                CompletedAt = enrollment.CompletedAt,
                Score = enrollment.Score,
                CertificateUrl = enrollment.CertificateUrl,
                IsCertified = enrollment.IsCertified,
                EnrollmentSource = enrollment.EnrollmentSource,
                Course = enrollment.Course?.ToDto()
            };
        }

        public static CourseEnrollmentDuyenCtt ToEntity(this CourseEnrollmentDuyenCttDto enrollmentDto)
        {
            if (enrollmentDto == null) return null;
            return new CourseEnrollmentDuyenCtt
            {
                EnrollmentDuyenCttid = enrollmentDto.EnrollmentDuyenCttid,
                UserId = enrollmentDto.UserId,
                CourseId = enrollmentDto.CourseId,
                EnrolledAt = enrollmentDto.EnrolledAt,
                Progress = enrollmentDto.Progress,
                CompletedAt = enrollmentDto.CompletedAt,
                Score = enrollmentDto.Score,
                CertificateUrl = enrollmentDto.CertificateUrl,
                IsCertified = enrollmentDto.IsCertified,
                EnrollmentSource = enrollmentDto.EnrollmentSource,
                Course = enrollmentDto.Course?.ToEntity()
            };
        }

        public static CourseEnrollmentDuyenCtt ToEntity(this CreateCourseEnrollmentDuyenCttDto dto)
        {
            if (dto == null) return null;

            return new CourseEnrollmentDuyenCtt
            {
                EnrollmentDuyenCttid = dto.EnrollmentDuyenCttid,
                UserId = dto.UserId,
                CourseId = dto.CourseId,
                EnrolledAt = dto.EnrolledAt,
                Progress = dto.Progress,
                CompletedAt = dto.CompletedAt,
                Score = dto.Score,
                CertificateUrl = dto.CertificateUrl,
                IsCertified = dto.IsCertified,
                EnrollmentSource = dto.EnrollmentSource,
                // Note: Course property omitted because it's for create/update input only
            };
        }

        public static CreateCourseEnrollmentDuyenCttDto ToCreateDto(this CourseEnrollmentDuyenCtt entity)
        {
            if (entity == null) return null;

            return new CreateCourseEnrollmentDuyenCttDto
            {
                EnrollmentDuyenCttid = entity.EnrollmentDuyenCttid,
                UserId = entity.UserId,
                CourseId = entity.CourseId,
                EnrolledAt = entity.EnrolledAt,
                Progress = entity.Progress,
                CompletedAt = entity.CompletedAt,
                Score = entity.Score,
                CertificateUrl = entity.CertificateUrl,
                IsCertified = entity.IsCertified,
                EnrollmentSource = entity.EnrollmentSource,
            };
        }
    }
}
