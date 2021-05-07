using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Day09.Migrations
{
    public partial class relational : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrackID",
                table: "Trainees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrackID",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_TrackID",
                table: "Trainees",
                column: "TrackID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TrackID",
                table: "Courses",
                column: "TrackID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Tracks_TrackID",
                table: "Courses",
                column: "TrackID",
                principalTable: "Tracks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Tracks_TrackID",
                table: "Trainees",
                column: "TrackID",
                principalTable: "Tracks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Tracks_TrackID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Tracks_TrackID",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Trainees_TrackID",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TrackID",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TrackID",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "TrackID",
                table: "Courses");
        }
    }
}
