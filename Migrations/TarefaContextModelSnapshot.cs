﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TAREFAS.Model;

namespace Tarefas.Migrations
{
    [DbContext(typeof(TarefaContext))]
    partial class TarefaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("TAREFAS.Model.Tarefa", b =>
                {
                    b.Property<int>("TarefaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Realizado")
                        .HasColumnType("INTEGER");

                    b.HasKey("TarefaId");

                    b.ToTable("Tarefas");
                });
#pragma warning restore 612, 618
        }
    }
}
