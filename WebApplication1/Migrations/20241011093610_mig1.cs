using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicDegrees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree_Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cd_academicDegrees_degrees_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discipline_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_Disciplines_discipline_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Post_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_posts_post_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cd_Facultys",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Facultys_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_Facultys_faculty_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, comment: "Ид преподователя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teacher_firstname = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "Имя преподователя"),
                    Teacher_Lastname = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "фамилия преподователя"),
                    Teacher_Patronomical = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "Отчество преподователя"),
                    DegreeId = table.Column<int>(type: "int", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    FacultyId = table.Column<int>(type: "int", nullable: true),
                    Teacher_phone = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false, comment: "Номер преподователя")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Teachers_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_AcademicDegrees_id",
                        column: x => x.DegreeId,
                        principalTable: "AcademicDegrees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Facultys_id",
                        column: x => x.FacultyId,
                        principalTable: "cd_Facultys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Post_id",
                        column: x => x.PostId,
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_workload",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    Load = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_workload_WorkLoad_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_disciple_id",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_teacher_id",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_Facultys_fk_teacher_id",
                table: "cd_Facultys",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_cd_Facultys_TeacherId",
                table: "cd_Facultys",
                column: "TeacherId",
                unique: true,
                filter: "[TeacherId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_cd_workload_DisciplineId",
                table: "cd_workload",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_cd_workload_TeacherId",
                table: "cd_workload",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "idx_Teachers_fk_academicdegree_id",
                table: "Teachers",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "idx_Teachers_fk_faculty_id",
                table: "Teachers",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "idx_Teachers_fk_post_id",
                table: "Teachers",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_cd_Facultys_Teachers_TeacherId",
                table: "cd_Facultys",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cd_Facultys_Teachers_TeacherId",
                table: "cd_Facultys");

            migrationBuilder.DropTable(
                name: "cd_workload");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "AcademicDegrees");

            migrationBuilder.DropTable(
                name: "cd_Facultys");

            migrationBuilder.DropTable(
                name: "posts");
        }
    }
}
