using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;
using TestGQL.Data;
using TestGQL.Query;
using TestGQL.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPooledDbContextFactory<TestGQLDBContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("ConnectionString")
));

builder.Services
    .AddGraphQLServer()
    .AllowIntrospection(true)
    .AddQueryType<TestGQLQuery>()
    .AddType<LibroObjectType>()
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

app.UseEndpoints(endpoint =>
    endpoint.MapGraphQL("/webapi/TestGQL")
);

app.UseGraphQLVoyager("/webapi/TestGQL-voyager", new VoyagerOptions() {
    GraphQLEndPoint = "/webapi/TestGQL",
});

app.MapControllers();

app.Run();
