using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebAPI1.Models;
using System.Data;
using System.Data.Entity;

namespace WebAPI1.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeAPIEntities db = new EmployeeAPIEntities();
        public HttpResponseMessage Get()
        {
            var employee = db.Employees.ToList();

            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }

        public string Post(Employee employee)
        {
            try
            {
                db.Employees.Add(employee);
                db.SaveChanges();

                return "Employee added successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public string Put(int id, Employee employee)
        {
            try
            {
                Employee updUmp = db.Employees.Find(id);
                updUmp.Name = employee.Name;
                updUmp.Department = employee.Department;
                updUmp.MailID = employee.MailID;
                updUmp.DOJ = employee.DOJ;

                db.Entry(updUmp).State = EntityState.Modified;
                db.SaveChanges();

                return "Departement Updated successfully";
            }
            catch(Exception e)
            {
                return e.Message;
            }

        }

        public string Delete(int id)
        {
            try
            {
                Employee deleUmp = db.Employees.Find(id);
                db.Employees.Remove(deleUmp);
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
