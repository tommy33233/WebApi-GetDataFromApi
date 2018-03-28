using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using getWebApiData.Models;
using Newtonsoft.Json;

namespace getWebApiData.Controllers
{
    public class HomeController : Controller
    {
        string Baseurl = "http://localhost:13247/";
        public async Task<ActionResult> Index()
        {
            List<Country> EmpInfo = new List<Country>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/values/");
                
                if (Res.IsSuccessStatusCode)
                {                    
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<List<Country>>(EmpResponse);

                }
                return View(EmpInfo);
            }
        }
    }
}