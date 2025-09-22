using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS_BE.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class _20250907170305_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:citext", ",,");

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(26)", nullable: false),
                    username = table.Column<string>(type: "citext", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<short>(type: "smallint", nullable: false),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "citext", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    version = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_account", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "drug",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(26)", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    stock = table.Column<decimal>(type: "numeric", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    version = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_drug", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(26)", nullable: false),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    gender = table.Column<short>(type: "smallint", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    version = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_patient", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "account_token",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(26)", nullable: false),
                    account_id = table.Column<string>(type: "character varying(26)", nullable: false),
                    token = table.Column<string>(type: "text", nullable: false),
                    expires_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_account_token", x => x.id);
                    table.ForeignKey(
                        name: "fk_account_token_account_account_id",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "unit",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(26)", nullable: false),
                    drug_id = table.Column<string>(type: "character varying(26)", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    multiple = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_unit", x => x.id);
                    table.ForeignKey(
                        name: "fk_unit_drug_drug_id",
                        column: x => x.drug_id,
                        principalTable: "drug",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(26)", nullable: false),
                    patient_id = table.Column<string>(type: "character varying(26)", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contact", x => x.id);
                    table.ForeignKey(
                        name: "fk_contact_patient_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patient",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "visit",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(26)", nullable: false),
                    patient_id = table.Column<string>(type: "character varying(26)", nullable: false),
                    visit_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    symptoms = table.Column<string>(type: "text", nullable: false),
                    diagnosis = table.Column<string>(type: "text", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    visit_id = table.Column<string>(type: "character varying(26)", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_visit", x => x.id);
                    table.ForeignKey(
                        name: "fk_visit_patient_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_visit_visit_visit_id",
                        column: x => x.visit_id,
                        principalTable: "visit",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "prescription",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(26)", nullable: false),
                    visit_id = table.Column<string>(type: "character varying(26)", nullable: false),
                    drug_id = table.Column<string>(type: "character varying(26)", nullable: false),
                    dosage = table.Column<string>(type: "text", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    unit_id = table.Column<string>(type: "character varying(26)", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_prescription", x => x.id);
                    table.ForeignKey(
                        name: "fk_prescription_drug_drug_id",
                        column: x => x.drug_id,
                        principalTable: "drug",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_prescription_unit_unit_id",
                        column: x => x.unit_id,
                        principalTable: "unit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_prescription_visit_visit_id",
                        column: x => x.visit_id,
                        principalTable: "visit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_account_email",
                table: "account",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_account_id",
                table: "account",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_account_password_hash",
                table: "account",
                column: "password_hash");

            migrationBuilder.CreateIndex(
                name: "ix_account_username",
                table: "account",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_account_token_account_id",
                table: "account_token",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_token_id",
                table: "account_token",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_contact_id",
                table: "contact",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_contact_patient_id",
                table: "contact",
                column: "patient_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_drug_id",
                table: "drug",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_patient_id",
                table: "patient",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_prescription_drug_id",
                table: "prescription",
                column: "drug_id");

            migrationBuilder.CreateIndex(
                name: "ix_prescription_id",
                table: "prescription",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_prescription_unit_id",
                table: "prescription",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "ix_prescription_visit_id",
                table: "prescription",
                column: "visit_id");

            migrationBuilder.CreateIndex(
                name: "ix_unit_drug_id",
                table: "unit",
                column: "drug_id");

            migrationBuilder.CreateIndex(
                name: "ix_unit_id",
                table: "unit",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_visit_id",
                table: "visit",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_visit_patient_id",
                table: "visit",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "ix_visit_visit_id",
                table: "visit",
                column: "visit_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account_token");

            migrationBuilder.DropTable(
                name: "contact");

            migrationBuilder.DropTable(
                name: "prescription");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "unit");

            migrationBuilder.DropTable(
                name: "visit");

            migrationBuilder.DropTable(
                name: "drug");

            migrationBuilder.DropTable(
                name: "patient");
        }
    }
}
