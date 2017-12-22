using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EEUDataBase_DLL.Models;
using EEUDataBase_DLL.Interfaces;
using EEUDataBase_DLL.Entities;
using EEUDataBase_DLL.Facade;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EEUDataBase.Controllers
{
    public class EmployeeController : ApiController
    {
        private IDataBase<Employee, int> employeeDB = new DLLFacade().GetEmployeeDB(new ApplicationDbContext());

        // GET api/Employees
        public IQueryable<Employee> GetEmployees()
        {
            return new EnumerableQuery<Employee>(employeeDB.ReadAll());
        }

        /*
         * Looks through the database to check for an employee with a matching id
         */
        private bool EmployeeInDatabase(int id)
        {
            return employeeDB.ReadById(id) != null;
        }

        // GET api/Employees/5
        [Authorize]
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = employeeDB.ReadById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // POST api/employee
        [Authorize]
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            employeeDB.Create(employee);

            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
        }

        // PUT api/Employees/5
        //[Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != employee.Id)
            {
                return BadRequest();
            }
            employeeDB.Update(employee);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/Employees/5
        //[Authorize]
        [ResponseType(typeof(int))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            if (!EmployeeInDatabase(id))
            {
                return NotFound();
            }

            employeeDB.Delete(id);

            return Ok(id);
        }
    }
}