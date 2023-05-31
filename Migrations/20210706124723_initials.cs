using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuroraAPI.Migrations
{
    public partial class initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doses (1)",
                columns: table => new
                {
                    dose_code = table.Column<int>(nullable: false),
                    dose_time = table.Column<TimeSpan>(nullable: false),
                    dose_date = table.Column<DateTime>(type: "date", nullable: false),
                    Time_of_abuse = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doses (1)", x => x.dose_code);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    medicine_code = table.Column<int>(nullable: false),
                    Medicine_Name = table.Column<string>(nullable: false),
                    no_of_tapes = table.Column<int>(nullable: false),
                    no_of_pills_in_tape = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.medicine_code);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false),
                    first_name = table.Column<string>(maxLength: 50, nullable: false),
                    last_name = table.Column<string>(maxLength: 50, nullable: true),
                    user_email = table.Column<string>(maxLength: 50, nullable: true),
                    city = table.Column<string>(maxLength: 50, nullable: true),
                    age = table.Column<int>(nullable: false),
                    weight = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "EC",
                columns: table => new
                {
                    contact_code = table.Column<int>(nullable: false),
                    User_ID = table.Column<int>(nullable: false),
                    first_name = table.Column<string>(maxLength: 50, nullable: false),
                    last_name = table.Column<string>(maxLength: 50, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EC", x => x.contact_code);
                    table.ForeignKey(
                        name: "FK_EC_users",
                        column: x => x.User_ID,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_dose_medicine",
                columns: table => new
                {
                    dose_code = table.Column<int>(nullable: false),
                    User_ID = table.Column<int>(nullable: false),
                    medicine_code = table.Column<int>(nullable: false),
                    number_of_pills = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_dose_medicine", x => x.dose_code);
                    table.ForeignKey(
                        name: "FK_user_dose_medicin_dose",
                        column: x => x.dose_code,
                        principalTable: "Doses (1)",
                        principalColumn: "dose_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_dose_medicinemedicine",
                        column: x => x.medicine_code,
                        principalTable: "Medicine",
                        principalColumn: "medicine_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_dose_medicine_user",
                        column: x => x.User_ID,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_phone",
                columns: table => new
                {
                    user_phone = table.Column<string>(fixedLength: true, maxLength: 15, nullable: false),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_phone", x => x.user_phone);
                    table.ForeignKey(
                        name: "FK_user_phone_user",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contact_phone",
                columns: table => new
                {
                    contact_phone = table.Column<string>(fixedLength: true, maxLength: 15, nullable: false),
                    contact_code = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact_phone", x => x.contact_phone);
                    table.ForeignKey(
                        name: "FK_contact_phone_EC",
                        column: x => x.contact_code,
                        principalTable: "EC",
                        principalColumn: "contact_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contact_phone_contact_code",
                table: "contact_phone",
                column: "contact_code");

            migrationBuilder.CreateIndex(
                name: "IX_EC_User_ID",
                table: "EC",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_user_dose_medicine_medicine_code",
                table: "user_dose_medicine",
                column: "medicine_code");

            migrationBuilder.CreateIndex(
                name: "IX_user_dose_medicine_User_ID",
                table: "user_dose_medicine",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_user_phone_user_id",
                table: "user_phone",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contact_phone");

            migrationBuilder.DropTable(
                name: "user_dose_medicine");

            migrationBuilder.DropTable(
                name: "user_phone");

            migrationBuilder.DropTable(
                name: "EC");

            migrationBuilder.DropTable(
                name: "Doses (1)");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
