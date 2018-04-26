using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
    public class WorkfreeDayController : ApiController
    {
        private IWorkfreeDayRepository workfreeDayRepository = new DLLFacade().GetWorkfreeDayRepository(new ApplicationDbContext());

        // GET api/WorkfreeDay
        [Authorize]
        public IQueryable<WorkfreeDay> GetAll()
        {
            return new EnumerableQuery<WorkfreeDay>(workfreeDayRepository.ReadAll());
        }

        /*
        * Looks through the database to check for a WorkfreeDay with a matching id
        */
        private bool WorkfreeDayInDatabase(int id)
        {
            return workfreeDayRepository.ReadById(id) != null;
        }

        // GET api/WorkfreeDay/5
        [Authorize]
        [ResponseType(typeof(WorkfreeDay))]
        public IHttpActionResult GetById(int id)
        {
            WorkfreeDay workfreeDay = workfreeDayRepository.ReadById(id);
            if (workfreeDay == null)
            {
                return NotFound();
            }

            return Ok(workfreeDay);
        }

        // POST api/WorkfreeDay
        [Authorize]
        [ResponseType(typeof(WorkfreeDay))]
        public IHttpActionResult Post(WorkfreeDay workfreeDay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            workfreeDay.Date = workfreeDay.Date.AddHours(4);
            workfreeDayRepository.Create(workfreeDay);

            return CreatedAtRoute("DefaultApi", new { id = workfreeDay.Id }, workfreeDay);
        }
        [Authorize]
        [ResponseType(typeof(List<WorkfreeDay>))]
        public IHttpActionResult PostList(List<WorkfreeDay> workfreeDays)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            workfreeDayRepository.CreateWorkfreeDays(workfreeDays);

            return Ok(workfreeDays);
        }

        // PUT api/WorkfreeDay/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, WorkfreeDay workfreeDay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != workfreeDay.Id)
            {
                return BadRequest();
            }
            workfreeDay.Date = workfreeDay.Date.AddHours(4);
            workfreeDayRepository.Update(workfreeDay);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/WorkfreeDay/5
        [Authorize]
        [ResponseType(typeof(int))]
        public IHttpActionResult Delete(int id)
        {
            if (!WorkfreeDayInDatabase(id))
            {
                return NotFound();
            }

            workfreeDayRepository.Delete(id);

            return Ok(id);
        }
    }
}
