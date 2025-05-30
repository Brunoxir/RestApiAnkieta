﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using restApiAnkiety;

#nullable disable

namespace restApiAnkiety.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.5");

            modelBuilder.Entity("restApiAnkiety.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AnswerDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("FormId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OptionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.HasIndex("OptionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("restApiAnkiety.Models.Form", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("restApiAnkiety.Models.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FormId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Votes")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("restApiAnkiety.Models.Answer", b =>
                {
                    b.HasOne("restApiAnkiety.Models.Form", "Form")
                        .WithMany("Answers")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("restApiAnkiety.Models.Option", "Option")
                        .WithMany("Answers")
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");

                    b.Navigation("Option");
                });

            modelBuilder.Entity("restApiAnkiety.Models.Option", b =>
                {
                    b.HasOne("restApiAnkiety.Models.Form", "Form")
                        .WithMany("Options")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");
                });

            modelBuilder.Entity("restApiAnkiety.Models.Form", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Options");
                });

            modelBuilder.Entity("restApiAnkiety.Models.Option", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
