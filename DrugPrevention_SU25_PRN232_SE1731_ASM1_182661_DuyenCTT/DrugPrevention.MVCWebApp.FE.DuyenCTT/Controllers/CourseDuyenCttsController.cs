using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DrugPrevention.Repositories.DuyenCTT.DBContext;
using DrugPrevention.Repositories.DuyenCTT.Models;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace DrugPrevention.MVCWebApp.FE.DuyenCTT.Controllers
{
    [Authorize]
    public class CourseDuyenCTTController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "https://localhost:7003/api/courses"; 

        public CourseDuyenCTTController(IHttpClientFactory httpClientFactory)
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

        // GET: CourseDuyenCTTController
        public async Task<IActionResult> Index()
        {
            AddJwtHeader();
            var response = await _httpClient.GetAsync(_apiBaseUrl );
            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var courses = JsonConvert.DeserializeObject<List<CourseDuyenCtt>>(json);

            return View(courses);
        }

        // GET: CourseDuyenCTTController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            AddJwtHeader();
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var course = JsonConvert.DeserializeObject<CourseDuyenCtt>(json);

            return View(course);
        }

        // GET: CourseDuyenCTTController/Create
        public IActionResult Create()
        {
            AddJwtHeader();
            return View();
        }

        // POST: CourseDuyenCTTController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseDuyenCtt course)
        {
            AddJwtHeader();
            if (!ModelState.IsValid)
                return View(course);

            var jsonContent = new StringContent(JsonConvert.SerializeObject(course), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_apiBaseUrl, jsonContent);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction(nameof(Index));
        }

        // GET: CourseDuyenCTTController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            AddJwtHeader();
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var course = JsonConvert.DeserializeObject<CourseDuyenCtt>(json);

            return View(course);
        }

        // POST: CourseDuyenCTTController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourseDuyenCtt course)
        {
            AddJwtHeader();
            if (id != course.CourseDuyenCttid)
                return BadRequest();

            var jsonContent = new StringContent(JsonConvert.SerializeObject(course), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_apiBaseUrl}/{id}", jsonContent);

            if (!response.IsSuccessStatusCode)
                return View("Error");

            return RedirectToAction(nameof(Index));
        }

        // GET: CourseDuyenCTTController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            AddJwtHeader();
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var course = JsonConvert.DeserializeObject<CourseDuyenCtt>(json);

            return View(course);
        }

        // POST: CourseDuyenCTTController/Delete/5
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
    }
}
