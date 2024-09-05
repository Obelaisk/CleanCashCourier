using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiClases_20270722_Proyecto.Migrations
{
    public partial class newcontactviewstructure
    {
        public void ProcedimientosAlmacenados(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.ContarTransaccionesUltimos10Años
                                AS
                                BEGIN
                                    DECLARE @FechaInicio DATE = DATEADD(YEAR, -10, GETDATE());

                                    SELECT COUNT(DISTINCT CASE 
                                                            WHEN IdEnvia < IdRecibe THEN CONCAT(IdEnvia, '-', IdRecibe) 
                                                            ELSE CONCAT(IdRecibe, '-', IdEnvia) 
                                                          END) AS NumeroTransacciones
                                    FROM Transacciones
                                    WHERE Fecha >= @FechaInicio;
                                END;
                                GO");
            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.ContarPaisesConClientes
                                AS
                                BEGIN
                                    SET NOCOUNT ON;

                                    SELECT COUNT(DISTINCT PaisId) AS NumeroPaises
                                    FROM Clientes;
                                END;
                                GO");
        }
        public void EliminarProcedimientosAlmacenados(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS dbo.ContarTransaccionesUltimos10Años;");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS dbo.ContarPaisesConClientes;");
        }
    }    
}
