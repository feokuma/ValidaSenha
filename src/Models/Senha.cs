using System.ComponentModel.DataAnnotations;

namespace ValidaSenha.Models
{
    public class Senha
    {
        [Required]
        public string input { get; set; }
    }
}
