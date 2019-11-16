using Microsoft.EntityFrameworkCore;
using OpenBankingApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBankingApi.Infrastructure
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options): base(options) { }

        #region DbSet
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ClienteTipo> ClienteTipo { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<ContaTipo> ContaTipos { get; set; }
        public DbSet<TransacaoTipo> TransacaoTipos { get; set; }
        public DbSet<Transacao> Transacaoes { get; set; }
        #endregion DbSet

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Pessoa>().HasOne(p => p.Endereco).WithOne(e => e.Pessoa).HasForeignKey<Endereco>(e => e.PessoaId);
            builder.Entity<Cliente>().HasOne(c => c.Pessoa).WithOne(p => p.Cliente).HasForeignKey<Pessoa>(p => p.ClienteId);
        }
    }
}
