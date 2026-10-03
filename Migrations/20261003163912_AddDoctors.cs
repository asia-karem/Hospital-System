using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital_System.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Image", "Name", "Specialization" },
                values: new object[,]
                {
                    { 1, "doctor1.jpg", "Ahmed Ali", "Cardiology" },
                    { 2, "doctor2.jpg", "Sara Mohamed", "Pediatrics" },
                    { 3, "doctor3.jpg", "Mohamed Hassan", "Dermatology" },
                    { 4, "doctor4.jpg", "Mona Ahmed", "Neurology" },
                    { 5, "doctor5.jpg", "Omar Khaled", "Orthopedics" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
