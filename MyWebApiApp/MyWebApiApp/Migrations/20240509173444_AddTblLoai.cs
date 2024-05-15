using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebApiApp.Migrations
{
    public partial class AddTblLoai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "maLoai",
                table: "HangHoa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Loai",
                columns: table => new
                {
                    maLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loai", x => x.maLoai);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_maLoai",
                table: "HangHoa",
                column: "maLoai");

            migrationBuilder.AddForeignKey(
                name: "FK_HangHoa_Loai_maLoai",
                table: "HangHoa",
                column: "maLoai",
                principalTable: "Loai",
                principalColumn: "maLoai",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HangHoa_Loai_maLoai",
                table: "HangHoa");

            migrationBuilder.DropTable(
                name: "Loai");

            migrationBuilder.DropIndex(
                name: "IX_HangHoa_maLoai",
                table: "HangHoa");

            migrationBuilder.DropColumn(
                name: "maLoai",
                table: "HangHoa");
        }
    }
}
