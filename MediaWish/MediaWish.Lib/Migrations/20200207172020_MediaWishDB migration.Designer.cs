﻿// <auto-generated />
using System;
using MediaWish.Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MediaWish.Library.Migrations
{
    [DbContext(typeof(MediaWishContext))]
    [Migration("20200207172020_MediaWishDB migration")]
    partial class MediaWishDBmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MediaWish.Library.Entities.Medias", b =>
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

            modelBuilder.Entity("MediaWish.Library.Entities.Users", b =>
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

            modelBuilder.Entity("MediaWish.Library.Entities.WishList", b =>
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

            modelBuilder.Entity("MediaWish.Library.Entities.WishList", b =>
                {
                    b.HasOne("MediaWish.Library.Entities.Medias", "medias")
                        .WithMany("wishLists")
                        .HasForeignKey("mediasId");

                    b.HasOne("MediaWish.Library.Entities.Users", "users")
                        .WithMany("wishLists")
                        .HasForeignKey("usersId");
                });
#pragma warning restore 612, 618
        }
    }
}
