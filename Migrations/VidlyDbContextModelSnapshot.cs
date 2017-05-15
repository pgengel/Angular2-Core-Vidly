using System;
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

            modelBuilder.Entity("Angular2_Core_Vidly.Core.DbModels.CustomerDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MembershipTypeId");

                    b.Property<string>("Name");

                    b.Property<bool>("isSubscribedToNewsLetter");

                    b.HasKey("Id");

                    b.HasIndex("MembershipTypeId");

                    b.ToTable("tb_Customer");
                });

            modelBuilder.Entity("Angular2_Core_Vidly.Core.DbModels.MembershipTypeDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("DiscountRate");

                    b.Property<byte>("DurationInMonths");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<short>("SignUpFee");

                    b.HasKey("Id");

                    b.ToTable("tb_MembershipType");
                });

            modelBuilder.Entity("Angular2_Core_Vidly.Core.DbModels.MovieDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("tb_Movie");
                });

            modelBuilder.Entity("Angular2_Core_Vidly.Core.DbModels.CustomerDbModel", b =>
                {
                    b.HasOne("Angular2_Core_Vidly.Core.DbModels.MembershipTypeDbModel", "MembershipType")
                        .WithMany()
                        .HasForeignKey("MembershipTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
