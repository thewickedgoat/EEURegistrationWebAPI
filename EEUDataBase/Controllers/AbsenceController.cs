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
    public class AbsenceController : ApiController
    {

        private IAbsenceDB absenceDB = new DLLFacade().GetAbsenceDB(new ApplicationDbContext());

        //[Authorize]
        // GET: api/Absences
        public IQueryable<Absence> GetAbsences()
        {
            return new EnumerableQuery<Absence>(absenceDB.ReadAll());
        }

        /*
         * Looks through the database to check for an absence with a matching id
         */
        private bool AbsenceInDatabase(int id)
        {
            return absenceDB.ReadById(id) != null;
        }

        // GET: api/Absences/5
        //[Authorize]
        [ResponseType(typeof(Absence))]
        public IHttpActionResult GetAbsence(int id)
        {
            Absence absence = absenceDB.ReadById(id);
            if(absence == null)
            {
                return NotFound();
            }
            return Ok(absence);
        }

        public IQueryable<Absence> GetIntervalAbsence(DateTime startDate, DateTime endDate)
        {
            return new EnumerableQuery<Absence>(absenceDB.ReadFromDateToDate(startDate, endDate));
        }

        // POST: api/Absence
        //[Authorize]
        [ResponseType(typeof(Absence))]
        public IHttpActionResult PostAbsence(Absence absence)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            absenceDB.Create(absence);

            return CreatedAtRoute("DefaultAPI", new { id = absence.Id }, absence);
        }

        // PUT: api/Absence/5
        //[Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAbsence(int id, Absence absence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            //checks that the incoming Id is matching with the ID on the absence to update 
            if(id != absence.Id)
            {
                return BadRequest();
            }
            absenceDB.Update(absence);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Absence/5
        //[Authorize]
        [ResponseType(typeof(Absence))]
        public IHttpActionResult DeleteAbsence(int id)
        {
            if(!AbsenceInDatabase(id))
            {
                return NotFound();
            }

            absenceDB.Delete(id);

            return Ok();
        }
    }
}
