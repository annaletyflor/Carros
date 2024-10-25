using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Carros.models;

namespace Carros.Data
{
    public class CarrosContext : DbContext
    {
        public CarrosContext (DbContextOptions<CarrosContext> options)
            : base(options)
        {
        }

        public DbSet<Carros.models.Carro> Carro { get; set; } = default!;
        public DbSet<Carros.models.Patio> Patio { get; set; } = default!;
        public DbSet<Carros.models.Cliente> Cliente { get; set; } = default!;
        public DbSet<Carros.models.locacoes> locacoes { get; set; } = default!;
    }
}
