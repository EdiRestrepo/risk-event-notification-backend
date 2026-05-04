using Confluent.Kafka;
using RiskEventNotifacion.Application.Interfaces;
using RiskEventNotifacion.Application.Services;
using RiskEventNotifacion.Domain.Interfaces;
using RiskEventNotifacion.Infraestructure.Interfaces;
using RiskEventNotifacion.Infraestructure.Persistence;
using RiskEventNotifacion.Infraestructure.Repositories;
using RiskEventNotifacion.Presentation.Facades;
using RiskEventNotifacion.Presentation.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSignalR();


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

//Singletons
builder.Services.AddSingleton<MySqlConnectionFactory>();

//Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAlertsService, AlertsService>();
builder.Services.AddScoped<IChannelsService, ChannelsService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<ITraceLogger, KafkaTraceLoggerProducer>();

//Facades
builder.Services.AddScoped<IAuthFacade, AuthFacade>();
builder.Services.AddScoped<IAlertsFacade, AlertsFacade>();
builder.Services.AddScoped<IChannelsFacade, ChannelsFacade>();

//Repository
builder.Services.AddScoped<IUsersApplicationRepository, UsersApplicationRepository>();
builder.Services.AddScoped<IUserChannelsRepository, UserChannelsRepository>();
builder.Services.AddScoped<IExternalNotificationLogsRepository, ExternalNotificationLogsRepository>();
builder.Services.AddScoped<IProcessTraceLogsRepository, ProcessTraceLogsRepository>();

//Host
builder.Services.AddHostedService<KafkaConsumerService>();

//Singletons
builder.Services.AddSingleton<
    IProducer<Null, String>>(
    sp =>
    {
        var configuration = sp.GetRequiredService<IConfiguration>();

        var config = new ProducerConfig
        {
            BootstrapServers = configuration["Kafka:BootstrapServers"]
        };

        return new ProducerBuilder<Null, String>(config).Build();
    });


builder.Services.AddSingleton<IKafkaProducerService, KafkaProducerService>();
builder.Services.AddSingleton<ITraceProducerService, TraceProducerService>();


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
