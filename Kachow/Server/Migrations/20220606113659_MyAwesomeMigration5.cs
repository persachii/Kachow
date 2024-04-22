using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Kachow.Server.Migrations
{
    public partial class MyAwesomeMigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_parcels_customers_customer_id",
                table: "parcels");

            migrationBuilder.DropForeignKey(
                name: "fk_refund_cases_customers_customer_id",
                table: "refund_cases");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "offices");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "refund_cases",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "ix_refund_cases_customer_id",
                table: "refund_cases",
                newName: "ix_refund_cases_user_id");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "parcels",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "ix_parcels_customer_id",
                table: "parcels",
                newName: "ix_parcels_user_id");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "refund_cases",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<byte[]>(type: "bytea", nullable: false),
                    password_salt = table.Column<byte[]>(type: "bytea", nullable: false),
                    verification_token = table.Column<string>(type: "text", nullable: true),
                    verified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    password_reset_token = table.Column<string>(type: "text", nullable: true),
                    reset_token_expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fullname = table.Column<string>(type: "text", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "workers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullname = table.Column<string>(type: "text", nullable: false),
                    passport_series = table.Column<int>(type: "integer", nullable: false),
                    passport_number = table.Column<int>(type: "integer", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    tin = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "feedbacks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rate = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    parcel_foreign_key = table.Column<int>(type: "integer", nullable: false),
                    worker_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_feedbacks", x => x.id);
                    table.ForeignKey(
                        name: "fk_feedbacks_parcels_parcel_id",
                        column: x => x.parcel_foreign_key,
                        principalTable: "parcels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_feedbacks_workers_worker_id",
                        column: x => x.worker_id,
                        principalTable: "workers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_feedbacks_parcel_foreign_key",
                table: "feedbacks",
                column: "parcel_foreign_key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_feedbacks_worker_id",
                table: "feedbacks",
                column: "worker_id");

            migrationBuilder.AddForeignKey(
                name: "fk_parcels_users_user_id",
                table: "parcels",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_refund_cases_users_user_id",
                table: "refund_cases",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_parcels_users_user_id",
                table: "parcels");

            migrationBuilder.DropForeignKey(
                name: "fk_refund_cases_users_user_id",
                table: "refund_cases");

            migrationBuilder.DropTable(
                name: "feedbacks");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "workers");

            migrationBuilder.DropColumn(
                name: "description",
                table: "refund_cases");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "refund_cases",
                newName: "customer_id");

            migrationBuilder.RenameIndex(
                name: "ix_refund_cases_user_id",
                table: "refund_cases",
                newName: "ix_refund_cases_customer_id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "parcels",
                newName: "customer_id");

            migrationBuilder.RenameIndex(
                name: "ix_parcels_user_id",
                table: "parcels",
                newName: "ix_parcels_customer_id");

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    address = table.Column<string>(type: "text", nullable: false),
                    fullname = table.Column<string>(type: "text", nullable: false),
                    passport_number = table.Column<int>(type: "integer", nullable: false),
                    passport_series = table.Column<int>(type: "integer", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    zip_code = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.id);
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

            migrationBuilder.AddForeignKey(
                name: "fk_parcels_customers_customer_id",
                table: "parcels",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_refund_cases_customers_customer_id",
                table: "refund_cases",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
