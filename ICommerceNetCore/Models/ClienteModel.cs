namespace ICommerceNetCore.Models
{
    public class ClienteModel
    {
        public int? Id { get; set; }
        public string? Nome { get; set; } 
        public string? Cpf { get; set; }
        public string? Rg { get; set; }
        public string? Cep { get; set; }
        public string? Endereco { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Ponto_Referencia { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
        public string? Fone_Fixo { get; set; }
        public string? Celular { get; set; }
        public string? Email { get; set; }
        public string? Empresa { get; set; }
        public string? Cnpj { get; set; }
        public DateTime? Data_Cadastro { get; set; } = DateTime.Now;
        public DateTime? Data_Alteracao { get; set; }
    }
}
