using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorLets.Shared.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }

        public decimal Score { get; set; }

        public bool HasSuccess { get; set; }

        public DateTime DoneTestAt { get; set; }

        [ForeignKey("TestID")]
        public virtual Test Test { get; set; }
        public int TestID { get; set; }

        [ForeignKey("Id")]
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
