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
    public class HolidayYearSpecController : ApiController
    {
        private IRepository<HolidayYearSpec, int> holidayYearSpecRepository = new DLLFacade().GetHolidayYearSpecRepository(new ApplicationDbContext());

        //[Authorize]
        // GET: api/Months
        public IQueryable<HolidayYearSpec> GetAll()
        {
            return new EnumerableQuery<HolidayYearSpec>(holidayYearSpecRepository.ReadAll());
        }

        /*
         * Looks through the database to check for a HolidayYear with a matching id
         */
        private bool HolidayYearInDatabase(int id)
        {
            return holidayYearSpecRepository.ReadById(id) != null;
        }

        // GET: api/HolidayYearSpec/5
        //[Authorize]
        [ResponseType(typeof(HolidayYearSpec))]
        public IHttpActionResult GetById(int id)
        {
            HolidayYearSpec holidayYearSpec = holidayYearSpecRepository.ReadById(id);
            if (holidayYearSpec == null)
            {
                return NotFound();
            }
            return Ok(holidayYearSpec);
        }

        // POST: api/HolidayYearSpec
        //[Authorize]
        [ResponseType(typeof(HolidayYearSpec))]
        public IHttpActionResult Post(HolidayYearSpec holidayYearSpec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            holidayYearSpecRepository.Create(holidayYearSpec);

            return CreatedAtRoute("DefaultAPI", new { id = holidayYearSpec.Id }, holidayYearSpec);
        }

        // PUT: api/HolidayYearSpec/5
        //[Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, HolidayYearSpec holidayYearSpec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //checks that the incoming Id is matching with the ID on the holidayYear to update 
            if (id != holidayYearSpec.Id)
            {
                return BadRequest();
            }
            holidayYearSpecRepository.Update(holidayYearSpec);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/HolidayYearSpec/5
        //[Authorize]
        [ResponseType(typeof(HolidayYearSpec))]
        public IHttpActionResult Delete(int id)
        {
            if (!HolidayYearInDatabase(id))
            {
                return NotFound();
            }

            holidayYearSpecRepository.Delete(id);

            return Ok(id);
        }
    }
}
