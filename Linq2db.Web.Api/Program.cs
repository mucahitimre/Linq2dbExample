using Linq2db.Web.Api;
using LinqToDB;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using LinqToDB.Data;
using LinqToDB.DataProvider.ClickHouse;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLinqToDBContext<AppDataConnection>((provider, options) =>
{
    var configuration = builder.Configuration.GetValue<string>("ConnectionStrings:ClickHouseConnectionString");
    return options
            .UseClickHouse(ClickHouseProvider.ClickHouseClient, configuration)
            .UseDefaultLogging(provider);
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataConnection = scope.ServiceProvider.GetService<AppDataConnection>();
    dataConnection.CreateTable<SmsLogDocument>(tableOptions: TableOptions.CreateIfNotExists);
    var useMockData = builder.Configuration.GetValue<bool>("UseMockData");
    if (useMockData && !dataConnection.GetTable<SmsLogDocument>().Any())
    {
        var mock = JsonConvert.DeserializeObject<List<SmsLogDocument>>(File.ReadAllText("ExampleData.json"));
        dataConnection.GetTable<SmsLogDocument>().BulkCopy(mock);
    }
}

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