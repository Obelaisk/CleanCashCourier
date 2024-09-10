using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiClases_20270722_Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class paises_changed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Iso3",
                table: "Paises",
                newName: "Iso3Pais");

            migrationBuilder.AddColumn<string>(
                name: "Iso3Divisa",
                table: "Paises",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais" },
                values: new object[] { "Afghan Afghani", "AFN", "AFG" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais" },
                values: new object[] { "Albanian Lek", "ALL", "ALB" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Iso3Divisa", "Iso3Pais" },
                values: new object[] { "EUR", "DEU" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Iso3Divisa", "Iso3Pais" },
                values: new object[] { "EUR", "AND" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais" },
                values: new object[] { "Angolan Kwanza", "AOA", "AGO" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais" },
                values: new object[] { "East Caribbean Dollar", "XCD", "ATG" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Saudi Riyal", "SAR", "SAU", "Arabia Saudita" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Algerian Dinar", "DZD", "DZA", "Argelia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Argentine Peso", "ARS", "ARG", "Argentina" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Armenian Dram", "AMD", "ARM", "Armenia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Australian Dollar", "AUD", "AUS", "Australia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Euro", "EUR", "AUT", "Austria" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Azerbaijani Manat", "AZN", "AZE", "Azerbaiyán" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Bahamian Dollar", "BSD", "BHS", "Bahamas" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Bahraini Dinar", "BHD", "BHR", "Baréin" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Bangladeshi Taka", "BDT", "BGD", "Bangladés" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Barbadian Dollar", "BBD", "BRB", "Barbados" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Belize Dollar", "BZD", "BLZ", "Belice" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "West African CFA Franc", "XOF", "BEN", "Benín" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Indian Rupee", "INR", "BTN", "Bhután" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Bolivian Boliviano", "BOB", "BOL", "Bolivia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Bosnia-Herzegovina Convertible Mark", "BAM", "BIH", "Bosnia y Herzegovina" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Botswana Pula", "BWP", "BWA", "Botswana" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Brazilian Real", "BRL", "BRA", "Brasil" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Brunei Dollar", "BND", "BRN", "Brunéi" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Bulgarian Lev", "BGN", "BGR", "Bulgaria" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "West African CFA Franc", "XOF", "BFA", "Burkina Faso" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Burundian Franc", "BIF", "BDI", "Burundi" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Indian Rupee", "INR", "BTN", "Bután" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Cape Verdean Escudo", "CVE", "CPV", "Cabo Verde" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Cambodian Riel", "KHR", "KHM", "Camboya" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Central African CFA Franc", "XAF", "CMR", "Camerún" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Canadian Dollar", "CAD", "CAN", "Canadá" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Central African CFA Franc", "XAF", "TCD", "Chad" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Chilean Peso", "CLP", "CHL", "Chile" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Chinese Yuan", "CNY", "CHN", "China" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Colombian Peso", "COP", "COL", "Colombia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Comorian Franc", "KMF", "COM", "Comoras" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Central African CFA Franc", "XAF", "COG", "Congo" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Costa Rican Colón", "CRC", "CRI", "Costa Rica" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Croatian Kuna", "HRK", "HRV", "Croacia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Cuban Peso", "CUP", "CUB", "Cuba" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Euro", "EUR", "CYP", "Chipre" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Danish Krone", "DKK", "DNK", "Dinamarca" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "East Caribbean Dollar", "XCD", "DMA", "Dominica" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Egyptian Pound", "EGP", "EGY", "Egipto" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "United States Dollar", "USD", "SLV", "El Salvador" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Unknown", "AED", "ARE", "Emiratos Árabes Unidos" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "United States Dollar", "USD", "ECU", "Ecuador" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Eritrean Nakfa", "ERN", "ERI", "Eritrea" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "EUR", "SVK", "Eslovaquia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Euro", "EUR", "SVN", "Eslovenia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Euro", "EUR", "ESP", "España" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "United States Dollar", "USD", "USA", "Estados Unidos" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Euro", "EUR", "EST", "Estonia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Ethiopian Birr", "ETB", "ETH", "Etiopía" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Fijian Dollar", "FJD", "FJI", "Fiji" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Philippine Peso", "PHP", "PHL", "Filipinas" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Euro", "EUR", "FIN", "Finlandia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Euro", "EUR", "FRA", "Francia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Central African CFA Franc", "XAF", "GAB", "Gabón" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Gambian Dalasi", "GMD", "GMB", "Gambia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Georgian Lari", "GEL", "GEO", "Georgia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Ghanaian Cedi", "GHS", "GHA", "Ghana" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "East Caribbean Dollar", "XCD", "GRD", "Granada" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Euro", "EUR", "GRC", "Grecia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Unknown", "GTQ", "GTM", "Guatemala" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Unknown", "GNF", "GIN", "Guinea" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "West African CFA Franc", "XOF", "GNB", "Guinea-Bisáu" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Guyanese Dollar", "GYD", "GUY", "Guyana" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Haitian Gourde", "HTG", "HTI", "Haití" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Honduran Lempira", "HNL", "HND", "Honduras" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Hungarian Forint", "HUF", "HUN", "Hungría" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Indian Rupee", "INR", "IND", "India" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Indonesian Rupiah", "IDR", "IDN", "Indonesia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Iraqi Dinar", "IQD", "IRQ", "Irak" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Iranian Rial", "IRR", "IRN", "Irán" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "EUR", "IRL", "Irlanda" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Icelandic Króna", "ISK", "ISL", "Islandia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "United States Dollar", "USD", "MHL", "Islas Marshall" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Unknown", "SBD", "SLB", "Islas Salomón" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "United States Dollar", "USD", "VGB", "Islas Vírgenes Británicas" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "United States Dollar", "USD", "VIR", "Islas Vírgenes de los Estados Unidos" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Euro", "EUR", "ITA", "Italia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Jamaican Dollar", "JMD", "JAM", "Jamaica" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Japanese Yen", "JPY", "JPN", "Japón" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Jordanian Dinar", "JOD", "JOR", "Jordania" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Unknown", "KZT", "KAZ", "Kazajistán" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Kenyan Shilling", "KES", "KEN", "Kenia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Kyrgyzstani Som", "KGS", "KGZ", "Kirguistán" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Australian Dollar", "AUD", "KIR", "Kiribati" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Kuwaiti Dinar", "KWD", "KWT", "Kuwait" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Lao Kip", "LAK", "LAO", "Laos" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Euro", "EUR", "LVA", "Latvia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Lebanese Pound", "LBP", "LBN", "Líbano" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Liberian Dollar", "LRD", "LBR", "Liberia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Libyan Dinar", "LYD", "LBY", "Libia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Swiss Franc", "CHF", "LIE", "Liechtenstein" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "EUR", "LTU", "Lituania" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Euro", "EUR", "LUX", "Luxemburgo" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Malagasy Ariary", "MGA", "MDG", "Madagascar" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Malaysian Ringgit", "MYR", "MYS", "Malasia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Malawian Kwacha", "MWK", "MWI", "Malawi" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Maldivian Rufiyaa", "MVR", "MDV", "Maldivas" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "West African CFA Franc", "XOF", "MLI", "Malí" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "EUR", "MLT", "Malta" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Moroccan Dirham", "MAD", "MAR", "Marruecos" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Mauritian Rupee", "MUR", "MUS", "Mauricio" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Mauritanian Ouguiya", "MRU", "MRT", "Mauritania" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Mexican Peso", "MXN", "MEX", "México" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "United States Dollar", "USD", "FSM", "Micronesia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Moldovan Leu", "MDL", "MDA", "Moldavia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Euro", "EUR", "MCO", "Mónaco" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Mongolian Tögrög", "MNT", "MNG", "Mongolia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Euro", "EUR", "MNE", "Montenegro" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Unknown", "CZK", "CZE", "Moravia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Unknown", "MZN", "MOZ", "Mozambique" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Namibian Dollar", "NAD", "NAM", "Namibia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Australian Dollar", "AUD", "NRU", "Nauru" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Nepalese Rupee", "NPR", "NPL", "Nepal" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Nicaraguan Córdoba", "NIO", "NIC", "Nicaragua" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "West African CFA Franc", "XOF", "NER", "Níger" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Nigerian Naira", "NGN", "NGA", "Nigeria" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Norwegian Krone", "NOK", "NOR", "Noruega" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "New Zealand Dollar", "NZD", "NZL", "Nueva Zelanda" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Omani Rial", "OMR", "OMN", "Omán" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "EUR", "NLD", "Países Bajos" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Pakistani Rupee", "PKR", "PAK", "Pakistán" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "United States Dollar", "USD", "PLW", "Palau" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Unknown", "PAB", "PAN", "Panamá" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Papua New Guinean Kina", "PGK", "PNG", "Papúa Nueva Guinea" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Paraguayan Guarani", "PYG", "PRY", "Paraguay" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Peruvian Sol", "PEN", "PER", "Perú" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Polish Zloty", "PLN", "POL", "Polonia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "EUR", "PRT", "Portugal" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Qatari Rial", "QAR", "QAT", "Qatar" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Romanian Leu", "RON", "ROU", "Rumanía" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Russian Ruble", "RUB", "RUS", "Rusia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Rwandan Franc", "RWF", "RWA", "Rwanda" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "East Caribbean Dollar", "XCD", "KNA", "San Cristóbal y Nieves" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Euro", "EUR", "SMR", "San Marino" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Unknown", "STN", "STP", "Santo Tomé y Príncipe" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "West African CFA Franc", "XOF", "SEN", "Senegal" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Unknown", "RSD", "SRB", "Serbia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Seychellois Rupee", "SCR", "SYC", "Seychelles" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Sierra Leonean Leone", "SLL", "SLE", "Sierra Leona" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Singapore Dollar", "SGD", "SGP", "Singapur" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Syrian Pound", "SYP", "SYR", "Siria" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Somali Shilling", "SOS", "SOM", "Somalia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Sri Lankan Rupee", "LKR", "LKA", "Sri Lanka" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Sudanese Pound", "SDG", "SDN", "Sudán" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "South Sudanese Pound", "SSP", "SSD", "Sudán del Sur" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Swedish Krona", "SEK", "SWE", "Suecia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Swiss Franc", "CHF", "CHE", "Suiza" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Unknown", "STN", "STP", "Santo Tomé y Príncipe" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Thai Baht", "THB", "THA", "Tailandia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "New Taiwan Dollar", "TWD", "TWN", "Taiwán" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Tanzanian Shilling", "TZS", "TZA", "Tanzania" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "West African CFA Franc", "XOF", "TGO", "Togo" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Tongan Paʻanga", "TOP", "TON", "Tonga" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Trinidad and Tobago Dollar", "TTD", "TTO", "Trinidad y Tobago" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Tunisian Dinar", "TND", "TUN", "Túnez" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Turkmenistani Manat", "TMT", "TKM", "Turkmenistán" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Turkish Lira", "TRY", "TUR", "Turquía" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Australian Dollar", "AUD", "TUV", "Tuvalu" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Ukrainian Hryvnia", "UAH", "UKR", "Ucrania" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Ugandan Shilling", "UGX", "UGA", "Uganda" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Uruguayan Peso", "UYU", "URY", "Uruguay" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Uzbekistani So'm", "UZS", "UZB", "Uzbekistán" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Vanuatu Vatu", "VUV", "VUT", "Vanuatu" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Venezuelan Bolívar Soberano", "VES", "VEN", "Venezuela" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[] { "Vietnamese Dong", "VND", "VNM", "Vietnam" });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Divisa", "Iso3Divisa", "Iso3Pais", "Nombre" },
                values: new object[,]
                {
                    { 173, "Yemeni Rial", "YER", "YEM", "Yemen" },
                    { 174, "Zambian Kwacha", "ZMW", "ZMB", "Zambia" },
                    { 175, "Zimbabwean Dollar", "ZWL", "ZWE", "Zimbabue" }
                });
            CrearVistas(migrationBuilder);
            ProcedimientosAlmacenados(migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DropColumn(
                name: "Iso3Divisa",
                table: "Paises");

            migrationBuilder.RenameColumn(
                name: "Iso3Pais",
                table: "Paises",
                newName: "Iso3");

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Divisa", "Iso3" },
                values: new object[] { "Afgani", "AFN" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Divisa", "Iso3" },
                values: new object[] { "Lek", "ALL" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 3,
                column: "Iso3",
                value: "EUR");

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 4,
                column: "Iso3",
                value: "EUR");

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Divisa", "Iso3" },
                values: new object[] { "Kwanza", "AOA" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Divisa", "Iso3" },
                values: new object[] { "Dólar del Caribe Oriental", "XCD" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Peso argentino", "ARS", "Argentina" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dram", "AMD", "Armenia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar australiano", "AUD", "Australia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Euro", "EUR", "Austria" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Manat azerí", "AZN", "Azerbaiyán" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar bahameño", "BSD", "Bahamas" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dinar bareiní", "BHD", "Bahréin" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Taka", "BDT", "Bangladesh" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar de Barbados", "BBD", "Barbados" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Euro", "EUR", "Bélgica" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar beliceño", "BZD", "Belice" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Franco CFA", "XOF", "Benín" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Boliviano", "BOB", "Bolivia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Marco convertible", "BAM", "Bosnia y Herzegovina" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Pula", "BWP", "Botsuana" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Real", "BRL", "Brasil" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar de Brunei", "BND", "Brunei" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Lev búlgaro", "BGN", "Bulgaria" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Franco CFA", "XOF", "Burkina Faso" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Franco burundés", "BIF", "Burundi" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Ngultrum", "BTN", "Bután" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Escudo caboverdiano", "CVE", "Cabo Verde" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Riel", "KHR", "Camboya" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Franco CFA", "XAF", "Camerún" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar canadiense", "CAD", "Canadá" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Riyal catarí", "QAR", "Catar" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Peso colombiano", "COP", "Colombia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Franco comorense", "KMF", "Comoras" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Franco congoleño", "CDF", "Congo, República Democrática del" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Franco CFA", "XAF", "Congo, República del" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Won norcoreano", "KPW", "Corea del Norte" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Won surcoreano", "KRW", "Corea del Sur" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Colón costarricense", "CRC", "Costa Rica" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Kuna", "HRK", "Croacia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Peso cubano", "CUP", "Cuba" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Corona danesa", "DKK", "Dinamarca" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Franco yibutiano", "DJF", "Djibouti" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar del Caribe Oriental", "XCD", "Dominica" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Libra egipcia", "EGP", "Egipto" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar estadounidense", "USD", "El Salvador" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dirham de los Emiratos Árabes Unidos", "AED", "Emiratos Árabes Unidos" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Nakfa", "ERN", "Eritrea" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Euro", "EUR", "Eslovaquia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Euro", "EUR", "Eslovenia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "Iso3", "Nombre" },
                values: new object[] { "EUR", "España" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar estadounidense", "USD", "Estados Unidos" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Lilangeni", "SZL", "Esuatini" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Birr", "ETB", "Etiopía" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar fiyiano", "FJD", "Fiyi" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Peso filipino", "PHP", "Filipinas" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Euro", "EUR", "Finlandia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Euro", "EUR", "Francia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Franco CFA", "XAF", "Gabón" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dalasi", "GMD", "Gambia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Lari", "GEL", "Georgia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Cedi", "GHS", "Ghana" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar del Caribe Oriental", "XCD", "Granada" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Euro", "EUR", "Grecia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Quetzal", "GTQ", "Guatemala" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Franco guineano", "GNF", "Guinea" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Franco CFA", "XOF", "Guinea-Bisáu" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar guyanés", "GYD", "Guyana" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Gourde", "HTG", "Haití" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Lempira", "HNL", "Honduras" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Forinto", "HUF", "Hungría" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Rupia india", "INR", "India" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Rupia indonesia", "IDR", "Indonesia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Rial iraní", "IRR", "Irán" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dinar iraquí", "IQD", "Irak" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Euro", "EUR", "Irlanda" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Nuevo shekel israelí", "ILS", "Israel" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Iso3", "Nombre" },
                values: new object[] { "EUR", "Italia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar jamaiquino", "JMD", "Jamaica" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Yen japonés", "JPY", "Japón" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dinar jordano", "JOD", "Jordania" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Tenge", "KZT", "Kazajistán" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Chelín keniano", "KES", "Kenia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Som", "KGS", "Kirguistán" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar australiano", "AUD", "Kiribati" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Kip", "LAK", "Laos" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Euro", "EUR", "Letonia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Libra libanesa", "LBP", "Líbano" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar liberiano", "LRD", "Liberia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dinar libio", "LYD", "Libia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Franco suizo", "CHF", "Liechtenstein" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Euro", "EUR", "Lituania" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Euro", "EUR", "Luxemburgo" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Ariary", "MGA", "Madagascar" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Ringgit", "MYR", "Malasia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Kwacha malawiano", "MWK", "Malaui" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Rufiyaa", "MVR", "Maldivas" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Franco CFA", "XOF", "Mali" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "Iso3", "Nombre" },
                values: new object[] { "EUR", "Malta" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dirham marroquí", "MAD", "Marruecos" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Rupia mauriciana", "MUR", "Mauricio" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Ouguiya", "MRU", "Mauritania" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Peso mexicano", "MXN", "México" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar estadounidense", "USD", "Micronesia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Leu moldavo", "MDL", "Moldova" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "Iso3", "Nombre" },
                values: new object[] { "EUR", "Mónaco" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Tugrik", "MNT", "Mongolia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Euro", "EUR", "Montenegro" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Metical", "MZN", "Mozambique" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Kyat", "MMK", "Myanmar" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar namibio", "NAD", "Namibia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar australiano", "AUD", "Nauru" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Rupia nepali", "NPR", "Nepal" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Córdoba", "NIO", "Nicaragua" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Franco CFA", "XOF", "Níger" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Naira", "NGN", "Nigeria" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Corona noruega", "NOK", "Noruega" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar neozelandés", "NZD", "Nueva Zelanda" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Rial omaní", "OMR", "Omán" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Rupia pakistaní", "PKR", "Pakistán" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar estadounidense", "USD", "Palaos" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Balboa / Dólar estadounidense", "PAB", "Panamá" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Kina", "PGK", "Papúa Nueva Guinea" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Guaraní", "PYG", "Paraguay" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Sol", "PEN", "Perú" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Zloty", "PLN", "Polonia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "Iso3", "Nombre" },
                values: new object[] { "EUR", "Portugal" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Libra esterlina", "GBP", "Reino Unido" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Franco CFA", "XAF", "República Centroafricana" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Peso dominicano", "DOP", "República Dominicana" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Franco ruandés", "RWF", "Ruanda" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Leu rumano", "RON", "Rumania" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Rublo ruso", "RUB", "Rusia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar del Caribe Oriental", "XCD", "San Cristóbal y Nieves" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "Iso3", "Nombre" },
                values: new object[] { "EUR", "San Marino" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar de Santo Tomé", "STN", "Santo Tomé y Príncipe" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Riyal saudí", "SAR", "Arabia Saudita" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Franco CFA", "XOF", "Senegal" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dinar serbio", "RSD", "Serbia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Rupia de las Seychelles", "SCR", "Seychelles" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Leona", "SLL", "Sierra Leona" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar de Singapur", "SGD", "Singapur" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Libra siria", "SYP", "Siria" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Chelín somalí", "SOS", "Somalia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Rupia de Sri Lanka", "LKR", "Sri Lanka" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Lilangeni", "SZL", "Esuatini" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Rand", "ZAR", "Sudáfrica" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Libra sudanesa", "SDG", "Sudán" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Corona sueca", "SEK", "Suecia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Franco suizo", "CHF", "Suiza" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar de Surinam", "SRD", "Surinam" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Nuevo dólar taiwanés", "TWD", "Taiwán" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Chelín tanzano", "TZS", "Tanzania" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Baht", "THB", "Tailandia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar estadounidense", "USD", "Timor Oriental" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Franco CFA", "XOF", "Togo" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Paʻanga", "TOP", "Tonga" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar de Trinidad y Tobago", "TTD", "Trinidad y Tobago" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dinar tunecino", "TND", "Túnez" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Lira turca", "TRY", "Turquía" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Manat turcomano", "TMT", "Turkmenistán" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar australiano", "AUD", "Tuvalu" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Chelín ugandés", "UGX", "Uganda" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Hryvnia", "UAH", "Ucrania" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Peso uruguayo", "UYU", "Uruguay" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Som uzbeko", "UZS", "Uzbekistán" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Vatu", "VUV", "Vanuatu" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Bolívar venezolano", "VES", "Venezuela" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dong", "VND", "Vietnam" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Rial yemení", "YER", "Yemen" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Kwacha zambiano", "ZMW", "Zambia" });

            migrationBuilder.UpdateData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "Divisa", "Iso3", "Nombre" },
                values: new object[] { "Dólar zimbabuense", "ZWL", "Zimbabue" });
            EliminarVistas(migrationBuilder);
            EliminarProcedimientosAlmacenados(migrationBuilder);
        }

    }
}
