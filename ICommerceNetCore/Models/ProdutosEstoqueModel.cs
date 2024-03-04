using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICommerceNetCore.Models
{
    public class ProdutosEstoqueModel
    {
        public int? Id { get; set; }
        public string? Codigo { get; set; }
        public string? Descricao { get; set; }
        public string? Marca { get; set; }
        public decimal? Preco_Custo { get; set; }
        public decimal? Preco_Venda { get; set; }
        public int Estoque_Min { get; set; }
        public int Estoque_Max { get; set; }
        public DateTime? Data_Fabricacao { get; set; }
        public DateTime? Data_Validade { get; set; }
        public string? Fornecedor { get; set; }

    }
}
