using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payment_api.Models;

namespace Payment_api.Context
{
    public class PagamentoApiContext : DbContext
    {
        public PagamentoApiContext(DbContextOptions<PagamentoApiContext> options) : base(options)
        {
            
        }
        public DbSet<VendaItem> vendaItem{ get; set; }
        public DbSet<Vendedor> Vendedor{ get; set; }
        public DbSet<CompraItem> Compra{ get; set; }
    }
}