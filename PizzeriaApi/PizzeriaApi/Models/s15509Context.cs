using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzeriaApi.Models
{
    public partial class s15509Context : DbContext
    {
        public s15509Context()
        {
        }

        public s15509Context(DbContextOptions<s15509Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Ciasto> Ciasto { get; set; }
        public virtual DbSet<Dostawca> Dostawca { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaSkladnik> PizzaSkladnik { get; set; }
        public virtual DbSet<Promocja> Promocja { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<Stan> Stan { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }

        // Unable to generate entity type for table 'dbo.DEPT'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SALGRADE'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s15509;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("PK__Administ__EB545B54C36AD55D");

                entity.Property(e => e.IdAdmin)
                    .HasColumnName("id_Admin")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdresEmail)
                    .IsRequired()
                    .HasColumnName("adres_email")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Haslo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ciasto>(entity =>
            {
                entity.HasKey(e => e.IdCiasta)
                    .HasName("PK__Ciasto__4254D002ECE6D0B8");

                entity.Property(e => e.IdCiasta)
                    .HasColumnName("id_Ciasta")
                    .ValueGeneratedNever();

                entity.Property(e => e.CenaCiasta).HasColumnName("cena_Ciasta");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dostawca>(entity =>
            {
                entity.HasKey(e => e.IdDostawcy)
                    .HasName("PK__Dostawca__8EFD1A18BDF4194F");

                entity.Property(e => e.IdDostawcy)
                    .HasColumnName("id_Dostawcy")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adres)
                    .IsRequired()
                    .HasColumnName("adres")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

  

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("PK__Pizza__3DA83BDAA82C2307");

                entity.Property(e => e.IdPizza)
                    .HasColumnName("id_Pizza")
                    .ValueGeneratedNever();

                entity.Property(e => e.CenaPizza).HasColumnName("cena_Pizza");

                entity.Property(e => e.CiastoIdCiasta).HasColumnName("Ciasto_id_Ciasta");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RodzajPizzy)
                    .IsRequired()
                    .HasColumnName("rodzaj_Pizzy")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PizzaSkladnik>(entity =>
            {
                entity.HasKey(e => new { e.SkladnikIdSkladnik, e.PizzaIdPizza })
                    .HasName("PK__Pizza_sk__B0C76E7D5CAA4509");

                entity.ToTable("Pizza_skladnik");

                entity.Property(e => e.SkladnikIdSkladnik).HasColumnName("Skladnik_id_Skladnik");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_id_Pizza");
            });

            modelBuilder.Entity<Promocja>(entity =>
            {
                entity.HasKey(e => e.IdPromocja)
                    .HasName("PK__Promocja__13ED828079CF9038");

                entity.Property(e => e.IdPromocja)
                    .HasColumnName("id_Promocja")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProcentRabatu).HasColumnName("procent_rabatu");
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladnik)
                    .HasName("PK__Skladnik__9D3A02D30F11BB3F");

                entity.Property(e => e.IdSkladnik)
                    .HasColumnName("id_Skladnik")
                    .ValueGeneratedNever();

                entity.Property(e => e.CenaSkladnika).HasColumnName("cena_Skladnika");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Stan>(entity =>
            {
                entity.HasKey(e => e.IdStan)
                    .HasName("PK__Stan__5D730C00C33B7DE9");

                entity.Property(e => e.IdStan)
                    .HasColumnName("id_Stan")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PozostalyCzas).HasColumnName("pozostaly_Czas");
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienie)
                    .HasName("PK__Zamowien__47864C6232A28031");

                entity.Property(e => e.IdZamowienie)
                    .HasColumnName("id_Zamowienie")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdresEmail)
                    .IsRequired()
                    .HasColumnName("adres_email")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CenaZamownienia).HasColumnName("cena_Zamownienia");

                entity.Property(e => e.DostawcaIdDostawcy).HasColumnName("Dostawca_id_Dostawcy");

                entity.Property(e => e.NrTel).HasColumnName("nr_tel");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_id_Pizza");

                entity.Property(e => e.PromocjaIdPromocja).HasColumnName("Promocja_id_Promocja");

                entity.Property(e => e.StanIdStan).HasColumnName("Stan_id_Stan");
            });
        }
    }
}
