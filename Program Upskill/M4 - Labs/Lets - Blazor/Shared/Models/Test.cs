using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorLets.Shared.Models
{
    public class Test
    {
        [Key]
        public int TestID { get; set; }

        public int NumberOfQuestions { get; set; }

        public decimal MinimalScore { get; set; }

        [ForeignKey("SubjectID")]
        public virtual Subject Subject { get; set; }
        public int SubjectID { get; set; }

        public string Title { get; set; }

        public ICollection<Question> Questions { get; set; } = new List<Question>(); 
    }
}
