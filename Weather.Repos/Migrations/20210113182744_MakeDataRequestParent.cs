using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.DataAccess.Migrations
{
    public partial class MakeDataRequestParent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZipWeather_DataRequest_DataRequestId",
                table: "ZipWeather");

            migrationBuilder.DropIndex(
                name: "IX_ZipWeather_DataRequestId",
                table: "ZipWeather");

            migrationBuilder.DropColumn(
                name: "DataRequestId",
                table: "ZipWeather");

            migrationBuilder.AddColumn<int>(
                name: "ZipWeatherId",
                table: "DataRequest",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataRequest_ZipWeatherId",
                table: "DataRequest",
                column: "ZipWeatherId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataRequest_ZipWeather_ZipWeatherId",
                table: "DataRequest",
                column: "ZipWeatherId",
                principalTable: "ZipWeather",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataRequest_ZipWeather_ZipWeatherId",
                table: "DataRequest");

            migrationBuilder.DropIndex(
                name: "IX_DataRequest_ZipWeatherId",
                table: "DataRequest");

            migrationBuilder.DropColumn(
                name: "ZipWeatherId",
                table: "DataRequest");

            migrationBuilder.AddColumn<int>(
                name: "DataRequestId",
                table: "ZipWeather",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZipWeather_DataRequestId",
                table: "ZipWeather",
                column: "DataRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ZipWeather_DataRequest_DataRequestId",
                table: "ZipWeather",
                column: "DataRequestId",
                principalTable: "DataRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
