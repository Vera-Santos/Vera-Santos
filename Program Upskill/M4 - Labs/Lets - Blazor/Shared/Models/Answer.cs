using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorLets.Shared.Models
{
    public class Answer
    {
        [Key]
        public int AnswerID { get; set; }

        [ForeignKey("QuestionID")]
        public virtual Question Question { get; set; }
        public int QuestionID { get; set; }

        public string AnswerText { get; set; }
    }
}
