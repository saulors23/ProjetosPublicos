using ICommerceNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ICommerceNetCore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ClienteModel> TB_CLIENTES { get; set; }
        public DbSet<FornecedorModel> TB_FORNECEDORES { get; set; }
        public DbSet<ProdutosEstoqueModel> TB_PRODUTOS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProdutosEstoqueModel>()
                .Property(p => p.Preco_Custo)
                .HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<ProdutosEstoqueModel>()
                .Property(p => p.Preco_Venda)
                .HasColumnType("decimal(10, 2)");
        }
    }
}
