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

        private IAbsenceRepository absenceRepository = new DLLFacade().GetAbsenceRepository(new ApplicationDbContext());

        //[Authorize]
        // GET: api/Absences
        public IQueryable<Absence> GetAbsences()
        {
            return new EnumerableQuery<Absence>(absenceRepository.ReadAll());
        }

        /*
         * Looks through the database to check for an absence with a matching id
         */
        private bool AbsenceInDatabase(int id)
        {
            return absenceRepository.ReadById(id) != null;
        }

        // GET: api/Absences/5
        //[Authorize]
        [ResponseType(typeof(Absence))]
        public IHttpActionResult GetAbsence(int id)
        {
            Absence absence = absenceRepository.ReadById(id);
            if(absence == null)
            {
                return NotFound();
            }
            return Ok(absence);
        }
        //[Authorize]
        public IQueryable<Absence> GetIntervalAbsence(DateTime startDate, DateTime endDate)
        {
            return new EnumerableQuery<Absence>(absenceRepository.ReadFromDateToDate(startDate, endDate));
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
            absence.Date = absence.Date.AddHours(4);
            absenceRepository.Create(absence);

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
            absence.Date = absence.Date.AddHours(4);


            //checks that the incoming Id is matching with the ID on the absence to update 
            if (id != absence.Id)
            {
                return BadRequest();
            }
            absenceRepository.Update(absence);

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

            absenceRepository.Delete(id);

            return Ok(id);
        }
    }
}
