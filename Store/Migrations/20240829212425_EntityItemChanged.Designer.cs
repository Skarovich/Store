﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Data;

#nullable disable

namespace Store.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240829212425_EntityItemChanged")]
    partial class EntityItemChanged
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryItem", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoriesId", "ItemsId");

                    b.HasIndex("ItemsId");

                    b.ToTable("CategoryItem");
                });

            modelBuilder.Entity("Store.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f6d0354b-cc58-4d78-a381-dbe16c1d300e"),
                            Name = "Дом"
                        },
                        new
                        {
                            Id = new Guid("96f31628-c271-4c36-b0dd-bac5f4c6c578"),
                            Name = "Кухня"
                        },
                        new
                        {
                            Id = new Guid("14a6ed20-13cf-44a2-b9c4-f5855c413958"),
                            Name = "Ванна"
                        });
                });

            modelBuilder.Entity("Store.Models.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(20)
                        .HasColumnType("decimal(20,2)");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId")
                        .IsUnique();

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Store.Models.ItemImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Extenstion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d6c1daf5-ae57-41df-8682-085dfcfd4dab"),
                            Extenstion = "jpg"
                        });
                });

            modelBuilder.Entity("CategoryItem", b =>
                {
                    b.HasOne("Store.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Store.Models.Item", b =>
                {
                    b.HasOne("Store.Models.ItemImage", "Image")
                        .WithOne("Item")
                        .HasForeignKey("Store.Models.Item", "ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Store.Models.ItemImage", b =>
                {
                    b.Navigation("Item")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
