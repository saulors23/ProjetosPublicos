using ICommerceNetCore.Data;
using ICommerceNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ICommerceNetCore.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        #region Lista todos os Clientes do Cadastro
        public async Task<List<ClienteModel>> GetClientes()
        {
            var clientes = await _context.TB_CLIENTES.ToListAsync();

            if (clientes == null) throw new System.Exception("Não existe registros de Clientes!");

            return clientes ?? new List<ClienteModel>();
        }
        #endregion

        #region Lista Cliente por Id
        public ClienteModel GetClienteById(int id)
        {
            return _context.TB_CLIENTES.FirstOrDefault(c => c.Id == id);
        }
        #endregion

        #region Adiciona um Novo Cliente
        public bool CpfExists(string cpf)
        {            
            return _context.TB_CLIENTES.Any(c => c.Cpf == cpf);
        }
        public void AddCliente(ClienteModel cliente)
        {
            _context.TB_CLIENTES.Add(cliente);
            _context.SaveChanges();
        }
        #endregion

        #region Edita os Dados de um Cliente
        public void UpdateCliente(ClienteModel cliente)
        {
            try
            {                
                var entry = _context.Entry(cliente);
                if (entry.State == EntityState.Detached)
                {
                    _context.Attach(cliente);
                    entry.State = EntityState.Modified;
                }

                var dataCadastroOriginal = entry.Property(e => e.Data_Cadastro).OriginalValue;

                cliente.Data_Alteracao = DateTime.Now;

                entry.Property(e => e.Data_Cadastro).OriginalValue = dataCadastroOriginal;

                entry.Property(e => e.Data_Cadastro).IsModified = false;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar o Cliente por ID: {ex.Message}", ex);
            }
        }
        #endregion

        #region Exclui os Dados de um Cliente
        public void DeleteCliente(int id)
        {
            var clienteToRemove = _context.TB_CLIENTES.FirstOrDefault(c => c.Id == id);
            if (clienteToRemove != null)
            {
                _context.TB_CLIENTES.Remove(clienteToRemove);
                _context.SaveChanges();
            }
        }
        #endregion
    }
}
