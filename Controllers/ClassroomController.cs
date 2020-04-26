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

    public class ClassroomController : ControllerBase
    {
        private DataContext _context;
           public ClassroomController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Get")]
        public ActionResult<List<Classroom>> GetClassrooms()
        {
            try
            {
                var classroom = _context.Classrooms.ToList();
                return classroom;
            }
            catch (System.Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult<Classroom> GetClassroomsById(int id)
        {
            try
            {
                var classroom = _context.Classrooms.Include(s => s.School)
                .SingleOrDefault(c => c.Id == id);
                return classroom;
            }
            catch (System.Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("GetBySchool")]
        public ActionResult<List<Classroom>> GetClassroomsBySchool([FromBody]int id)
        {
            try
            {
                var classroomList = _context.Classrooms.Include(s => s.School)
                .Where(c => c.School.Id == id)
                .ToList();
                return classroomList;
            }
            catch (System.Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


        [HttpPost]
        [Route("AddClassroom")]
        public IActionResult AddClassroom([FromBody]Classroom classroom)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var school = _context.Schools.FirstOrDefault(s => s.Id == classroom.SchoolId);
                    if (school == null)
                        return NotFound();

                    // classroom.School.Id = school.Id;
                    // classroom.School.Name = school.Name;
                    _context.Classrooms.Add(classroom);
                    _context.SaveChanges();
                    return Ok(new DataResponse { Message = "Escola cadastrada com sucesso.", Status = "success", Data = classroom });
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
               // return StatusCode((int)HttpStatusCode.InternalServerError);
                throw ex;
            }

        }


        [HttpPut("{id}")]
        [Route("UpdateSchool")]
        public IActionResult UpdateClassroomByID(int id, [FromBody]Classroom classroom)
        {
            try
            {
                if (ModelState.IsValid && classroom.Id == id)
                {
                    var classroomDb = _context.Classrooms.FirstOrDefault(s => s.Id == id);
                    if (classroomDb == null)
                        return NotFound();

                    _context.Classrooms.Update(classroomDb);
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
        [Route("DeleteClassroom")]
        public IActionResult DeleteClassroomByID(int id)
        {
            try
            {
                var classroom = _context.Classrooms.FirstOrDefault(i => i.Id == id);
                if (classroom == null)
                    return NotFound();

                _context.Classrooms.Remove(classroom);
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
