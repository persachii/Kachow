using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Kachow.Server.Migrations
{
    public partial class MyAwesomeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullname = table.Column<string>(type: "text", nullable: false),
                    passport_series = table.Column<int>(type: "integer", nullable: false),
                    passport_number = table.Column<int>(type: "integer", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    zip_code = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "delivery_methods",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_delivery_methods", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "delivery_statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_delivery_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "offices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    address = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_offices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "parcel_names",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_parcel_names", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "refund_cases",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customer_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    last_upload = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_refund_cases", x => x.id);
                    table.ForeignKey(
                        name: "fk_refund_cases_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "parcels",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    parcel_name_id = table.Column<int>(type: "integer", nullable: false),
                    department_address = table.Column<string>(type: "text", nullable: false),
                    destination_address = table.Column<string>(type: "text", nullable: false),
                    departure_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    anticipated_delivery_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_upload = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    delivery_status_id = table.Column<int>(type: "integer", nullable: false),
                    customer_id = table.Column<int>(type: "integer", nullable: false),
                    delivery_method_id = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_parcels", x => x.id);
                    table.ForeignKey(
                        name: "fk_parcels_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_parcels_delivery_methods_delivery_method_id",
                        column: x => x.delivery_method_id,
                        principalTable: "delivery_methods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_parcels_delivery_statuses_delivery_status_id",
                        column: x => x.delivery_status_id,
                        principalTable: "delivery_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_parcels_parcel_names_parcel_name_id",
                        column: x => x.parcel_name_id,
                        principalTable: "parcel_names",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_parcels_customer_id",
                table: "parcels",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_parcels_delivery_method_id",
                table: "parcels",
                column: "delivery_method_id");

            migrationBuilder.CreateIndex(
                name: "ix_parcels_delivery_status_id",
                table: "parcels",
                column: "delivery_status_id");

            migrationBuilder.CreateIndex(
                name: "ix_parcels_parcel_name_id",
                table: "parcels",
                column: "parcel_name_id");

            migrationBuilder.CreateIndex(
                name: "ix_refund_cases_customer_id",
                table: "refund_cases",
                column: "customer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "offices");

            migrationBuilder.DropTable(
                name: "parcels");

            migrationBuilder.DropTable(
                name: "refund_cases");

            migrationBuilder.DropTable(
                name: "delivery_methods");

            migrationBuilder.DropTable(
                name: "delivery_statuses");

            migrationBuilder.DropTable(
                name: "parcel_names");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
