using System.ComponentModel.DataAnnotations;

namespace DrugPrevention.APIServices.BE.DuyenCTT.DTOs
{
    public class CourseDuyenCttDto
    {
        public int CourseDuyenCttid { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200, ErrorMessage = "Title must be less than 200 characters.")]
        public string Title { get; set; }

        [StringLength(1000, ErrorMessage = "Description must be less than 1000 characters.")]
        public string Description { get; set; }

        [StringLength(500, ErrorMessage = "Target group must be less than 500 characters.")]
        public string TargetGroup { get; set; }

        public bool? IsActive { get; set; }
    }
}
