﻿// <auto-generated />
using System;
using Event_.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Event_.Migrations
{
    [DbContext(typeof(Event_Context))]
    [Migration("20250318122808_DbEvent_Api")]
    partial class DbEvent_Api
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Event_.Domains.ComentarioEvento", b =>
                {
                    b.Property<Guid>("ComentarioEventoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("EventoID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Exibe")
                        .HasColumnType("BIT");

                    b.Property<Guid>("UsuarioID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ComentarioEventoID");

                    b.HasIndex("EventoID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("ComentarioEvento");
                });

            modelBuilder.Entity("Event_.Domains.Evento", b =>
                {
                    b.Property<Guid>("EventoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataEvento")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("InstituicoesID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeEvento")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("TiposEventosID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EventoID");

                    b.HasIndex("InstituicoesID");

                    b.HasIndex("TiposEventosID");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("Event_.Domains.Instituicoes", b =>
                {
                    b.Property<Guid>("InstituicoesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("VARCHAR(14)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("InstituicoesID");

                    b.HasIndex("CNPJ")
                        .IsUnique();

                    b.ToTable("instituicoes");
                });

            modelBuilder.Entity("Event_.Domains.PresencasEventos", b =>
                {
                    b.Property<Guid>("PresencasEventoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventoID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Situacao")
                        .HasColumnType("Bit");

                    b.Property<Guid>("UsuarioID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PresencasEventoID");

                    b.HasIndex("EventoID")
                        .IsUnique();

                    b.HasIndex("UsuarioID");

                    b.ToTable("PresencaEvento");
                });

            modelBuilder.Entity("Event_.Domains.TiposEventos", b =>
                {
                    b.Property<Guid>("TiposEventosID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TituloTipoEvento")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("TiposEventosID");

                    b.ToTable("TiposEventos");
                });

            modelBuilder.Entity("Event_.Domains.TiposUsuarios", b =>
                {
                    b.Property<Guid>("TiposUsuariosID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TituloTipoUsuario")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("TiposUsuariosID");

                    b.ToTable("TiposUsuarios");
                });

            modelBuilder.Entity("Event_.Domains.Usuario", b =>
                {
                    b.Property<Guid>("UsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.Property<Guid>("TipoUsuarioID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TiposUsuariosID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UsuarioID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("TiposUsuariosID");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Event_.Domains.ComentarioEvento", b =>
                {
                    b.HasOne("Event_.Domains.Evento", "evento")
                        .WithMany()
                        .HasForeignKey("EventoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Event_.Domains.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("evento");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("Event_.Domains.Evento", b =>
                {
                    b.HasOne("Event_.Domains.Instituicoes", "instituicao")
                        .WithMany()
                        .HasForeignKey("InstituicoesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Event_.Domains.TiposEventos", "tipoevento")
                        .WithMany()
                        .HasForeignKey("TiposEventosID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("instituicao");

                    b.Navigation("tipoevento");
                });

            modelBuilder.Entity("Event_.Domains.PresencasEventos", b =>
                {
                    b.HasOne("Event_.Domains.Evento", "eventos")
                        .WithOne("presencasEventos")
                        .HasForeignKey("Event_.Domains.PresencasEventos", "EventoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Event_.Domains.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("eventos");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("Event_.Domains.Usuario", b =>
                {
                    b.HasOne("Event_.Domains.TiposUsuarios", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("TiposUsuariosID");

                    b.Navigation("TipoUsuario");
                });

            modelBuilder.Entity("Event_.Domains.Evento", b =>
                {
                    b.Navigation("presencasEventos");
                });
#pragma warning restore 612, 618
        }
    }
}
