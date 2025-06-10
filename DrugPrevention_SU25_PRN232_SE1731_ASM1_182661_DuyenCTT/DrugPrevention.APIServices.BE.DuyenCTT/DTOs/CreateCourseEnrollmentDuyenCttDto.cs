namespace DrugPrevention.APIServices.BE.DuyenCTT.DTOs
{
    public class CreateCourseEnrollmentDuyenCttDto
    {
        public int EnrollmentDuyenCttid { get; set; }
        public int? UserId { get; set; }
        public int? CourseId { get; set; }
        public DateTime? EnrolledAt { get; set; }
        public int? Progress { get; set; }
        public DateTime? CompletedAt { get; set; }
        public decimal? Score { get; set; }
        public string CertificateUrl { get; set; }
        public bool? IsCertified { get; set; }
        public string EnrollmentSource { get; set; }

    }
}
