﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using dotnet_RPG.Services;

namespace dotnet_RPG.Migrations
{
    [DbContext(typeof(SeshBuilderDbContext))]
    [Migration("20200811114205_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("dotnet_RPG.Models.Pose", b =>
                {
                    b.Property<int>("PoseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("PoseName")
                        .HasColumnType("text");

                    b.HasKey("PoseId");

                    b.ToTable("Poses");
                });

            modelBuilder.Entity("dotnet_RPG.Models.SeshPose", b =>
                {
                    b.Property<int>("PoseId")
                        .HasColumnType("integer");

                    b.Property<int>("SessionId")
                        .HasColumnType("integer");

                    b.HasKey("PoseId", "SessionId");

                    b.HasIndex("SessionId");

                    b.ToTable("SeshPoses");
                });

            modelBuilder.Entity("dotnet_RPG.Models.Session", b =>
                {
                    b.Property<int>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("SessionName")
                        .HasColumnType("text");

                    b.HasKey("SessionId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("dotnet_RPG.Models.SeshPose", b =>
                {
                    b.HasOne("dotnet_RPG.Models.Pose", "Pose")
                        .WithMany("SeshPoseList")
                        .HasForeignKey("PoseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dotnet_RPG.Models.Session", "Session")
                        .WithMany("SeshPoseList")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
