using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CargaFicherosApp.Compras
{
    public partial class comprasContext : DbContext
    {
        public comprasContext()
        {
        }

        public comprasContext(DbContextOptions<comprasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dwh> Dwh { get; set; }
        public virtual DbSet<Dwh2> Dwh2 { get; set; }
        public virtual DbSet<Gbpl> Gbpl { get; set; }
        public virtual DbSet<Informegrupocompra> Informegrupocompra { get; set; }
        public virtual DbSet<Ksrm> Ksrm { get; set; }
        public virtual DbSet<KsrmExport> KsrmExport { get; set; }
        public virtual DbSet<KsrmExtension> KsrmExtension { get; set; }
        public virtual DbSet<Overaltrackingreport> Overaltrackingreport { get; set; }
        public virtual DbSet<PedidosPlantaGenerico> PedidosPlantaGenerico { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Testing> Testing { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=escaxw025201;port=3306;user=compras_usr;password=Santiago001$;database=compras");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dwh>(entity =>
            {
                entity.ToTable("dwh");

                entity.Property(e => e.Dwhid).HasColumnName("dwhid");

                entity.Property(e => e.Bestbid)
                    .HasColumnName("bestbid")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Budget)
                    .HasColumnName("budget")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.ContractTo)
                    .HasColumnName("contractTo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Contractfrom)
                    .HasColumnName("contractfrom")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Contractnumber)
                    .HasColumnName("contractnumber")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.Loli)
                    .HasColumnName("loli")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Performance)
                    .HasColumnName("performance")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.PerformancePer)
                    .HasColumnName("performance_per")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Savings)
                    .HasColumnName("savings")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.SavingsPer)
                    .HasColumnName("savings_per")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Supplier)
                    .HasColumnName("supplier")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TypeC)
                    .HasColumnName("typeC")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.YearMonth)
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dwh2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh2");

                entity.Property(e => e.Bestbid).HasColumnName("bestbid");

                entity.Property(e => e.Budget).HasColumnName("budget");

                entity.Property(e => e.ContractTo).HasColumnName("contractTo");

                entity.Property(e => e.Contractfrom).HasColumnName("contractfrom");

                entity.Property(e => e.Contractnumber).HasColumnName("contractnumber");

                entity.Property(e => e.Dwhid).HasColumnName("dwhid");

                entity.Property(e => e.Empresa).HasColumnName("empresa");

                entity.Property(e => e.Loli).HasColumnName("loli");

                entity.Property(e => e.Performance).HasColumnName("performance");

                entity.Property(e => e.PerformancePer).HasColumnName("performance_per");

                entity.Property(e => e.Savings).HasColumnName("savings");

                entity.Property(e => e.SavingsPer).HasColumnName("savings_per");

                entity.Property(e => e.Supplier).HasColumnName("supplier");

                entity.Property(e => e.TypeC).HasColumnName("typeC");
            });

            modelBuilder.Entity<Gbpl>(entity =>
            {
                entity.HasKey(e => e.Cosialta)
                    .HasName("PRIMARY");

                entity.ToTable("gbpl");

                entity.HasIndex(e => e.Cosialta)
                    .HasName(" COSIALTA_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Cosialta)
                    .HasColumnName("COSIALTA")
                    .HasColumnType("timestamp(6)");

                entity.Property(e => e.Cliefnr)
                    .HasColumnName(" CLIEFNR")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Cobestnr)
                    .HasColumnName(" COBESTNR")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Cocausal)
                    .HasColumnName(" COCAUSAL")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Coclavw0)
                    .HasColumnName(" COCLAVW0")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Codcuota)
                    .HasColumnName("CODCUOTA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Codresto).HasColumnName(" CODRESTO");

                entity.Property(e => e.Codunsnr)
                    .HasColumnName(" CODUNSNR")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Comoneda)
                    .HasColumnName(" COMONEDA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Comonese)
                    .HasColumnName(" COMONESE")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Compania)
                    .HasColumnName(" COMPANIA")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Coorige)
                    .HasColumnName("COORIGE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Costatus)
                    .HasColumnName("COSTATUS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Cotipnum)
                    .HasColumnName(" COTIPNUM")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Counmevw)
                    .HasColumnName("COUNMEVW")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Counprvw)
                    .HasColumnName(" COUNPRVW")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Coupseat)
                    .HasColumnName("COUPSEAT")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Cowerkvw)
                    .HasColumnName(" COWERKVW")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Feconped).HasColumnName("FECONPED");

                entity.Property(e => e.Fefinhis).HasColumnName("FEFINHIS");

                entity.Property(e => e.Feiniefe).HasColumnName(" FEINIEFE");

                entity.Property(e => e.Fesimodi).HasColumnName(" FESIMODI");

                entity.Property(e => e.Feverlst).HasColumnName(" FEVERLST");

                entity.Property(e => e.Feverlwe).HasColumnName(" FEVERLWE");

                entity.Property(e => e.Pradebon)
                    .HasColumnName(" PRADEBON")
                    .HasColumnType("decimal(16,2)");

                entity.Property(e => e.Prbrseeu)
                    .HasColumnName(" PRBRSEEU")
                    .HasColumnType("decimal(16,2)");

                entity.Property(e => e.Prbrudiv)
                    .HasColumnName(" PRBRUDIV")
                    .HasColumnType("decimal(16,2)");

                entity.Property(e => e.Prbrueur)
                    .HasColumnName(" PRBRUEUR")
                    .HasColumnType("decimal(16,2)");

                entity.Property(e => e.Prelogis)
                    .HasColumnName(" PRELOGIS")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Prunidiv)
                    .HasColumnName(" PRUNIDIV")
                    .HasColumnType("decimal(16,2)");

                entity.Property(e => e.Prunieur)
                    .HasColumnName(" PRUNIEUR")
                    .HasColumnType("decimal(16,2)");

                entity.Property(e => e.Prvrsedv)
                    .HasColumnName(" PRVRSEDV")
                    .HasColumnType("decimal(16,2)");
            });

            modelBuilder.Entity<Informegrupocompra>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("informegrupocompra");

                entity.Property(e => e.DptoCompras).HasColumnName("dpto_compras");

                entity.Property(e => e.DptpComprasContrato).HasColumnName("Dptp_compras_Contrato");

                entity.Property(e => e.GrupoKsrm).HasColumnName("grupo_ksrm");

                entity.Property(e => e.InInforme).HasColumnName("in_informe");

                entity.Property(e => e.TipoInforme).HasColumnName("tipo_informe");
            });

            modelBuilder.Entity<Ksrm>(entity =>
            {
                entity.HasKey(e => e.Idksrm)
                    .HasName("PRIMARY");

                entity.ToTable("ksrm");

                entity.HasIndex(e => e.Idksrm)
                    .HasName("idksrm_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idksrm).HasColumnName("idksrm");

                entity.Property(e => e.Cambio)
                    .HasColumnName("CAMBIO")
                    .HasColumnType("decimal(16,2)");

                entity.Property(e => e.Codbuyer)
                    .HasColumnName("CODBUYER")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Coingest)
                    .HasColumnName("COINGEST")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Coprovee)
                    .HasColumnName("COPROVEE")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cosocdad)
                    .HasColumnName("COSOCDAD")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Delincom)
                    .HasColumnName("DELINCOM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Divisa)
                    .HasColumnName("DIVISA")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnName("FECHA")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEmision)
                    .HasColumnName("FECHA_EMISION")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.GrupoCompra)
                    .HasColumnName("grupo_compra")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Idstring)
                    .HasColumnName("IDSTRING")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Importe)
                    .HasColumnName("IMPORTE")
                    .HasColumnType("decimal(16,2)");

                entity.Property(e => e.Importebestbid)
                    .HasColumnName("IMPORTEBESTBID")
                    .HasColumnType("decimal(16,2)");

                entity.Property(e => e.Importesc)
                    .HasColumnName("IMPORTESC")
                    .HasColumnType("decimal(16,2)");

                entity.Property(e => e.Nupedido)
                    .HasColumnName("NUPEDIDO")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nusolcom)
                    .HasColumnName("NUSOLCOM")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Version)
                    .HasColumnName("VERSION")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KsrmExport>(entity =>
            {
                entity.HasKey(e => e.Idksrm)
                    .HasName("PRIMARY");

                entity.ToTable("ksrm_export");

                entity.HasIndex(e => e.Idksrm)
                    .HasName("idksrm_export_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idksrm).HasColumnName("idksrm");

                entity.Property(e => e.Cambio)
                    .HasColumnName("CAMBIO")
                    .HasColumnType("decimal(16,2)");

                entity.Property(e => e.Codbuyer)
                    .HasColumnName("CODBUYER")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Coingest)
                    .HasColumnName("COINGEST")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Coprovee)
                    .HasColumnName("COPROVEE")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cosocdad)
                    .HasColumnName("COSOCDAD")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Delincom)
                    .HasColumnName("DELINCOM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Divisa)
                    .HasColumnName("DIVISA")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnName("FECHA")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEmision)
                    .HasColumnName("FECHA_EMISION")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.GrupoCompra)
                    .HasColumnName("grupo_compra")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Idstring)
                    .HasColumnName("IDSTRING")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Importe)
                    .HasColumnName("IMPORTE")
                    .HasColumnType("decimal(16,2)");

                entity.Property(e => e.Importebestbid)
                    .HasColumnName("IMPORTEBESTBID")
                    .HasColumnType("decimal(16,2)");

                entity.Property(e => e.Importesc)
                    .HasColumnName("IMPORTESC")
                    .HasColumnType("decimal(16,2)");

                entity.Property(e => e.Nupedido)
                    .HasColumnName("NUPEDIDO")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nusolcom)
                    .HasColumnName("NUSOLCOM")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Version)
                    .HasColumnName("VERSION")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KsrmExtension>(entity =>
            {
                entity.HasKey(e => e.Idksrm)
                    .HasName("PRIMARY");

                entity.ToTable("ksrm_extension");

                entity.HasIndex(e => e.Idksrm)
                    .HasName("idksrmextension_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idksrm).HasColumnName("idksrm");

                entity.Property(e => e.Cambio)
                    .HasColumnName("CAMBIO")
                    .HasColumnType("decimal(16,2)");

                entity.Property(e => e.Codbuyer)
                    .HasColumnName("CODBUYER")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Coingest)
                    .HasColumnName("COINGEST")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Coprovee)
                    .HasColumnName("COPROVEE")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cosocdad)
                    .HasColumnName("COSOCDAD")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Delincom)
                    .HasColumnName("DELINCOM")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Divisa)
                    .HasColumnName("DIVISA")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnName("FECHA")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEmision)
                    .HasColumnName("FECHA_EMISION")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.GrupoCompra)
                    .HasColumnName("grupo_compra")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Idstring)
                    .HasColumnName("IDSTRING")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Importe)
                    .HasColumnName("IMPORTE")
                    .HasColumnType("decimal(16,2)");

                entity.Property(e => e.Importebestbid)
                    .HasColumnName("IMPORTEBESTBID")
                    .HasColumnType("decimal(16,2)");

                entity.Property(e => e.Importesc)
                    .HasColumnName("IMPORTESC")
                    .HasColumnType("decimal(16,2)");

                entity.Property(e => e.Nupedido)
                    .HasColumnName("NUPEDIDO")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nusolcom)
                    .HasColumnName("NUSOLCOM")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Version)
                    .HasColumnName("VERSION")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Overaltrackingreport>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("overaltrackingreport");

                entity.Property(e => e.ConItem).HasColumnName("CON Item");

                entity.Property(e => e.ConNumber).HasColumnName("CON Number");

                entity.Property(e => e.ConValue).HasColumnName("CON Value");

                entity.Property(e => e.DUNSNumber).HasColumnName("D-U-N-S Number");

                entity.Property(e => e.InvValue).HasColumnName("INV Value");

                entity.Property(e => e.PoCreationDate).HasColumnName("PO Creation date");

                entity.Property(e => e.PoItem).HasColumnName("PO Item");

                entity.Property(e => e.PoNumber).HasColumnName("PO Number");

                entity.Property(e => e.PoValue).HasColumnName("PO Value");

                entity.Property(e => e.ProcessType).HasColumnName("Process type");

                entity.Property(e => e.ScCalenderDay).HasColumnName("SC Calender day");

                entity.Property(e => e.ScCostCenter).HasColumnName("SC Cost center");

                entity.Property(e => e.ScDocName).HasColumnName("SC Doc. name");

                entity.Property(e => e.ScItem).HasColumnName("SC Item");

                entity.Property(e => e.ScItemDescr).HasColumnName("SC Item descr.");

                entity.Property(e => e.ScNumber).HasColumnName("SC Number");

                entity.Property(e => e.ScStatusApproval).HasColumnName("SC Status - approval");

                entity.Property(e => e.ScValue).HasColumnName("SC Value");

                entity.Property(e => e.ScWbsElement).HasColumnName("SC WBS element");
            });

            modelBuilder.Entity<PedidosPlantaGenerico>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pedidos_planta_generico");

                entity.Property(e => e.GClave).HasColumnName("G_CLAVE");

                entity.Property(e => e.GFechaConfirmacion).HasColumnName("G_FECHA_CONFIRMACION");

                entity.Property(e => e.GFechaFin).HasColumnName("G_FECHA_FIN");

                entity.Property(e => e.GFechaInicio).HasColumnName("G_FECHA_INICIO");

                entity.Property(e => e.GImporte).HasColumnName("G_IMPORTE");

                entity.Property(e => e.GMoneda).HasColumnName("G_MONEDA");

                entity.Property(e => e.GPedido).HasColumnName("G_PEDIDO");

                entity.Property(e => e.GProveedor).HasColumnName("G_PROVEEDOR");

                entity.Property(e => e.GStatus).HasColumnName("G_STATUS");

                entity.Property(e => e.GUp).HasColumnName("G_UP");

                entity.Property(e => e.PFechaConfirmacion).HasColumnName("P_FECHA_CONFIRMACION");

                entity.Property(e => e.PFechaFin).HasColumnName("P_FECHA_FIN");

                entity.Property(e => e.PFechaInicio).HasColumnName("P_FECHA_INICIO");

                entity.Property(e => e.PImporte).HasColumnName("P_IMPORTE");

                entity.Property(e => e.PMoneda).HasColumnName("P_MONEDA");

                entity.Property(e => e.PProveedor).HasColumnName("P_PROVEEDOR");

                entity.Property(e => e.PStatus).HasColumnName("P_STATUS");
            });

            modelBuilder.Entity<Proveedores>(entity =>
            {
                entity.HasKey(e => e.Idproveedores)
                    .HasName("PRIMARY");

                entity.ToTable("proveedores");

                entity.HasIndex(e => e.Idproveedores)
                    .HasName("idproveedores_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idproveedores).HasColumnName("idproveedores");

                entity.Property(e => e.Fechacreacion).HasColumnName("fechacreacion");

                entity.Property(e => e.Idksrm)
                    .HasColumnName("idksrm")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Loli)
                    .HasColumnName("loli")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Testing>(entity =>
            {
                entity.HasKey(e => e.Idtesting)
                    .HasName("PRIMARY");

                entity.ToTable("testing");

                entity.Property(e => e.Idtesting).HasColumnName("idtesting");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
