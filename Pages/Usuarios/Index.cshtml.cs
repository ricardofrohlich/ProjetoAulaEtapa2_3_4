using App0502Aula.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;

namespace App0502Aula.Pages.Usuarios
{
    public class IndexModel : PageModel
    {
        public List<Usuario> Usuarios { get; set; }
        public void OnGet()
        {
           Usuarios = new List<Usuario>();//instanciar uma lista que eu vou carregar do arquivo que eu estou salvando
            if (System.IO.File.Exists("usuarios.txt"))
            {
                //ler todo o arquivo..
                var linhas = System.IO.File.ReadAllLines("usuarios.txt");
                foreach (var linha in linhas)
                {
                    var dados = linha.Split(';');
                    //dados[0] = id
                    //dados[1] = nome
                    //dados[2] = senha
                    //dados[3] = email
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
        }
    }
}
