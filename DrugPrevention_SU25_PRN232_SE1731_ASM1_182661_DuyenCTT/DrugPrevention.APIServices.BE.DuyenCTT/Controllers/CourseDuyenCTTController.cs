using DrugPrevention.APIServices.BE.DuyenCTT.DTOs;
using DrugPrevention.APIServices.BE.DuyenCTT.Mappers;
using DrugPrevention.Services.DuyenCTT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrugPrevention.APIServices.BE.DuyenCTT.Controllers
{
    [Route("api/courses")]
    [ApiController]
    [Authorize]
    public class CourseDuyenCTTController : ControllerBase
    {
        private readonly ICourseDuyenCTTService _courseService;

        public CourseDuyenCTTController(ICourseDuyenCTTService courseService)
        {
            _courseService = courseService;
        }

        // GET: api/courses
        [HttpGet]
        [Authorize(Roles = "1,2")]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllAsync();
            var courseDtos = courses.Select(c => c.ToDto()).ToList();
            return Ok(courseDtos);
        }

        // GET: api/courses/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
                return NotFound();

            return Ok(course.ToDto());
        }

        // POST: api/courses
        [HttpPost]
        [Authorize(Roles = "1,2")]
        public async Task<IActionResult> CreateCourse([FromBody] CourseDuyenCttDto courseDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var course = courseDto.ToEntity();
            await _courseService.CreateAsync(course);
            return Ok(); // Or CreatedAtAction(...) if you want to return the new course
        }

        // PUT: api/courses/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "1,2")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseDuyenCttDto courseDto)
        {
            if (id != courseDto.CourseDuyenCttid)
                return BadRequest("Course ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedEntity = courseDto.ToEntity();
            var result = await _courseService.UpdateAsync(updatedEntity);

            if (result == 0)
                return NotFound();

            return Ok();
        }

        // DELETE: api/courses/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var success = await _courseService.DeleteAsync(id);
            if (!success)
                return NotFound();

            return Ok();
        }
    }
}
