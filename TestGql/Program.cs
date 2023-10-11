using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;
using TestGql.Data;
using TestGql.Query;
using TestGql.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPooledDbContextFactory<TestGqlDbContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("ConnectionString")
));

builder.Services
    .AddGraphQLServer()
    .AllowIntrospection(true)
    .RegisterDbContext<TestGqlDbContext>(DbContextKind.Pooled)
    .AddQueryType<TestGqlQuery>()
    .AddType<LibroObjectType>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapGraphQL("/webapi/TestGql");

app.UseGraphQLVoyager("/webapi/TestGql-voyager", new VoyagerOptions() {
    GraphQLEndPoint = "/webapi/TestGql",
});

app.MapControllers();

app.Run();
