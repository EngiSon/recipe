﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeAPI.Dal;

#nullable disable

namespace RecipeAPI.Migrations
{
    [DbContext(typeof(RecipeContext))]
    [Migration("20221210101405_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RecipeAPI.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("RecipeAPI.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FoodType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("RecipeAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserUser", b =>
                {
                    b.Property<int>("FavoritedUsersId")
                        .HasColumnType("int");

                    b.Property<int>("UsersFavoritedId")
                        .HasColumnType("int");

                    b.HasKey("FavoritedUsersId", "UsersFavoritedId");

                    b.HasIndex("UsersFavoritedId");

                    b.ToTable("UserUser");
                });

            modelBuilder.Entity("RecipeAPI.Models.Ingredient", b =>
                {
                    b.HasOne("RecipeAPI.Models.Recipe", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("RecipeAPI.Models.Recipe", b =>
                {
                    b.HasOne("RecipeAPI.Models.User", "Author")
                        .WithMany("Recipes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("UserUser", b =>
                {
                    b.HasOne("RecipeAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("FavoritedUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipeAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersFavoritedId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecipeAPI.Models.Recipe", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("RecipeAPI.Models.User", b =>
                {
                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}
