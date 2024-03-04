using ICommerceNetCore.Data;
using ICommerceNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ICommerceNetCore.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly AppDbContext _context;

        public FornecedorRepository(AppDbContext context)
        {
            _context = context;
        }

        #region Lista todos os Fornecedores do Cadastro
        public async Task<List<FornecedorModel>> GetFornecedores()
        {
            var fornecedores = await _context.TB_FORNECEDORES.ToListAsync();

            if (fornecedores == null) throw new System.Exception("Não existe registros de Fornecedores!");

            return fornecedores ?? new List<FornecedorModel>();
        }
        #endregion

        #region Lista Fornecedor por Id
        public FornecedorModel GetFornecedorById(int id)
        {
            return _context.TB_FORNECEDORES.FirstOrDefault(c => c.Id == id);
        }
        #endregion

        #region Adiciona um Novo Fornecedor
        public bool CnpjExists(string cnpj)
        {            
            return _context.TB_FORNECEDORES.Any(c => c.Cnpj == cnpj);
        }
        public void AddFornecedor(FornecedorModel fornecedor)
        {
            _context.TB_FORNECEDORES.Add(fornecedor);
            _context.SaveChanges();
        }
        #endregion

        #region Edita os Dados de um Fornecedor
        public void UpdateFornecedor(FornecedorModel fornecedor)
        {
            try
            {                
                var entry = _context.Entry(fornecedor);
                if (entry.State == EntityState.Detached)
                {
                    _context.Attach(fornecedor);
                    entry.State = EntityState.Modified;
                }

                var dataCadastroOriginal = entry.Property(e => e.Data_Cadastro).OriginalValue;
                
                fornecedor.Data_Alteracao = DateTime.Now;

                entry.Property(e => e.Data_Cadastro).OriginalValue = dataCadastroOriginal;

                entry.Property(e => e.Data_Cadastro).IsModified = false;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar o Fornecedor por ID: {ex.Message}", ex);
            }
        }
        #endregion

        #region Exclui os Dados de um Fornecedor
        public void DeleteFornecedor(int id)
        {
            var fornecedorToRemove = _context.TB_FORNECEDORES.FirstOrDefault(c => c.Id == id);
            if (fornecedorToRemove != null)
            {
                _context.TB_FORNECEDORES.Remove(fornecedorToRemove);
                _context.SaveChanges();
            }
        }
        #endregion
    }
}
