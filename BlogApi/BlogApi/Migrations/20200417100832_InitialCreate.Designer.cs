﻿// <auto-generated />
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlogApi.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20200417100832_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("BlogApi.Models.Category", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BlogApi.Models.Media", b =>
                {
                    b.Property<string>("MediaId")
                        .HasColumnType("TEXT");

                    b.Property<string>("MediaType")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("MediaId");

                    b.HasIndex("PostId");

                    b.ToTable("Media");
                });

            modelBuilder.Entity("BlogApi.Models.Post", b =>
                {
                    b.Property<string>("PostId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("PostId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("BlogApi.Models.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isRegistered")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BlogApi.Models.Media", b =>
                {
                    b.HasOne("BlogApi.Models.Post", "Post")
                        .WithMany("Media")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("BlogApi.Models.Post", b =>
                {
                    b.HasOne("BlogApi.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId");

                    b.HasOne("BlogApi.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
