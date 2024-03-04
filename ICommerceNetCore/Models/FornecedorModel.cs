namespace ICommerceNetCore.Models
{
    public class FornecedorModel
    {
        public int? Id { get; set; }
        public string? Razao_Social { get; set; }
        public string? Cnpj { get; set; }
        public string? Inscricao_Estadual { get; set; }
        public string? Cep { get; set; }                
        public string? Endereco { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Ponto_Referencia { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
        public string? Nome_Contato { get; set; }
        public string? Fone_Fixo { get; set; }
        public string? Celular { get; set; }
        public string? Email { get; set; }                
        public DateTime? Data_Cadastro { get; set; } = DateTime.Now;
        public DateTime? Data_Alteracao { get; set; } 
    }
}
