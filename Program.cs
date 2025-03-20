using Event_.Context;
using Event_.Domains;
using Event_.Interfaces;
using Event_.Repositories;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services // Acessa a coleção de serviços da aplicação (Dependency Injection)
    .AddControllers() // Adiciona suporte a controladores na API (MVC ou Web API)
    .AddJsonOptions(options => // Configura as opções do serializador JSON padrão (System.Text.Json)
    {
        // Configuração para ignorar propriedades nulas ao serializar objetos em JSON
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;

        // Configuração para evitar referência circular ao serializar objetos que possuem relacionamentos recursivos
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// Adiciona o contexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<Event_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//adicionar o repósitorio e a interface ao container de injeção de depêndencia
builder.Services.AddScoped<ITiposUsuariosRepository, TiposUsuariosRepository>();
builder.Services.AddScoped<ITiposEventosRepository, TiposEventosRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


//adicionar o serviço de Controllers
builder.Services.AddControllers();



var app = builder.Build();

//adicionar o mapeamento dos controllers
app.MapControllers();

app.Run();

