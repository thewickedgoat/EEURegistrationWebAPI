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

namespace EEUDataBase.Controllers
{
    public class DepartmentController : ApiController
    {
        private IDataBase<Department, int> departmentDB = new DLLFacade().GetDepartmentDB(new ApplicationDbContext());

        // GET api/Departments>
        //[Authorize]
        public IQueryable<Department> GetDepartments()
        {
            return new EnumerableQuery<Department>(departmentDB.ReadAll());
        }

        /*
         * Looks through the database to check for an department with a matching id
         */
        private bool DepartmentInDatabase(int id)
        {
            return departmentDB.ReadById(id) != null;
        }

        // GET api/Departments/5
        //[Authorize]
        [ResponseType(typeof(Department))]
        public IHttpActionResult GetDepartment(int id)
        {
            Department department = departmentDB.ReadById(id);
            if(department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        // POST api/Departments
        //[Authorize(Roles = "Administrator")]
        [ResponseType(typeof(Department))]
        public IHttpActionResult PostDepartment(Department department)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            departmentDB.Create(department);

            return CreatedAtRoute("DefaultApi", new { id = department.Id }, department);
        }

        // PUT api/Departments/5
        //[Authorize(Roles = "Administrator")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDepartment(int id, Department department)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != department.Id)
            {
                return BadRequest();
            }
            departmentDB.Update(department);
        
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/Departments/5
        //[Authorize(Roles = "Administrator")]
        [ResponseType(typeof(Department))]
        public IHttpActionResult DeleteDepartment(int id)
        {
            if (!DepartmentInDatabase(id))
            {
                return NotFound();
            }

            departmentDB.Delete(id);
            return Ok();
        }
    }
}