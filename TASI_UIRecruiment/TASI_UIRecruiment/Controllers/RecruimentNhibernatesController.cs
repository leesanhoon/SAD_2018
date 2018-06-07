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
    public class RecruimentNhibernatesController : Controller
    {

        string url = "http://localhost:49841/api/recruiment";
        HttpClient client;

        public RecruimentNhibernatesController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private RecruimentNhibernateDBContext db = new RecruimentNhibernateDBContext();

        // GET: RecruimentNhibernates
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
                List<RecruimentNhibernate> Employees = JsonConvert.DeserializeObject<List<RecruimentNhibernate>>(responseData, settings);
                return View(Employees);

            }
            return View("Error");
        }

        // GET: RecruimentNhibernates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecruimentNhibernate recruimentNhibernate = db.RecruimentNhibernate.Find(id);
            if (recruimentNhibernate == null)
            {
                return HttpNotFound();
            }
            return View(recruimentNhibernate);
        }

        // GET: RecruimentNhibernates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecruimentNhibernates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Fullname,Email,Phone,Status")] RecruimentNhibernate recruimentNhibernate)
        {
            if (ModelState.IsValid)
            {
                db.RecruimentNhibernate.Add(recruimentNhibernate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recruimentNhibernate);
        }

        // GET: RecruimentNhibernates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecruimentNhibernate recruimentNhibernate = db.RecruimentNhibernate.Find(id);
            if (recruimentNhibernate == null)
            {
                return HttpNotFound();
            }
            return View(recruimentNhibernate);
        }

        // POST: RecruimentNhibernates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Fullname,Email,Phone,Status")] RecruimentNhibernate recruimentNhibernate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recruimentNhibernate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recruimentNhibernate);
        }

        // GET: RecruimentNhibernates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecruimentNhibernate recruimentNhibernate = db.RecruimentNhibernate.Find(id);
            if (recruimentNhibernate == null)
            {
                return HttpNotFound();
            }
            return View(recruimentNhibernate);
        }

        // POST: RecruimentNhibernates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecruimentNhibernate recruimentNhibernate = db.RecruimentNhibernate.Find(id);
            db.RecruimentNhibernate.Remove(recruimentNhibernate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
