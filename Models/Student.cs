using System.ComponentModel.DataAnnotations;

namespace MVCApps.Models
{
    public class Student
    {
        [Key]
        public int student_ID {get;set;}       
        public string first_Name {get;set;}
        public string last_Name {get;set;}
        public Group Group { get; set; }
    }
}