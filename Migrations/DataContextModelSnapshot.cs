﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication.Data;

#nullable disable

namespace WebApplication.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.13");

            modelBuilder.Entity("WebApplication.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenom")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telephone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("WebApplication.Fournisseur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Siret")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telephone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Fournisseurs");
                });

            modelBuilder.Entity("WebApplication.Model.CmdClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Date")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Heure")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumCommande")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Prix")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("CmdClient");
                });

            modelBuilder.Entity("WebApplication.Model.CmdFournisseur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Date")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Heure")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumCommande")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Prix")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("CmdFournisseurs");
                });

            modelBuilder.Entity("WebApplication.Produit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Famille")
                        .HasColumnType("TEXT");

                    b.Property<string>("Millesime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.Property<string>("PrixCarton")
                        .HasColumnType("TEXT");

                    b.Property<string>("PrixUnitaire")
                        .HasColumnType("TEXT");

                    b.Property<string>("Quantite")
                        .HasColumnType("TEXT");

                    b.Property<string>("Reference")
                        .HasColumnType("TEXT");

                    b.Property<string>("Volume")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Produits");
                });

            modelBuilder.Entity("WebApplication.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenom")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telephone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("WebApplication.Produit", b =>
                {
                    b.HasOne("WebApplication.Client", null)
                        .WithMany("Produits")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("WebApplication.Client", b =>
                {
                    b.Navigation("Produits");
                });
#pragma warning restore 612, 618
        }
    }
}
