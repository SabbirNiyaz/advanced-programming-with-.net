using System;
using System.Collections.Generic;
using DbFirstWebApi.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace DbFirstWebApi.EF;

public partial class SpDbFirstWebApiContext : DbContext
{
    public SpDbFirstWebApiContext()
    {
    }

    public SpDbFirstWebApiContext(DbContextOptions<SpDbFirstWebApiContext> options)
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
            entity.ToTable("Student_table");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
