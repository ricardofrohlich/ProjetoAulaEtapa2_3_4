using System.ComponentModel.DataAnnotations;

namespace App0502Aula.Model
{
    public class Usuario
    {
        [Required(ErrorMessage = "O ID é obrigatório!")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório!")]
        [MinLength(5, ErrorMessage = "O nome deve ter no mínimo 5 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(15, MinimumLength = 6,ErrorMessage = "A senha deve ter entre 6 e 15 caracteres")]
        public string Senha { get; set; }
        [EmailAddress(ErrorMessage = "O e-mail deve ser um edereço de e-mail válido")]
        public string Email { get; set; }
    }
}
