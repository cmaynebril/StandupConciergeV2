﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StandupConciergeV2.Models;

namespace StandupConciergeV2.Migrations
{
    [DbContext(typeof(StandupConciergeContext))]
    [Migration("20190604074205_questions4")]
    partial class questions4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StandupConciergeV2.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ScheduleId");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("StandupConciergeV2.Models.QuestionsQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("QuestionId");

                    b.Property<string>("Questions");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionsQuestion");
                });

            modelBuilder.Entity("StandupConciergeV2.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("date");

                    b.Property<string>("day");

                    b.Property<string>("frequency");

                    b.Property<DateTime?>("time");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("StandupConciergeV2.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAdd");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StandupConciergeV2.Models.Question", b =>
                {
                    b.HasOne("StandupConciergeV2.Models.Schedule", "Schedule")
                        .WithMany("Questions")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StandupConciergeV2.Models.QuestionsQuestion", b =>
                {
                    b.HasOne("StandupConciergeV2.Models.Question", "Question")
                        .WithMany("QuestionsQuestion")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
