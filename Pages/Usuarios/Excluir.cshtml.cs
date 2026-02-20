using App0502Aula.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App0502Aula.Pages.Usuarios
{
    public class ExcluirModel : PageModel
    {
        [BindProperty]
        public Usuario Usuario { get; set; }
        public IActionResult OnGet(int id)
        {
            var usuarios = CarregarUsuarios();
            Usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if(Usuario == null)
            {
                Response.StatusCode = 404; //definindo o status de resposta 404 = notfound
                ModelState.AddModelError(string.Empty, "Usuário não encontrado");
            }
            return Page(); //retornou aqui, se seguiu a execução e tem modelo de dado, ele vai mostrar pra verificar a exclusão


        }

        public IActionResult OnPost()
        {
            if (Usuario == null)
            {
                TempData["Mensagem"] = "Usuário não encontrado";
                TempData["MensagemTipo"] = "warning";
                return RedirectToPage("Index");
            }
            var usuarios = CarregarUsuarios();
            var usuarioExistente = usuarios.FirstOrDefault(u => u.Id == Usuario.Id);
            if(usuarioExistente != null)
            {
                int id = usuarioExistente.Id; //armazenando aqui pra eu nao perder o id que exclui pra mostrar a mensagem que foi excluido
                string nome = usuarioExistente.Nome; //nome também pra mostrar na mensagem;
                TempData["Mensagem"] = id + " - " + nome + " excluido com sucesso!";
                usuarios.Remove(usuarioExistente);

                var linhas = new List<string>();
                foreach(var usuario in usuarios)
                {
                    linhas.Add(usuario.Id + ";" + usuario.Nome + ";" + usuario.Senha + ";" + usuario.Email);
                }
                System.IO.File.WriteAllLines("usuarios.txt", linhas);
            }
            return RedirectToPage("Index");

        }

        private List<Usuario> CarregarUsuarios()
        {
            var Usuarios = new List<Usuario>();
            if (System.IO.File.Exists("usuarios.txt"))
            {
                var linhas = System.IO.File.ReadAllLines("usuarios.txt");
                foreach (var linha in linhas)
                {
                    var dados = linha.Split(";");
                    var usuario = new Usuario()
                    {
                        Id = int.Parse(dados[0]),
                        Nome = dados[1],
                        Senha = dados[2],
                        Email = dados[3]
                    };
                    Usuarios.Add(usuario);
                }
            }
            return Usuarios;
        }
    }
}
