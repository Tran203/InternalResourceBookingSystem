using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InternalResourceBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class CreatedDbSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceId = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Capacity", "Description", "IsAvailable", "Location", "Name" },
                values: new object[,]
                {
                    { 1, 10, "10-seater with projector & whiteboard", true, "2nd Floor, West Wing", "Meeting Room Alpha" },
                    { 2, 8, "8-seater with video conferencing", true, "3rd Floor, East Wing", "Meeting Room Beta" },
                    { 3, 16, "Premium boardroom for 16 people", true, "1st Floor, Admin Block", "Boardroom Executive" },
                    { 4, 4, "Quick 4-person collaboration space", true, "4th Floor, Open Area", "Huddle Room 1" },
                    { 5, 30, "30-seater training facility", false, "Ground Floor, Training", "Training Room" },
                    { 6, 4, "Compact sedan - White", true, "Parking Bay A1", "Toyota Corolla (Car 1)" },
                    { 7, 5, "Double cab for site visits", true, "Parking Bay B3", "Ford Ranger (Bakkie)" },
                    { 8, 15, "15-seater passenger van", false, "Garage Level 2", "Mercedes Sprinter Van" },
                    { 9, 2, "Small delivery bakkie", true, "Loading Bay", "Nissan NP200 (Delivery)" },
                    { 10, 1, "i7, 32GB RAM, 1TB SSD", true, "IT Storage Room", "Dell Laptop Pro" },
                    { 11, 1, "M2 Max for design/video", false, "Creative Team Locker", "MacBook Pro 16" },
                    { 12, 1, "Portable 4K projector", true, "AV Cupboard", "Projector Epson 4K" },
                    { 13, 1, "Portable Bluetooth speakers", true, "Events Store", "JBL Party Speakers" },
                    { 14, 4, "Wireless microphone kit", true, "AV Cupboard", "Wireless Mic Set (4)" },
                    { 15, 1, "HP Color LaserJet - A3 capable", true, "Print Room, 2nd Floor", "Large Color Printer" },
                    { 16, 1, "Electric height-adjustable desk", true, "Furniture Storage", "Standing Desk" },
                    { 17, 1, "Portable Unlimited data router", false, "IT Desk", "4G Mobile Hotspot" },
                    { 18, 6, "Gaming setup in chill room", true, "Recreation Room, 5th Floor", "Xbox Series X + TV" },
                    { 19, 1, "Full-body massage chair", true, "Wellness Room", "Massage Chair" },
                    { 20, 1, "Professional espresso machine", true, "Kitchen, 4th Floor", "Coffee Machine (Barista)" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookedBy", "EndTime", "Purpose", "ResourceId", "StartTime" },
                values: new object[,]
                {
                    { 1, "Thandi Mokoena", new DateTime(2025, 11, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), "Sprint Planning", 1, new DateTime(2025, 11, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Sipho Ngubane", new DateTime(2025, 11, 25, 17, 0, 0, 0, DateTimeKind.Unspecified), "Client Visit - Cape Town", 6, new DateTime(2025, 11, 25, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Lerato Khumalo", new DateTime(2025, 11, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), "Offsite Development Sprint", 10, new DateTime(2025, 11, 18, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Lisa Naidoo", new DateTime(2025, 12, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), "Executive Leadership Meeting", 3, new DateTime(2025, 12, 3, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Dev Team", new DateTime(2025, 12, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), "Product Demo Rehearsal", 1, new DateTime(2025, 12, 3, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Events Team", new DateTime(2025, 12, 4, 12, 0, 0, 0, DateTimeKind.Unspecified), "Year-End Townhall Setup", 12, new DateTime(2025, 12, 4, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "HR Department", new DateTime(2025, 12, 5, 19, 30, 0, 0, DateTimeKind.Unspecified), "Team Building Gaming Night", 18, new DateTime(2025, 12, 5, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Finance Team", new DateTime(2025, 12, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "2026 Budget Review", 2, new DateTime(2025, 12, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Field Operations", new DateTime(2025, 12, 4, 18, 0, 0, 0, DateTimeKind.Unspecified), "Site Visit - Durban", 7, new DateTime(2025, 12, 4, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Design Team", new DateTime(2025, 12, 6, 14, 0, 0, 0, DateTimeKind.Unspecified), "Quick Brainstorm", 4, new DateTime(2025, 12, 6, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Nomsa Zuma", new DateTime(2025, 12, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), "Training Workshop Prep", 10, new DateTime(2025, 12, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Marketing Team", new DateTime(2025, 12, 20, 19, 0, 0, 0, DateTimeKind.Unspecified), "Product Launch Party", 13, new DateTime(2025, 12, 20, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Wellness Committee", new DateTime(2025, 12, 9, 12, 30, 0, 0, DateTimeKind.Unspecified), "Stress Relief Session", 19, new DateTime(2025, 12, 9, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Early Risers Club", new DateTime(2025, 12, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), "Coffee Tasting Morning", 20, new DateTime(2025, 12, 11, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Sales Team", new DateTime(2025, 12, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), "Q4 Sales Planning", 1, new DateTime(2025, 12, 18, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "HR Team", new DateTime(2025, 12, 18, 12, 30, 0, 0, DateTimeKind.Unspecified), "Performance Reviews", 3, new DateTime(2025, 12, 18, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "Logistics", new DateTime(2025, 12, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), "Year-End Deliveries", 6, new DateTime(2025, 12, 23, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "Finance", new DateTime(2025, 12, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), "Annual Report Printing", 15, new DateTime(2025, 12, 16, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "Creative Director", new DateTime(2026, 1, 10, 17, 0, 0, 0, DateTimeKind.Unspecified), "Brand Video Project", 11, new DateTime(2026, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "Board of Directors", new DateTime(2025, 12, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), "Year-End Board Meeting", 3, new DateTime(2025, 12, 19, 14, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ResourceId",
                table: "Bookings",
                column: "ResourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Resources");
        }
    }
}
