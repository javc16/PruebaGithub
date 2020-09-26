using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using LuckyStore.Models;
using Microsoft.EntityFrameworkCore;

namespace LuckyStore.Context
{
    public class FacturaContext:DbContext
    {
        public FacturaContext(DbContextOptions<FacturaContext> options) :base(options)
        {
            
        }

        public DbSet<Factura> Factura { get; set; }
        public DbSet<Detalle> Detalle { get; set; }

    }
}
