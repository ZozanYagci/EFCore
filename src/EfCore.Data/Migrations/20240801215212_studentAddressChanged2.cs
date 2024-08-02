using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class studentAddressChanged2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                schema: "dbo",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_AddressId",
                schema: "dbo",
                table: "Students",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "student_address_student_id_fk",
                schema: "dbo",
                table: "Students",
                column: "AddressId",
                principalSchema: "dbo",
                principalTable: "StudentAddresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "student_address_student_id_fk",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_AddressId",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AddressId",
                schema: "dbo",
                table: "Students");
        }
    }
}
