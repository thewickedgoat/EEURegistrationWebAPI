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
    public class PublicHolidayController : ApiController
    {
        private IRepository<PublicHoliday, int> publicHolidayRepository = new DLLFacade().GetPublicHolidayRepository(new ApplicationDbContext());

        // GET api/PublicHoliday
        //[Authorize]
        public IQueryable<PublicHoliday> GetPublicHoliday()
        {
            return new EnumerableQuery<PublicHoliday>(publicHolidayRepository.ReadAll());
        }

        /*
        * Looks through the database to check for a PublicHoliday with a matching id
        */
        private bool PublicHolidayInDatabase(int id)
        {
            return publicHolidayRepository.ReadById(id) != null;
        }

        // GET api/PublicHoliday/5
        //[Authorize]
        [ResponseType(typeof(PublicHoliday))]
        public IHttpActionResult GetPublicHoliday(int id)
        {
            PublicHoliday publicHoliday = publicHolidayRepository.ReadById(id);
            if (publicHoliday == null)
            {
                return NotFound();
            }

            return Ok(publicHoliday);
        }

        // POST api/PublicHoliday
        //[Authorize]
        [ResponseType(typeof(PublicHoliday))]
        public IHttpActionResult PostPublicHoliday(PublicHoliday publicHoliday)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            publicHoliday.Date = publicHoliday.Date.AddHours(4);
            publicHolidayRepository.Create(publicHoliday);

            return CreatedAtRoute("DefaultApi", new { id = publicHoliday.Id }, publicHoliday);
        }

        // PUT api/PublicHoliday/5
        //[Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPublicHoliday(int id, PublicHoliday publicHoliday)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != publicHoliday.Id)
            {
                return BadRequest();
            }
            publicHoliday.Date = publicHoliday.Date.AddHours(4);
            publicHolidayRepository.Update(publicHoliday);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/PublicHoliday/5
        //[Authorize]
        [ResponseType(typeof(int))]
        public IHttpActionResult DeletePublicHoliday(int id)
        {
            if (!PublicHolidayInDatabase(id))
            {
                return NotFound();
            }

            publicHolidayRepository.Delete(id);

            return Ok(id);
        }
    }
}
