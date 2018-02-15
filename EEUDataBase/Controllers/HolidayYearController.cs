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
    public class HolidayYearController : ApiController
    {
        private IRepository<HolidayYear, int> holidayYearRepository = new DLLFacade().GetHolidayYearRepository(new ApplicationDbContext());

        //[Authorize]
        // GET: api/Months
        public IQueryable<HolidayYear> GetHolidayYears()
        {
            return new EnumerableQuery<HolidayYear>(holidayYearRepository.ReadAll());
        }

        /*
         * Looks through the database to check for a HolidayYear with a matching id
         */
        private bool HolidayYearInDatabase(int id)
        {
            return holidayYearRepository.ReadById(id) != null;
        }

        // GET: api/HolidayYear/5
        //[Authorize]
        [ResponseType(typeof(HolidayYear))]
        public IHttpActionResult GetHolidayYear(int id)
        {
            HolidayYear holidayYear = holidayYearRepository.ReadById(id);
            if (holidayYear == null)
            {
                return NotFound();
            }
            return Ok(holidayYear);
        }

        // POST: api/HolidayYear
        //[Authorize]
        [ResponseType(typeof(HolidayYear))]
        public IHttpActionResult PostHolidayYear(HolidayYear holidayYear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            holidayYearRepository.Create(holidayYear);

            return CreatedAtRoute("DefaultAPI", new { id = holidayYear.Id }, holidayYear);
        }

        // PUT: api/HolidayYear/5
        //[Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHolidayYear(int id, HolidayYear holidayYear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //checks that the incoming Id is matching with the ID on the holidayYear to update 
            if (id != holidayYear.Id)
            {
                return BadRequest();
            }
            holidayYearRepository.Update(holidayYear);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/HolidayYear/5
        //[Authorize]
        [ResponseType(typeof(HolidayYear))]
        public IHttpActionResult DeleteHolidayYear(int id)
        {
            if (!HolidayYearInDatabase(id))
            {
                return NotFound();
            }

            holidayYearRepository.Delete(id);

            return Ok(id);
        }
    }
}
