using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TrainingManagement.CourseApi.Data;
using TrainingManagement.CourseApi.Models;

namespace TrainingManagement.CourseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class CourseApiController : ControllerBase
    {
        private readonly CourseDbContext _context;
        public CourseApiController(CourseDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ResponseDTO GetCourses()
        {
            ResponseDTO responseDTO = new ResponseDTO();
            try
            {
                var courses = _context.Courses.ToList();
                responseDTO.Data = courses;
                responseDTO.IsRequestProcessed = true;
                responseDTO.Message = "Course info retrieved successfully";
                responseDTO.StatusCode = 200;


                return responseDTO;
            }
            catch (Exception ex)
            {
                responseDTO.Message = "Error while retrieving the course details. Pls try again.";
                responseDTO.Data = null;
                responseDTO.IsRequestProcessed = false;
                responseDTO.Errors.Add(ex.Message);
                responseDTO.StatusCode = 500;
                return responseDTO;
            }
        }
        [HttpPost]
        public ResponseDTO PostCourses([FromBody] RequestDTO requestDto)
        {
            ResponseDTO responseDto = new ResponseDTO();
            var courseDetails = JsonConvert.DeserializeObject<Course[]>(requestDto.Data.ToString());
            for (int i = 0; i < courseDetails.Length; i++)
            {
                courseDetails[i].CourseID = new Random().Next(1, Int32.MaxValue / 2);
                _context.Courses.Add(courseDetails[i]);
                try
                {
                    var intRecords = _context.SaveChanges();
                    if (intRecords > 0)
                    {
                        responseDto.StatusCode = 201;
                        responseDto.Message = "Course details added successfully";
                        responseDto.IsRequestProcessed = true;
                    }
                    else
                    {
                        responseDto.IsRequestProcessed = false;
                        responseDto.Message = "Could not add new course details";
                    }
                }
                catch (Exception ex)
                {
                    responseDto.Message = "Error while adding the course details. Pls try again.";
                    responseDto.Data = null;
                    responseDto.IsRequestProcessed = false;
                    responseDto.Errors.Add(ex.Message);
                    responseDto.StatusCode = 500;
                    return responseDto;
                }
            }
            return responseDto;
        }

        [HttpPut]
        public ResponseDTO UpdateCourse([FromQuery] int courseID, [FromBody] RequestDTO requestDto)
        {
            //TODO: 
            throw new NotImplementedException();
        }

        [HttpPatch]
        public ResponseDTO UpdateCourseDetails([FromQuery] int courseID, [FromBody] RequestDTO requestDto)
        {
            //TODO: 
            throw new NotImplementedException();
        }

        [HttpDelete]
        public ResponseDTO DeleteCourse([FromQuery] int courseID)
        {
            //TODO: 
            throw new NotImplementedException();
        }

    }
}
