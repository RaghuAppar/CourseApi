using System.ComponentModel.DataAnnotations;

namespace TrainingManagement.CourseApi.Data
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
    
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int Duration { get; set; }

    }
}
