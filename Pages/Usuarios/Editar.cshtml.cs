using App0502Aula.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App0502Aula.Pages.Usuarios
{
    public class EditarModel : PageModel
    {
        [BindProperty]
        public Usuario Usuario { get; set; }

        public void OnGet(int id) //receber este ID do usuario por parametro para detalhar -> carregando na memoria pra preencher os campos no html
        {
            //carregar a lista de usuarios... buscar do arquivo
            var usuarios = CarregarUsuarios(); //neste momento, tenho a lista de usuarios que estao cadastrados no meu txt
            //buscar o usuario pelo ID utilizando o método LINQ
            Usuario = usuarios.FirstOrDefault(u => u.Id == id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var linhas = System.IO.File.ReadAllLines("usuarios.txt").ToList();

            for(int i = 0; i < linhas.Count; i++)
            {
                var dados = linhas[i].Split(";");
                if (int.Parse(dados[0]) == Usuario.Id)
                {
                    linhas[i] = Usuario.Id + ";" + Usuario.Nome + ";" + Usuario.Senha + ";" + Usuario.Email;
                    break;
                }
            }
            System.IO.File.WriteAllLines("usuarios.txt", linhas);
            return RedirectToPage("/Usuarios/Index");
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
