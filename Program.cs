using PROJETO_ADVOCACIA.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddCustomDbContext(connection);
builder.Services.AddServices();

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");
app.UseDeveloperExceptionPage();


//DbContextExtensions.MigrationInit(app);

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

// rotas
app.AddRotas();


app.Run();

public partial class Program { }