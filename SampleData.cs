using System.Linq;
using MVCApps.Models;

namespace MVCApps
{
    public class SampleData
    {
        public static void Initialize(UniversityContext context) 
        {
            if (!context.Courses.Any())
            {
                context.Courses.AddRange(
                    new Course
                    {
                        course_ID = 1,
                        name = "Math",
                        description = "Learn Math",
                    },
                    new Course 
                    {
                        course_ID = 2,
                        name = "Physics",
                        description = "Learn Physics",
                    },
                    new Course
                    {
                        course_ID = 3,
                        name = "Literature",
                        description = "Learn Literature",
                    }                    
                );                
                context.SaveChanges();
            }
        }
    }
}