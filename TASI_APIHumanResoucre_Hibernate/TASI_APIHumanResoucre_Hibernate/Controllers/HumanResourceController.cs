using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TASI_APIHumanResoucre_Hibernate.Models;
using NHibernate;
using NHibernate.Linq;

namespace TASI_APIHumanResoucre_Hibernate.Controllers
{
    public class HumanResourceController : ApiController
    {
        //NHibernate Session  
        ISession session = NHibernateSession.OpenSession();
        //Get All Employee  
        public List<HumanResource> GetListRecruiment()
        {
            List<HumanResource> employee = session.Query<HumanResource>().ToList();
            return employee;
        }
        //Add New Employee  
        [HttpPost]
        public HttpResponseMessage AddNewEmployee(HumanResource employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(employee);
                        transaction.Commit();
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, "Success");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error !");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        //GetEmployeeData  
        [HttpGet]
        public HumanResource DetailsEmployee(int id)
        {
            var employee = session.Get<HumanResource>(id);
            return employee;
        }
        //UpdateEmployee  
        [HttpPut]
        public HttpResponseMessage UpdateEmployee(HumanResource employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var emp = session.Get<HumanResource>(employee.Id);
                    emp.Fullname = employee.Fullname;
                    emp.Email = employee.Email;
                    emp.Phone = employee.Phone;
                    emp.Status = employee.Status;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(emp);
                        transaction.Commit();
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, "Success");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error !");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        //Delete Employee  
        [HttpDelete]
        public HttpResponseMessage DeleteEmployee(int Id)
        {
            try
            {
                var employee = session.Get<HumanResource>(Id);
                if (employee != null)
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(employee);
                        transaction.Commit();
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, "Success");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error !");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
