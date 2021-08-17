using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorLets.Shared.Models
{
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }

        [ForeignKey("TestID")]
        public virtual Test Test { get; set; }
        public int TestID { get; set; }

        public string QuestionText { get; set; }

        public bool IsActive { get; set; }

        public string SolutionText { get; set; }

        public int AnswerKey { get; set; }

        public byte[] Image { get; set; }

        public ICollection<Answer> Answers { get; set; } = new List<Answer>(); 
    }
}
