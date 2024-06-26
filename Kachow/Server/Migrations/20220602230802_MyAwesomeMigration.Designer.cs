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
    [Migration("20220602230802_MyAwesomeMigration")]
    partial class MyAwesomeMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Kachow.Server.Data.Models.Customer", b =>
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

                    b.Property<int>("ZipCode")
                        .HasColumnType("integer")
                        .HasColumnName("zip_code");

                    b.HasKey("Id")
                        .HasName("pk_customers");

                    b.ToTable("customers", (string)null);
                });

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

            modelBuilder.Entity("Kachow.Server.Data.Models.Office", b =>
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

                    b.Property<int>("Phone")
                        .HasColumnType("integer")
                        .HasColumnName("phone");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_offices");

                    b.ToTable("offices", (string)null);
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

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer")
                        .HasColumnName("customer_id");

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

                    b.HasKey("Id")
                        .HasName("pk_parcels");

                    b.HasIndex("CustomerId")
                        .HasDatabaseName("ix_parcels_customer_id");

                    b.HasIndex("DeliveryMethodId")
                        .HasDatabaseName("ix_parcels_delivery_method_id");

                    b.HasIndex("DeliveryStatusId")
                        .HasDatabaseName("ix_parcels_delivery_status_id");

                    b.HasIndex("ParcelNameId")
                        .HasDatabaseName("ix_parcels_parcel_name_id");

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

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer")
                        .HasColumnName("customer_id");

                    b.Property<DateTime>("LastUpload")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_upload");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_refund_cases");

                    b.HasIndex("CustomerId")
                        .HasDatabaseName("ix_refund_cases_customer_id");

                    b.ToTable("refund_cases", (string)null);
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.Parcel", b =>
                {
                    b.HasOne("Kachow.Server.Data.Models.Customer", "Customer")
                        .WithMany("Parcels")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_parcels_customers_customer_id");

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

                    b.Navigation("Customer");

                    b.Navigation("DeliveryMethod");

                    b.Navigation("DeliveryStatus");

                    b.Navigation("ParcelName");
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.RefundCases", b =>
                {
                    b.HasOne("Kachow.Server.Data.Models.Customer", "Customer")
                        .WithMany("RefundCases")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_refund_cases_customers_customer_id");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.Customer", b =>
                {
                    b.Navigation("Parcels");

                    b.Navigation("RefundCases");
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.DeliveryMethod", b =>
                {
                    b.Navigation("Parcels");
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.DeliveryStatus", b =>
                {
                    b.Navigation("Parcels");
                });

            modelBuilder.Entity("Kachow.Server.Data.Models.ParcelName", b =>
                {
                    b.Navigation("Parcels");
                });
#pragma warning restore 612, 618
        }
    }
}
