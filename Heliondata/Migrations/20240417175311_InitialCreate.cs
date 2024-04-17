using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Heliondata.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CUI = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(type: "longtext", nullable: true),
                    FirstName = table.Column<string>(type: "longtext", nullable: true),
                    Position = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Workplaces",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Zone = table.Column<string>(type: "longtext", nullable: true),
                    City = table.Column<string>(type: "longtext", nullable: true),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workplaces", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Representatives",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: true),
                    LastName = table.Column<string>(type: "longtext", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: true),
                    Position = table.Column<string>(type: "longtext", nullable: true),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representatives", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Representatives_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Processes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SignDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    RepresentativeId = table.Column<int>(type: "int", nullable: false),
                    ESignature = table.Column<string>(type: "longtext", nullable: true),
                    GPSLocation = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Processes_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Processes_Representatives_RepresentativeId",
                        column: x => x.RepresentativeId,
                        principalTable: "Representatives",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmployeeProcess",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProcess", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeeProcess_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProcess_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProcessService",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessService", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProcessService_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessService_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProcessWorkplace",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    WorkplaceId = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessWorkplace", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProcessWorkplace_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessWorkplace_Workplaces_WorkplaceId",
                        column: x => x.WorkplaceId,
                        principalTable: "Workplaces",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "ID", "CUI", "Name" },
                values: new object[,]
                {
                    { 1, 123456789, "Company A" },
                    { 2, 987654321, "Company B" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "FirstName", "LastName", "Position" },
                values: new object[,]
                {
                    { 1, "Sam", "Wilson", "Analyst" },
                    { 2, "Lucy", "Hart", "Manager" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "CCTV" },
                    { 2, "Security" }
                });

            migrationBuilder.InsertData(
                table: "Workplaces",
                columns: new[] { "ID", "Address", "City", "Name", "Zone" },
                values: new object[,]
                {
                    { 1, "123 5th Ave", "New York", "Headquarters", "Downtown" },
                    { 2, "456 7th Ave", "New York", "Branch Office", "Uptown" }
                });

            migrationBuilder.InsertData(
                table: "Representatives",
                columns: new[] { "ID", "CompanyID", "Email", "FirstName", "LastName", "Position" },
                values: new object[,]
                {
                    { 1, 1, "john.doe@example.com", "John", "Doe", "Manager" },
                    { 2, 1, "alice.smith@example.com", "Alice", "Smith", "Supervisor" },
                    { 3, 2, "bob.johnson@example.com", "Bob", "Johnson", "Director" },
                    { 4, 2, "emma.brown@example.com", "Emma", "Brown", "Coordinator" }
                });

            migrationBuilder.InsertData(
                table: "Processes",
                columns: new[] { "ID", "CompanyID", "ESignature", "GPSLocation", "RepresentativeId", "SignDate" },
                values: new object[,]
                {
                    { 1, null, "Signature1", "Location1", 1, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, "Signature2", "Location2", 2, new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EmployeeProcess",
                columns: new[] { "ID", "EmployeeId", "ProcessId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProcessService",
                columns: new[] { "ID", "ProcessId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProcessWorkplace",
                columns: new[] { "ID", "ProcessId", "WorkplaceId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProcess_EmployeeId",
                table: "EmployeeProcess",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProcess_ProcessId",
                table: "EmployeeProcess",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_CompanyID",
                table: "Processes",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_RepresentativeId",
                table: "Processes",
                column: "RepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessService_ProcessId",
                table: "ProcessService",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessService_ServiceId",
                table: "ProcessService",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessWorkplace_ProcessId",
                table: "ProcessWorkplace",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessWorkplace_WorkplaceId",
                table: "ProcessWorkplace",
                column: "WorkplaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Representatives_CompanyID",
                table: "Representatives",
                column: "CompanyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProcess");

            migrationBuilder.DropTable(
                name: "ProcessService");

            migrationBuilder.DropTable(
                name: "ProcessWorkplace");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Processes");

            migrationBuilder.DropTable(
                name: "Workplaces");

            migrationBuilder.DropTable(
                name: "Representatives");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
