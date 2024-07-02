using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectMedicalClinic.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentMedications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppId);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "DocAddress", "DocFirstName", "DocLastName", "DocPhoneNumber", "Specialization", "YearsOfExperience" },
                values: new object[,]
                {
                    { 1, "123 Main St, Hometown", "John", "Doe", "555-1234", "Cardiology", 20 },
                    { 2, "456 Elm St, Hometown", "Jane", "Smith", "555-5678", "Pediatrics", 15 },
                    { 3, "789 Oak St, Hometown", "Emily", "Johnson", "555-9101", "Dermatology", 10 },
                    { 4, "101 Pine St, Hometown", "Michael", "Brown", "555-1122", "Neurology", 25 },
                    { 5, "202 Birch St, Hometown", "Sarah", "Williams", "555-3344", "Orthopedics", 18 },
                    { 6, "303 Cedar St, Hometown", "David", "Miller", "555-7788", "General Surgery", 12 }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Address", "CurrentMedications", "DateOfBirth", "DoctorId", "FirstName", "Gender", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St, Warsaw, Poland", "Lisinopril, Albuterol", new DateTime(1985, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Michał", "Male", "Guest", "123-456-7890" },
                    { 2, "456 Elm St, Krakow, Poland", "Metformin", new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Anna", "Female", "Kowalski", "987-654-3210" },
                    { 3, "789 Oak St, Gdansk, Poland", "Atorvastatin", new DateTime(1975, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "John", "Male", "Smith", "555-123-4567" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Floor", "Name", "PatientId" },
                values: new object[,]
                {
                    { 1, "First", "Room A", 1 },
                    { 2, "Second", "Room B", 2 },
                    { 3, "Third", "Room C", 3 }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppId", "AppointmentDate", "DoctorId", "Notes", "PatientId", "RoomId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 3, 0, 0, 0, 0, DateTimeKind.Local), 1, "Follow-up appointment", 1, 1 },
                    { 2, new DateTime(2024, 7, 4, 0, 0, 0, 0, DateTimeKind.Local), 2, "Initial consultation", 2, 2 },
                    { 3, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Local), 3, "Check-up appointment", 3, 3 },
                    { 4, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), 1, "Procedure follow-up", 3, 2 },
                    { 5, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Local), 3, "Diagnostic discussion", 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_RoomId",
                table: "Appointments",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DoctorId",
                table: "Patients",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_PatientId",
                table: "Rooms",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
