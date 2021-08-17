using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BlazorLets.Shared.Models
{
    public class Example
    {
        [Key]
        public int ExampleID { get; set; }

        [ForeignKey("SubjectID")]
        public virtual Subject Subject { get; set; }
        public int SubjectID { get; set; }

        public string Text { get; set; }

        public byte[] Image { get; set; }
    }
}
