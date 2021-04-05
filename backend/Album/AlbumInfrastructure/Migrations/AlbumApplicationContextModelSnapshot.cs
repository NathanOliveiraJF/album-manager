﻿// <auto-generated />
using AlbumInfrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlbumInfrastructure.Migrations
{
    [DbContext(typeof(AlbumApplicationContext))]
    partial class AlbumApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlbumDomain.Models.Album", b =>
                {
                    b.Property<string>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("AnoLancamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AlbumId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("AlbumDomain.Models.Musica", b =>
                {
                    b.Property<string>("MusicaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("AlbumId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Duracao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MusicaId");

                    b.HasIndex("AlbumId");

                    b.ToTable("Musica");
                });

            modelBuilder.Entity("AlbumDomain.Models.Musica", b =>
                {
                    b.HasOne("AlbumDomain.Models.Album", null)
                        .WithMany("Musicas")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AlbumDomain.Models.Album", b =>
                {
                    b.Navigation("Musicas");
                });
#pragma warning restore 612, 618
        }
    }
}
