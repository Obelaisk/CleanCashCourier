using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiClases_20270722_Proyecto.Migrations
{
    public partial class paises_changed
    {
        public void CrearVistas(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    CREATE VIEW VCONTACTOS 
                    AS SELECT
                      Clientes_Origen.Id AS IdCliente
                     ,Clientes_Contacto.Usuario AS NombreUsuarioContacto
                     ,Paises_Contacto.Nombre AS Pais
                    FROM dbo.Contactos
                    INNER JOIN dbo.Clientes Clientes_Origen
                      ON Contactos.ClienteOrigenId = Clientes_Origen.Id
                    INNER JOIN dbo.Clientes Clientes_Contacto
                      ON Contactos.ClienteDestinoId = Clientes_Contacto.Id
                    INNER JOIN dbo.Paises Paises_Contacto
                      ON Clientes_Contacto.PaisId = Paises_Contacto.Id;
                ");
        }
        public void EliminarVistas(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS VCONTACTOS;");
        }
    }
}