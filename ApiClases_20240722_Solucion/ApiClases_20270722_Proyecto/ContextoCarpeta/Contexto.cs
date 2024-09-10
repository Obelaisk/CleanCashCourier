using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Text.Json;

namespace ApiClases_20270722_Proyecto.ContextoCarpeta;

public class Contexto: IdentityDbContext<UsuarioAplicacion>{
    
        public Contexto(DbContextOptions<Contexto> options) : base(options) {
        }

        // DbSet es una colección de entidades que se pueden consultar, insertar, actualizar y eliminar.
        // DbSet es una propiedad de DbContext que representa una colección de entidades en la base de datos.
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Transaccion> Transacciones{ get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public virtual DbSet<VContacto> VContactos { get; set; }
        public DbSet<ConteoResult> ConteoResults { get; set; }  // DbSet temporal

        



    // OnConfiguring se llama cuando se crea el contexto
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // Para activar el seguimiento de consultas,
            // se debe establecer el nivel de seguimiento en Debug
            // en el archivo de configuración de la aplicación (appsettings.json)
            // y se debe agregar el siguiente código 
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Contacto>()
            .HasOne(c => c.ClienteOrigen)
            .WithMany()
            .HasForeignKey(c => c.ClienteOrigenId)
            .OnDelete(DeleteBehavior.Restrict); // O DeleteBehavior.NoAction

        modelBuilder.Entity<Contacto>()
            .HasOne(c => c.ClienteDestino)
            .WithMany()
            .HasForeignKey(c => c.ClienteDestinoId)
            .OnDelete(DeleteBehavior.Restrict); // O DeleteBehavior.NoAction


        modelBuilder.Entity<VContacto>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VContactos");
        });
        base.OnModelCreating(modelBuilder); // para el identity
        /*modelBuilder.Entity<Pais>().HasData(
                new Pais { Id = 1, Nombre = "Afganistán", Divisa = "Afgani", Iso3 = "AFN" },
                new Pais { Id = 2, Nombre = "Albania", Divisa = "Lek", Iso3 = "ALL" },
                new Pais { Id = 3, Nombre = "Alemania", Divisa = "Euro", Iso3 = "EUR" },
                new Pais { Id = 4, Nombre = "Andorra", Divisa = "Euro", Iso3 = "EUR" },
                new Pais { Id = 5, Nombre = "Angola", Divisa = "Kwanza", Iso3 = "AOA" },
                new Pais { Id = 6, Nombre = "Antigua y Barbuda", Divisa = "Dólar del Caribe Oriental", Iso3 = "XCD" },
                new Pais { Id = 7, Nombre = "Argentina", Divisa = "Peso argentino", Iso3 = "ARS" },
                new Pais { Id = 8, Nombre = "Armenia", Divisa = "Dram", Iso3 = "AMD" },
                new Pais { Id = 9, Nombre = "Australia", Divisa = "Dólar australiano", Iso3 = "AUD" },
                new Pais { Id = 10, Nombre = "Austria", Divisa = "Euro", Iso3 = "EUR" },
                new Pais { Id = 11, Nombre = "Azerbaiyán", Divisa = "Manat azerí", Iso3 = "AZN" },
                new Pais { Id = 12, Nombre = "Bahamas", Divisa = "Dólar bahameño", Iso3 = "BSD" },
                new Pais { Id = 13, Nombre = "Bahréin", Divisa = "Dinar bareiní", Iso3 = "BHD" },
                new Pais { Id = 14, Nombre = "Bangladesh", Divisa = "Taka", Iso3 = "BDT" },
                new Pais { Id = 15, Nombre = "Barbados", Divisa = "Dólar de Barbados", Iso3 = "BBD" },
                new Pais { Id = 16, Nombre = "Bélgica", Divisa = "Euro", Iso3 = "EUR" },
                new Pais { Id = 17, Nombre = "Belice", Divisa = "Dólar beliceño", Iso3 = "BZD" },
                new Pais { Id = 18, Nombre = "Benín", Divisa = "Franco CFA", Iso3 = "XOF" },
                new Pais { Id = 19, Nombre = "Bolivia", Divisa = "Boliviano", Iso3 = "BOB" },
                new Pais { Id = 20, Nombre = "Bosnia y Herzegovina", Divisa = "Marco convertible", Iso3 = "BAM" },
                new Pais { Id = 21, Nombre = "Botsuana", Divisa = "Pula", Iso3 = "BWP" },
                new Pais { Id = 22, Nombre = "Brasil", Divisa = "Real", Iso3 = "BRL" },
                new Pais { Id = 23, Nombre = "Brunei", Divisa = "Dólar de Brunei", Iso3 = "BND" },
                new Pais { Id = 24, Nombre = "Bulgaria", Divisa = "Lev búlgaro", Iso3 = "BGN" },
                new Pais { Id = 25, Nombre = "Burkina Faso", Divisa = "Franco CFA", Iso3 = "XOF" },
                new Pais { Id = 26, Nombre = "Burundi", Divisa = "Franco burundés", Iso3 = "BIF" },
                new Pais { Id = 27, Nombre = "Bután", Divisa = "Ngultrum", Iso3 = "BTN" },
                new Pais { Id = 28, Nombre = "Cabo Verde", Divisa = "Escudo caboverdiano", Iso3 = "CVE" },
                new Pais { Id = 29, Nombre = "Camboya", Divisa = "Riel", Iso3 = "KHR" },
                new Pais { Id = 30, Nombre = "Camerún", Divisa = "Franco CFA", Iso3 = "XAF" },
                new Pais { Id = 31, Nombre = "Canadá", Divisa = "Dólar canadiense", Iso3 = "CAD" },
                new Pais { Id = 32, Nombre = "Catar", Divisa = "Riyal catarí", Iso3 = "QAR" },
                new Pais { Id = 33, Nombre = "Colombia", Divisa = "Peso colombiano", Iso3 = "COP" },
                new Pais { Id = 34, Nombre = "Comoras", Divisa = "Franco comorense", Iso3 = "KMF" },
                new Pais { Id = 35, Nombre = "Congo, República Democrática del", Divisa = "Franco congoleño", Iso3 = "CDF" },
                new Pais { Id = 36, Nombre = "Congo, República del", Divisa = "Franco CFA", Iso3 = "XAF" },
                new Pais { Id = 37, Nombre = "Corea del Norte", Divisa = "Won norcoreano", Iso3 = "KPW" },
                new Pais { Id = 38, Nombre = "Corea del Sur", Divisa = "Won surcoreano", Iso3 = "KRW" },
                new Pais { Id = 39, Nombre = "Costa Rica", Divisa = "Colón costarricense", Iso3 = "CRC" },
                new Pais { Id = 40, Nombre = "Croacia", Divisa = "Kuna", Iso3 = "HRK" },
                new Pais { Id = 41, Nombre = "Cuba", Divisa = "Peso cubano", Iso3 = "CUP" },
                new Pais { Id = 42, Nombre = "Dinamarca", Divisa = "Corona danesa", Iso3 = "DKK" },
                new Pais { Id = 43, Nombre = "Djibouti", Divisa = "Franco yibutiano", Iso3 = "DJF" },
                new Pais { Id = 44, Nombre = "Dominica", Divisa = "Dólar del Caribe Oriental", Iso3 = "XCD" },
                new Pais { Id = 45, Nombre = "Egipto", Divisa = "Libra egipcia", Iso3 = "EGP" },
                new Pais { Id = 46, Nombre = "El Salvador", Divisa = "Dólar estadounidense", Iso3 = "USD" },
                new Pais { Id = 47, Nombre = "Emiratos Árabes Unidos", Divisa = "Dirham de los Emiratos Árabes Unidos", Iso3 = "AED" },
                new Pais { Id = 48, Nombre = "Eritrea", Divisa = "Nakfa", Iso3 = "ERN" },
                new Pais { Id = 49, Nombre = "Eslovaquia", Divisa = "Euro", Iso3 = "EUR" },
                new Pais { Id = 50, Nombre = "Eslovenia", Divisa = "Euro", Iso3 = "EUR" },
                new Pais { Id = 51, Nombre = "España", Divisa = "Euro", Iso3 = "EUR" },
                new Pais { Id = 52, Nombre = "Estados Unidos", Divisa = "Dólar estadounidense", Iso3 = "USD" },
                new Pais { Id = 53, Nombre = "Esuatini", Divisa = "Lilangeni", Iso3 = "SZL" },
                new Pais { Id = 54, Nombre = "Etiopía", Divisa = "Birr", Iso3 = "ETB" },
                new Pais { Id = 55, Nombre = "Fiyi", Divisa = "Dólar fiyiano", Iso3 = "FJD" },
                new Pais { Id = 56, Nombre = "Filipinas", Divisa = "Peso filipino", Iso3 = "PHP" },
                new Pais { Id = 57, Nombre = "Finlandia", Divisa = "Euro", Iso3 = "EUR" },
                new Pais { Id = 58, Nombre = "Francia", Divisa = "Euro", Iso3 = "EUR" },
                new Pais { Id = 59, Nombre = "Gabón", Divisa = "Franco CFA", Iso3 = "XAF" },
                new Pais { Id = 60, Nombre = "Gambia", Divisa = "Dalasi", Iso3 = "GMD" },
                new Pais { Id = 61, Nombre = "Georgia", Divisa = "Lari", Iso3 = "GEL" },
                new Pais { Id = 62, Nombre = "Ghana", Divisa = "Cedi", Iso3 = "GHS" },
                new Pais { Id = 63, Nombre = "Granada", Divisa = "Dólar del Caribe Oriental", Iso3 = "XCD" },
                new Pais { Id = 64, Nombre = "Grecia", Divisa = "Euro", Iso3 = "EUR" },
                new Pais { Id = 65, Nombre = "Guatemala", Divisa = "Quetzal", Iso3 = "GTQ" },
                new Pais { Id = 66, Nombre = "Guinea", Divisa = "Franco guineano", Iso3 = "GNF" },
                new Pais { Id = 67, Nombre = "Guinea-Bisáu", Divisa = "Franco CFA", Iso3 = "XOF" },
                new Pais { Id = 68, Nombre = "Guyana", Divisa = "Dólar guyanés", Iso3 = "GYD" },
                new Pais { Id = 69, Nombre = "Haití", Divisa = "Gourde", Iso3 = "HTG" },
                new Pais { Id = 70, Nombre = "Honduras", Divisa = "Lempira", Iso3 = "HNL" },
                new Pais { Id = 71, Nombre = "Hungría", Divisa = "Forinto", Iso3 = "HUF" },
                new Pais { Id = 72, Nombre = "India", Divisa = "Rupia india", Iso3 = "INR" },
                new Pais { Id = 73, Nombre = "Indonesia", Divisa = "Rupia indonesia", Iso3 = "IDR" },
                new Pais { Id = 74, Nombre = "Irán", Divisa = "Rial iraní", Iso3 = "IRR" },
                new Pais { Id = 75, Nombre = "Irak", Divisa = "Dinar iraquí", Iso3 = "IQD" },
                new Pais { Id = 76, Nombre = "Irlanda", Divisa = "Euro", Iso3 = "EUR" },
                new Pais { Id = 77, Nombre = "Israel", Divisa = "Nuevo shekel israelí", Iso3 = "ILS" },
                new Pais { Id = 78, Nombre = "Italia", Divisa = "Euro", Iso3 = "EUR" },
                new Pais { Id = 79, Nombre = "Jamaica", Divisa = "Dólar jamaiquino", Iso3 = "JMD" },
                new Pais { Id = 80, Nombre = "Japón", Divisa = "Yen japonés", Iso3 = "JPY" },
                new Pais { Id = 81, Nombre = "Jordania", Divisa = "Dinar jordano", Iso3 = "JOD" },
                new Pais { Id = 82, Nombre = "Kazajistán", Divisa = "Tenge", Iso3 = "KZT" },
                new Pais { Id = 83, Nombre = "Kenia", Divisa = "Chelín keniano", Iso3 = "KES" },
                new Pais { Id = 84, Nombre = "Kirguistán", Divisa = "Som", Iso3 = "KGS" },
                new Pais { Id = 85, Nombre = "Kiribati", Divisa = "Dólar australiano", Iso3 = "AUD" },
                new Pais { Id = 86, Nombre = "Laos", Divisa = "Kip", Iso3 = "LAK" },
                new Pais { Id = 87, Nombre = "Letonia", Divisa = "Euro", Iso3 = "EUR" },
                new Pais { Id = 88, Nombre = "Líbano", Divisa = "Libra libanesa", Iso3 = "LBP" },
                new Pais { Id = 89, Nombre = "Liberia", Divisa = "Dólar liberiano", Iso3 = "LRD" },
                new Pais { Id = 90, Nombre = "Libia", Divisa = "Dinar libio", Iso3 = "LYD" },
                new Pais { Id = 91, Nombre = "Liechtenstein", Divisa = "Franco suizo", Iso3 = "CHF" },
                new Pais { Id = 92, Nombre = "Lituania", Divisa = "Euro", Iso3 = "EUR" },
                new Pais { Id = 93, Nombre = "Luxemburgo", Divisa = "Euro", Iso3 = "EUR" },
                new Pais { Id = 94, Nombre = "Madagascar", Divisa = "Ariary", Iso3 = "MGA" },
                new Pais { Id = 95, Nombre = "Malasia", Divisa = "Ringgit", Iso3 = "MYR" },
                new Pais { Id = 96, Nombre = "Malaui", Divisa = "Kwacha malawiano", Iso3 = "MWK" },
                new Pais { Id = 97, Nombre = "Maldivas", Divisa = "Rufiyaa", Iso3 = "MVR" },
                new Pais { Id = 98, Nombre = "Mali", Divisa = "Franco CFA", Iso3 = "XOF" },
                new Pais { Id = 99, Nombre = "Malta", Divisa = "Euro", Iso3 = "EUR" },
                new Pais { Id = 100, Nombre = "Marruecos", Divisa = "Dirham marroquí", Iso3 = "MAD" },
                new Pais { Id = 101, Nombre = "Mauricio", Divisa = "Rupia mauriciana", Iso3 = "MUR" },
                new Pais { Id = 102, Nombre = "Mauritania", Divisa = "Ouguiya", Iso3 = "MRU" },
                new Pais { Id = 103, Nombre = "México", Divisa = "Peso mexicano", Iso3 = "MXN" },
                new Pais { Id = 104, Nombre = "Micronesia", Divisa = "Dólar estadounidense", Iso3 = "USD" },
                new Pais { Id = 105, Nombre = "Moldova", Divisa = "Leu moldavo", Iso3 = "MDL" },
                new Pais { Id = 106, Nombre = "Mónaco", Divisa = "Euro", Iso3 = "EUR" },
                new Pais { Id = 107, Nombre = "Mongolia", Divisa = "Tugrik", Iso3 = "MNT" },
                new Pais { Id = 108, Nombre = "Montenegro", Divisa = "Euro", Iso3 = "EUR" },
                new Pais { Id = 109, Nombre = "Mozambique", Divisa = "Metical", Iso3 = "MZN" },
                new Pais { Id = 110, Nombre = "Myanmar", Divisa = "Kyat", Iso3 = "MMK" },
                new Pais { Id = 111, Nombre = "Namibia", Divisa = "Dólar namibio", Iso3 = "NAD" },
                new Pais { Id = 112, Nombre = "Nauru", Divisa = "Dólar australiano", Iso3 = "AUD" },
                new Pais { Id = 113, Nombre = "Nepal", Divisa = "Rupia nepali", Iso3 = "NPR" },
                new Pais { Id = 114, Nombre = "Nicaragua", Divisa = "Córdoba", Iso3 = "NIO" },
                new Pais { Id = 115, Nombre = "Níger", Divisa = "Franco CFA", Iso3 = "XOF" },
                new Pais { Id = 116, Nombre = "Nigeria", Divisa = "Naira", Iso3 = "NGN" },
                new Pais { Id = 117, Nombre = "Noruega", Divisa = "Corona noruega", Iso3 = "NOK" },
                new Pais { Id = 118, Nombre = "Nueva Zelanda", Divisa = "Dólar neozelandés", Iso3 = "NZD" },
                new Pais { Id = 119, Nombre = "Omán", Divisa = "Rial omaní", Iso3 = "OMR" },
                new Pais { Id = 120, Nombre = "Pakistán", Divisa = "Rupia pakistaní", Iso3 = "PKR" },
                new Pais { Id = 121, Nombre = "Palaos", Divisa = "Dólar estadounidense", Iso3 = "USD" },
                new Pais { Id = 122, Nombre = "Panamá", Divisa = "Balboa / Dólar estadounidense", Iso3 = "PAB" },
                new Pais { Id = 123, Nombre = "Papúa Nueva Guinea", Divisa = "Kina", Iso3 = "PGK" },
                new Pais { Id = 124, Nombre = "Paraguay", Divisa = "Guaraní", Iso3 = "PYG" },
                new Pais { Id = 125, Nombre = "Perú", Divisa = "Sol", Iso3 = "PEN" },
                new Pais { Id = 126, Nombre = "Polonia", Divisa = "Zloty", Iso3 = "PLN" },
                new Pais { Id = 127, Nombre = "Portugal", Divisa = "Euro", Iso3 = "EUR" },
                new Pais { Id = 128, Nombre = "Reino Unido", Divisa = "Libra esterlina", Iso3 = "GBP" },
                new Pais { Id = 129, Nombre = "República Centroafricana", Divisa = "Franco CFA", Iso3 = "XAF" },
                new Pais { Id = 130, Nombre = "República Dominicana", Divisa = "Peso dominicano", Iso3 = "DOP" },
                new Pais { Id = 131, Nombre = "Ruanda", Divisa = "Franco ruandés", Iso3 = "RWF" },
                new Pais { Id = 132, Nombre = "Rumania", Divisa = "Leu rumano", Iso3 = "RON" },
                new Pais { Id = 133, Nombre = "Rusia", Divisa = "Rublo ruso", Iso3 = "RUB" },
                new Pais { Id = 134, Nombre = "San Cristóbal y Nieves", Divisa = "Dólar del Caribe Oriental", Iso3 = "XCD" },
                new Pais { Id = 135, Nombre = "San Marino", Divisa = "Euro", Iso3 = "EUR" },
                new Pais { Id = 136, Nombre = "Santo Tomé y Príncipe", Divisa = "Dólar de Santo Tomé", Iso3 = "STN" },
                new Pais { Id = 137, Nombre = "Arabia Saudita", Divisa = "Riyal saudí", Iso3 = "SAR" },
                new Pais { Id = 138, Nombre = "Senegal", Divisa = "Franco CFA", Iso3 = "XOF" },
                new Pais { Id = 139, Nombre = "Serbia", Divisa = "Dinar serbio", Iso3 = "RSD" },
                new Pais { Id = 140, Nombre = "Seychelles", Divisa = "Rupia de las Seychelles", Iso3 = "SCR" },
                new Pais { Id = 141, Nombre = "Sierra Leona", Divisa = "Leona", Iso3 = "SLL" },
                new Pais { Id = 142, Nombre = "Singapur", Divisa = "Dólar de Singapur", Iso3 = "SGD" },
                new Pais { Id = 143, Nombre = "Siria", Divisa = "Libra siria", Iso3 = "SYP" },
                new Pais { Id = 144, Nombre = "Somalia", Divisa = "Chelín somalí", Iso3 = "SOS" },
                new Pais { Id = 145, Nombre = "Sri Lanka", Divisa = "Rupia de Sri Lanka", Iso3 = "LKR" },
                new Pais { Id = 146, Nombre = "Esuatini", Divisa = "Lilangeni", Iso3 = "SZL" },
                new Pais { Id = 147, Nombre = "Sudáfrica", Divisa = "Rand", Iso3 = "ZAR" },
                new Pais { Id = 148, Nombre = "Sudán", Divisa = "Libra sudanesa", Iso3 = "SDG" },
                new Pais { Id = 149, Nombre = "Suecia", Divisa = "Corona sueca", Iso3 = "SEK" },
                new Pais { Id = 150, Nombre = "Suiza", Divisa = "Franco suizo", Iso3 = "CHF" },
                new Pais { Id = 151, Nombre = "Surinam", Divisa = "Dólar de Surinam", Iso3 = "SRD" },
                new Pais { Id = 152, Nombre = "Taiwán", Divisa = "Nuevo dólar taiwanés", Iso3 = "TWD" },
                new Pais { Id = 153, Nombre = "Tanzania", Divisa = "Chelín tanzano", Iso3 = "TZS" },
                new Pais { Id = 154, Nombre = "Tailandia", Divisa = "Baht", Iso3 = "THB" },
                new Pais { Id = 155, Nombre = "Timor Oriental", Divisa = "Dólar estadounidense", Iso3 = "USD" },
                new Pais { Id = 156, Nombre = "Togo", Divisa = "Franco CFA", Iso3 = "XOF" },
                new Pais { Id = 157, Nombre = "Tonga", Divisa = "Paʻanga", Iso3 = "TOP" },
                new Pais { Id = 158, Nombre = "Trinidad y Tobago", Divisa = "Dólar de Trinidad y Tobago", Iso3 = "TTD" },
                new Pais { Id = 159, Nombre = "Túnez", Divisa = "Dinar tunecino", Iso3 = "TND" },
                new Pais { Id = 160, Nombre = "Turquía", Divisa = "Lira turca", Iso3 = "TRY" },
                new Pais { Id = 161, Nombre = "Turkmenistán", Divisa = "Manat turcomano", Iso3 = "TMT" },
                new Pais { Id = 162, Nombre = "Tuvalu", Divisa = "Dólar australiano", Iso3 = "AUD" },
                new Pais { Id = 163, Nombre = "Uganda", Divisa = "Chelín ugandés", Iso3 = "UGX" },
                new Pais { Id = 164, Nombre = "Ucrania", Divisa = "Hryvnia", Iso3 = "UAH" },
                new Pais { Id = 165, Nombre = "Uruguay", Divisa = "Peso uruguayo", Iso3 = "UYU" },
                new Pais { Id = 166, Nombre = "Uzbekistán", Divisa = "Som uzbeko", Iso3 = "UZS" },
                new Pais { Id = 167, Nombre = "Vanuatu", Divisa = "Vatu", Iso3 = "VUV" },
                new Pais { Id = 168, Nombre = "Venezuela", Divisa = "Bolívar venezolano", Iso3 = "VES" },
                new Pais { Id = 169, Nombre = "Vietnam", Divisa = "Dong", Iso3 = "VND" },
                new Pais { Id = 170, Nombre = "Yemen", Divisa = "Rial yemení", Iso3 = "YER" },
                new Pais { Id = 171, Nombre = "Zambia", Divisa = "Kwacha zambiano", Iso3 = "ZMW" },
                new Pais { Id = 172, Nombre = "Zimbabue", Divisa = "Dólar zimbabuense", Iso3 = "ZWL" }
            );
        */
        modelBuilder.Entity<Pais>().HasData(LoadPaisesJson("./data/listapaises.json"));

        // Agregar tres paises por defecto a la base de datos
        modelBuilder.Entity<Cliente>().HasData(
                new Cliente() { Id = 1, Nombre = "Ana", Apellido = "Juanes", Email = "ana777@gmail.com", Usuario = "ana777", Empleo = "Ingeniera de Software", PaisId = 4, FechaNacimiento = new DateTime(1900, 1, 1) },
                new Cliente() { Id = 2, Nombre = "Pedro", Apellido = "Sanchez", Email = "elcoletas@gmail.com", Usuario = "elcoletas", Empleo = "Político", PaisId = 5, FechaNacimiento = new DateTime(1900, 1, 1) },
                new Cliente() { Id = 3, Nombre = "Miguel", Apellido = "Martinez", Email = "emanems@gmail.com", Usuario = "emanems", Empleo = "Músico", PaisId = 1, FechaNacimiento = new DateTime(1900, 1, 1) },
                new Cliente() { Id = 4, Nombre = "Juan", Apellido = "Lopez", Email = "jujalag@gmail.com", Usuario = "jujalag", Empleo = "Profesor", PaisId = 1, FechaNacimiento = new DateTime(1900, 1, 1) },
                new Cliente() { Id = 5, Nombre = "Iñigo", Apellido = "Vertiz", Email = "ibai@gmail.com", Usuario = "ibai", Empleo = "Streamer", PaisId = 6, FechaNacimiento = new DateTime(1900, 1, 1) },
                new Cliente { Id = 6, Nombre = "Barack", Apellido = "Obama", Email = "baracko@gmail.com", Usuario = "baracko", Empleo = "Expresidente", PaisId = 5, FechaNacimiento = new DateTime(1961, 8, 4) },
                new Cliente { Id = 7, Nombre = "Lionel", Apellido = "Messi", Email = "leomessi@gmail.com", Usuario = "leomessi", Empleo = "Futbolista", PaisId = 7, FechaNacimiento = new DateTime(1987, 6, 24) },
                new Cliente { Id = 8, Nombre = "Elon", Apellido = "Musk", Email = "elonmusk@gmail.com", Usuario = "elonmusk", Empleo = "Empresario", PaisId = 8, FechaNacimiento = new DateTime(1971, 6, 28) },
                new Cliente { Id = 9, Nombre = "Oprah", Apellido = "Winfrey", Email = "oprahw@gmail.com", Usuario = "oprahw", Empleo = "Presentadora de TV", PaisId = 5, FechaNacimiento = new DateTime(1954, 1, 29) },
                new Cliente { Id = 10, Nombre = "Bill", Apellido = "Gates", Email = "billgates@gmail.com", Usuario = "billgates", Empleo = "Filántropo", PaisId = 5, FechaNacimiento = new DateTime(1955, 10, 28) },
                new Cliente { Id = 11, Nombre = "Angela", Apellido = "Merkel", Email = "angelam@gmail.com", Usuario = "angelam", Empleo = "Expresidenta", PaisId = 9, FechaNacimiento = new DateTime(1954, 7, 17) },
                new Cliente { Id = 12, Nombre = "Shakira", Apellido = "Ripoll", Email = "shakira@gmail.com", Usuario = "shakira", Empleo = "Cantante", PaisId = 10, FechaNacimiento = new DateTime(1977, 2, 2) },
                new Cliente { Id = 13, Nombre = "Steve", Apellido = "Jobs", Email = "stevejobs@gmail.com", Usuario = "stevejobs", Empleo = "Empresario", PaisId = 5, FechaNacimiento = new DateTime(1955, 2, 24) },
                new Cliente { Id = 14, Nombre = "Mark", Apellido = "Zuckerberg", Email = "markz@gmail.com", Usuario = "markz", Empleo = "CEO de Facebook", PaisId = 5, FechaNacimiento = new DateTime(1984, 5, 14) },
                new Cliente { Id = 15, Nombre = "Serena", Apellido = "Williams", Email = "serenaw@gmail.com", Usuario = "serenaw", Empleo = "Tenista", PaisId = 5, FechaNacimiento = new DateTime(1981, 9, 26) },
                new Cliente { Id = 16, Nombre = "Cristiano", Apellido = "Ronaldo", Email = "cr7@gmail.com", Usuario = "cr7", Empleo = "Futbolista", PaisId = 11, FechaNacimiento = new DateTime(1985, 2, 5) },
                new Cliente { Id = 17, Nombre = "LeBron", Apellido = "James", Email = "lebronj@gmail.com", Usuario = "lebronj", Empleo = "Jugador de Baloncesto", PaisId = 5, FechaNacimiento = new DateTime(1984, 12, 30) },
                new Cliente { Id = 18, Nombre = "Elena", Apellido = "Kagan", Email = "elenak@gmail.com", Usuario = "elenak", Empleo = "Jueza del Tribunal Supremo", PaisId = 5, FechaNacimiento = new DateTime(1960, 4, 28) },
                new Cliente { Id = 19, Nombre = "J.K.", Apellido = "Rowling", Email = "jkrowling@gmail.com", Usuario = "jkrowling", Empleo = "Escritora", PaisId = 4, FechaNacimiento = new DateTime(1965, 7, 31) },
                new Cliente { Id = 20, Nombre = "Dwayne", Apellido = "Johnson", Email = "therock@gmail.com", Usuario = "therock", Empleo = "Actor", PaisId = 5, FechaNacimiento = new DateTime(1972, 5, 2) }
        );

        modelBuilder.Entity<Transaccion>().HasData(
            new Transaccion { Id = 1, IdEnvia = 6, CantidadEnvia = 1000.50, IdRecibe = 7, CantidadRecibe = 1130.57, Fecha = new DateTime(2015, 3, 15, 9, 30, 0), MonedaOrigen = "USD", MonedaDestino = "EUR", CosteTransaccion = 10.50 },
            new Transaccion { Id = 2, IdEnvia = 8, CantidadEnvia = 2000.75, IdRecibe = 9, CantidadRecibe = 2560.96, Fecha = new DateTime(2018, 6, 10, 14, 45, 0), MonedaOrigen = "USD", MonedaDestino = "GBP", CosteTransaccion = 20.75 },
            new Transaccion { Id = 3, IdEnvia = 10, CantidadEnvia = 1500.25, IdRecibe = 11, CantidadRecibe = 1740.29, Fecha = new DateTime(2020, 8, 21, 16, 0, 0), MonedaOrigen = "USD", MonedaDestino = "JPY", CosteTransaccion = 15.25 },
            new Transaccion { Id = 4, IdEnvia = 12, CantidadEnvia = 2500.33, IdRecibe = 13, CantidadRecibe = 3500.46, Fecha = new DateTime(2011, 11, 30, 11, 15, 0), MonedaOrigen = "USD", MonedaDestino = "CAD", CosteTransaccion = 25.33 },
            new Transaccion { Id = 5, IdEnvia = 14, CantidadEnvia = 3000.67, IdRecibe = 15, CantidadRecibe = 4260.95, Fecha = new DateTime(2017, 2, 7, 8, 30, 0), MonedaOrigen = "USD", MonedaDestino = "AUD", CosteTransaccion = 30.67 },
            new Transaccion { Id = 6, IdEnvia = 16, CantidadEnvia = 4000.99, IdRecibe = 17, CantidadRecibe = 2920.73, Fecha = new DateTime(2021, 12, 25, 19, 45, 0), MonedaOrigen = "USD", MonedaDestino = "CHF", CosteTransaccion = 40.99 },
            new Transaccion { Id = 7, IdEnvia = 18, CantidadEnvia = 500.45, IdRecibe = 19, CantidadRecibe = 790.58, Fecha = new DateTime(2012, 4, 18, 7, 0, 0), MonedaOrigen = "USD", MonedaDestino = "CNY", CosteTransaccion = 5.45 },
            new Transaccion { Id = 8, IdEnvia = 20, CantidadEnvia = 600.35, IdRecibe = 6, CantidadRecibe = 888.48, Fecha = new DateTime(2019, 7, 13, 13, 30, 0), MonedaOrigen = "USD", MonedaDestino = "INR", CosteTransaccion = 6.35 },
            new Transaccion { Id = 9, IdEnvia = 7, CantidadEnvia = 700.12, IdRecibe = 8, CantidadRecibe = 1085.55, Fecha = new DateTime(2014, 5, 9, 10, 15, 0), MonedaOrigen = "USD", MonedaDestino = "BRL", CosteTransaccion = 7.12 },
            new Transaccion { Id = 10, IdEnvia = 9, CantidadEnvia = 800.75, IdRecibe = 10, CantidadRecibe = 1240.92, Fecha = new DateTime(2016, 9, 14, 15, 0, 0), MonedaOrigen = "USD", MonedaDestino = "MXN", CosteTransaccion = 8.75 },
            new Transaccion { Id = 11, IdEnvia = 11, CantidadEnvia = 900.63, IdRecibe = 12, CantidadRecibe = 1350.36, Fecha = new DateTime(2022, 3, 12, 12, 30, 0), MonedaOrigen = "USD", MonedaDestino = "ZAR", CosteTransaccion = 9.63 },
            new Transaccion { Id = 12, IdEnvia = 13, CantidadEnvia = 100.90, IdRecibe = 14, CantidadRecibe = 140.73, Fecha = new DateTime(2023, 1, 1, 6, 45, 0), MonedaOrigen = "USD", MonedaDestino = "RUB", CosteTransaccion = 1.90 },
            new Transaccion { Id = 13, IdEnvia = 15, CantidadEnvia = 200.33, IdRecibe = 16, CantidadRecibe = 246.40, Fecha = new DateTime(2024, 6, 17, 17, 30, 0), MonedaOrigen = "USD", MonedaDestino = "KRW", CosteTransaccion = 2.33 },
            new Transaccion { Id = 14, IdEnvia = 17, CantidadEnvia = 300.50, IdRecibe = 18, CantidadRecibe = 402.67, Fecha = new DateTime(2013, 2, 25, 9, 0, 0), MonedaOrigen = "USD", MonedaDestino = "SGD", CosteTransaccion = 3.50 },
            new Transaccion { Id = 15, IdEnvia = 19, CantidadEnvia = 400.80, IdRecibe = 20, CantidadRecibe = 548.34, Fecha = new DateTime(2020, 8, 11, 14, 15, 0), MonedaOrigen = "USD", MonedaDestino = "HKD", CosteTransaccion = 4.80 },
            new Transaccion { Id = 16, IdEnvia = 6, CantidadEnvia = 5000.95, IdRecibe = 7, CantidadRecibe = 7250.44, Fecha = new DateTime(2010, 12, 31, 11, 30, 0), MonedaOrigen = "USD", MonedaDestino = "NZD", CosteTransaccion = 50.95 },
            new Transaccion { Id = 17, IdEnvia = 8, CantidadEnvia = 3500.45, IdRecibe = 9, CantidadRecibe = 4270.87, Fecha = new DateTime(2017, 11, 5, 16, 45, 0), MonedaOrigen = "USD", MonedaDestino = "SEK", CosteTransaccion = 35.45 },
            new Transaccion { Id = 18, IdEnvia = 10, CantidadEnvia = 6000.25, IdRecibe = 11, CantidadRecibe = 7680.35, Fecha = new DateTime(2015, 3, 24, 18, 0, 0), MonedaOrigen = "USD", MonedaDestino = "NOK", CosteTransaccion = 60.25 },
            new Transaccion { Id = 19, IdEnvia = 12, CantidadEnvia = 4200.67, IdRecibe = 13, CantidadRecibe = 4980.12, Fecha = new DateTime(2019, 5, 22, 7, 30, 0), MonedaOrigen = "USD", MonedaDestino = "DKK", CosteTransaccion = 42.67 },
            new Transaccion { Id = 20, IdEnvia = 14, CantidadEnvia = 4800.85, IdRecibe = 15, CantidadRecibe = 6960.40, Fecha = new DateTime(2011, 10, 10, 20, 15, 0), MonedaOrigen = "USD", MonedaDestino = "PLN", CosteTransaccion = 48.85 },
            new Transaccion { Id = 21, IdEnvia = 16, CantidadEnvia = 5500.25, IdRecibe = 17, CantidadRecibe = 8030.50, Fecha = new DateTime(2021, 7, 18, 10, 0, 0), MonedaOrigen = "USD", MonedaDestino = "HUF", CosteTransaccion = 55.25 },
            new Transaccion { Id = 22, IdEnvia = 18, CantidadEnvia = 3100.34, IdRecibe = 19, CantidadRecibe = 4327.15, Fecha = new DateTime(2018, 4, 2, 15, 45, 0), MonedaOrigen = "USD", MonedaDestino = "CZK", CosteTransaccion = 31.34 },
            new Transaccion { Id = 23, IdEnvia = 20, CantidadEnvia = 2900.75, IdRecibe = 6, CantidadRecibe = 3357.86, Fecha = new DateTime(2014, 11, 19, 9, 15, 0), MonedaOrigen = "USD", MonedaDestino = "TRY", CosteTransaccion = 29.75 },
            new Transaccion { Id = 24, IdEnvia = 7, CantidadEnvia = 1700.44, IdRecibe = 8, CantidadRecibe = 2400.63, Fecha = new DateTime(2023, 8, 30, 12, 0, 0), MonedaOrigen = "USD", MonedaDestino = "ILS", CosteTransaccion = 17.44 },
            new Transaccion { Id = 25, IdEnvia = 9, CantidadEnvia = 650.92, IdRecibe = 10, CantidadRecibe = 995.71, Fecha = new DateTime(2012, 6, 5, 8, 30, 0), MonedaOrigen = "USD", MonedaDestino = "MYR", CosteTransaccion = 6.92 },
            new Transaccion { Id = 26, IdEnvia = 11, CantidadEnvia = 4500.55, IdRecibe = 12, CantidadRecibe = 6120.88, Fecha = new DateTime(2020, 1, 27, 14, 0, 0), MonedaOrigen = "USD", MonedaDestino = "THB", CosteTransaccion = 45.55 },
            new Transaccion { Id = 27, IdEnvia = 13, CantidadEnvia = 3800.68, IdRecibe = 14, CantidadRecibe = 4346.78, Fecha = new DateTime(2022, 4, 8, 11, 15, 0), MonedaOrigen = "USD", MonedaDestino = "IDR", CosteTransaccion = 38.68 },
            new Transaccion { Id = 28, IdEnvia = 15, CantidadEnvia = 2700.45, IdRecibe = 16, CantidadRecibe = 3159.52, Fecha = new DateTime(2013, 9, 15, 13, 0, 0), MonedaOrigen = "USD", MonedaDestino = "PHP", CosteTransaccion = 27.45 },
            new Transaccion { Id = 29, IdEnvia = 17, CantidadEnvia = 1900.34, IdRecibe = 18, CantidadRecibe = 2652.87, Fecha = new DateTime(2016, 12, 22, 15, 45, 0), MonedaOrigen = "USD", MonedaDestino = "VND", CosteTransaccion = 19.34 },
            new Transaccion { Id = 30, IdEnvia = 19, CantidadEnvia = 5100.15, IdRecibe = 20, CantidadRecibe = 6120.57, Fecha = new DateTime(2024, 10, 18, 18, 0, 0), MonedaOrigen = "USD", MonedaDestino = "EGP", CosteTransaccion = 51.15 }
        );

        modelBuilder.Entity<Contacto>().HasData(
            new Contacto { Id = 1, ClienteOrigenId = 1, ClienteDestinoId = 5 },
            new Contacto { Id = 2, ClienteOrigenId = 2, ClienteDestinoId = 10 },
            new Contacto { Id = 3, ClienteOrigenId = 3, ClienteDestinoId = 15 },
            new Contacto { Id = 4, ClienteOrigenId = 4, ClienteDestinoId = 8 },
            new Contacto { Id = 5, ClienteOrigenId = 5, ClienteDestinoId = 20 },
            new Contacto { Id = 6, ClienteOrigenId = 6, ClienteDestinoId = 14 },
            new Contacto { Id = 7, ClienteOrigenId = 7, ClienteDestinoId = 3 },
            new Contacto { Id = 8, ClienteOrigenId = 8, ClienteDestinoId = 16 },
            new Contacto { Id = 9, ClienteOrigenId = 9, ClienteDestinoId = 2 },
            new Contacto { Id = 10, ClienteOrigenId = 10, ClienteDestinoId = 12 },
            new Contacto { Id = 11, ClienteOrigenId = 11, ClienteDestinoId = 7 },
            new Contacto { Id = 12, ClienteOrigenId = 12, ClienteDestinoId = 9 },
            new Contacto { Id = 13, ClienteOrigenId = 13, ClienteDestinoId = 1 },
            new Contacto { Id = 14, ClienteOrigenId = 14, ClienteDestinoId = 18 },
            new Contacto { Id = 15, ClienteOrigenId = 15, ClienteDestinoId = 4 },
            new Contacto { Id = 16, ClienteOrigenId = 16, ClienteDestinoId = 13 },
            new Contacto { Id = 17, ClienteOrigenId = 17, ClienteDestinoId = 6 },
            new Contacto { Id = 18, ClienteOrigenId = 18, ClienteDestinoId = 11 },
            new Contacto { Id = 19, ClienteOrigenId = 19, ClienteDestinoId = 17 },
            new Contacto { Id = 20, ClienteOrigenId = 20, ClienteDestinoId = 19 },
            new Contacto { Id = 21, ClienteOrigenId = 1, ClienteDestinoId = 7 },
            new Contacto { Id = 22, ClienteOrigenId = 2, ClienteDestinoId = 5 },
            new Contacto { Id = 23, ClienteOrigenId = 3, ClienteDestinoId = 9 },
            new Contacto { Id = 24, ClienteOrigenId = 4, ClienteDestinoId = 13 },
            new Contacto { Id = 25, ClienteOrigenId = 5, ClienteDestinoId = 3 },
            new Contacto { Id = 26, ClienteOrigenId = 6, ClienteDestinoId = 20 },
            new Contacto { Id = 27, ClienteOrigenId = 7, ClienteDestinoId = 14 },
            new Contacto { Id = 28, ClienteOrigenId = 8, ClienteDestinoId = 11 },
            new Contacto { Id = 29, ClienteOrigenId = 9, ClienteDestinoId = 15 },
            new Contacto { Id = 30, ClienteOrigenId = 10, ClienteDestinoId = 4 },
            new Contacto { Id = 31, ClienteOrigenId = 11, ClienteDestinoId = 8 },
            new Contacto { Id = 32, ClienteOrigenId = 12, ClienteDestinoId = 1 },
            new Contacto { Id = 33, ClienteOrigenId = 13, ClienteDestinoId = 19 },
            new Contacto { Id = 34, ClienteOrigenId = 14, ClienteDestinoId = 6 },
            new Contacto { Id = 35, ClienteOrigenId = 15, ClienteDestinoId = 10 },
            new Contacto { Id = 36, ClienteOrigenId = 16, ClienteDestinoId = 2 },
            new Contacto { Id = 37, ClienteOrigenId = 17, ClienteDestinoId = 18 },
            new Contacto { Id = 38, ClienteOrigenId = 18, ClienteDestinoId = 16 },
            new Contacto { Id = 39, ClienteOrigenId = 19, ClienteDestinoId = 12 },
            new Contacto { Id = 40, ClienteOrigenId = 20, ClienteDestinoId = 17 },
            new Contacto { Id = 41, ClienteOrigenId = 1, ClienteDestinoId = 14 },
            new Contacto { Id = 42, ClienteOrigenId = 2, ClienteDestinoId = 6 },
            new Contacto { Id = 43, ClienteOrigenId = 3, ClienteDestinoId = 11 },
            new Contacto { Id = 44, ClienteOrigenId = 4, ClienteDestinoId = 20 },
            new Contacto { Id = 45, ClienteOrigenId = 5, ClienteDestinoId = 7 },
            new Contacto { Id = 46, ClienteOrigenId = 6, ClienteDestinoId = 9 },
            new Contacto { Id = 47, ClienteOrigenId = 7, ClienteDestinoId = 1 },
            new Contacto { Id = 48, ClienteOrigenId = 8, ClienteDestinoId = 4 },
            new Contacto { Id = 49, ClienteOrigenId = 9, ClienteDestinoId = 13 },
            new Contacto { Id = 50, ClienteOrigenId = 10, ClienteDestinoId = 3 },
            new Contacto { Id = 51, ClienteOrigenId = 11, ClienteDestinoId = 8 },
            new Contacto { Id = 52, ClienteOrigenId = 12, ClienteDestinoId = 15 },
            new Contacto { Id = 53, ClienteOrigenId = 13, ClienteDestinoId = 18 },
            new Contacto { Id = 54, ClienteOrigenId = 14, ClienteDestinoId = 16 },
            new Contacto { Id = 55, ClienteOrigenId = 15, ClienteDestinoId = 2 },
            new Contacto { Id = 56, ClienteOrigenId = 16, ClienteDestinoId = 12 },
            new Contacto { Id = 57, ClienteOrigenId = 17, ClienteDestinoId = 19 },
            new Contacto { Id = 58, ClienteOrigenId = 18, ClienteDestinoId = 5 },
            new Contacto { Id = 59, ClienteOrigenId = 19, ClienteDestinoId = 14 },
            new Contacto { Id = 60, ClienteOrigenId = 20, ClienteDestinoId = 9 },
            new Contacto { Id = 61, ClienteOrigenId = 1, ClienteDestinoId = 10 },
            new Contacto { Id = 62, ClienteOrigenId = 2, ClienteDestinoId = 3 },
            new Contacto { Id = 63, ClienteOrigenId = 3, ClienteDestinoId = 17 },
            new Contacto { Id = 64, ClienteOrigenId = 4, ClienteDestinoId = 11 },
            new Contacto { Id = 65, ClienteOrigenId = 5, ClienteDestinoId = 6 },
            new Contacto { Id = 66, ClienteOrigenId = 6, ClienteDestinoId = 8 },
            new Contacto { Id = 67, ClienteOrigenId = 7, ClienteDestinoId = 19 },
            new Contacto { Id = 68, ClienteOrigenId = 8, ClienteDestinoId = 2 },
            new Contacto { Id = 69, ClienteOrigenId = 9, ClienteDestinoId = 7 },
            new Contacto { Id = 70, ClienteOrigenId = 10, ClienteDestinoId = 1 },
            new Contacto { Id = 71, ClienteOrigenId = 11, ClienteDestinoId = 16 },
            new Contacto { Id = 72, ClienteOrigenId = 12, ClienteDestinoId = 4 },
            new Contacto { Id = 73, ClienteOrigenId = 13, ClienteDestinoId = 9 },
            new Contacto { Id = 74, ClienteOrigenId = 14, ClienteDestinoId = 13 },
            new Contacto { Id = 75, ClienteOrigenId = 15, ClienteDestinoId = 18 },
            new Contacto { Id = 76, ClienteOrigenId = 16, ClienteDestinoId = 10 },
            new Contacto { Id = 77, ClienteOrigenId = 17, ClienteDestinoId = 6 },
            new Contacto { Id = 78, ClienteOrigenId = 18, ClienteDestinoId = 12 },
            new Contacto { Id = 79, ClienteOrigenId = 19, ClienteDestinoId = 15 },
            new Contacto { Id = 80, ClienteOrigenId = 20, ClienteDestinoId = 11 },
            new Contacto { Id = 81, ClienteOrigenId = 1, ClienteDestinoId = 17 },
            new Contacto { Id = 82, ClienteOrigenId = 2, ClienteDestinoId = 8 },
            new Contacto { Id = 83, ClienteOrigenId = 3, ClienteDestinoId = 5 },
            new Contacto { Id = 84, ClienteOrigenId = 4, ClienteDestinoId = 14 },
            new Contacto { Id = 85, ClienteOrigenId = 5, ClienteDestinoId = 3 },
            new Contacto { Id = 86, ClienteOrigenId = 6, ClienteDestinoId = 18 },
            new Contacto { Id = 87, ClienteOrigenId = 7, ClienteDestinoId = 13 },
            new Contacto { Id = 88, ClienteOrigenId = 8, ClienteDestinoId = 19 },
            new Contacto { Id = 89, ClienteOrigenId = 9, ClienteDestinoId = 4 },
            new Contacto { Id = 90, ClienteOrigenId = 10, ClienteDestinoId = 7 },
            new Contacto { Id = 91, ClienteOrigenId = 11, ClienteDestinoId = 15 },
            new Contacto { Id = 92, ClienteOrigenId = 12, ClienteDestinoId = 6 },
            new Contacto { Id = 93, ClienteOrigenId = 13, ClienteDestinoId = 20 },
            new Contacto { Id = 94, ClienteOrigenId = 14, ClienteDestinoId = 1 },
            new Contacto { Id = 95, ClienteOrigenId = 15, ClienteDestinoId = 9 },
            new Contacto { Id = 96, ClienteOrigenId = 16, ClienteDestinoId = 11 },
            new Contacto { Id = 97, ClienteOrigenId = 17, ClienteDestinoId = 8 },
            new Contacto { Id = 98, ClienteOrigenId = 18, ClienteDestinoId = 2 },
            new Contacto { Id = 99, ClienteOrigenId = 19, ClienteDestinoId = 12 },
            new Contacto { Id = 100, ClienteOrigenId = 20, ClienteDestinoId = 10 }
            );
        modelBuilder.Entity<ConteoResult>().HasNoKey();

    }
    // Método para cargar los países desde un archivo JSON
    private List<Pais> LoadPaisesJson(string filePath)
    {
        var jsonString = File.ReadAllText(filePath);
        var paises = JsonSerializer.Deserialize<List<Pais>>(jsonString);
        return paises;
    }
}



