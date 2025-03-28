﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TVSorter.Data;

#nullable disable

namespace TVSorter.Migrations;

[DbContext(typeof(TvSorterDbContext))]
[Migration("20240101173216_Initial")]
partial class Initial
{
    /// <inheritdoc />
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

        modelBuilder.Entity("TVSorter.Data.Setting", b =>
            {
                b.Property<string>("SettingName")
                    .HasColumnType("TEXT");

                b.Property<string>("SettingValue")
                    .HasColumnType("TEXT");

                b.HasKey("SettingName");

                b.ToTable("Setting", (string)null);
            });

        modelBuilder.Entity("TVSorter.Model.Episode", b =>
            {
                b.Property<string>("TvdbId")
                    .HasColumnType("TEXT");

                b.Property<int>("EpisodeNumber")
                    .HasColumnType("INTEGER");

                b.Property<int>("FileCount")
                    .HasColumnType("INTEGER");

                b.Property<DateTime>("FirstAir")
                    .HasColumnType("TEXT");

                b.Property<string>("Name")
                    .HasColumnType("TEXT");

                b.Property<int>("SeasonNumber")
                    .HasColumnType("INTEGER");

                b.Property<int>("ShowId")
                    .HasColumnType("INTEGER");

                b.HasKey("TvdbId");

                b.HasIndex("ShowId");

                b.ToTable("Episodes");
            });

        modelBuilder.Entity("TVSorter.Model.TvShow", b =>
            {
                b.Property<int>("TvdbId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<string>("AlternateNames")
                    .HasColumnType("TEXT");

                b.Property<string>("Banner")
                    .HasColumnType("TEXT");

                b.Property<string>("CustomDestinationDir")
                    .HasColumnType("TEXT");

                b.Property<string>("CustomFormat")
                    .HasColumnType("TEXT");

                b.Property<string>("FolderName")
                    .HasColumnType("TEXT");

                b.Property<DateTime>("LastUpdated")
                    .HasColumnType("TEXT");

                b.Property<bool>("Locked")
                    .HasColumnType("INTEGER");

                b.Property<string>("Name")
                    .HasColumnType("TEXT");

                b.Property<bool>("UseCustomDestination")
                    .HasColumnType("INTEGER");

                b.Property<bool>("UseCustomFormat")
                    .HasColumnType("INTEGER");

                b.Property<bool>("UseDvdOrder")
                    .HasColumnType("INTEGER");

                b.HasKey("TvdbId");

                b.ToTable("TvShows");
            });

        modelBuilder.Entity("TVSorter.Model.Episode", b =>
            {
                b.HasOne("TVSorter.Model.TvShow", "Show")
                    .WithMany("Episodes")
                    .HasForeignKey("ShowId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Show");
            });

        modelBuilder.Entity("TVSorter.Model.TvShow", b =>
            {
                b.Navigation("Episodes");
            });
#pragma warning restore 612, 618
    }
}
