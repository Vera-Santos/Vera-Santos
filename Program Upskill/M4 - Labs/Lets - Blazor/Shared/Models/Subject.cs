using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorLets.Shared.Models
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }

        public string SubjectName { get; set; }

        [ForeignKey("CycleGradeCourseID")]
        public virtual CycleGradeCourse CycleGradeCourse { get; set; }
        public int CycleGradeCourseID { get; set; }

        public ICollection<Test> Tests { get; set; } = new List<Test>(); 
    }
}
