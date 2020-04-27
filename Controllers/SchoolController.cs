using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Education.Models;
using Education.Services;

namespace Education.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _service;

		public SchoolController(ISchoolService schoolService)
		{
			_service = schoolService;
		}

        [HttpGet("GetAll")]
		public async Task<IActionResult> Get()
		{
			return Ok(await _service.GetAllSchools());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetSingle(int id)
		{
			return Ok(await _service.GetSchoolById(id));
		}

		[HttpPost]
        [Route("AddSchool")]
		public async Task<IActionResult> AddSchool([FromBody]School newSchool)
		{
			return Ok(await _service.AddSchool(newSchool));
		}

		[HttpPut]
		public async Task<IActionResult> UpdateSchool(School updatedSchool)
		{
			DataResponse<School> response = await _service.UpdateSchool(updatedSchool);

			if (response.Data == null)
			{
				return NotFound();
			}

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			DataResponse<List<School>> response = await _service.DeleteSchool(id);
			if (response.Data == null)
			{
				return NotFound();
			}

			return Ok(response);
		}

		

        // [HttpGet]
        // [Route("Get")]
        // public ActionResult<List<School>> GetSchools()
        // {
        //     try
        //     {
        //         var school = _context.Schools.ToList();
        //         return school;
        //     }
        //     catch (System.Exception)
        //     {
        //         return StatusCode((int)HttpStatusCode.InternalServerError);
        //     }
        // }


        // [HttpPost]
        // [Route("AddSchool")]
        // public IActionResult AddSchool([FromBody]School school)
        // {
        //     try
        //     {
        //         if (ModelState.IsValid)
        //         {
        //             _context.Schools.Add(school);
        //             _context.SaveChanges();
        //             return Ok(new DataResponse { Message = "Escola cadastrada com sucesso.", Status = "success", Data = school });
        //         }
        //         else
        //         {
        //             return BadRequest(ModelState);
        //         }
        //     }
        //     catch (System.Exception)
        //     {
        //         return StatusCode((int)HttpStatusCode.InternalServerError);
        //     }

        // }


        // [HttpPut("{id}")]
        // [Route("UpdateSchool")]
        // public IActionResult UpdateSchoolByID(int id, [FromBody]School school)
        // {
        //     try
        //     {
        //         if (ModelState.IsValid && school.Id == id)
        //         {
        //             var schoolDb = _context.Schools.FirstOrDefault(s => s.Id == id);
        //             if (schoolDb == null)
        //                 return NotFound();

        //             _context.Schools.Update(schoolDb);
        //             _context.SaveChanges();

        //             return new NoContentResult();
        //         }
        //         else
        //         {
        //             return BadRequest(ModelState);
        //         }
        //     }
        //     catch (System.Exception)
        //     {

        //         return StatusCode((int)HttpStatusCode.InternalServerError);
        //     }


        // }

        // [HttpDelete]
        // [Route("DeleteSchool")]
        // public IActionResult DeleteSchoolByID(int id)
        // {
        //     try
        //     {
        //         var school = _context.Schools.FirstOrDefault(i => i.Id == id);
        //         if (school == null)
        //             return NotFound();

        //         _context.Schools.Remove(school);
        //         _context.SaveChanges();

        //         return new NoContentResult();
        //     }
        //     catch (System.Exception)
        //     {
        //         return StatusCode((int)HttpStatusCode.InternalServerError);
        //     }

        // }


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
