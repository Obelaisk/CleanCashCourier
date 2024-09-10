using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiClases_20270722_Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class newcontactviewstructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Empleo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConteoResults",
                columns: table => new
                {
                    Conteo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Divisa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Iso3 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEnvia = table.Column<int>(type: "int", nullable: false),
                    CantidadEnvia = table.Column<double>(type: "float", nullable: false),
                    IdRecibe = table.Column<int>(type: "int", nullable: false),
                    CantidadRecibe = table.Column<double>(type: "float", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonedaOrigen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonedaDestino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CosteTransaccion = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Empleo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteOrigenId = table.Column<int>(type: "int", nullable: false),
                    ClienteDestinoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contactos_Clientes_ClienteDestinoId",
                        column: x => x.ClienteDestinoId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contactos_Clientes_ClienteOrigenId",
                        column: x => x.ClienteOrigenId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Divisa", "Iso3", "Nombre" },
                values: new object[,]
                {
                    { 1, "Afgani", "AFN", "Afganistán" },
                    { 2, "Lek", "ALL", "Albania" },
                    { 3, "Euro", "EUR", "Alemania" },
                    { 4, "Euro", "EUR", "Andorra" },
                    { 5, "Kwanza", "AOA", "Angola" },
                    { 6, "Dólar del Caribe Oriental", "XCD", "Antigua y Barbuda" },
                    { 7, "Peso argentino", "ARS", "Argentina" },
                    { 8, "Dram", "AMD", "Armenia" },
                    { 9, "Dólar australiano", "AUD", "Australia" },
                    { 10, "Euro", "EUR", "Austria" },
                    { 11, "Manat azerí", "AZN", "Azerbaiyán" },
                    { 12, "Dólar bahameño", "BSD", "Bahamas" },
                    { 13, "Dinar bareiní", "BHD", "Bahréin" },
                    { 14, "Taka", "BDT", "Bangladesh" },
                    { 15, "Dólar de Barbados", "BBD", "Barbados" },
                    { 16, "Euro", "EUR", "Bélgica" },
                    { 17, "Dólar beliceño", "BZD", "Belice" },
                    { 18, "Franco CFA", "XOF", "Benín" },
                    { 19, "Boliviano", "BOB", "Bolivia" },
                    { 20, "Marco convertible", "BAM", "Bosnia y Herzegovina" },
                    { 21, "Pula", "BWP", "Botsuana" },
                    { 22, "Real", "BRL", "Brasil" },
                    { 23, "Dólar de Brunei", "BND", "Brunei" },
                    { 24, "Lev búlgaro", "BGN", "Bulgaria" },
                    { 25, "Franco CFA", "XOF", "Burkina Faso" },
                    { 26, "Franco burundés", "BIF", "Burundi" },
                    { 27, "Ngultrum", "BTN", "Bután" },
                    { 28, "Escudo caboverdiano", "CVE", "Cabo Verde" },
                    { 29, "Riel", "KHR", "Camboya" },
                    { 30, "Franco CFA", "XAF", "Camerún" },
                    { 31, "Dólar canadiense", "CAD", "Canadá" },
                    { 32, "Riyal catarí", "QAR", "Catar" },
                    { 33, "Peso colombiano", "COP", "Colombia" },
                    { 34, "Franco comorense", "KMF", "Comoras" },
                    { 35, "Franco congoleño", "CDF", "Congo, República Democrática del" },
                    { 36, "Franco CFA", "XAF", "Congo, República del" },
                    { 37, "Won norcoreano", "KPW", "Corea del Norte" },
                    { 38, "Won surcoreano", "KRW", "Corea del Sur" },
                    { 39, "Colón costarricense", "CRC", "Costa Rica" },
                    { 40, "Kuna", "HRK", "Croacia" },
                    { 41, "Peso cubano", "CUP", "Cuba" },
                    { 42, "Corona danesa", "DKK", "Dinamarca" },
                    { 43, "Franco yibutiano", "DJF", "Djibouti" },
                    { 44, "Dólar del Caribe Oriental", "XCD", "Dominica" },
                    { 45, "Libra egipcia", "EGP", "Egipto" },
                    { 46, "Dólar estadounidense", "USD", "El Salvador" },
                    { 47, "Dirham de los Emiratos Árabes Unidos", "AED", "Emiratos Árabes Unidos" },
                    { 48, "Nakfa", "ERN", "Eritrea" },
                    { 49, "Euro", "EUR", "Eslovaquia" },
                    { 50, "Euro", "EUR", "Eslovenia" },
                    { 51, "Euro", "EUR", "España" },
                    { 52, "Dólar estadounidense", "USD", "Estados Unidos" },
                    { 53, "Lilangeni", "SZL", "Esuatini" },
                    { 54, "Birr", "ETB", "Etiopía" },
                    { 55, "Dólar fiyiano", "FJD", "Fiyi" },
                    { 56, "Peso filipino", "PHP", "Filipinas" },
                    { 57, "Euro", "EUR", "Finlandia" },
                    { 58, "Euro", "EUR", "Francia" },
                    { 59, "Franco CFA", "XAF", "Gabón" },
                    { 60, "Dalasi", "GMD", "Gambia" },
                    { 61, "Lari", "GEL", "Georgia" },
                    { 62, "Cedi", "GHS", "Ghana" },
                    { 63, "Dólar del Caribe Oriental", "XCD", "Granada" },
                    { 64, "Euro", "EUR", "Grecia" },
                    { 65, "Quetzal", "GTQ", "Guatemala" },
                    { 66, "Franco guineano", "GNF", "Guinea" },
                    { 67, "Franco CFA", "XOF", "Guinea-Bisáu" },
                    { 68, "Dólar guyanés", "GYD", "Guyana" },
                    { 69, "Gourde", "HTG", "Haití" },
                    { 70, "Lempira", "HNL", "Honduras" },
                    { 71, "Forinto", "HUF", "Hungría" },
                    { 72, "Rupia india", "INR", "India" },
                    { 73, "Rupia indonesia", "IDR", "Indonesia" },
                    { 74, "Rial iraní", "IRR", "Irán" },
                    { 75, "Dinar iraquí", "IQD", "Irak" },
                    { 76, "Euro", "EUR", "Irlanda" },
                    { 77, "Nuevo shekel israelí", "ILS", "Israel" },
                    { 78, "Euro", "EUR", "Italia" },
                    { 79, "Dólar jamaiquino", "JMD", "Jamaica" },
                    { 80, "Yen japonés", "JPY", "Japón" },
                    { 81, "Dinar jordano", "JOD", "Jordania" },
                    { 82, "Tenge", "KZT", "Kazajistán" },
                    { 83, "Chelín keniano", "KES", "Kenia" },
                    { 84, "Som", "KGS", "Kirguistán" },
                    { 85, "Dólar australiano", "AUD", "Kiribati" },
                    { 86, "Kip", "LAK", "Laos" },
                    { 87, "Euro", "EUR", "Letonia" },
                    { 88, "Libra libanesa", "LBP", "Líbano" },
                    { 89, "Dólar liberiano", "LRD", "Liberia" },
                    { 90, "Dinar libio", "LYD", "Libia" },
                    { 91, "Franco suizo", "CHF", "Liechtenstein" },
                    { 92, "Euro", "EUR", "Lituania" },
                    { 93, "Euro", "EUR", "Luxemburgo" },
                    { 94, "Ariary", "MGA", "Madagascar" },
                    { 95, "Ringgit", "MYR", "Malasia" },
                    { 96, "Kwacha malawiano", "MWK", "Malaui" },
                    { 97, "Rufiyaa", "MVR", "Maldivas" },
                    { 98, "Franco CFA", "XOF", "Mali" },
                    { 99, "Euro", "EUR", "Malta" },
                    { 100, "Dirham marroquí", "MAD", "Marruecos" },
                    { 101, "Rupia mauriciana", "MUR", "Mauricio" },
                    { 102, "Ouguiya", "MRU", "Mauritania" },
                    { 103, "Peso mexicano", "MXN", "México" },
                    { 104, "Dólar estadounidense", "USD", "Micronesia" },
                    { 105, "Leu moldavo", "MDL", "Moldova" },
                    { 106, "Euro", "EUR", "Mónaco" },
                    { 107, "Tugrik", "MNT", "Mongolia" },
                    { 108, "Euro", "EUR", "Montenegro" },
                    { 109, "Metical", "MZN", "Mozambique" },
                    { 110, "Kyat", "MMK", "Myanmar" },
                    { 111, "Dólar namibio", "NAD", "Namibia" },
                    { 112, "Dólar australiano", "AUD", "Nauru" },
                    { 113, "Rupia nepali", "NPR", "Nepal" },
                    { 114, "Córdoba", "NIO", "Nicaragua" },
                    { 115, "Franco CFA", "XOF", "Níger" },
                    { 116, "Naira", "NGN", "Nigeria" },
                    { 117, "Corona noruega", "NOK", "Noruega" },
                    { 118, "Dólar neozelandés", "NZD", "Nueva Zelanda" },
                    { 119, "Rial omaní", "OMR", "Omán" },
                    { 120, "Rupia pakistaní", "PKR", "Pakistán" },
                    { 121, "Dólar estadounidense", "USD", "Palaos" },
                    { 122, "Balboa / Dólar estadounidense", "PAB", "Panamá" },
                    { 123, "Kina", "PGK", "Papúa Nueva Guinea" },
                    { 124, "Guaraní", "PYG", "Paraguay" },
                    { 125, "Sol", "PEN", "Perú" },
                    { 126, "Zloty", "PLN", "Polonia" },
                    { 127, "Euro", "EUR", "Portugal" },
                    { 128, "Libra esterlina", "GBP", "Reino Unido" },
                    { 129, "Franco CFA", "XAF", "República Centroafricana" },
                    { 130, "Peso dominicano", "DOP", "República Dominicana" },
                    { 131, "Franco ruandés", "RWF", "Ruanda" },
                    { 132, "Leu rumano", "RON", "Rumania" },
                    { 133, "Rublo ruso", "RUB", "Rusia" },
                    { 134, "Dólar del Caribe Oriental", "XCD", "San Cristóbal y Nieves" },
                    { 135, "Euro", "EUR", "San Marino" },
                    { 136, "Dólar de Santo Tomé", "STN", "Santo Tomé y Príncipe" },
                    { 137, "Riyal saudí", "SAR", "Arabia Saudita" },
                    { 138, "Franco CFA", "XOF", "Senegal" },
                    { 139, "Dinar serbio", "RSD", "Serbia" },
                    { 140, "Rupia de las Seychelles", "SCR", "Seychelles" },
                    { 141, "Leona", "SLL", "Sierra Leona" },
                    { 142, "Dólar de Singapur", "SGD", "Singapur" },
                    { 143, "Libra siria", "SYP", "Siria" },
                    { 144, "Chelín somalí", "SOS", "Somalia" },
                    { 145, "Rupia de Sri Lanka", "LKR", "Sri Lanka" },
                    { 146, "Lilangeni", "SZL", "Esuatini" },
                    { 147, "Rand", "ZAR", "Sudáfrica" },
                    { 148, "Libra sudanesa", "SDG", "Sudán" },
                    { 149, "Corona sueca", "SEK", "Suecia" },
                    { 150, "Franco suizo", "CHF", "Suiza" },
                    { 151, "Dólar de Surinam", "SRD", "Surinam" },
                    { 152, "Nuevo dólar taiwanés", "TWD", "Taiwán" },
                    { 153, "Chelín tanzano", "TZS", "Tanzania" },
                    { 154, "Baht", "THB", "Tailandia" },
                    { 155, "Dólar estadounidense", "USD", "Timor Oriental" },
                    { 156, "Franco CFA", "XOF", "Togo" },
                    { 157, "Paʻanga", "TOP", "Tonga" },
                    { 158, "Dólar de Trinidad y Tobago", "TTD", "Trinidad y Tobago" },
                    { 159, "Dinar tunecino", "TND", "Túnez" },
                    { 160, "Lira turca", "TRY", "Turquía" },
                    { 161, "Manat turcomano", "TMT", "Turkmenistán" },
                    { 162, "Dólar australiano", "AUD", "Tuvalu" },
                    { 163, "Chelín ugandés", "UGX", "Uganda" },
                    { 164, "Hryvnia", "UAH", "Ucrania" },
                    { 165, "Peso uruguayo", "UYU", "Uruguay" },
                    { 166, "Som uzbeko", "UZS", "Uzbekistán" },
                    { 167, "Vatu", "VUV", "Vanuatu" },
                    { 168, "Bolívar venezolano", "VES", "Venezuela" },
                    { 169, "Dong", "VND", "Vietnam" },
                    { 170, "Rial yemení", "YER", "Yemen" },
                    { 171, "Kwacha zambiano", "ZMW", "Zambia" },
                    { 172, "Dólar zimbabuense", "ZWL", "Zimbabue" }
                });

            migrationBuilder.InsertData(
                table: "Transacciones",
                columns: new[] { "Id", "CantidadEnvia", "CantidadRecibe", "CosteTransaccion", "Fecha", "IdEnvia", "IdRecibe", "MonedaDestino", "MonedaOrigen" },
                values: new object[,]
                {
                    { 1, 1000.5, 1130.5699999999999, 10.5, new DateTime(2015, 3, 15, 9, 30, 0, 0, DateTimeKind.Unspecified), 6, 7, "EUR", "USD" },
                    { 2, 2000.75, 2560.96, 20.75, new DateTime(2018, 6, 10, 14, 45, 0, 0, DateTimeKind.Unspecified), 8, 9, "GBP", "USD" },
                    { 3, 1500.25, 1740.29, 15.25, new DateTime(2020, 8, 21, 16, 0, 0, 0, DateTimeKind.Unspecified), 10, 11, "JPY", "USD" },
                    { 4, 2500.3299999999999, 3500.46, 25.329999999999998, new DateTime(2011, 11, 30, 11, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, "CAD", "USD" },
                    { 5, 3000.6700000000001, 4260.9499999999998, 30.670000000000002, new DateTime(2017, 2, 7, 8, 30, 0, 0, DateTimeKind.Unspecified), 14, 15, "AUD", "USD" },
                    { 6, 4000.9899999999998, 2920.73, 40.990000000000002, new DateTime(2021, 12, 25, 19, 45, 0, 0, DateTimeKind.Unspecified), 16, 17, "CHF", "USD" },
                    { 7, 500.44999999999999, 790.58000000000004, 5.4500000000000002, new DateTime(2012, 4, 18, 7, 0, 0, 0, DateTimeKind.Unspecified), 18, 19, "CNY", "USD" },
                    { 8, 600.35000000000002, 888.48000000000002, 6.3499999999999996, new DateTime(2019, 7, 13, 13, 30, 0, 0, DateTimeKind.Unspecified), 20, 6, "INR", "USD" },
                    { 9, 700.12, 1085.55, 7.1200000000000001, new DateTime(2014, 5, 9, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, "BRL", "USD" },
                    { 10, 800.75, 1240.9200000000001, 8.75, new DateTime(2016, 9, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), 9, 10, "MXN", "USD" },
                    { 11, 900.63, 1350.3599999999999, 9.6300000000000008, new DateTime(2022, 3, 12, 12, 30, 0, 0, DateTimeKind.Unspecified), 11, 12, "ZAR", "USD" },
                    { 12, 100.90000000000001, 140.72999999999999, 1.8999999999999999, new DateTime(2023, 1, 1, 6, 45, 0, 0, DateTimeKind.Unspecified), 13, 14, "RUB", "USD" },
                    { 13, 200.33000000000001, 246.40000000000001, 2.3300000000000001, new DateTime(2024, 6, 17, 17, 30, 0, 0, DateTimeKind.Unspecified), 15, 16, "KRW", "USD" },
                    { 14, 300.5, 402.67000000000002, 3.5, new DateTime(2013, 2, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), 17, 18, "SGD", "USD" },
                    { 15, 400.80000000000001, 548.34000000000003, 4.7999999999999998, new DateTime(2020, 8, 11, 14, 15, 0, 0, DateTimeKind.Unspecified), 19, 20, "HKD", "USD" },
                    { 16, 5000.9499999999998, 7250.4399999999996, 50.950000000000003, new DateTime(2010, 12, 31, 11, 30, 0, 0, DateTimeKind.Unspecified), 6, 7, "NZD", "USD" },
                    { 17, 3500.4499999999998, 4270.8699999999999, 35.450000000000003, new DateTime(2017, 11, 5, 16, 45, 0, 0, DateTimeKind.Unspecified), 8, 9, "SEK", "USD" },
                    { 18, 6000.25, 7680.3500000000004, 60.25, new DateTime(2015, 3, 24, 18, 0, 0, 0, DateTimeKind.Unspecified), 10, 11, "NOK", "USD" },
                    { 19, 4200.6700000000001, 4980.1199999999999, 42.670000000000002, new DateTime(2019, 5, 22, 7, 30, 0, 0, DateTimeKind.Unspecified), 12, 13, "DKK", "USD" },
                    { 20, 4800.8500000000004, 6960.3999999999996, 48.850000000000001, new DateTime(2011, 10, 10, 20, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, "PLN", "USD" },
                    { 21, 5500.25, 8030.5, 55.25, new DateTime(2021, 7, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), 16, 17, "HUF", "USD" },
                    { 22, 3100.3400000000001, 4327.1499999999996, 31.34, new DateTime(2018, 4, 2, 15, 45, 0, 0, DateTimeKind.Unspecified), 18, 19, "CZK", "USD" },
                    { 23, 2900.75, 3357.8600000000001, 29.75, new DateTime(2014, 11, 19, 9, 15, 0, 0, DateTimeKind.Unspecified), 20, 6, "TRY", "USD" },
                    { 24, 1700.4400000000001, 2400.6300000000001, 17.440000000000001, new DateTime(2023, 8, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), 7, 8, "ILS", "USD" },
                    { 25, 650.91999999999996, 995.71000000000004, 6.9199999999999999, new DateTime(2012, 6, 5, 8, 30, 0, 0, DateTimeKind.Unspecified), 9, 10, "MYR", "USD" },
                    { 26, 4500.5500000000002, 6120.8800000000001, 45.549999999999997, new DateTime(2020, 1, 27, 14, 0, 0, 0, DateTimeKind.Unspecified), 11, 12, "THB", "USD" },
                    { 27, 3800.6799999999998, 4346.7799999999997, 38.68, new DateTime(2022, 4, 8, 11, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, "IDR", "USD" },
                    { 28, 2700.4499999999998, 3159.52, 27.449999999999999, new DateTime(2013, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), 15, 16, "PHP", "USD" },
                    { 29, 1900.3399999999999, 2652.8699999999999, 19.34, new DateTime(2016, 12, 22, 15, 45, 0, 0, DateTimeKind.Unspecified), 17, 18, "VND", "USD" },
                    { 30, 5100.1499999999996, 6120.5699999999997, 51.149999999999999, new DateTime(2024, 10, 18, 18, 0, 0, 0, DateTimeKind.Unspecified), 19, 20, "EGP", "USD" }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Apellido", "Email", "Empleo", "FechaNacimiento", "Nombre", "PaisId", "Usuario" },
                values: new object[,]
                {
                    { 1, "Juanes", "ana777@gmail.com", "Ingeniera de Software", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana", 4, "ana777" },
                    { 2, "Sanchez", "elcoletas@gmail.com", "Político", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro", 5, "elcoletas" },
                    { 3, "Martinez", "emanems@gmail.com", "Músico", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miguel", 1, "emanems" },
                    { 4, "Lopez", "jujalag@gmail.com", "Profesor", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", 1, "jujalag" },
                    { 5, "Vertiz", "ibai@gmail.com", "Streamer", new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iñigo", 6, "ibai" },
                    { 6, "Obama", "baracko@gmail.com", "Expresidente", new DateTime(1961, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barack", 5, "baracko" },
                    { 7, "Messi", "leomessi@gmail.com", "Futbolista", new DateTime(1987, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lionel", 7, "leomessi" },
                    { 8, "Musk", "elonmusk@gmail.com", "Empresario", new DateTime(1971, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elon", 8, "elonmusk" },
                    { 9, "Winfrey", "oprahw@gmail.com", "Presentadora de TV", new DateTime(1954, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oprah", 5, "oprahw" },
                    { 10, "Gates", "billgates@gmail.com", "Filántropo", new DateTime(1955, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill", 5, "billgates" },
                    { 11, "Merkel", "angelam@gmail.com", "Expresidenta", new DateTime(1954, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angela", 9, "angelam" },
                    { 12, "Ripoll", "shakira@gmail.com", "Cantante", new DateTime(1977, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shakira", 10, "shakira" },
                    { 13, "Jobs", "stevejobs@gmail.com", "Empresario", new DateTime(1955, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steve", 5, "stevejobs" },
                    { 14, "Zuckerberg", "markz@gmail.com", "CEO de Facebook", new DateTime(1984, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mark", 5, "markz" },
                    { 15, "Williams", "serenaw@gmail.com", "Tenista", new DateTime(1981, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Serena", 5, "serenaw" },
                    { 16, "Ronaldo", "cr7@gmail.com", "Futbolista", new DateTime(1985, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristiano", 11, "cr7" },
                    { 17, "James", "lebronj@gmail.com", "Jugador de Baloncesto", new DateTime(1984, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "LeBron", 5, "lebronj" },
                    { 18, "Kagan", "elenak@gmail.com", "Jueza del Tribunal Supremo", new DateTime(1960, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elena", 5, "elenak" },
                    { 19, "Rowling", "jkrowling@gmail.com", "Escritora", new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.K.", 4, "jkrowling" },
                    { 20, "Johnson", "therock@gmail.com", "Actor", new DateTime(1972, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dwayne", 5, "therock" }
                });

            migrationBuilder.InsertData(
                table: "Contactos",
                columns: new[] { "Id", "ClienteDestinoId", "ClienteOrigenId" },
                values: new object[,]
                {
                    { 1, 5, 1 },
                    { 2, 10, 2 },
                    { 3, 15, 3 },
                    { 4, 8, 4 },
                    { 5, 20, 5 },
                    { 6, 14, 6 },
                    { 7, 3, 7 },
                    { 8, 16, 8 },
                    { 9, 2, 9 },
                    { 10, 12, 10 },
                    { 11, 7, 11 },
                    { 12, 9, 12 },
                    { 13, 1, 13 },
                    { 14, 18, 14 },
                    { 15, 4, 15 },
                    { 16, 13, 16 },
                    { 17, 6, 17 },
                    { 18, 11, 18 },
                    { 19, 17, 19 },
                    { 20, 19, 20 },
                    { 21, 7, 1 },
                    { 22, 5, 2 },
                    { 23, 9, 3 },
                    { 24, 13, 4 },
                    { 25, 3, 5 },
                    { 26, 20, 6 },
                    { 27, 14, 7 },
                    { 28, 11, 8 },
                    { 29, 15, 9 },
                    { 30, 4, 10 },
                    { 31, 8, 11 },
                    { 32, 1, 12 },
                    { 33, 19, 13 },
                    { 34, 6, 14 },
                    { 35, 10, 15 },
                    { 36, 2, 16 },
                    { 37, 18, 17 },
                    { 38, 16, 18 },
                    { 39, 12, 19 },
                    { 40, 17, 20 },
                    { 41, 14, 1 },
                    { 42, 6, 2 },
                    { 43, 11, 3 },
                    { 44, 20, 4 },
                    { 45, 7, 5 },
                    { 46, 9, 6 },
                    { 47, 1, 7 },
                    { 48, 4, 8 },
                    { 49, 13, 9 },
                    { 50, 3, 10 },
                    { 51, 8, 11 },
                    { 52, 15, 12 },
                    { 53, 18, 13 },
                    { 54, 16, 14 },
                    { 55, 2, 15 },
                    { 56, 12, 16 },
                    { 57, 19, 17 },
                    { 58, 5, 18 },
                    { 59, 14, 19 },
                    { 60, 9, 20 },
                    { 61, 10, 1 },
                    { 62, 3, 2 },
                    { 63, 17, 3 },
                    { 64, 11, 4 },
                    { 65, 6, 5 },
                    { 66, 8, 6 },
                    { 67, 19, 7 },
                    { 68, 2, 8 },
                    { 69, 7, 9 },
                    { 70, 1, 10 },
                    { 71, 16, 11 },
                    { 72, 4, 12 },
                    { 73, 9, 13 },
                    { 74, 13, 14 },
                    { 75, 18, 15 },
                    { 76, 10, 16 },
                    { 77, 6, 17 },
                    { 78, 12, 18 },
                    { 79, 15, 19 },
                    { 80, 11, 20 },
                    { 81, 17, 1 },
                    { 82, 8, 2 },
                    { 83, 5, 3 },
                    { 84, 14, 4 },
                    { 85, 3, 5 },
                    { 86, 18, 6 },
                    { 87, 13, 7 },
                    { 88, 19, 8 },
                    { 89, 4, 9 },
                    { 90, 7, 10 },
                    { 91, 15, 11 },
                    { 92, 6, 12 },
                    { 93, 20, 13 },
                    { 94, 1, 14 },
                    { 95, 9, 15 },
                    { 96, 11, 16 },
                    { 97, 8, 17 },
                    { 98, 2, 18 },
                    { 99, 12, 19 },
                    { 100, 10, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PaisId",
                table: "Clientes",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_ClienteDestinoId",
                table: "Contactos",
                column: "ClienteDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_ClienteOrigenId",
                table: "Contactos",
                column: "ClienteOrigenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "ConteoResults");

            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
