using App0502Aula.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace App0502Aula.Pages.Usuarios
{

    public class CriarModel : PageModel
    {
        [BindProperty]
        public Usuario Usuario { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) //verificando se o modelo de dado é válido
            {
                Console.WriteLine("eu nao estou mentindo, isso vai funcionar no EF");
                return Page();
            }
            else
            {
                int id = Usuario.Id; //armazenando aqui pra eu nao perder o id que exclui pra mostrar a mensagem que foi excluido
                string nome = Usuario.Nome; //nome também pra mostrar na mensagem;
                TempData["Mensagem"] = id + " - " + nome + " cadastrado com sucesso!";
                TempData["MensagemTipo"] = "success";
                using (var writer = new StreamWriter("usuarios.txt", true))
                {
                    writer.WriteLine(Usuario.Id + ";" + Usuario.Nome + ";" + Usuario.Senha + ";" + Usuario.Email);
                    return RedirectToPage("/Usuarios/Index");
                }
            }
          
        }
    }
}
