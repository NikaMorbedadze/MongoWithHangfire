using Hangfire;
using Hangfire.Mongo;
using Hangfire.Mongo.Migration;
using Hangfire.Mongo.Migration.Strategies;
using Hangfire.Mongo.Migration.Strategies.Backup;
using MongoDB.Driver;
using MongoWithHangfire.Data;
using MongoWithHangfire.Entity;
using MongoWithHangfire.Service;
using MongoWithHangfire.Service.Interfaces;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var mongoConnection = builder.Configuration.GetConnectionString("HangfireConnection");
var migrationOptions = new MongoMigrationOptions
{
    MigrationStrategy = new DropMongoMigrationStrategy(),
    BackupStrategy = new CollectionMongoBackupStrategy()
};

builder.Services.AddHangfire(config =>
{
    config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170);
    config.UseSimpleAssemblyNameTypeSerializer();
    config.UseRecommendedSerializerSettings();
    config.UseMongoStorage(mongoConnection, "Hangfire",
        new MongoStorageOptions { MigrationOptions = migrationOptions });
});
builder.Services.AddHangfireServer();


builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<ICarService, CarService>();

//builder.Services.AddHangfire(x => x.UseMongoStorage(builder.Configuration.GetConnectionString("HangfireConnection"), storageOptions));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();