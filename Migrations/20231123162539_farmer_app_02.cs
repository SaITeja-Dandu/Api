using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class farmer_app_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FLand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TotalArea = table.Column<double>(type: "float", nullable: false),
                    NumberOfParts = table.Column<int>(type: "int", nullable: false),
                    IsReadyForCultivation = table.Column<bool>(type: "bit", nullable: false),
                    DaysToReady = table.Column<int>(type: "int", nullable: false),
                    CultivationType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FLand_FUser_UserId",
                        column: x => x.UserId,
                        principalTable: "FUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FCultivation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LandId = table.Column<int>(type: "int", nullable: false),
                    PlantType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeedCost = table.Column<double>(type: "float", nullable: false),
                    MaintenanceCost = table.Column<double>(type: "float", nullable: false),
                    CultivationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FCultivation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FCultivation_FLand_LandId",
                        column: x => x.LandId,
                        principalTable: "FLand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FHarvest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CultivationId = table.Column<int>(type: "int", nullable: false),
                    Yield = table.Column<double>(type: "float", nullable: false),
                    SellingCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FHarvest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FHarvest_FCultivation_CultivationId",
                        column: x => x.CultivationId,
                        principalTable: "FCultivation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FPesticide",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CultivationId = table.Column<int>(type: "int", nullable: false),
                    PesticideType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FPesticide", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FPesticide_FCultivation_CultivationId",
                        column: x => x.CultivationId,
                        principalTable: "FCultivation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FWatering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CultivationId = table.Column<int>(type: "int", nullable: false),
                    WateringFrequency = table.Column<int>(type: "int", nullable: false),
                    WateringDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FWatering", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FWatering_FCultivation_CultivationId",
                        column: x => x.CultivationId,
                        principalTable: "FCultivation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HarvestId = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    GrossProfit = table.Column<double>(type: "float", nullable: false),
                    NetProfit = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FReports_FHarvest_HarvestId",
                        column: x => x.HarvestId,
                        principalTable: "FHarvest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FCultivation_LandId",
                table: "FCultivation",
                column: "LandId");

            migrationBuilder.CreateIndex(
                name: "IX_FHarvest_CultivationId",
                table: "FHarvest",
                column: "CultivationId");

            migrationBuilder.CreateIndex(
                name: "IX_FLand_UserId",
                table: "FLand",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FPesticide_CultivationId",
                table: "FPesticide",
                column: "CultivationId");

            migrationBuilder.CreateIndex(
                name: "IX_FReports_HarvestId",
                table: "FReports",
                column: "HarvestId");

            migrationBuilder.CreateIndex(
                name: "IX_FWatering_CultivationId",
                table: "FWatering",
                column: "CultivationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FPesticide");

            migrationBuilder.DropTable(
                name: "FReports");

            migrationBuilder.DropTable(
                name: "FWatering");

            migrationBuilder.DropTable(
                name: "FHarvest");

            migrationBuilder.DropTable(
                name: "FCultivation");

            migrationBuilder.DropTable(
                name: "FLand");

            migrationBuilder.DropTable(
                name: "FUser");
        }
    }
}
