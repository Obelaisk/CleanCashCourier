using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClases_20270722_Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class add_procedimiento_almacenado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            ProcedimientosAlmacenados(migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            EliminarProcedimientosAlmacenados(migrationBuilder);
        }
    }
}
