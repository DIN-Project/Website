using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace din3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    CaseId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<long>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ManufacturerId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.CaseId);
                    table.ForeignKey(
                        name: "FK_Cases_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coolers",
                columns: table => new
                {
                    CoolerId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<long>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ManufacturerId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coolers", x => x.CoolerId);
                    table.ForeignKey(
                        name: "FK_Coolers_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GraphicsCards",
                columns: table => new
                {
                    GraphicsCardId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<long>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ManufacturerId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraphicsCards", x => x.GraphicsCardId);
                    table.ForeignKey(
                        name: "FK_GraphicsCards_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Headsets",
                columns: table => new
                {
                    HeadsetId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<long>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ManufacturerId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headsets", x => x.HeadsetId);
                    table.ForeignKey(
                        name: "FK_Headsets_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Keyboards",
                columns: table => new
                {
                    KeyboardId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<long>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ManufacturerId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keyboards", x => x.KeyboardId);
                    table.ForeignKey(
                        name: "FK_Keyboards_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monitors",
                columns: table => new
                {
                    MonitorId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<long>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ManufacturerId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitors", x => x.MonitorId);
                    table.ForeignKey(
                        name: "FK_Monitors_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    MotherboardId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<long>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ManufacturerId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.MotherboardId);
                    table.ForeignKey(
                        name: "FK_Motherboards_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mouses",
                columns: table => new
                {
                    MouseId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<long>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ManufacturerId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mouses", x => x.MouseId);
                    table.ForeignKey(
                        name: "FK_Mouses_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PowerSupplies",
                columns: table => new
                {
                    PowerSupplyId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<long>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ManufacturerId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerSupplies", x => x.PowerSupplyId);
                    table.ForeignKey(
                        name: "FK_PowerSupplies_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Processors",
                columns: table => new
                {
                    ProcessorId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<long>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ManufacturerId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processors", x => x.ProcessorId);
                    table.ForeignKey(
                        name: "FK_Processors_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rams",
                columns: table => new
                {
                    RamId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<long>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ManufacturerId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rams", x => x.RamId);
                    table.ForeignKey(
                        name: "FK_Rams_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    ComputerId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CaseId = table.Column<long>(type: "INTEGER", nullable: false),
                    CoolerId = table.Column<long>(type: "INTEGER", nullable: false),
                    GraphicsCardId = table.Column<long>(type: "INTEGER", nullable: false),
                    MotherboardId = table.Column<long>(type: "INTEGER", nullable: false),
                    PowerSupplyId = table.Column<long>(type: "INTEGER", nullable: false),
                    ProcessorId = table.Column<long>(type: "INTEGER", nullable: false),
                    RamId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.ComputerId);
                    table.ForeignKey(
                        name: "FK_Computers_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computers_Coolers_CoolerId",
                        column: x => x.CoolerId,
                        principalTable: "Coolers",
                        principalColumn: "CoolerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computers_GraphicsCards_GraphicsCardId",
                        column: x => x.GraphicsCardId,
                        principalTable: "GraphicsCards",
                        principalColumn: "GraphicsCardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computers_Motherboards_MotherboardId",
                        column: x => x.MotherboardId,
                        principalTable: "Motherboards",
                        principalColumn: "MotherboardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computers_PowerSupplies_PowerSupplyId",
                        column: x => x.PowerSupplyId,
                        principalTable: "PowerSupplies",
                        principalColumn: "PowerSupplyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computers_Processors_ProcessorId",
                        column: x => x.ProcessorId,
                        principalTable: "Processors",
                        principalColumn: "ProcessorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computers_Rams_RamId",
                        column: x => x.RamId,
                        principalTable: "Rams",
                        principalColumn: "RamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<long>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ManufacturerId",
                table: "Cases",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_CaseId",
                table: "Computers",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_CoolerId",
                table: "Computers",
                column: "CoolerId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_GraphicsCardId",
                table: "Computers",
                column: "GraphicsCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_MotherboardId",
                table: "Computers",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_PowerSupplyId",
                table: "Computers",
                column: "PowerSupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_ProcessorId",
                table: "Computers",
                column: "ProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_RamId",
                table: "Computers",
                column: "RamId");

            migrationBuilder.CreateIndex(
                name: "IX_Coolers_ManufacturerId",
                table: "Coolers",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_GraphicsCards_ManufacturerId",
                table: "GraphicsCards",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Headsets_ManufacturerId",
                table: "Headsets",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Keyboards_ManufacturerId",
                table: "Keyboards",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Monitors_ManufacturerId",
                table: "Monitors",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_ManufacturerId",
                table: "Motherboards",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Mouses_ManufacturerId",
                table: "Mouses",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerSupplies_ManufacturerId",
                table: "PowerSupplies",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Processors_ManufacturerId",
                table: "Processors",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rams_ManufacturerId",
                table: "Rams",
                column: "ManufacturerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "Headsets");

            migrationBuilder.DropTable(
                name: "Keyboards");

            migrationBuilder.DropTable(
                name: "Monitors");

            migrationBuilder.DropTable(
                name: "Mouses");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Coolers");

            migrationBuilder.DropTable(
                name: "GraphicsCards");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "PowerSupplies");

            migrationBuilder.DropTable(
                name: "Processors");

            migrationBuilder.DropTable(
                name: "Rams");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
