﻿// <auto-generated />
using IV.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IV.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240828062429_InitialCreate7600")]
    partial class InitialCreate7600
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.7.24405.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IV.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("IV.Models.CalorieCalculation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ActivityLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AdminID")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<double>("DailyCalories")
                        .HasColumnType("float");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<int>("RecommendedCalories")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("AdminID");

                    b.HasIndex("UserID");

                    b.ToTable("CalorieCalculations");
                });

            modelBuilder.Entity("IV.Models.InspirationalVideo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("AdminID")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AdminID");

                    b.HasIndex("UserID");

                    b.ToTable("InspirationalVideos");
                });

            modelBuilder.Entity("IV.Models.MotivationalQuote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("AdminID")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AdminID");

                    b.HasIndex("UserID");

                    b.ToTable("MotivationalQuotes");
                });

            modelBuilder.Entity("IV.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Height")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Weight")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("IV.Models.CalorieCalculation", b =>
                {
                    b.HasOne("IV.Models.Admin", null)
                        .WithMany("CalorieCalculations")
                        .HasForeignKey("AdminID");

                    b.HasOne("IV.Models.User", null)
                        .WithMany("CalorieCalculations")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("IV.Models.InspirationalVideo", b =>
                {
                    b.HasOne("IV.Models.Admin", null)
                        .WithMany("InspirationalVideos")
                        .HasForeignKey("AdminID");

                    b.HasOne("IV.Models.User", "User")
                        .WithMany("InspirationalVideos")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("IV.Models.MotivationalQuote", b =>
                {
                    b.HasOne("IV.Models.Admin", null)
                        .WithMany("MotivationalQuotes")
                        .HasForeignKey("AdminID");

                    b.HasOne("IV.Models.User", "User")
                        .WithMany("MotivationalQuotes")
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IV.Models.Admin", b =>
                {
                    b.Navigation("CalorieCalculations");

                    b.Navigation("InspirationalVideos");

                    b.Navigation("MotivationalQuotes");
                });

            modelBuilder.Entity("IV.Models.User", b =>
                {
                    b.Navigation("CalorieCalculations");

                    b.Navigation("InspirationalVideos");

                    b.Navigation("MotivationalQuotes");
                });
#pragma warning restore 612, 618
        }
    }
}
