using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Education.Models;
using Education.Services;

namespace Education.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ClassroomController : ControllerBase
    {
		private readonly IClassroomService _service;

		public ClassroomController(IClassroomService classroomService)
		{
			_service = classroomService;
		}

        [HttpGet("GetAll")]
		public async Task<IActionResult> Get()
		{
			return Ok(await _service.GetAllClassrooms());
		}


		[HttpPost]
        [Route("AddClassroom")]
		public async Task<IActionResult> AddClassroom([FromBody]Classroom newClassroom)
		{
			return Ok(await _service.AddClassroom(newClassroom));
		}

		[HttpPut]
		public async Task<IActionResult> UpdateClassroom(Classroom updatedClassroom)
		{
			DataResponse<Classroom> response = await _service.UpdateClassroom(updatedClassroom);

			if (response.Data == null)
			{
				return NotFound();
			}

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			DataResponse<List<Classroom>> response = await _service.DeleteClassroom(id);
			if (response.Data == null)
			{
				return NotFound();
			}

			return Ok(response);
		}

    }
}
