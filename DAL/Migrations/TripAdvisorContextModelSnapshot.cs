﻿// <auto-generated />
using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(TripAdvisorContext))]
    partial class TripAdvisorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("content");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasColumnType("int")
                        .HasColumnName("rank");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("title");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("UserId");

                    b.ToTable("comment", "trip_advisor");
                });

            modelBuilder.Entity("DAL.Models.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("place_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BathRoomCount")
                        .HasColumnType("int")
                        .HasColumnName("bath_count");

                    b.Property<int>("BedRoomCount")
                        .HasColumnType("int")
                        .HasColumnName("bed_count");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("city");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("desc");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("state");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)")
                        .HasColumnName("street");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("title");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("zip_code");

                    b.HasKey("PlaceId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("TypeId");

                    b.ToTable("place", "trip_advisor");
                });

            modelBuilder.Entity("DAL.Models.PlaceTag", b =>
                {
                    b.Property<int>("PlaceTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("place_tag_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("PlaceTagId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("TagId");

                    b.ToTable("place_tag", "trip_advisor");
                });

            modelBuilder.Entity("DAL.Models.PlaceType", b =>
                {
                    b.Property<int>("PlaceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("type_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("type");

                    b.HasKey("PlaceTypeId");

                    b.ToTable("place_type", "trip_advisor");
                });

            modelBuilder.Entity("DAL.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("tag_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("type");

                    b.HasKey("TagId");

                    b.ToTable("tag", "trip_advisor");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("first_name");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("surname");

                    b.Property<string>("user_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("user", "trip_advisor");

                    b.HasDiscriminator<string>("user_type").HasValue("user");
                });

            modelBuilder.Entity("DAL.Models.UserFavourite", b =>
                {
                    b.Property<int>("UserFavouriteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_favourite_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserFavouriteId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("UserId");

                    b.ToTable("user_favourite", "trip_advisor");
                });

            modelBuilder.Entity("DAL.Models.UserVisit", b =>
                {
                    b.Property<int>("UserVisitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_visit__id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserVisitId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("UserId");

                    b.ToTable("user_visit", "trip_advisor");
                });

            modelBuilder.Entity("DAL.Models.Owner", b =>
                {
                    b.HasBaseType("DAL.Models.User");

                    b.Property<string>("MailAddress")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)")
                        .HasColumnName("mail");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("password");

                    b.ToTable("user", "trip_advisor");

                    b.HasDiscriminator().HasValue("owner");
                });

            modelBuilder.Entity("DAL.Models.Comment", b =>
                {
                    b.HasOne("DAL.Models.Place", "Place")
                        .WithMany("Comments")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Place");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.Place", b =>
                {
                    b.HasOne("DAL.Models.Owner", "Owner")
                        .WithMany("Places")
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("FK_place_owner")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DAL.Models.PlaceType", "Type")
                        .WithMany("Places")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("FK_place_type")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Owner");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("DAL.Models.PlaceTag", b =>
                {
                    b.HasOne("DAL.Models.Place", "Place")
                        .WithMany("PlaceTags")
                        .HasForeignKey("PlaceId")
                        .HasConstraintName("FK_place_tag_place")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Tag", "Tag")
                        .WithMany("PlaceTags")
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK_place_tag_tag")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("DAL.Models.UserFavourite", b =>
                {
                    b.HasOne("DAL.Models.Place", "Place")
                        .WithMany("UserFavourites")
                        .HasForeignKey("PlaceId")
                        .HasConstraintName("FK_user_favourite_place")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany("UserFavourites")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_user_favourite_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.UserVisit", b =>
                {
                    b.HasOne("DAL.Models.Place", "Place")
                        .WithMany("UserVisits")
                        .HasForeignKey("PlaceId")
                        .HasConstraintName("FK_user_visit_place")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany("UserVisits")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_user_visit_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.Place", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PlaceTags");

                    b.Navigation("UserFavourites");

                    b.Navigation("UserVisits");
                });

            modelBuilder.Entity("DAL.Models.PlaceType", b =>
                {
                    b.Navigation("Places");
                });

            modelBuilder.Entity("DAL.Models.Tag", b =>
                {
                    b.Navigation("PlaceTags");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Navigation("UserFavourites");

                    b.Navigation("UserVisits");
                });

            modelBuilder.Entity("DAL.Models.Owner", b =>
                {
                    b.Navigation("Places");
                });
#pragma warning restore 612, 618
        }
    }
}
