using TrainingManagement.CourseApi.Data;

namespace TrainingManagement.CourseApi.Models
{
    public class ResponseDTO
    {
        public object? Data { get; set; }
        public bool IsRequestProcessed { get; set; }
        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public List<string> Errors { get; set; }
        public DateTime ResponseTimestamp { get; set; } = DateTime.UtcNow;
        public int StatusCode { get; set; }
        public ResponseDTO()
        {
            Errors= new List<string>();
        }
    }
}
