using System.Collections.Generic;
using System.Threading.Tasks;
using Education.Models;

namespace Education.Services
{
	public interface IClassroomService
	{
		Task<DataResponse<List<Classroom>>> GetAllClassrooms();
		Task<DataResponse<Classroom>> GetClassroomById(int id);
		Task<DataResponse<List<Classroom>>> AddClassroom(Classroom newClassroom);
		Task<DataResponse<Classroom>> UpdateClassroom(Classroom updatedClassroom);
		Task<DataResponse<List<Classroom>>> DeleteClassroom(int id);
	}
}
