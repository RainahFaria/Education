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


		[HttpPost]
        [Route("AddSchool")]
		public async Task<IActionResult> AddSchool([FromBody]School newSchool)
		{
			return Ok(await _service.AddSchool(newSchool));
		}

		// [HttpPut]
        // [Route("UpdateSchool")]
		// public async Task<IActionResult> UpdateSchool([FromBody]School updatedSchool)
		// {
		// 	DataResponse<School> response = await _service.UpdateSchool(updatedSchool);

		// 	if (response.Data == null)
		// 	{
		// 		return NotFound();
		// 	}

		// 	return Ok(response);
		// }

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

    }
}
