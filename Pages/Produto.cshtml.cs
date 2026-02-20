using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class ProdutoModel : PageModel
    {
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public void OnGet()
        {
            Descricao = "Pepsi Cola 2 litros";
            Preco = 8.99m;
        }
    }
}
