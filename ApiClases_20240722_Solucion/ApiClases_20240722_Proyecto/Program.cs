var builder = WebApplication.CreateBuilder(args);

//Agregar servicio MVC
builder.Services.AddControllers();

//Agregar servicio swagger (OpenAPI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Agregar servicios a la aplicaci�n
var app = builder.Build();

//Configurar middleweare


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