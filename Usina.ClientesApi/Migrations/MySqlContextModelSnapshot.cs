﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Usina.ClientesApi.Models.Context;

#nullable disable

namespace Usina.ClientesApi.Migrations
{
    [DbContext(typeof(MySqlContext))]
    partial class MySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Usina.ClientesApi.Models.Cliente", b =>
                {
                    b.Property<long>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Codigo");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Cidade");

                    b.Property<DateTime>("DataInsercao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DataInsercao");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Endereco");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Nome");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("UF");

                    b.HasKey("Codigo");

                    b.ToTable("cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
