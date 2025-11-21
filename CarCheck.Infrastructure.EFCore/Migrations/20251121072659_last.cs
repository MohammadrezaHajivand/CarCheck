using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarCheck.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionRequests_Users_UserId",
                table: "InspectionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionRequests_Users_UserId1",
                table: "InspectionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionRequests_Vehicles_VehicleId1",
                table: "InspectionRequests");

            migrationBuilder.DropIndex(
                name: "IX_InspectionRequests_UserId1",
                table: "InspectionRequests");

            migrationBuilder.DropIndex(
                name: "IX_InspectionRequests_VehicleId1",
                table: "InspectionRequests");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "InspectionRequests");

            migrationBuilder.DropColumn(
                name: "VehicleId1",
                table: "InspectionRequests");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionRequests_Users_UserId",
                table: "InspectionRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionRequests_Users_UserId",
                table: "InspectionRequests");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "InspectionRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId1",
                table: "InspectionRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionRequests_UserId1",
                table: "InspectionRequests",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionRequests_VehicleId1",
                table: "InspectionRequests",
                column: "VehicleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionRequests_Users_UserId",
                table: "InspectionRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionRequests_Users_UserId1",
                table: "InspectionRequests",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionRequests_Vehicles_VehicleId1",
                table: "InspectionRequests",
                column: "VehicleId1",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
