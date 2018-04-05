using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Collections.Generic;
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
    public class MonthController : ApiController
    {
        private IMonthRepository monthRepository = new DLLFacade().GetMonthRepository(new ApplicationDbContext());

        //[Authorize]
        // GET: api/Months
        public IQueryable<Month> GetMonths()
        {
            return new EnumerableQuery<Month>(monthRepository.ReadAll());
        }

        /*
         * Looks through the database to check for a Month with a matching id
         */
        private bool MonthInDatabase(int id)
        {
            return monthRepository.ReadById(id) != null;
        }

        // GET: api/Months/5
        //[Authorize]
        [ResponseType(typeof(Month))]
        public IHttpActionResult GetMonth(int id)
        {
            Month month = monthRepository.ReadById(id);
            if (month == null)
            {
                return NotFound();
            }
            return Ok(month);
        }

        // POST: api/Month
        //[Authorize]
        [ResponseType(typeof(Month))]
        public IHttpActionResult PostMonth(Month month)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            month.MonthDate.AddHours(4);
            monthRepository.Create(month);

            return CreatedAtRoute("DefaultAPI", new { id = month.Id }, month);
        }

        //[Route("List")]
        //[ResponseType(typeof(List<Month>))]
        //public IHttpActionResult CreateList(List<Month> months)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    monthRepository.CreateMonths(months);

        //    return Ok(months);
        //}

        // PUT: api/Month/5
        //[Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMonth(int id, Month month)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            //checks that the incoming Id is matching with the ID on the month to update 
            if (id != month.Id)
            {
                return BadRequest();
            }
            monthRepository.Update(month);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Month/5
        //[Authorize]
        [ResponseType(typeof(Month))]
        public IHttpActionResult DeleteMonth(int id)
        {
            if (!MonthInDatabase(id))
            {
                return NotFound();
            }

            monthRepository.Delete(id);

            return Ok(id);
        }
    }
}
