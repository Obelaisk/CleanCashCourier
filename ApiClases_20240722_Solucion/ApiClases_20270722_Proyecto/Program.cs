using ApiClases_20270722_Proyecto.ContextoCarpeta;
using ApiClases_20270722_Proyecto.Repositorios;

var builder = WebApplication.CreateBuilder(args);

//Agregar servicio MVC
builder.Services.AddControllers();

//Agregar servicio swagger (OpenAPI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var dondeSacoDatos = "BBDD";
if(dondeSacoDatos == "memoria")
{
    //builder.Services.AddSingleton<IClienteRepositorio, ClienteRepositorioMemoria>();
}
else if(dondeSacoDatos == "csv")
{

    //builder.Services.AddSingleton<IClienteRepositorio, ClienteRepositorioCsv>();
}
else if(dondeSacoDatos == "BBDD") { 
    builder.Services.AddScoped<IRepositorioGenerico<Transaccion>, TransaccionRepositorioBBDD<Transaccion>>();
    
    builder.Services.AddScoped<IRepositorioGenerico<Pais>, PaisRepositorioBBDD<Pais>>();
    builder.Services.AddScoped<IRepositorioGenerico<Cliente>, ClienteRepositorioBBDD<Cliente>>();

}

// Agregar BBDD (SQLServer)
builder.Services.AddDbContext<Contexto>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//A�adir Autommaper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



builder.Services.AddCors(options =>

    {

        options.AddPolicy("AllowAllOrigins",

        builder =>

        {

            builder.AllowAnyOrigin()

    .AllowAnyMethod()

    .AllowAnyHeader();

        });

    });



    //Agregar servicios a la aplicaci�n
    var app = builder.Build();



app.UseCors("AllowAllOrigins");
//Comprobar si el entorno es de desarrollo

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Redirecci�n a https
app.UseHttpsRedirection();

//Middleweare de autorizaci�n 
app.UseAuthorization();

//Middleweare de enrutamiento --> determina que acci�n y controlador se utilizara en funci�n de la url solicitada
app.MapControllers();


app.Run();