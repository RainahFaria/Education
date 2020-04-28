
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Education.Data;
using Education.Models;

namespace Education.Services
{
	public class SchoolService : ISchoolService
	{
		private readonly DataContext _dBContext;
           public SchoolService(DataContext context)
        {
            _dBContext = context;
        }

		public async Task<DataResponse<List<School>>> GetAllSchools()
		{
			DataResponse<List<School>> dataResponse = new DataResponse<List<School>>();
			dataResponse.Data =  _dBContext.Schools.ToList();
			dataResponse.Status = "success";

			return dataResponse;
		}

		public async Task<DataResponse<List<School>>> AddSchool(School newSchool)
		{
			_dBContext.Schools.Add(newSchool);
			_dBContext.SaveChanges();

			DataResponse<List<School>> dataResponse = new DataResponse<List<School>>();
		    dataResponse.Data = _dBContext.Schools.ToList();
			dataResponse.Status = "success";

			return dataResponse;
		}
		public async Task<DataResponse<School>> UpdateSchool(School updatedSchool)
		{
			DataResponse<School> dataResponse = new DataResponse<School>();

			try
			{
				School school = _dBContext.Schools.Where(c => c.Id == updatedSchool.Id).FirstOrDefault();
				school.Name = updatedSchool.Name;

				_dBContext.Schools.Update(school);
				_dBContext.SaveChanges(); 

				dataResponse.Data = school;
				dataResponse.Status = "success";
			}
			catch (Exception ex)
			{
				dataResponse.Status = "error";
				dataResponse.Message = ex.Message;
				dataResponse.Data = null;
			}

			return dataResponse;
		}

		public async Task<DataResponse<List<School>>> DeleteSchool(int id)
		{
			DataResponse<List<School>> dataResponse = new DataResponse<List<School>>();

			try
			{
				School school = _dBContext.Schools.Where(c => c.Id == id).FirstOrDefault();
				_dBContext.Schools.Remove(school);
				_dBContext.SaveChanges();

				dataResponse.Data = _dBContext.Schools.ToList();
				dataResponse.Status = "success";
			}
			catch (Exception ex)
			{
				dataResponse.Status = "error";
				dataResponse.Message = ex.Message;
				dataResponse.Data = null;
			}

			return dataResponse;
		}

    }
}