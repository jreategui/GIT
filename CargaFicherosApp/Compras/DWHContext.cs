using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CargaFicherosApp.Compras
{
    public partial class DWHContext : DbContext
    {
        public DWHContext() { }



        public DWHContext(DbContextOptions<comprasContext> options) : base(options)
        {
        }
        public virtual DbSet<SICG_F_DWH_CONSORCIAL> SICG_F_DWH_CONSORCIAL { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ConnString = "USER ID = USER_COMPRAS;Password=Pa_cnntrsvcok21!; DATA SOURCE = 10.82.4.248:1523 / DTWHSEAT;";// PERSIST SECURITY INFO = True
            optionsBuilder.UseOracle(@ConnString, options => options
                                        .UseOracleSQLCompatibility("11"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Set a default schema for ALL tables
            modelBuilder.HasDefaultSchema("SICG");
            modelBuilder.Entity<SICG_F_DWH_CONSORCIAL>()
                .HasKey(c => new { c.ORDERNUMBER, c.YEARMONTH });
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}