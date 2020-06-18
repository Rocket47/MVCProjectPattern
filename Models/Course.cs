using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MVCApps.Models
{
    public class Course
    {
        [Key]
        public int course_ID {get; set;}
        public string name {get; set;}
        public string description {get; set;}        
    }
}

