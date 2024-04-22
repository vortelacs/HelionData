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
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Discriminator = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    CNP = table.Column<int>(type: "int", nullable: true),
                    Activity = table.Column<string>(type: "longtext", nullable: true),
                    RegistrationCode = table.Column<int>(type: "int", nullable: true)
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
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    RepresentativeId = table.Column<int>(type: "int", nullable: false),
                    ESignature = table.Column<byte[]>(type: "longblob", nullable: true),
                    GPSLocation = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Processes_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Processes_Representatives_RepresentativeId",
                        column: x => x.RepresentativeId,
                        principalTable: "Representatives",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmployeeProcesses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProcesses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeeProcesses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProcesses_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProcessServices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessServices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProcessServices_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProcessWorkplaces",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    WorkplaceId = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessWorkplaces", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProcessWorkplaces_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessWorkplaces_Workplaces_WorkplaceId",
                        column: x => x.WorkplaceId,
                        principalTable: "Workplaces",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "ID", "CUI", "Discriminator", "Name" },
                values: new object[,]
                {
                    { 1, 1234589, "Company", "Company A" },
                    { 2, 9876521, "Company", "Company B" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "ID", "Activity", "CNP", "CUI", "Discriminator", "Name" },
                values: new object[] { 3, "Freelancing", 12567890, 1112234, "PFA", "PFA John Doe" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "ID", "CUI", "Discriminator", "Name", "RegistrationCode" },
                values: new object[] { 4, 2223455, "SRL", "SRL Quick Services", 56789234 });

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
                columns: new[] { "ID", "CompanyId", "ESignature", "GPSLocation", "RepresentativeId", "SignDate" },
                values: new object[,]
                {
                    { 1, 1, new byte[] { 83, 105, 103, 110, 97, 116, 117, 114, 101, 49, 68, 97, 116, 97 }, "47.0428222 21.9190659", 1, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new byte[] { 83, 105, 103, 110, 97, 116, 117, 114, 101, 49, 68, 97, 116, 97 }, "27.1433222 32.9123659", 2, new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EmployeeProcesses",
                columns: new[] { "ID", "EmployeeId", "ProcessId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProcessServices",
                columns: new[] { "ID", "ProcessId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProcessWorkplaces",
                columns: new[] { "ID", "ProcessId", "WorkplaceId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProcesses_EmployeeId",
                table: "EmployeeProcesses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProcesses_ProcessId",
                table: "EmployeeProcesses",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_CompanyId",
                table: "Processes",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_RepresentativeId",
                table: "Processes",
                column: "RepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessServices_ProcessId",
                table: "ProcessServices",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessServices_ServiceId",
                table: "ProcessServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessWorkplaces_ProcessId",
                table: "ProcessWorkplaces",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessWorkplaces_WorkplaceId",
                table: "ProcessWorkplaces",
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
                name: "EmployeeProcesses");

            migrationBuilder.DropTable(
                name: "ProcessServices");

            migrationBuilder.DropTable(
                name: "ProcessWorkplaces");

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
