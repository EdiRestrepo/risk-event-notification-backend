using RiskEventNotifacion.Application.Interfaces;
using RiskEventNotifacion.Application.Services;
using RiskEventNotifacion.Domain.Interfaces;
using RiskEventNotifacion.Infraestructure.Interfaces;
using RiskEventNotifacion.Infraestructure.Persistence;
using RiskEventNotifacion.Infraestructure.Repositories;
using RiskEventNotifacion.Infraestructure.Repositorys;
using RiskEventNotifacion.Presentation.Facades;
using RiskEventNotifacion.Presentation.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddSingleton<IKafkaProducerService, KafkaProducerService>();
builder.Services.AddHostedService<KafkaConsumerService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy
                .WithOrigins(
                    "http://localhost:4200"
                 )
                //.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        });
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Singetons
builder.Services.AddSingleton<MySqlConnectionFactory>();

//Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAlertsService, AlertsService>();
builder.Services.AddScoped<IChannelsService, ChannelsService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

//Facades
builder.Services.AddScoped<IAuthFacade, AuthFacade>();
builder.Services.AddScoped<IAlertsFacade, AlertsFacade>();
builder.Services.AddScoped<IChannelsFacade, ChannelsFacade>();

//Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUsersApplicationRepository, UsersApplicationRepository>();
builder.Services.AddScoped<IUserChannelsRepository, UserChannelsRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Risk Event Notifcacion API");
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();
app.MapHub<NotificationHub>("/notificationHub");
app.Run();
