﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenBankingApi.Infrastructure;

namespace OpenBankingApi.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20191116012829_DeleteTabelasLog")]
    partial class DeleteTabelasLog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OpenBankingApi.Domain.Models.Banco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Cnpj");

                    b.Property<long>("Codigo");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataModificacao");

                    b.Property<bool>("IsAtivo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Bancos");
                });

            modelBuilder.Entity("OpenBankingApi.Domain.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteTipoId");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataModificacao");

                    b.Property<bool>("IsAtivo");

                    b.Property<long>("Registro");

                    b.HasKey("Id");

                    b.HasIndex("ClienteTipoId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("OpenBankingApi.Domain.Models.ClienteTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataModificacao");

                    b.Property<bool>("IsAtivo");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("ClienteTipo");
                });

            modelBuilder.Entity("OpenBankingApi.Domain.Models.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Agencia");

                    b.Property<int>("BancoId");

                    b.Property<int>("ClienteId");

                    b.Property<int>("ContaTipoId");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataModificacao");

                    b.Property<bool>("IsAtivo");

                    b.Property<long>("Numero");

                    b.HasKey("Id");

                    b.HasIndex("BancoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ContaTipoId");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("OpenBankingApi.Domain.Models.ContaTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataModificacao");

                    b.Property<bool>("IsAtivo");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("ContaTipos");
                });

            modelBuilder.Entity("OpenBankingApi.Domain.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasMaxLength(100);

                    b.Property<long>("Cep");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataModificacao");

                    b.Property<string>("Estado")
                        .HasMaxLength(100);

                    b.Property<bool>("IsAtivo");

                    b.Property<int>("Numero");

                    b.Property<string>("Pais")
                        .HasMaxLength(30);

                    b.Property<int>("PessoaId");

                    b.Property<string>("Rua")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("OpenBankingApi.Domain.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId");

                    b.Property<long>("Cpf");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataModificacao");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<bool>("IsAtivo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<long>("Rg");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("OpenBankingApi.Domain.Models.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContaId");

                    b.Property<DateTime>("Data");

                    b.Property<int>("TransacaoTipoId");

                    b.HasKey("Id");

                    b.HasIndex("ContaId");

                    b.HasIndex("TransacaoTipoId");

                    b.ToTable("Transacaoes");
                });

            modelBuilder.Entity("OpenBankingApi.Domain.Models.TransacaoTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataModificacao");

                    b.Property<bool>("IsAtivo");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("TransacaoTipos");
                });

            modelBuilder.Entity("OpenBankingApi.Domain.Models.Cliente", b =>
                {
                    b.HasOne("OpenBankingApi.Domain.Models.ClienteTipo", "ClienteTipo")
                        .WithMany()
                        .HasForeignKey("ClienteTipoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpenBankingApi.Domain.Models.Conta", b =>
                {
                    b.HasOne("OpenBankingApi.Domain.Models.Banco", "Banco")
                        .WithMany()
                        .HasForeignKey("BancoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OpenBankingApi.Domain.Models.Cliente", "Cliente")
                        .WithMany("Contas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OpenBankingApi.Domain.Models.ContaTipo", "ContaTipo")
                        .WithMany()
                        .HasForeignKey("ContaTipoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpenBankingApi.Domain.Models.Endereco", b =>
                {
                    b.HasOne("OpenBankingApi.Domain.Models.Pessoa", "Pessoa")
                        .WithOne("Endereco")
                        .HasForeignKey("OpenBankingApi.Domain.Models.Endereco", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpenBankingApi.Domain.Models.Pessoa", b =>
                {
                    b.HasOne("OpenBankingApi.Domain.Models.Cliente", "Cliente")
                        .WithOne("Pessoa")
                        .HasForeignKey("OpenBankingApi.Domain.Models.Pessoa", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpenBankingApi.Domain.Models.Transacao", b =>
                {
                    b.HasOne("OpenBankingApi.Domain.Models.Conta", "Conta")
                        .WithMany()
                        .HasForeignKey("ContaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OpenBankingApi.Domain.Models.TransacaoTipo", "TransacaoTipo")
                        .WithMany()
                        .HasForeignKey("TransacaoTipoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}