using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocumentName",
                table: "TenderDocuments",
                newName: "Notes");

            migrationBuilder.AddColumn<byte[]>(
                name: "Document",
                table: "TenderDocuments",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TenderDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "TenderDocuments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Document",
                table: "TenderDocuments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TenderDocuments");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "TenderDocuments");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "TenderDocuments",
                newName: "DocumentName");
        }
    }
}
