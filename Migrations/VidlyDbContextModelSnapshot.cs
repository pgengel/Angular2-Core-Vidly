﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Angular2_Core_Vidly.Persistence;

namespace Vidly.Migrations
{
    [DbContext(typeof(VidlyDbContext))]
    partial class VidlyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vidly.Core.DbModels.CustomerDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Birthday");

                    b.Property<int>("MembershipTypeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("isSubscribedToNewsLetter");

                    b.HasKey("Id");

                    b.HasIndex("MembershipTypeId");

                    b.ToTable("tb_Customer");
                });

            modelBuilder.Entity("Vidly.Core.DbModels.GenreDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("tb_Genre");
                });

            modelBuilder.Entity("Vidly.Core.DbModels.MembershipTypeDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DiscountRate");

                    b.Property<int>("DurationInMonths");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("SignUpFee");

                    b.HasKey("Id");

                    b.ToTable("tb_MembershipType");
                });

            modelBuilder.Entity("Vidly.Core.DbModels.MovieDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAdded");

                    b.Property<int>("GenreId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("NumberAvailable");

                    b.Property<int>("NumberInStock");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<int?>("RentalDbModelId");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("RentalDbModelId");

                    b.ToTable("tb_Movie");
                });

            modelBuilder.Entity("Vidly.Core.DbModels.RentalDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<int>("MovieId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("tb_Rental");
                });

            modelBuilder.Entity("Vidly.Core.DbModels.CustomerDbModel", b =>
                {
                    b.HasOne("Vidly.Core.DbModels.MembershipTypeDbModel", "MembershipType")
                        .WithMany()
                        .HasForeignKey("MembershipTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vidly.Core.DbModels.MovieDbModel", b =>
                {
                    b.HasOne("Vidly.Core.DbModels.GenreDbModel", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vidly.Core.DbModels.RentalDbModel")
                        .WithMany("Movies")
                        .HasForeignKey("RentalDbModelId");
                });

            modelBuilder.Entity("Vidly.Core.DbModels.RentalDbModel", b =>
                {
                    b.HasOne("Vidly.Core.DbModels.CustomerDbModel", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
