﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bolsa_de_trabajo.Models;

#nullable disable

namespace bolsa_de_trabajo.Migrations
{
    [DbContext(typeof(GOES_DBContext))]
    [Migration("20240918222158_Agregamos campo de Birthdate")]
    partial class AgregamoscampodeBirthdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("bolsa_de_trabajo.Models.BinnacleCV", b =>
                {
                    b.Property<int>("IdBinnacleCV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBinnacleCV"));

                    b.Property<int>("CVId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ChangeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Changes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lenguages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalReferences")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkExperience")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdBinnacleCV");

                    b.HasIndex("CVId");

                    b.ToTable("BinnacleCV");
                });

            modelBuilder.Entity("bolsa_de_trabajo.Models.CV", b =>
                {
                    b.Property<int>("IdCv")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCv"));

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lenguages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalReferences")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkExperience")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCv");

                    b.HasIndex("CandidateId")
                        .IsUnique();

                    b.ToTable("CV");
                });

            modelBuilder.Entity("bolsa_de_trabajo.Models.Candidates", b =>
                {
                    b.Property<int>("IdCandidates")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCandidates"));

                    b.Property<DateOnly>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("names")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdCandidates");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("bolsa_de_trabajo.Models.CandidatesToJobs", b =>
                {
                    b.Property<int>("IdCandidatesToJobs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCandidatesToJobs"));

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.HasKey("IdCandidatesToJobs");

                    b.HasIndex("CandidateId");

                    b.HasIndex("JobId");

                    b.ToTable("CandidatesToJobs");
                });

            modelBuilder.Entity("bolsa_de_trabajo.Models.Jobs", b =>
                {
                    b.Property<int>("IdJobs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdJobs"));

                    b.Property<string>("Desciption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("IdJobs");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("bolsa_de_trabajo.Models.SelectorAgent", b =>
                {
                    b.Property<int>("IdCandidates")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCandidates"));

                    b.Property<DateOnly>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("names")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdCandidates");

                    b.ToTable("SelectorAgent");
                });

            modelBuilder.Entity("bolsa_de_trabajo.Models.SelectorAgentToJobs", b =>
                {
                    b.Property<int>("IdSelectorAgentToJobs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSelectorAgentToJobs"));

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<int>("SelectorAgentId")
                        .HasColumnType("int");

                    b.HasKey("IdSelectorAgentToJobs");

                    b.HasIndex("JobId");

                    b.HasIndex("SelectorAgentId");

                    b.ToTable("SelectorAgentToJobs");
                });

            modelBuilder.Entity("bolsa_de_trabajo.Models.BinnacleCV", b =>
                {
                    b.HasOne("bolsa_de_trabajo.Models.CV", "CV")
                        .WithMany()
                        .HasForeignKey("CVId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CV");
                });

            modelBuilder.Entity("bolsa_de_trabajo.Models.CV", b =>
                {
                    b.HasOne("bolsa_de_trabajo.Models.Candidates", "Candidate")
                        .WithOne("CV")
                        .HasForeignKey("bolsa_de_trabajo.Models.CV", "CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("bolsa_de_trabajo.Models.CandidatesToJobs", b =>
                {
                    b.HasOne("bolsa_de_trabajo.Models.Candidates", "Candidates")
                        .WithMany("candidatesToJobs")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bolsa_de_trabajo.Models.Jobs", "Jobs")
                        .WithMany("CandidatesToJobs")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidates");

                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("bolsa_de_trabajo.Models.SelectorAgentToJobs", b =>
                {
                    b.HasOne("bolsa_de_trabajo.Models.Jobs", "Jobs")
                        .WithMany("SelectorAgentToJobs")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bolsa_de_trabajo.Models.SelectorAgent", "SelectorAgent")
                        .WithMany("selectorAgentToJobs")
                        .HasForeignKey("SelectorAgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jobs");

                    b.Navigation("SelectorAgent");
                });

            modelBuilder.Entity("bolsa_de_trabajo.Models.Candidates", b =>
                {
                    b.Navigation("CV")
                        .IsRequired();

                    b.Navigation("candidatesToJobs");
                });

            modelBuilder.Entity("bolsa_de_trabajo.Models.Jobs", b =>
                {
                    b.Navigation("CandidatesToJobs");

                    b.Navigation("SelectorAgentToJobs");
                });

            modelBuilder.Entity("bolsa_de_trabajo.Models.SelectorAgent", b =>
                {
                    b.Navigation("selectorAgentToJobs");
                });
#pragma warning restore 612, 618
        }
    }
}
