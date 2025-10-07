using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZoologicoCrud.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAnimalEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Carers_CarerId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Habitads_HabitadId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Species_SpecieId",
                table: "Animals");

            migrationBuilder.AlterColumn<int>(
                name: "SpecieId",
                table: "Animals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HabitadId",
                table: "Animals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarerId",
                table: "Animals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Carers_CarerId",
                table: "Animals",
                column: "CarerId",
                principalTable: "Carers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Habitads_HabitadId",
                table: "Animals",
                column: "HabitadId",
                principalTable: "Habitads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Species_SpecieId",
                table: "Animals",
                column: "SpecieId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Carers_CarerId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Habitads_HabitadId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Species_SpecieId",
                table: "Animals");

            migrationBuilder.AlterColumn<int>(
                name: "SpecieId",
                table: "Animals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HabitadId",
                table: "Animals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CarerId",
                table: "Animals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Carers_CarerId",
                table: "Animals",
                column: "CarerId",
                principalTable: "Carers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Habitads_HabitadId",
                table: "Animals",
                column: "HabitadId",
                principalTable: "Habitads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Species_SpecieId",
                table: "Animals",
                column: "SpecieId",
                principalTable: "Species",
                principalColumn: "Id");
        }
    }
}
