using Kolokwium.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {
        }

        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        
        public DbSet<MyAlbum> Albums { get; set; }
        public DbSet<MyMusician> Musicians { get; set; }
        public DbSet<MyMusician_Track> MusicianTracks { get; set; }
        public DbSet<MyMusicLabel> MusicLabels { get; set; }
        public DbSet<MyTrack> Tracks { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MyMusician>(m =>
           {
               m.HasKey(m => m.IdMusician);
               m.Property(m => m.FirstName).IsRequired().HasMaxLength(30);
               m.Property(m => m.LastName).IsRequired().HasMaxLength(50);
               m.Property(m => m.NickName).HasMaxLength(20);

               m.HasMany(m => m.MusicianTracks).WithOne(m => m.MyMusician).HasForeignKey(m => m.IdMusician);
               
               m.HasData(
                   new MyMusician
                   {
                       IdMusician = 1,
                       FirstName = "Jakub",
                       LastName = "Montewka"
                   },
                   new MyMusician
                   {
                       IdMusician = 2,
                       FirstName = "Wojciech",
                       LastName = "Siekierzyński",
                       NickName = "Siekiera"
                   });
               
           });

            modelBuilder.Entity<Musician_Track>(mt =>
           {
               mt.HasKey(mt => mt.IdTrack);
               mt.HasKey(mt => mt.IdMusician);

               mt.HasOne(m => m.Musician).WithMany(m => m.MusicianTracks).HasForeignKey(m => m.IdMusician);
               mt.HasOne(t => t.Track).WithMany(t => t.MusicianTracks).HasForeignKey(t => t.IdTrack);
               
               mt.HasData(
                   new Musician_Track
                   {
                       IdTrack = 1,
                       IdMusician = 1
                   },
                   new Musician_Track
                   {
                       IdTrack = 2,
                       IdMusician = 2
                   });
               
           });

            modelBuilder.Entity<Track>(t =>
            {
                t.HasKey(t => t.IdTrack);
                t.Property(t => t.TrackName).IsRequired().HasMaxLength(20);
                t.Property(t => t.Duration).IsRequired();
                t.Property(t => t.IdMusicAlbum);

                t.HasMany(tr => tr.MusicianTracks).WithOne(tr => tr.Track).HasForeignKey(tr => tr.IdTrack);
                t.HasOne(a => a.Album).WithMany(a => a.Tracks).HasForeignKey(a => a.IdTrack);

                
                t.HasData(
                    new Track
                    {
                        IdTrack = 1,
                        TrackName = "Polonez F-dur",
                        Duration = 314,
                        IdMusicAlbum = 2
                    },
                    new Track
                    {
                        IdTrack = 2,
                        TrackName = "Show must go on!",
                        Duration = 501,
                        IdMusicAlbum = 1
                    });
                
            });

            modelBuilder.Entity<MyAlbum>(a =>
            {
                a.HasKey(a => a.IdAlbum);
                a.Property(a => a.AlbumName).IsRequired().HasMaxLength(30);
                a.Property(a => a.PublishDate).IsRequired();
                a.Property(a => a.IdMusicLabel);

                a.HasMany(tr => tr.MyTracks).WithOne(tr => tr.MyAlbum).HasForeignKey(tr => tr.IdMusicAlbum);
                a.HasOne(m => m.MyMusicLabel).WithMany(a => a.MyAlbums).HasForeignKey(m => m.IdMusicLabel);

                a.HasData(
                    new MyAlbum
                    {
                        IdAlbum = 1,
                        AlbumName = "Bohemian Rhapsody",
                        PublishDate = DateTime.Parse("1972-03-12"),
                        IdMusicLabel = 1
                    },
                    new MyAlbum
                    {
                        IdAlbum = 2,
                        AlbumName = "chopin - top 99",
                        PublishDate = DateTime.Parse("1909-11-12"),
                        IdMusicLabel = 1
                    });
            });

            modelBuilder.Entity<MyMusicLabel>(ml =>
            {
                ml.HasKey(ml => ml.IdMusicLabel);
                ml.Property(ml => ml.Name).IsRequired().HasMaxLength(50);

                ml.HasData(
                    new MyMusicLabel
                    {
                        IdMusicLabel = 1,
                        Name = "Muzyka klasyczna"
                    });
            });

        }
    }
}
