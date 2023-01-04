using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using ClothingShopWeb.Data.Entities;

namespace ClothingShopWeb.Admin.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Loggin()
        {
            return View();
        }
        
        public async Task<IActionResult> Loggin(string userName,string password)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:44333/api/User/Loggin/{userName}/{password}");
            string apiReult = await response.Result.Content.ReadAsStringAsync();
            var st = JsonConvert.DeserializeObject<bool>(apiReult);
            if (st==true)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }
    }
}
