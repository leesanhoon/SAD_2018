using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TASI_UIHumanResource.Models;

namespace TASI_UIHumanResource.Controllers
{
    public class HumanResourcesController : Controller
    {
        string url = "http://localhost:54859/api/humanresources";
        HttpClient client;

        public HumanResourcesController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private HumanResourceDBContext db = new HumanResourceDBContext();

        // GET: HumanResources
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                };
                List<HumanResource> Employees = JsonConvert.DeserializeObject<List<HumanResource>>(responseData, settings);
                return View(Employees);

            }
            return View("Error");
        }

        
    }
}
