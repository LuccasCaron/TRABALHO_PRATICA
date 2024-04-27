using PROJETO_ADVOCACIA.Controllers;
using PROJETO_ADVOCACIA.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCustomDbContext();
builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

// rotas

app.RotasUser();
app.RotasAdvogado();
app.RotasCliente();
app.RotasEstagiario();

app.Run();
