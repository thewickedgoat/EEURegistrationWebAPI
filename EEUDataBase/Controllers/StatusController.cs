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
    public class StatusController : ApiController
    {
        private IRepository<Status, int> statusRepository = new DLLFacade().GetStatusRepository(new ApplicationDbContext());

        // GET api/Status
        //[Authorize]
        public IQueryable<Status> GetStatuses()
        {
            return new EnumerableQuery<Status>(statusRepository.ReadAll());
        }
        
        /*
         * Looks through the database to check for a Status with a matching id
         */
        private bool StatusInDatabase(int id)
        {
            return statusRepository.ReadById(id) != null;
        }

        // GET api/Status/5
        //[Authorize]
        [ResponseType(typeof(Status))]
        public IHttpActionResult GetStatus(int id)
        {
            Status status = statusRepository.ReadById(id);
            if (status == null)
            {
                return NotFound();
            }

            return Ok(status);
        }

        // POST api/status
        //[Authorize]
        [ResponseType(typeof(Status))]
        public IHttpActionResult PostStatus(Status status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            statusRepository.Create(status);

            return CreatedAtRoute("DefaultApi", new { id = status.Id }, status);
        }

        // PUT api/Status/5
        //[Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatus(int id, Status status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != status.Id)
            {
                return BadRequest();
            }
            statusRepository.Update(status);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/Status/5
        //[Authorize]
        [ResponseType(typeof(int))]
        public IHttpActionResult DeleteStatus(int id)
        {
            if (!StatusInDatabase(id))
            {
                return NotFound();
            }

            statusRepository.Delete(id);

            return Ok(id);
        }
    }
}