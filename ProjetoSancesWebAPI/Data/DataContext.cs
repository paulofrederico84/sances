using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjetoSancesWebAPI.Models;

namespace ProjetoSancesWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoProduto> PedidoProduto { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cliente>()
                   .HasData(new List<Cliente>(){
                        new Cliente(1, "Marta", "08545685238", 33225555),
                        new Cliente(2, "Paula", "14785236998", 3354288),
                        new Cliente(3, "Laura", "98745632114", 55668899),
                        new Cliente(4, "Luiza", "95184763252", 6565659),
                        new Cliente(5, "Lucas", "96587412365", 565685415),
                        new Cliente(6, "Pedro", "85274196385", 456454545),
                        new Cliente(7, "Paulo", "32569874196", 987451852)
                    });

            builder.Entity<Produto>()
                   .HasData(new List<Produto>(){
                        new Produto(1, "Filtro Óleo", 12.25),
                        new Produto(2, "Embreagem", 145.60),
                        new Produto(3, "Pastilha Freio", 74.99),
                        new Produto(4, "Óleo Motor", 16.80),
                        new Produto(5, "Filtro Ar", 33.00),
                        new Produto(6, "Amortecedor", 120.65),
                        new Produto(7, "Mão de Obra", 80.00)
                    }); 

            builder.Entity<Pedido>()
                   .HasData(new List<Pedido>(){
                        new Pedido(1, new DateTime(2020,09,21,00,00,00), 5, 0, "Analise"),
                        new Pedido(2, new DateTime(2020,06,22,00,00,00), 1, 0, "Analise"),
                        new Pedido(3, new DateTime(2020,03,25,00,00,00), 7, 0, "Analise")
                        
                    });

            builder.Entity<PedidoProduto>()
                   .HasData(new List<PedidoProduto>(){
                        new PedidoProduto(1, 1, 1, 1, 0),
                        new PedidoProduto(2, 1, 4, 5, 0),  
                        new PedidoProduto(3, 2, 3, 1, 0),
                        new PedidoProduto(4, 2, 6, 2, 0),
                        new PedidoProduto(5, 2, 7, 2, 0),
                        new PedidoProduto(6, 3, 5, 1, 0),
                        new PedidoProduto(7, 3, 2, 1, 0)
                    });                           
        }

    }
}