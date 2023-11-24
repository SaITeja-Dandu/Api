using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class farmer_app_03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FCultivation_FLand_LandId",
                table: "FCultivation");

            migrationBuilder.DropForeignKey(
                name: "FK_FHarvest_FCultivation_CultivationId",
                table: "FHarvest");

            migrationBuilder.DropForeignKey(
                name: "FK_FLand_FUser_UserId",
                table: "FLand");

            migrationBuilder.DropForeignKey(
                name: "FK_FPesticide_FCultivation_CultivationId",
                table: "FPesticide");

            migrationBuilder.DropForeignKey(
                name: "FK_FReports_FHarvest_HarvestId",
                table: "FReports");

            migrationBuilder.DropForeignKey(
                name: "FK_FWatering_FCultivation_CultivationId",
                table: "FWatering");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FWatering",
                table: "FWatering");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FUser",
                table: "FUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FReports",
                table: "FReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FPesticide",
                table: "FPesticide");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FLand",
                table: "FLand");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FHarvest",
                table: "FHarvest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FCultivation",
                table: "FCultivation");

            migrationBuilder.RenameTable(
                name: "FWatering",
                newName: "F_Watering");

            migrationBuilder.RenameTable(
                name: "FUser",
                newName: "F_User");

            migrationBuilder.RenameTable(
                name: "FReports",
                newName: "F_Reports");

            migrationBuilder.RenameTable(
                name: "FPesticide",
                newName: "F_Pesticide");

            migrationBuilder.RenameTable(
                name: "FLand",
                newName: "F_Land");

            migrationBuilder.RenameTable(
                name: "FHarvest",
                newName: "F_Harvest");

            migrationBuilder.RenameTable(
                name: "FCultivation",
                newName: "F_Cultivation");

            migrationBuilder.RenameIndex(
                name: "IX_FWatering_CultivationId",
                table: "F_Watering",
                newName: "IX_F_Watering_CultivationId");

            migrationBuilder.RenameIndex(
                name: "IX_FReports_HarvestId",
                table: "F_Reports",
                newName: "IX_F_Reports_HarvestId");

            migrationBuilder.RenameIndex(
                name: "IX_FPesticide_CultivationId",
                table: "F_Pesticide",
                newName: "IX_F_Pesticide_CultivationId");

            migrationBuilder.RenameIndex(
                name: "IX_FLand_UserId",
                table: "F_Land",
                newName: "IX_F_Land_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FHarvest_CultivationId",
                table: "F_Harvest",
                newName: "IX_F_Harvest_CultivationId");

            migrationBuilder.RenameIndex(
                name: "IX_FCultivation_LandId",
                table: "F_Cultivation",
                newName: "IX_F_Cultivation_LandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_F_Watering",
                table: "F_Watering",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_F_User",
                table: "F_User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_F_Reports",
                table: "F_Reports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_F_Pesticide",
                table: "F_Pesticide",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_F_Land",
                table: "F_Land",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_F_Harvest",
                table: "F_Harvest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_F_Cultivation",
                table: "F_Cultivation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_F_Cultivation_F_Land_LandId",
                table: "F_Cultivation",
                column: "LandId",
                principalTable: "F_Land",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_F_Harvest_F_Cultivation_CultivationId",
                table: "F_Harvest",
                column: "CultivationId",
                principalTable: "F_Cultivation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_F_Land_F_User_UserId",
                table: "F_Land",
                column: "UserId",
                principalTable: "F_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_F_Pesticide_F_Cultivation_CultivationId",
                table: "F_Pesticide",
                column: "CultivationId",
                principalTable: "F_Cultivation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_F_Reports_F_Harvest_HarvestId",
                table: "F_Reports",
                column: "HarvestId",
                principalTable: "F_Harvest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_F_Watering_F_Cultivation_CultivationId",
                table: "F_Watering",
                column: "CultivationId",
                principalTable: "F_Cultivation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_F_Cultivation_F_Land_LandId",
                table: "F_Cultivation");

            migrationBuilder.DropForeignKey(
                name: "FK_F_Harvest_F_Cultivation_CultivationId",
                table: "F_Harvest");

            migrationBuilder.DropForeignKey(
                name: "FK_F_Land_F_User_UserId",
                table: "F_Land");

            migrationBuilder.DropForeignKey(
                name: "FK_F_Pesticide_F_Cultivation_CultivationId",
                table: "F_Pesticide");

            migrationBuilder.DropForeignKey(
                name: "FK_F_Reports_F_Harvest_HarvestId",
                table: "F_Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_F_Watering_F_Cultivation_CultivationId",
                table: "F_Watering");

            migrationBuilder.DropPrimaryKey(
                name: "PK_F_Watering",
                table: "F_Watering");

            migrationBuilder.DropPrimaryKey(
                name: "PK_F_User",
                table: "F_User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_F_Reports",
                table: "F_Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_F_Pesticide",
                table: "F_Pesticide");

            migrationBuilder.DropPrimaryKey(
                name: "PK_F_Land",
                table: "F_Land");

            migrationBuilder.DropPrimaryKey(
                name: "PK_F_Harvest",
                table: "F_Harvest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_F_Cultivation",
                table: "F_Cultivation");

            migrationBuilder.RenameTable(
                name: "F_Watering",
                newName: "FWatering");

            migrationBuilder.RenameTable(
                name: "F_User",
                newName: "FUser");

            migrationBuilder.RenameTable(
                name: "F_Reports",
                newName: "FReports");

            migrationBuilder.RenameTable(
                name: "F_Pesticide",
                newName: "FPesticide");

            migrationBuilder.RenameTable(
                name: "F_Land",
                newName: "FLand");

            migrationBuilder.RenameTable(
                name: "F_Harvest",
                newName: "FHarvest");

            migrationBuilder.RenameTable(
                name: "F_Cultivation",
                newName: "FCultivation");

            migrationBuilder.RenameIndex(
                name: "IX_F_Watering_CultivationId",
                table: "FWatering",
                newName: "IX_FWatering_CultivationId");

            migrationBuilder.RenameIndex(
                name: "IX_F_Reports_HarvestId",
                table: "FReports",
                newName: "IX_FReports_HarvestId");

            migrationBuilder.RenameIndex(
                name: "IX_F_Pesticide_CultivationId",
                table: "FPesticide",
                newName: "IX_FPesticide_CultivationId");

            migrationBuilder.RenameIndex(
                name: "IX_F_Land_UserId",
                table: "FLand",
                newName: "IX_FLand_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_F_Harvest_CultivationId",
                table: "FHarvest",
                newName: "IX_FHarvest_CultivationId");

            migrationBuilder.RenameIndex(
                name: "IX_F_Cultivation_LandId",
                table: "FCultivation",
                newName: "IX_FCultivation_LandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FWatering",
                table: "FWatering",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FUser",
                table: "FUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FReports",
                table: "FReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FPesticide",
                table: "FPesticide",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FLand",
                table: "FLand",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FHarvest",
                table: "FHarvest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FCultivation",
                table: "FCultivation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FCultivation_FLand_LandId",
                table: "FCultivation",
                column: "LandId",
                principalTable: "FLand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FHarvest_FCultivation_CultivationId",
                table: "FHarvest",
                column: "CultivationId",
                principalTable: "FCultivation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FLand_FUser_UserId",
                table: "FLand",
                column: "UserId",
                principalTable: "FUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FPesticide_FCultivation_CultivationId",
                table: "FPesticide",
                column: "CultivationId",
                principalTable: "FCultivation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FReports_FHarvest_HarvestId",
                table: "FReports",
                column: "HarvestId",
                principalTable: "FHarvest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FWatering_FCultivation_CultivationId",
                table: "FWatering",
                column: "CultivationId",
                principalTable: "FCultivation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
