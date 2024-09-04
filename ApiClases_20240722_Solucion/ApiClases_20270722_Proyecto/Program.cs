﻿using Microsoft.EntityFrameworkCore.Migrations.Internal;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicio MVC
builder.Services.AddControllers();

// Agregar servicio swagger (OpenAPI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar servicios de repositorios y otros servicios
builder.Services.AddScoped<IRepositorioGenerico<Transaccion>, TransaccionRepositorioBBDD<Transaccion>>();
builder.Services.AddScoped<IRepositorioGenerico<Pais>, PaisRepositorioBBDD<Pais>>();
builder.Services.AddScoped<IRepositorioGenerico<Cliente>, ClienteRepositorioBBDD<Cliente>>();
builder.Services.AddScoped<IRepositorioGenerico<Contacto>, ContactosRepositorioBBDD<Contacto>>();
builder.Services.AddScoped<IServicioToken, ServicioToken>();
builder.Services.AddScoped<IContarPaisesConClientes, ContarPaisesConClientesRepositorio>();
builder.Services.AddScoped<IContarTransaccionesUltimos10AniosRepositorio, ContarTransaccionesUltimos10AniosRepositorio>();
builder.Services.AddScoped<IVistaContactoRepositorio<VContacto>, VistaContactosRepositorio>();
builder.Services.AddScoped<ContactosRepositorioBBDD<Contacto>>();

// Agregar BBDD (SQLServer)
builder.Services.AddDbContext<Contexto>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configurar Identity
builder.Services.AddIdentity<UsuarioAplicacion, IdentityRole>()
    .AddEntityFrameworkStores<Contexto>()
    .AddDefaultTokenProviders();

// Configurar JWT
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

// Añadir Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configuración de CORS para permitir solicitudes desde orígenes específicos.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder
            .WithOrigins("http://localhost:4200")  // Permite solicitudes desde localhost:4200.
            .AllowAnyHeader()  // Permite cualquier encabezado.
            .AllowAnyMethod()  // Permite cualquier método HTTP.
            .AllowCredentials());  // Permite el uso de credenciales.

    //options.AddPolicy("AllowAzureHost",
    //    builder => builder
    //        .WithOrigins("https://proud-stone-092ce9d03.5.azurestaticapps.net")  // Permite solicitudes desde el host de Azure.
    //        .AllowAnyHeader()  // Permite cualquier encabezado.
    //        .AllowAnyMethod()  // Permite cualquier método HTTP.
    //        .AllowCredentials());  // Permite el uso de credenciales.
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();

        });
});

// Agregar servicios a la aplicación
var app = builder.Build();

// Aplica las migraciones de base de datos.
ApplyMigrations(app);

// Crear roles
await CreateRoles(app);

// Comprobar si el entorno es de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Habilita Swagger en desarrollo.
    app.UseSwaggerUI();  // Habilita la interfaz de usuario de Swagger.
    // Redirect to Swagger UI automatically
    app.Use(async (context, next) =>
    {
        if (context.Request.Path == "/")
        {
            context.Response.Redirect("/swagger");
        }
        else
        {
            await next();
        }
    });
    // Allow Development
    app.UseCors("AllowLocalhost");
}
else
{
    // Allow Production
    app.UseCors("AllowAllOrigins");
    //app.UseCors("AllowAzureHost");

}

// Redirección a https
app.UseHttpsRedirection();

// Middleware de autenticación
app.UseAuthentication();

// Middleware de autorización
app.UseAuthorization();

// Middleware de enrutamiento --> determina qué acción y controlador se utilizará en función de la URL solicitada
app.MapControllers();

// Ejecutar la aplicación
app.Run();

async Task CreateRoles(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        string[] roleNames = { "Cliente", "Administrador" };
        IdentityResult roleResult;

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }



}
// M�todo para aplicar las migraciones de base de datos.
void ApplyMigrations(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<Contexto>();

        try
        {
            // Aplicar todas las migraciones pendientes
            dbContext.Database.Migrate();
            Console.WriteLine("Migraciones aplicadas exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al aplicar las migraciones: {ex.Message}");
            throw;
        }
    }
}