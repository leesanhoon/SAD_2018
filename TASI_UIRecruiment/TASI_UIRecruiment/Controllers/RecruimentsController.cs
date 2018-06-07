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
using TASI_UIRecruiment.Models;

namespace TASI_UIRecruiment.Controllers
{
    public class RecruimentsController : Controller
    {

        string url = "http://localhost:54684/api/recruiment";
        HttpClient client;

        public RecruimentsController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private RecruimentDBContext db = new RecruimentDBContext();

        // GET: Recruiments
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
                List<Recruiment> recruiment = JsonConvert.DeserializeObject<List<Recruiment>>(responseData, settings);
                return View(recruiment);

            }
            return View("Error");
        }

        







    }
}
