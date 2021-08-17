using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorLets.Shared.Models
{
    public class ReportedProblem
    {
        public int ReportedProblemID { get; set; }

        [Required(ErrorMessage = "E-mail obrigatório.")]
        [EmailAddress(ErrorMessage = "O endereço de e-mail não é válido.")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Texto obrigatório.")]
        public string Text { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public DateTime SubmissionDate { get; set; }

        public bool? Done { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public DateTime DoneDate { get; set; }
    }
}
