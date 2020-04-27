using System.Collections.Generic;
using System.Threading.Tasks;
using Education.Models;

namespace Education.Services
{
	public interface ISchoolService
	{
		Task<DataResponse<List<School>>> GetAllSchools();
		Task<DataResponse<School>> GetSchoolById(int id);
		Task<DataResponse<List<School>>> AddSchool(School newSchool);
		Task<DataResponse<School>> UpdateSchool(School updatedSchool);
		Task<DataResponse<List<School>>> DeleteSchool(int id);
	}
}
