using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DrugPrevention.Repositories.DuyenCTT.DBContext;
using DrugPrevention.Repositories.DuyenCTT.Models;
using DrugPrevention.Services.DuyenCTT;
using DrugPrevention.Repositories.DuyenCTT.ModelExtensions;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Web;

namespace DrugPrevention.MVCWebApp.FE.DuyenCTT.Controllers
{
    [Authorize]
    public class CourseEnrollmentDuyenCttsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "https://localhost:7003/api/course-enrollments";

        public CourseEnrollmentDuyenCttsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }
        private void AddJwtHeader()
        {
            var token = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }


        // GET: CourseEnrollmentDuyenCtts
        public async Task<IActionResult> Index(string enrollmentSource, double? score, string title, int pageIndex = 1, int pageSize = 10)
        {
            AddJwtHeader();

            var query = HttpUtility.ParseQueryString(string.Empty);
            if (!string.IsNullOrEmpty(enrollmentSource)) query["enrollmentSource"] = enrollmentSource;
            if (score.HasValue) query["score"] = score.ToString();
            if (!string.IsNullOrEmpty(title)) query["title"] = title;
            query["pageIndex"] = pageIndex.ToString();
            query["pageSize"] = pageSize.ToString();

            var url = $"{_apiBaseUrl}/search?{query}";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaginationResult<CourseEnrollmentDuyenCtt>>(json);
            if (result == null || result.Items == null || !result.Items.Any())
            {
                TempData["Message"] = "No data";
                return View("Index", new List<CourseEnrollmentDuyenCtt>());
            }

            ViewBag.PageIndex = result.PageIndex;
            ViewBag.TotalPages = result.TotalPages;
            ViewBag.PageSize = result.PageSize;
            ViewBag.SearchParams = new { enrollmentSource, score, title };

            return View(result.Items);
        }


        // GET: CourseEnrollmentDuyenCtts/Details/5
        public async Task<IActionResult> Details(int id)
        {
            AddJwtHeader();
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<CourseEnrollmentDuyenCtt>(json);
            return View(item);
        }

        // GET: CourseEnrollmentDuyenCtts/Create
        public IActionResult Create()
        {
            AddJwtHeader();
            return View();
        }

        // POST: CourseEnrollmentDuyenCtts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseEnrollmentDuyenCtt enrollment)
        {
            AddJwtHeader();
            if (!ModelState.IsValid)
                return View(enrollment);

            var jsonContent = new StringContent(JsonConvert.SerializeObject(enrollment), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_apiBaseUrl, jsonContent);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction(nameof(Index));
        }

        // GET: CourseEnrollmentDuyenCtts/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            AddJwtHeader();
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<CourseEnrollmentDuyenCtt>(json);
            return View(item);
        }

        // POST: CourseEnrollmentDuyenCtts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourseEnrollmentDuyenCtt enrollment)
        {
            AddJwtHeader();
            if (id != enrollment.EnrollmentDuyenCttid)
                return BadRequest();

            var jsonContent = new StringContent(JsonConvert.SerializeObject(enrollment), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_apiBaseUrl}/{id}", jsonContent);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction(nameof(Index));
        }

        // GET: CourseEnrollmentDuyenCtts/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            AddJwtHeader();
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<CourseEnrollmentDuyenCtt>(json);
            return View(item);
        }

        // POST: CourseEnrollmentDuyenCtts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            AddJwtHeader();
            var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Search(string enrollmentSource, double? score, string title)
        {
            AddJwtHeader();

            var query = new List<string>();
            if (!string.IsNullOrWhiteSpace(enrollmentSource))
                query.Add($"enrollmentSource={Uri.EscapeDataString(enrollmentSource)}");
            if (score.HasValue)
                query.Add($"score={score.Value}");
            if (!string.IsNullOrWhiteSpace(title))
                query.Add($"title={Uri.EscapeDataString(title)}");

            string queryString = string.Join("&", query);
            var url = $"{_apiBaseUrl}/search?{queryString}";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaginationResult<CourseEnrollmentDuyenCtt>>(json);
            if (result == null || result.Items == null || !result.Items.Any())
            {
                TempData["Message"] = "No data";
                return View("Index", new List<CourseEnrollmentDuyenCtt>());
            }


            return View("Index", result.Items);
        }

    }
}
