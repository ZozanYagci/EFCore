using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class studentAddressChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentAddresses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    District = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAddresses", x => x.Id);
                });

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

            migrationBuilder.DropTable(
                name: "StudentAddresses",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Students_AddressId",
                schema: "dbo",
                table: "Students");
        }
    }
}
