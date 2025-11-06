
using FiveMotors.InputModels;
using FiveMotors.Models;
using Microsoft.EntityFrameworkCore;

namespace FiveMotors.Data
{
    public class FiveMotorsContext : DbContext
    {
        public FiveMotorsContext(DbContextOptions<FiveMotorsContext> options) : base(options) { }

        public DbSet<Cliente> clientes { get; set; }

        public DbSet<Veiculo> veiculos { get; set; }

        public DbSet<Agendamento> agendamentos { get; set; }

        public DbSet<FormaDePagamento> formaDePagamamentos { get; set; }
        public DbSet<Venda> vendas { get; set; }

        public DbSet<ItemDaVenda> itemDaVendas { get; set; }

        public DbSet<EstoquePedido> estoquePedidos { get; set; }

        public DbSet<FaleComVendedor> faleComVendedors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("tbCliente");

            modelBuilder.Entity<Veiculo>().ToTable("tbVeiculo");

            modelBuilder.Entity<Agendamento>().ToTable("tbAgendamento");

            modelBuilder.Entity<FormaDePagamento>().ToTable("tbFormaDePagamento");

            modelBuilder.Entity<Venda>().ToTable("tbVenda");

            modelBuilder.Entity<ItemDaVenda>()
                .ToTable("tbItemDaVenda")
                .HasOne(iv => iv.Venda)
                .WithMany(v => v.ItemDaVenda)
                .HasForeignKey(iv => iv.VendaId)
                .OnDelete(DeleteBehavior.Restrict); // ou .NoAction()



            modelBuilder.Entity<EstoquePedido>().ToTable("tbEstoquePedido");

            modelBuilder.Entity<FaleComVendedor>().ToTable("tbFaleComVendedor");

            modelBuilder.Entity<ApplicationUser>()
            .HasOne(u => u.Cliente)
            .WithOne(c => c.User)
            .HasForeignKey<Cliente>(c => c.UserId);
        
    }
        }
   
}

