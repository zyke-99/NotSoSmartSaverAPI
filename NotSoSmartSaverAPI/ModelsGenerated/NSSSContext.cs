using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NotSoSmartSaverAPI.ModelsGenerated
{
    public partial class NSSSContext : DbContext
    {
        public NSSSContext()
        {
        }

        public NSSSContext(DbContextOptions<NSSSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Budget> Budget { get; set; }
        public virtual DbSet<Expense> Expense { get; set; }
        public virtual DbSet<Goal> Goal { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Income> Income { get; set; }
        public virtual DbSet<Userandgroup> Userandgroup { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=194.5.157.98;Database=notsosmart;User Id=postgres;Password=nQ123.XYZ9@e;Port=5432");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Budget>(entity =>
            {
                entity.HasKey(e => e.Ownerid)
                    .HasName("budget_pkey");

                entity.ToTable("budget");

                entity.Property(e => e.Ownerid)
                    .HasColumnName("ownerid")
                    .HasColumnType("character(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alcohol).HasColumnName("alcohol");

                entity.Property(e => e.Car).HasColumnName("car");

                entity.Property(e => e.Food).HasColumnName("food");

                entity.Property(e => e.Goal).HasColumnName("goal");

                entity.Property(e => e.Insurance).HasColumnName("insurance");

                entity.Property(e => e.Leisure).HasColumnName("leisure");

                entity.Property(e => e.Loan).HasColumnName("loan");

                entity.Property(e => e.Other).HasColumnName("other");

                entity.Property(e => e.Rent).HasColumnName("rent");

                entity.Property(e => e.Subscriptions).HasColumnName("subscriptions");

                entity.Property(e => e.Tobacco).HasColumnName("tobacco");
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.HasKey(e => e.Ownerid)
                    .HasName("expense_pkey");

                entity.ToTable("expense");

                entity.HasIndex(e => e.Expenseid)
                    .HasName("expense_expenseid_key")
                    .IsUnique();

                entity.Property(e => e.Ownerid)
                    .HasColumnName("ownerid")
                    .HasColumnType("character(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Expensecategory).HasColumnName("expensecategory");

                entity.Property(e => e.Expenseid)
                    .IsRequired()
                    .HasColumnName("expenseid")
                    .HasColumnType("character(36)");

                entity.Property(e => e.Expensename).HasColumnName("expensename");

                entity.Property(e => e.Expensetime).HasColumnName("expensetime");

                entity.Property(e => e.Moneyused).HasColumnName("moneyused");

                entity.Property(e => e.Userid)
                    .IsRequired()
                    .HasColumnName("userid")
                    .HasColumnType("character(36)");
            });

            modelBuilder.Entity<Goal>(entity =>
            {
                entity.HasKey(e => e.Ownerid)
                    .HasName("goal_pkey");

                entity.ToTable("goal");

                entity.Property(e => e.Ownerid)
                    .HasColumnName("ownerid")
                    .HasColumnType("character(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Goalexpectedtime).HasColumnName("goalexpectedtime");

                entity.Property(e => e.Goalid)
                    .IsRequired()
                    .HasColumnName("goalid")
                    .HasColumnType("character(36)");

                entity.Property(e => e.Goalname).HasColumnName("goalname");

                entity.Property(e => e.Goaltime).HasColumnName("goaltime");

                entity.Property(e => e.Moneyallocated).HasColumnName("moneyallocated");

                entity.Property(e => e.Moneyrequired).HasColumnName("moneyrequired");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasKey(e => e.Groupid)
                    .HasName("groups_pkey");

                entity.ToTable("groups");

                entity.Property(e => e.Groupid)
                    .HasColumnName("groupid")
                    .HasColumnType("character(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Groupmoney).HasColumnName("groupmoney");

                entity.Property(e => e.Groupname).HasColumnName("groupname");
            });

            modelBuilder.Entity<Income>(entity =>
            {
                entity.HasKey(e => e.Ownerid)
                    .HasName("income_pkey");

                entity.ToTable("income");

                entity.HasIndex(e => e.Incomeid)
                    .HasName("income_incomeid_key")
                    .IsUnique();

                entity.Property(e => e.Ownerid)
                    .HasColumnName("ownerid")
                    .HasColumnType("character(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Incomeid)
                    .IsRequired()
                    .HasColumnName("incomeid");

                entity.Property(e => e.Incomename).HasColumnName("incomename");

                entity.Property(e => e.Incometime).HasColumnName("incometime");

                entity.Property(e => e.Moneyrecieved).HasColumnName("moneyrecieved");

                entity.Property(e => e.Userid)
                    .IsRequired()
                    .HasColumnName("userid");
            });

            modelBuilder.Entity<Userandgroup>(entity =>
            {
                entity.HasKey(e => e.Groupid)
                    .HasName("userandgroup_pkey");

                entity.ToTable("userandgroup");

                entity.Property(e => e.Groupid)
                    .HasColumnName("groupid")
                    .HasColumnType("character(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("users_pkey");

                entity.ToTable("users");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("character(36)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Useremail).HasColumnName("useremail");

                entity.Property(e => e.Userlastname).HasColumnName("userlastname");

                entity.Property(e => e.Usermoney).HasColumnName("usermoney");

                entity.Property(e => e.Username).HasColumnName("username");

                entity.Property(e => e.Userpassword).HasColumnName("userpassword");
            });
        }
    }
}
