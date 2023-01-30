
using TraineAPI.Extentation;


var builder = WebApplication.CreateBuilder(args);

//register repositorymanegar 
builder.Services.ConfigreRepositoryManegar();
builder.Services.ConfigureSqlContext(builder.Configuration);


// Add services to the container.
//register presentation layer to know place of controller 
builder.Services.AddControllers()
.AddApplicationPart(typeof(TraineAPI.Presentation.AssemblyReference).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
