using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddDayEntityAndIsNoActiveToTaskEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayEntityId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsNoActive",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_DayEntityId",
                table: "Tasks",
                column: "DayEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Days_DayEntityId",
                table: "Tasks",
                column: "DayEntityId",
                principalTable: "Days",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Days_DayEntityId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_DayEntityId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "DayEntityId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IsNoActive",
                table: "Tasks");
        }
    }
}
