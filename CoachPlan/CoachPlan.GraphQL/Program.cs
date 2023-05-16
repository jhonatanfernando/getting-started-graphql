using CoachPlan.Data.Context;
using CoachPlan.Data.Repositories;
using CoachPlan.Domain.Repositories;
using CoachPlan.GraphQL.Features;
using CoachPlan.GraphQL.Features.Exercise;
using CoachPlan.GraphQL.Features.Muscle;
using CoachPlan.Service.Services;
using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPooledDbContextFactory<CoachPlanContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IMuscleRepository, MuscleRepository>();
builder.Services.AddTransient<MuscleService>();
builder.Services.AddTransient<IExerciseRepository, ExerciseRepository>();
builder.Services.AddTransient<ExerciseService>();       

builder.Services
    .AddGraphQLServer()
    .RegisterService<MuscleService>()
    .RegisterService<ExerciseService>()
    .AddType<MuscleType>()
    .AddType<ExerciseType>()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWebSockets();

app.MapGraphQL();

app.UseGraphQLVoyager(options: new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql",
});

app.Run();

