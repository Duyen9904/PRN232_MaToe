using DrugPrevention.BusinessObject.Shared.Models.SE182661.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseEnrollmentDuyenCTT.Microservices.SE182661.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseEnrollmentDuyenCTTController : ControllerBase
    {
        private readonly ILogger<CourseEnrollmentDuyenCTTController> _logger;
        private readonly IBus _bus;
        private List<CourseEnrollmentDuyenCtt> _courseEnrollments;

        public CourseEnrollmentDuyenCTTController(ILogger<CourseEnrollmentDuyenCTTController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
            _courseEnrollments = new List<CourseEnrollmentDuyenCtt>()
            {
                new CourseEnrollmentDuyenCtt
                {
                    EnrollmentDuyenCttid = 1,
                    UserId = 101,
                    CourseId = 201,
                    EnrolledAt = DateTime.Now,
                    Progress = 50,
                    CompletedAt = null,
                    Score = 85.5m,
                    CertificateUrl = "http://example.com/certificate/1",
                    IsCertified = true,
                    EnrollmentSource = "Online"
                },
                new CourseEnrollmentDuyenCtt
                {
                    EnrollmentDuyenCttid = 2,
                    UserId = 102,
                    CourseId = 202,
                    EnrolledAt = DateTime.Now.AddDays(-1),
                    Progress = 75,
                    CompletedAt = DateTime.Now.AddDays(-1),
                    Score = 90.0m,
                    CertificateUrl = "http://example.com/certificate/2",
                    IsCertified = true,
                    EnrollmentSource = "Offline"
                }
            };
         }
        // GET: api/<CourseEnrollmentDuyenCTTController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            // return courseenrollment
            return _courseEnrollments.Select(e => e.ToString()).ToList();
        }

        // GET api/<CourseEnrollmentDuyenCTTController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _courseEnrollments.FirstOrDefault(e => e.EnrollmentDuyenCttid == id)?.ToString() ?? "Not Found";
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
