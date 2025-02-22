using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bledea_Aurica_Iuliana_SpitalApp.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceToAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Appointments",
                newName: "ServiceType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServiceType",
                table: "Appointments",
                newName: "Status");
        }
    }
}
