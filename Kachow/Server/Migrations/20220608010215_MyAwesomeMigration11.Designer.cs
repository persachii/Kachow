﻿// <auto-generated />
using System;
using Kachow.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Kachow.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220608010215_MyAwesomeMigration11")]
    partial class MyAwesomeMigration11
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Kachow.Server.Data.Models.DeliveryMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("pk_delivery_methods");

                    b.ToTable("delivery_methods", (string)null);
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.DeliveryStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_delivery_statuses");

                    b.ToTable("delivery_statuses", (string)null);
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("ParcelForeignKey")
                        .HasColumnType("integer")
                        .HasColumnName("parcel_foreign_key");

                    b.Property<int>("Rate")
                        .HasColumnType("integer")
                        .HasColumnName("rate");

                    b.Property<int>("WorkerId")
                        .HasColumnType("integer")
                        .HasColumnName("worker_id");

                    b.HasKey("Id")
                        .HasName("pk_feedbacks");

                    b.HasIndex("ParcelForeignKey")
                        .IsUnique()
                        .HasDatabaseName("ix_feedbacks_parcel_foreign_key");

                    b.HasIndex("WorkerId")
                        .HasDatabaseName("ix_feedbacks_worker_id");

                    b.ToTable("feedbacks", (string)null);
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.Parcel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AnticipatedDeliveryDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("anticipated_delivery_date");

                    b.Property<int>("DeliveryMethodId")
                        .HasColumnType("integer")
                        .HasColumnName("delivery_method_id");

                    b.Property<int>("DeliveryStatusId")
                        .HasColumnType("integer")
                        .HasColumnName("delivery_status_id");

                    b.Property<string>("DepartmentAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("department_address");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("departure_date");

                    b.Property<string>("DestinationAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("destination_address");

                    b.Property<DateTime>("LastUpload")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_upload");

                    b.Property<int>("ParcelNameId")
                        .HasColumnType("integer")
                        .HasColumnName("parcel_name_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_parcels");

                    b.HasIndex("DeliveryMethodId")
                        .HasDatabaseName("ix_parcels_delivery_method_id");

                    b.HasIndex("DeliveryStatusId")
                        .HasDatabaseName("ix_parcels_delivery_status_id");

                    b.HasIndex("ParcelNameId")
                        .HasDatabaseName("ix_parcels_parcel_name_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_parcels_user_id");

                    b.ToTable("parcels", (string)null);
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.ParcelName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("pk_parcel_names");

                    b.ToTable("parcel_names", (string)null);
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.RefundCases", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime>("LastUpload")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_upload");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_refund_cases");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_refund_cases_user_id");

                    b.ToTable("refund_cases", (string)null);
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Fullname")
                        .HasColumnType("text")
                        .HasColumnName("fullname");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("password_hash");

                    b.Property<string>("PasswordResetToken")
                        .HasColumnType("text")
                        .HasColumnName("password_reset_token");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("password_salt");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("reset_token_expires");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("text")
                        .HasColumnName("verification_token");

                    b.Property<DateTime?>("VerifiedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("verified_at");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("fullname");

                    b.Property<int>("PassportNumber")
                        .HasColumnType("integer")
                        .HasColumnName("passport_number");

                    b.Property<int>("PassportSeries")
                        .HasColumnType("integer")
                        .HasColumnName("passport_series");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<string>("Tin")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("tin");

                    b.HasKey("Id")
                        .HasName("pk_workers");

                    b.ToTable("workers", (string)null);
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.Feedback", b =>
                {
                    b.HasOne("Kachow.Server.Data.Models.Parcel", "Parcel")
                        .WithOne("Feedback")
                        .HasForeignKey("Kachow.Server.Data.Models.Feedback", "ParcelForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_feedbacks_parcels_parcel_id");

                    b.HasOne("Kachow.Server.Data.Models.Worker", "Worker")
                        .WithMany("Feedbacks")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_feedbacks_workers_worker_id");

                    b.Navigation("Parcel");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.Parcel", b =>
                {
                    b.HasOne("Kachow.Server.Data.Models.DeliveryMethod", "DeliveryMethod")
                        .WithMany("Parcels")
                        .HasForeignKey("DeliveryMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_parcels_delivery_methods_delivery_method_id");

                    b.HasOne("Kachow.Server.Data.Models.DeliveryStatus", "DeliveryStatus")
                        .WithMany("Parcels")
                        .HasForeignKey("DeliveryStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_parcels_delivery_statuses_delivery_status_id");

                    b.HasOne("Kachow.Server.Data.Models.ParcelName", "ParcelName")
                        .WithMany("Parcels")
                        .HasForeignKey("ParcelNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_parcels_parcel_names_parcel_name_id");

                    b.HasOne("Kachow.Server.Data.Models.User", "User")
                        .WithMany("Parcels")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_parcels_users_user_id");

                    b.Navigation("DeliveryMethod");

                    b.Navigation("DeliveryStatus");

                    b.Navigation("ParcelName");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.RefundCases", b =>
                {
                    b.HasOne("Kachow.Server.Data.Models.User", "User")
                        .WithMany("RefundCases")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_refund_cases_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.DeliveryMethod", b =>
                {
                    b.Navigation("Parcels");
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.DeliveryStatus", b =>
                {
                    b.Navigation("Parcels");
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.Parcel", b =>
                {
                    b.Navigation("Feedback");
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.ParcelName", b =>
                {
                    b.Navigation("Parcels");
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.User", b =>
                {
                    b.Navigation("Parcels");

                    b.Navigation("RefundCases");
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.Worker", b =>
                {
                    b.Navigation("Feedbacks");
                });
#pragma warning restore 612, 618
        }
    }
}
