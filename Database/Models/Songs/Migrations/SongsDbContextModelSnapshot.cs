﻿// <auto-generated />
using System;
using Database.Models.Songs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EKS_database_web.Data.Songs.Migrations
{
    [DbContext(typeof(SongsDbContext))]
    partial class SongsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("Database.Models.Songs.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("TEXT");

                    b.Property<long>("LastModified")
                        .HasColumnName("lastModified")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("Database.Models.Songs.Playlist", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("TEXT");

                    b.Property<long>("LastModified")
                        .HasColumnName("lastModified")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("playlists");
                });

            modelBuilder.Entity("Database.Models.Songs.Song", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .HasColumnName("author")
                        .HasColumnType("TEXT");

                    b.Property<long>("LastModified")
                        .HasColumnName("lastModified")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("Number")
                        .HasColumnName("number")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("songs");
                });

            modelBuilder.Entity("Database.Models.Songs.SongCategory", b =>
                {
                    b.Property<long>("SongId")
                        .HasColumnName("song")
                        .HasColumnType("INTEGER");

                    b.Property<long>("CategoryId")
                        .HasColumnName("category")
                        .HasColumnType("INTEGER");

                    b.HasKey("SongId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("song_category");
                });

            modelBuilder.Entity("Database.Models.Songs.SongPlaylist", b =>
                {
                    b.Property<long>("SongId")
                        .HasColumnName("song")
                        .HasColumnType("INTEGER");

                    b.Property<long>("PlaylistId")
                        .HasColumnName("playlist")
                        .HasColumnType("INTEGER");

                    b.HasKey("SongId", "PlaylistId");

                    b.HasIndex("PlaylistId");

                    b.ToTable("song_playlist");
                });

            modelBuilder.Entity("Database.Models.Songs.Verse", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SequenceNumber")
                        .HasColumnName("seqenceNumber")
                        .HasColumnType("INTEGER");

                    b.Property<long>("SongId")
                        .HasColumnName("songId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnName("text")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SongId");

                    b.ToTable("verses");
                });

            modelBuilder.Entity("Database.Models.Songs.SongCategory", b =>
                {
                    b.HasOne("Database.Models.Songs.Category", "Category")
                        .WithMany("SongCategories")
                        .HasForeignKey("CategoryId")
                        .IsRequired();

                    b.HasOne("Database.Models.Songs.Song", "Song")
                        .WithMany("SongCategories")
                        .HasForeignKey("SongId")
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.Songs.SongPlaylist", b =>
                {
                    b.HasOne("Database.Models.Songs.Playlist", "Playlist")
                        .WithMany("SongPlaylists")
                        .HasForeignKey("PlaylistId")
                        .IsRequired();

                    b.HasOne("Database.Models.Songs.Song", "Song")
                        .WithMany("SongPlaylists")
                        .HasForeignKey("SongId")
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.Songs.Verse", b =>
                {
                    b.HasOne("Database.Models.Songs.Song", "Song")
                        .WithMany("Verses")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
