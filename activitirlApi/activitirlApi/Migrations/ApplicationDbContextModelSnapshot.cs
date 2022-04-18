﻿// <auto-generated />
using System;
using ActivitIRLApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ActivitIRLApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ActivitIRLApi.Models.Entities.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"), 1L, 1);

                    b.Property<string>("Comments")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedInEventId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("CreatedInEventId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ActivitIRLApi.Models.Entities.Preference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Preferences");
                });

            modelBuilder.Entity("ActivitIRLApi.Models.Entities.User", b =>
                {
                    b.Property<int?>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("UserId"), 1L, 1);

                    b.Property<string>("Alias")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("ApartmentNumber")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasMaxLength(20)
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Gender")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("LastName")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<byte[]>("PWHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varbinary(255)");

                    b.Property<byte[]>("PWSalt")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varbinary(255)");

                    b.Property<int?>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StreetName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ZipCode")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("Alias")
                        .IsUnique()
                        .HasFilter("[Alias] IS NOT NULL");

                    b.HasIndex("EmailAddress")
                        .IsUnique()
                        .HasFilter("[EmailAddress] IS NOT NULL");

                    b.HasIndex("EventId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ActivitIRLApi.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"), 1L, 1);

                    b.Property<string>("Activity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ApartmentNumber")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("bit");

                    b.Property<int>("MaxAge")
                        .HasColumnType("int");

                    b.Property<int>("MaxUsers")
                        .HasColumnType("int");

                    b.Property<int>("MinAge")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDeadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ActivitIRLApi.Models.Entities.Comment", b =>
                {
                    b.HasOne("ActivitIRLApi.Models.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ActivitIRLApi.Models.Event", "CreatedIn")
                        .WithMany("Comments")
                        .HasForeignKey("CreatedInEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("CreatedIn");
                });

            modelBuilder.Entity("ActivitIRLApi.Models.Entities.Preference", b =>
                {
                    b.HasOne("ActivitIRLApi.Models.Entities.User", null)
                        .WithMany("preferences")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ActivitIRLApi.Models.Entities.User", b =>
                {
                    b.HasOne("ActivitIRLApi.Models.Event", null)
                        .WithMany("ListOfUsers")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("ActivitIRLApi.Models.Entities.User", b =>
                {
                    b.Navigation("preferences");
                });

            modelBuilder.Entity("ActivitIRLApi.Models.Event", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("ListOfUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
