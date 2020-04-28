
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Education.Data;
using Education.Models;

namespace Education.Services
{
	public class ClassroomService : IClassroomService
	{
		private readonly DataContext _dBContext;
           public ClassroomService(DataContext context)
        {
            _dBContext = context;
        }

		public async Task<DataResponse<List<Classroom>>> GetAllClassrooms()
		{
			DataResponse<List<Classroom>> dataResponse = new DataResponse<List<Classroom>>();
			dataResponse.Data =  _dBContext.Classrooms.ToList();
			dataResponse.Status = "success";

			return dataResponse;
		}

		public async Task<DataResponse<List<Classroom>>> AddClassroom(Classroom newClassroom)
		{			
			DataResponse<List<Classroom>> dataResponse = new DataResponse<List<Classroom>>();

			_dBContext.Classrooms.Add(newClassroom);
			_dBContext.SaveChangesAsync();

		    dataResponse.Data = _dBContext.Classrooms.ToList();
			dataResponse.Status = "success";

			return dataResponse;
		}
		public async Task<DataResponse<Classroom>> UpdateClassroom(Classroom updatedClassroom)
		{
			DataResponse<Classroom> dataResponse = new DataResponse<Classroom>();

			try
			{
				Classroom classroom = _dBContext.Classrooms.Where(c => c.Id == updatedClassroom.Id).FirstOrDefault();
				classroom.Room = updatedClassroom.Room;

				_dBContext.Classrooms.Update(classroom);
				_dBContext.SaveChanges(); 

				dataResponse.Data = classroom;
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

		public async Task<DataResponse<List<Classroom>>> DeleteClassroom(int id)
		{
			DataResponse<List<Classroom>> dataResponse = new DataResponse<List<Classroom>>();

			try
			{
				Classroom classroom = _dBContext.Classrooms.Where(c => c.Id == id).FirstOrDefault();
				_dBContext.Classrooms.Remove(classroom);
				_dBContext.SaveChanges();

				dataResponse.Data = _dBContext.Classrooms.ToList();
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