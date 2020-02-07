﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestProject.Lib.Entites;

namespace TestProject.Lib.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestProject.Lib.Entites.Medias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MediaType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("medias");
                });

            modelBuilder.Entity("TestProject.Lib.Entites.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("TestProject.Lib.Entites.WishList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MediaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MediaPlatform")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MediaTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("mediasId")
                        .HasColumnType("int");

                    b.Property<int?>("usersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("mediasId");

                    b.HasIndex("usersId");

                    b.ToTable("wishLists");
                });

            modelBuilder.Entity("TestProject.Lib.Entites.WishList", b =>
                {
                    b.HasOne("TestProject.Lib.Entites.Medias", "medias")
                        .WithMany("wishLists")
                        .HasForeignKey("mediasId");

                    b.HasOne("TestProject.Lib.Entites.Users", "users")
                        .WithMany("wishLists")
                        .HasForeignKey("usersId");
                });
#pragma warning restore 612, 618
        }
    }
}
