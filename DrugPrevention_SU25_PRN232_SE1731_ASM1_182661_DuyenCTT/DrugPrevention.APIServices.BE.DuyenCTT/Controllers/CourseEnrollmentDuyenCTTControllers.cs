using DrugPrevention.APIServices.BE.DuyenCTT.DTOs;
using DrugPrevention.APIServices.BE.DuyenCTT.Mappers;
using DrugPrevention.Repositories.DuyenCTT.ModelExtensions;
using DrugPrevention.Repositories.DuyenCTT.Models;
using DrugPrevention.Services.DuyenCTT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DrugPrevention.APIServices.BE.DuyenCTT.Controllers
{
    [Route("api/course-enrollments")]
    [ApiController]
    [Authorize]
    public class CourseEnrollmentDuyenCTTControllers : ControllerBase
    {
        private readonly ICourseEnrollmentDuyenCTTServices _courseEnrollmentDuyenCTTServices;

        public CourseEnrollmentDuyenCTTControllers(ICourseEnrollmentDuyenCTTServices courseEnrollmentDuyenCTTServices)
        {
            _courseEnrollmentDuyenCTTServices = courseEnrollmentDuyenCTTServices;
        }

        // GET: api/CourseEnrollmentDuyenCTT?pageIndex=1&pageSize=10
        [HttpGet]
        [Authorize(Roles = "1,2")]
        public async Task<ActionResult<PaginationResult<CourseEnrollmentDuyenCttDto>>> Get([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _courseEnrollmentDuyenCTTServices.GetAllAsync(pageIndex, pageSize);
            var dtoResult = new PaginationResult<CourseEnrollmentDuyenCttDto>(
                result.Items.Select(e => e.ToDto()).ToList(),
                result.TotalItems,
                result.PageIndex,
                result.PageSize
            );
            return Ok(dtoResult);
        }

        // GET api/CourseEnrollmentDuyenCTT/5
        [HttpGet("{id}")]
        [Authorize(Roles = "1,2")]
        public async Task<ActionResult<CourseEnrollmentDuyenCttDto>> Get(int id)
        {
            var result = await _courseEnrollmentDuyenCTTServices.GetByIdAsync(id);
            if (result == null || result.EnrollmentDuyenCttid == 0)
                return NotFound();
            return Ok(result.ToDto());
        }

        // POST api/CourseEnrollmentDuyenCTT
        [HttpPost]
        [Authorize(Roles = "1,2")]
        public async Task<ActionResult<int>> Post([FromBody] CreateCourseEnrollmentDuyenCttDto createDto)
        {
            var entity = createDto.ToEntity();
            var id = await _courseEnrollmentDuyenCTTServices.CreateAsync(entity);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1,2")]
        public async Task<ActionResult<int>> Put(int id, [FromBody] CreateCourseEnrollmentDuyenCttDto updateDto)
        {
            if (id != updateDto.EnrollmentDuyenCttid)
                return BadRequest("ID mismatch");

            var entity = updateDto.ToEntity();
            var result = await _courseEnrollmentDuyenCTTServices.UpdateAsync(entity);
            return Ok(result);
        }


        // DELETE api/CourseEnrollmentDuyenCTT/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var success = await _courseEnrollmentDuyenCTTServices.DeleteAsync(id);
            if (!success)
                return NotFound();
            return Ok(success);
        }

        // GET api/CourseEnrollmentDuyenCTT/search?enrollmentSource=abc&score=85&title=xyz&pageIndex=1&pageSize=10
        [HttpGet("search")]
        [Authorize(Roles = "1,2")]
        public async Task<ActionResult<PaginationResult<CourseEnrollmentDuyenCttDto>>> Search(
            [FromQuery] string? enrollmentSource,
            [FromQuery] double? score,
            [FromQuery] string? title,
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 10)
        {
            var result = await _courseEnrollmentDuyenCTTServices.SearchAsync(
                enrollmentSource, score, title, pageIndex, pageSize);

            var dtoResult = new PaginationResult<CourseEnrollmentDuyenCttDto>(
                result.Items.Select(e => e.ToDto()).ToList(),
                result.TotalItems,
                result.PageIndex,
                result.PageSize
            );

            return Ok(dtoResult);
        }

    }


}
