using DrugPrevention.Repositories.DuyenCTT.Models;
using DrugPrevention.Services.DuyenCTT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DrugPrevention.APIServices.BE.DuyenCTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseEnrollmentDuyenCTTControllers : ControllerBase
    {
        private readonly ICourseEnrollmentDuyenCTTServices _courseEnrollmentDuyenCTTServices;

        public CourseEnrollmentDuyenCTTControllers(ICourseEnrollmentDuyenCTTServices courseEnrollmentDuyenCTTServices)
        {
            _courseEnrollmentDuyenCTTServices = courseEnrollmentDuyenCTTServices;
        }


        // GET: api/<CourseEnrollmentDuyenCTTController>
        [HttpGet]
        public async Task<IEnumerable<CourseEnrollment>> Get()
        {
           return await _courseEnrollmentDuyenCTTServices.GetAllAsync();
        }

        // GET api/<CourseEnrollmentDuyenCTTController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CourseEnrollmentDuyenCTTController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CourseEnrollmentDuyenCTTController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CourseEnrollmentDuyenCTTController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
