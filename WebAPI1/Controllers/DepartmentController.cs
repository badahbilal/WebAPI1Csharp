using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI1.Models;
using System.Data.Entity;

namespace WebAPI1.Controllers
{
    public class DepartmentController : ApiController
    {
        EmployeeAPIEntities db = new EmployeeAPIEntities();

        public HttpResponseMessage Get()
        {
            //var departments = db.Departments.Where(x => x.id == 5).FirstOrDefault();
            var departments = db.Departments.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, departments);
        }

        public string Post(Department department)
        {
            try
            {
                db.Departments.Add(department);
                db.SaveChanges();

                return "Depratment added successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public string Put(int id ,Department department)
        {
            try
            {
                Department dep = db.Departments.Find(id);
                dep.name = department.name;
                db.Entry(dep).State = EntityState.Modified;
                db.SaveChanges();
                return "Departement Updated successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public string Delete(int id)
        {      
            try
            {
                Department deleDep = db.Departments.Find(id);
                db.Departments.Remove(deleDep);
                db.SaveChanges();

                return "Departement Deleted successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
