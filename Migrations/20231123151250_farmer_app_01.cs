using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class farmer_app_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.CreateTable(
                name: "Pesticide",
                columns: table => new
                {
                    PesticideID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PesticideName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SuitableFor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pesticide", x => x.PesticideID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Land",
                columns: table => new
                {
                    LandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    TotalArea = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberOfParts = table.Column<int>(type: "int", nullable: false),
                    ReadyForCultivation = table.Column<bool>(type: "bit", nullable: false),
                    DaysToReady = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Land", x => x.LandID);
                    table.ForeignKey(
                        name: "FK_Land_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LandPart",
                columns: table => new
                {
                    LandPartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LandID = table.Column<int>(type: "int", nullable: false),
                    PartNumber = table.Column<int>(type: "int", nullable: false),
                    CropType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeedCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LaborCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CultivationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandPart", x => x.LandPartID);
                    table.ForeignKey(
                        name: "FK_LandPart_Land_LandID",
                        column: x => x.LandID,
                        principalTable: "Land",
                        principalColumn: "LandID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LandPartPesticide",
                columns: table => new
                {
                    LandPartPesticideID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LandPartID = table.Column<int>(type: "int", nullable: false),
                    PesticideID = table.Column<int>(type: "int", nullable: false),
                    DateUsed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandPartPesticide", x => x.LandPartPesticideID);
                    table.ForeignKey(
                        name: "FK_LandPartPesticide_LandPart_LandPartID",
                        column: x => x.LandPartID,
                        principalTable: "LandPart",
                        principalColumn: "LandPartID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LandPartPesticide_Pesticide_PesticideID",
                        column: x => x.PesticideID,
                        principalTable: "Pesticide",
                        principalColumn: "PesticideID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yield",
                columns: table => new
                {
                    YieldID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LandPartID = table.Column<int>(type: "int", nullable: false),
                    YieldAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellingCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YieldDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yield", x => x.YieldID);
                    table.ForeignKey(
                        name: "FK_Yield_LandPart_LandPartID",
                        column: x => x.LandPartID,
                        principalTable: "LandPart",
                        principalColumn: "LandPartID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Land_UserID",
                table: "Land",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_LandPart_LandID",
                table: "LandPart",
                column: "LandID");

            migrationBuilder.CreateIndex(
                name: "IX_LandPartPesticide_LandPartID",
                table: "LandPartPesticide",
                column: "LandPartID");

            migrationBuilder.CreateIndex(
                name: "IX_LandPartPesticide_PesticideID",
                table: "LandPartPesticide",
                column: "PesticideID");

            migrationBuilder.CreateIndex(
                name: "IX_Yield_LandPartID",
                table: "Yield",
                column: "LandPartID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LandPartPesticide");

            migrationBuilder.DropTable(
                name: "Yield");

            migrationBuilder.DropTable(
                name: "Pesticide");

            migrationBuilder.DropTable(
                name: "LandPart");

            migrationBuilder.DropTable(
                name: "Land");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });
        }
    }
}
