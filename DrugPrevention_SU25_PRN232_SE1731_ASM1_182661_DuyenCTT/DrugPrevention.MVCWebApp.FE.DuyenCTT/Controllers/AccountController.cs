using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DrugPrevention.MVCWebApp.FE.DuyenCTT.Models;

namespace DrugPrevention.MVCWebApp.FE.DuyenCTT.Controllers
{
    public class AccountController : Controller
    {
        private string APIEndPoint = "https://localhost:7003/api/";
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsJsonAsync(APIEndPoint + "SystemUserAccounts/Login", loginRequest))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var tokenString = await response.Content.ReadAsStringAsync();

                            // Debug print token string
                            Console.WriteLine("JWT Token Response: " + tokenString);

                            var tokenHandler = new JwtSecurityTokenHandler();
                            var jwtToken = tokenHandler.ReadToken(tokenString) as JwtSecurityToken;

                            if (jwtToken != null)
                            {
                                var userName = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
                                var roleId = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

                                // Debug print claims
                                Console.WriteLine("Username from token: " + userName);
                                Console.WriteLine("Role from token: " + roleId);

                                var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, userName),
                            new Claim(ClaimTypes.Role, roleId),
                        };

                                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                                // Save to cookies
                                Response.Cookies.Append("UserName", userName);
                                Response.Cookies.Append("Role", roleId);
                                Response.Cookies.Append("TokenString", tokenString);
                                HttpContext.Session.SetString("JWToken", tokenString);

                                // Redirect after login
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                Console.WriteLine("Failed to parse JWT token.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Login API call failed with status: " + response.StatusCode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception during login: " + ex.Message);
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                ModelState.AddModelError("", "Login failure");
                return View();
            }

            // Only redirect if success happens inside the if block
            ModelState.AddModelError("", "Login failed");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            //// Do sign-out
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //// Delete cookies
            Response.Cookies.Delete("UserName");
            Response.Cookies.Delete("Role");
            Response.Cookies.Delete("TokenString");

            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> Forbidden()
        {
            return View();
        }
    }
}
