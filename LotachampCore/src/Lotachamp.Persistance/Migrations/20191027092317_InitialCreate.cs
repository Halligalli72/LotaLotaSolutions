using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lotachamp.Persistance.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invite",
                columns: table => new
                {
                    InviteId = table.Column<Guid>(nullable: false, defaultValueSql: "(NEWID())"),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "(GETDATE())"),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Activated = table.Column<bool>(nullable: false),
                    InvitedBy = table.Column<Guid>(nullable: false),
                    CanInvite = table.Column<bool>(nullable: false),
                    InviteLimit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invite", x => x.InviteId);
                });

            migrationBuilder.CreateTable(
                name: "Measurement",
                columns: table => new
                {
                    MeasurementId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "(GETDATE())"),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ResultUnit = table.Column<string>(maxLength: 10, nullable: false),
                    ResultFormatString = table.Column<string>(maxLength: 10, nullable: false),
                    ResultLabelText = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurement", x => x.MeasurementId);
                });

            migrationBuilder.CreateTable(
                name: "RankAlgorithm",
                columns: table => new
                {
                    RankAlgorithmId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "(GETDATE())"),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankAlgorithm", x => x.RankAlgorithmId);
                });

            migrationBuilder.CreateTable(
                name: "Tour",
                columns: table => new
                {
                    TourId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "(GETDATE())"),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    IsPublic = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour", x => x.TourId);
                });

            migrationBuilder.CreateTable(
                name: "SportTemplate",
                columns: table => new
                {
                    SportTemplateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "(GETDATE())"),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    TemplateName = table.Column<string>(nullable: true),
                    RankAlgorithmId = table.Column<int>(nullable: false),
                    MeasurementId = table.Column<int>(nullable: false),
                    PictureRequired = table.Column<bool>(nullable: false),
                    P1 = table.Column<int>(nullable: false),
                    P2 = table.Column<int>(nullable: false),
                    P3 = table.Column<int>(nullable: false),
                    P4 = table.Column<int>(nullable: false),
                    P5 = table.Column<int>(nullable: false),
                    SeedPoint = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportTemplate", x => x.SportTemplateId);
                    table.ForeignKey(
                        name: "FK_SportTemplate_Measurement_MeasurementId",
                        column: x => x.MeasurementId,
                        principalTable: "Measurement",
                        principalColumn: "MeasurementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportTemplate_RankAlgorithm_RankAlgorithmId",
                        column: x => x.RankAlgorithmId,
                        principalTable: "RankAlgorithm",
                        principalColumn: "RankAlgorithmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    ParticipantId = table.Column<Guid>(nullable: false, defaultValueSql: "(NEWID())"),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "(GETDATE())"),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    TourId = table.Column<int>(nullable: false),
                    InviteId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Alias = table.Column<string>(maxLength: 10, nullable: false),
                    IsCompeting = table.Column<bool>(nullable: false),
                    IsTourAdmin = table.Column<bool>(nullable: false),
                    IsTourOfficial = table.Column<bool>(nullable: false),
                    InviteId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.ParticipantId);
                    table.ForeignKey(
                        name: "FK_Participant_Invite_InviteId1",
                        column: x => x.InviteId1,
                        principalTable: "Invite",
                        principalColumn: "InviteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Participant_Tour_TourId",
                        column: x => x.TourId,
                        principalTable: "Tour",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sport",
                columns: table => new
                {
                    SportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "(GETDATE())"),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    TourId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    RankAlgorithmId = table.Column<int>(nullable: false),
                    MeasurementId = table.Column<int>(nullable: false),
                    PictureRequired = table.Column<bool>(nullable: false),
                    P1 = table.Column<int>(nullable: false),
                    P2 = table.Column<int>(nullable: false),
                    P3 = table.Column<int>(nullable: false),
                    P4 = table.Column<int>(nullable: false),
                    P5 = table.Column<int>(nullable: false),
                    SeedPoint = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sport", x => x.SportId);
                    table.ForeignKey(
                        name: "FK_Sport_Measurement_MeasurementId",
                        column: x => x.MeasurementId,
                        principalTable: "Measurement",
                        principalColumn: "MeasurementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sport_RankAlgorithm_RankAlgorithmId",
                        column: x => x.RankAlgorithmId,
                        principalTable: "RankAlgorithm",
                        principalColumn: "RankAlgorithmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sport_Tour_TourId",
                        column: x => x.TourId,
                        principalTable: "Tour",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    ScoreId = table.Column<Guid>(nullable: false, defaultValueSql: "(NEWID())"),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "(GETDATE())"),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    SportId = table.Column<int>(nullable: false),
                    ParticipantId = table.Column<Guid>(nullable: false),
                    ResultValue = table.Column<int>(nullable: false, defaultValue: 0),
                    ScoreDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Notes = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.ScoreId);
                    table.ForeignKey(
                        name: "FK_Score_Participant_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participant",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Score_Sport_SportId",
                        column: x => x.SportId,
                        principalTable: "Sport",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    PictureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "(GETDATE())"),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ScoreId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Content = table.Column<byte[]>(nullable: true),
                    ContentType = table.Column<string>(maxLength: 100, nullable: true),
                    ImageText = table.Column<string>(maxLength: 250, nullable: true),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.PictureId);
                    table.ForeignKey(
                        name: "FK_Picture_Score_ScoreId",
                        column: x => x.ScoreId,
                        principalTable: "Score",
                        principalColumn: "ScoreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participant_InviteId1",
                table: "Participant",
                column: "InviteId1");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_TourId",
                table: "Participant",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_ScoreId",
                table: "Picture",
                column: "ScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_ParticipantId",
                table: "Score",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_SportId",
                table: "Score",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Sport_MeasurementId",
                table: "Sport",
                column: "MeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_Sport_RankAlgorithmId",
                table: "Sport",
                column: "RankAlgorithmId");

            migrationBuilder.CreateIndex(
                name: "IX_Sport_TourId",
                table: "Sport",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_SportTemplate_MeasurementId",
                table: "SportTemplate",
                column: "MeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_SportTemplate_RankAlgorithmId",
                table: "SportTemplate",
                column: "RankAlgorithmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "SportTemplate");

            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "Sport");

            migrationBuilder.DropTable(
                name: "Invite");

            migrationBuilder.DropTable(
                name: "Measurement");

            migrationBuilder.DropTable(
                name: "RankAlgorithm");

            migrationBuilder.DropTable(
                name: "Tour");
        }
    }
}
