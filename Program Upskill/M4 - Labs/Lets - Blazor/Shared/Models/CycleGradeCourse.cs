using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorLets.Shared.Models
{
    public class CycleGradeCourse
    {
        [Key]
        public int CycleGradeCourseID { get; set; }

        public string Cycle { get; set; }

        public string Grade { get; set; }

        public string Course { get; set; }

        public ICollection<Subject> Subjects { get; set; } = new List<Subject>(); 
    }
}
