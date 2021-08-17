using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorLets.Shared.Models
{
    [NotMapped]
    public class UserWithRoles
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telemovel { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Role { get; set; }
        public bool IsChecked { get; set; }
        public string Texto { get; set; }= "Selecione o Id do utilizador para o editar";
    }
}
