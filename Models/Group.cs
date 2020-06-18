using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCApps.Models
{
    public class Group
    {
        [Key]
        public int group_ID { get; set; }        
        public string name { get; set; }
        public Course Course { get; set; }      
    }
}