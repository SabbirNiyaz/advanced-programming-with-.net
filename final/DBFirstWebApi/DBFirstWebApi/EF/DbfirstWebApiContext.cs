using System;
using System.Collections.Generic;
using DBFirstWebApi.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace DBFirstWebApi.EF;

public partial class DbfirstWebApiContext : DbContext
{
    public DbfirstWebApiContext()
    {
    }

    public DbfirstWebApiContext(DbContextOptions<DbfirstWebApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StudentTable> StudentTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DbConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentTable>(entity =>
        {
            entity.ToTable("StudentTable");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
