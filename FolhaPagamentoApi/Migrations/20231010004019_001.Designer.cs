﻿// <auto-generated />
using FolhaPagamentoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FolhaPagamentoApi.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20231010004019_001")]
    partial class _001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.22");

            modelBuilder.Entity("FolhaPagamentoApi.Folha", b =>
                {
                    b.Property<int>("FolhaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ano")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Mes")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("FolhaId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Folhas");
                });

            modelBuilder.Entity("FolhaPagamentoApi.Models.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("FuncionarioId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("FolhaPagamentoApi.Folha", b =>
                {
                    b.HasOne("FolhaPagamentoApi.Models.Funcionario", "Funcionario")
                        .WithMany("Folhas")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("FolhaPagamentoApi.Models.Funcionario", b =>
                {
                    b.Navigation("Folhas");
                });
#pragma warning restore 612, 618
        }
    }
}
