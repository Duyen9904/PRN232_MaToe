using System.ComponentModel.DataAnnotations;

namespace DrugPrevention.APIServices.BE.DuyenCTT.DTOs
{
    public class CourseEnrollmentDuyenCttDto
    {
        public int EnrollmentDuyenCttid { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public int? UserId { get; set; }

        [Required(ErrorMessage = "Course ID is required.")]
        public int? CourseId { get; set; }

        public DateTime? EnrolledAt { get; set; }

        [Range(0, 100, ErrorMessage = "Progress must be between 0 and 100.")]
        public int? Progress { get; set; }

        public DateTime? CompletedAt { get; set; }

        [Range(0.0, 10.0, ErrorMessage = "Score must be between 0.0 and 10.0.")]
        public decimal? Score { get; set; }

        [Url(ErrorMessage = "Certificate URL must be a valid URL.")]
        public string CertificateUrl { get; set; }

        public bool? IsCertified { get; set; }

        [StringLength(100, ErrorMessage = "Enrollment source must be less than 100 characters.")]
        public string EnrollmentSource { get; set; }

        public CourseDuyenCttDto Course { get; set; }
    }
}
