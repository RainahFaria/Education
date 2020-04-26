using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Education.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Net;
using System.Reflection;
using Education.Data;

namespace Education.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SchoolController : ControllerBase
    {
        private DataContext _context;
           public SchoolController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Get")]
        public ActionResult<List<School>> GetSchools()
        {
            try
            {
                var school = _context.Schools.ToList();
                return school;
            }
            catch (System.Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


        [HttpPost]
        [Route("AddSchool")]
        public IActionResult AddSchool([FromBody]School school)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Schools.Add(school);
                    _context.SaveChanges();
                    return Ok(new DataResponse { Message = "Escola cadastrada com sucesso.", Status = "success", Data = school });
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (System.Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }


        [HttpPut("{id}")]
        [Route("UpdateSchool")]
        public IActionResult UpdateSchoolByID(int id, [FromBody]School school)
        {
            try
            {
                if (ModelState.IsValid && school.Id == id)
                {
                    var schoolDb = _context.Schools.FirstOrDefault(s => s.Id == id);
                    if (schoolDb == null)
                        return NotFound();

                    _context.Schools.Update(schoolDb);
                    _context.SaveChanges();

                    return new NoContentResult();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (System.Exception)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError);
            }


        }

        [HttpDelete]
        [Route("DeleteSchool")]
        public IActionResult DeleteSchoolByID(int id)
        {
            try
            {
                var school = _context.Schools.FirstOrDefault(i => i.Id == id);
                if (school == null)
                    return NotFound();

                _context.Schools.Remove(school);
                _context.SaveChanges();

                return new NoContentResult();
            }
            catch (System.Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }


        // [HttpGet]
        // [Route("")]
        // public async Task<ActionResult<List<School>>> Get([FromServices] DataContext context)
        // {
        //     var school = await context.Schools.ToListAsync();
        //     return school;
        // }

        // [HttpPost]
        // [Route("")]
        // public async Task<ActionResult<School>> Post(
        //     [FromServices] DataContext context,
        //     [FromBody] School model)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         context.Schools.Add(model);
        //         await context.SaveChangesAsync();
        //         return model;
        //     }
        //     else
        //     {
        //         return BadRequest(ModelState);
        //     }
        // }
    }
}
