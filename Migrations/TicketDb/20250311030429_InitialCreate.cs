using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataRacingV1.Migrations.TicketDb
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: true),
                    VehiculoTipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehiculoFabricante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehiculoModelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehiculoVariante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehiculoPotencia = table.Column<int>(type: "int", nullable: true),
                    VehiculoManual = table.Column<bool>(type: "bit", nullable: true),
                    InfoDueno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoKm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoDominio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoCombustible = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoTransmision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoAdmision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoEscape = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoComentarios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoDTCs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileEquipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileArchivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadedFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UploadedFile_Tickets_TicketEntityId",
                        column: x => x.TicketEntityId,
                        principalTable: "Tickets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OriginalFileId",
                table: "Tickets",
                column: "OriginalFileId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFile_TicketEntityId",
                table: "UploadedFile",
                column: "TicketEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_UploadedFile_OriginalFileId",
                table: "Tickets",
                column: "OriginalFileId",
                principalTable: "UploadedFile",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_UploadedFile_OriginalFileId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "UploadedFile");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
