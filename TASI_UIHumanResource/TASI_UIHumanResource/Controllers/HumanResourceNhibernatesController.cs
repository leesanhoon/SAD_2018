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
    public class HumanResourceNhibernatesController : Controller
    {

        string url = "http://localhost:50402/api/humanresource";
        HttpClient client;

        public HumanResourceNhibernatesController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private HumanResourceNhibernateDBContext db = new HumanResourceNhibernateDBContext();

        // GET: HumanResourceNhibernates
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
                List<HumanResourceNhibernate> Employees = JsonConvert.DeserializeObject<List<HumanResourceNhibernate>>(responseData, settings);
                return View(Employees);

            }
            return View("Error");
        }

        // GET: HumanResourceNhibernates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HumanResourceNhibernate humanResourceNhibernate = db.HumanResourceNhibernates.Find(id);
            if (humanResourceNhibernate == null)
            {
                return HttpNotFound();
            }
            return View(humanResourceNhibernate);
        }

        // GET: HumanResourceNhibernates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HumanResourceNhibernates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Fullname,Email,Phone,Status")] HumanResourceNhibernate humanResourceNhibernate)
        {
            if (ModelState.IsValid)
            {
                db.HumanResourceNhibernates.Add(humanResourceNhibernate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(humanResourceNhibernate);
        }

        // GET: HumanResourceNhibernates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HumanResourceNhibernate humanResourceNhibernate = db.HumanResourceNhibernates.Find(id);
            if (humanResourceNhibernate == null)
            {
                return HttpNotFound();
            }
            return View(humanResourceNhibernate);
        }

        // POST: HumanResourceNhibernates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Fullname,Email,Phone,Status")] HumanResourceNhibernate humanResourceNhibernate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(humanResourceNhibernate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(humanResourceNhibernate);
        }

        // GET: HumanResourceNhibernates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HumanResourceNhibernate humanResourceNhibernate = db.HumanResourceNhibernates.Find(id);
            if (humanResourceNhibernate == null)
            {
                return HttpNotFound();
            }
            return View(humanResourceNhibernate);
        }

        // POST: HumanResourceNhibernates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HumanResourceNhibernate humanResourceNhibernate = db.HumanResourceNhibernates.Find(id);
            db.HumanResourceNhibernates.Remove(humanResourceNhibernate);
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
