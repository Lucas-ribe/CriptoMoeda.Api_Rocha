using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Context
{
    public class HistoricoContext : DbContext
    {
        public HistoricoContext(DbContextOptions<HistoricoContext> options) : base(options)
        {
        }

        public DbSet<HistoricoDeNegociacoes> HistoricoDeNegociacoes { get; set; }
        public DbSet<RegistroDeNegociacoes> RegistroDeNegociacoes { get; set; }
    }
}
