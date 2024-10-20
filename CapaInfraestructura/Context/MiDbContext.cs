using System;
using System.Collections.Generic;
using CapaInfraestructura.CapaDominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace CapaInfraestructura.Context;

public partial class MiDbContext : DbContext
{
    public MiDbContext()
    {
    }

    public MiDbContext(DbContextOptions<MiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriasTicket> CategoriasTickets { get; set; }

    public virtual DbSet<EstadosEvento> EstadosEventos { get; set; }

    public virtual DbSet<EstadosTicket> EstadosTickets { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<NivelesLiderazgo> NivelesLiderazgos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Rede> Redes { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-9546U8D; Database=TicketsAppMIJBP;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasOne(d => d.EstadoEventoIdEstadoEventoNavigation).WithMany(p => p.Eventos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EstadoEventoEvento");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasOne(d => d.NivelLiderazgoIdNivelLiderazgoNavigation).WithMany(p => p.Personas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NivelLiderazgoPersona");

            entity.HasOne(d => d.RedIdRedNavigation).WithMany(p => p.Personas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RedPersona");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasOne(d => d.CategoriaTicketIdCategoriaTicketNavigation).WithMany(p => p.Tickets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CategoriaTicketTicket");

            entity.HasOne(d => d.EstadoTicketIdEstadoTicketNavigation).WithMany(p => p.Tickets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EstadoTicketTicket");

            entity.HasOne(d => d.EventoIdEventoNavigation).WithMany(p => p.Tickets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventoTicket");

            entity.HasOne(d => d.PersonaIdPersonaNavigation).WithMany(p => p.Tickets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaTicket");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
