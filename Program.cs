using Jornada.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registrar o DbContext com o provedor do PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();



//app.MapPost("/feedbacks", async (AppDbContext context, Feedback feedback) =>
//{
//    context.Feedbacks.Add(feedback);
//    await context.SaveChangesAsync();
//    return Results.Created($"/feedbacks/{feedback.Id}", feedback);
//});

//app.MapGet("/feedbacks", (AppDbContext context) =>
//{
//    var feedbacks = context.Feedbacks.ToList();
//    return feedbacks;
//});


//app.MapPut("/feedbacks/{id}", async (AppDbContext context, int id, Feedback newFeedback) =>
//{
//    var feedback = await context.Feedbacks.FindAsync(id);

//    if (feedback == null) return Results.NotFound("Feedback not found");

//    feedback.Photo = newFeedback.Photo;
//    feedback.Message = newFeedback.Message;
//    feedback.Name = newFeedback.Name;
//    feedback.Id = newFeedback.Id;

//    await context.SaveChangesAsync();

//    return Results.Ok("Feedback updated with success!");
//});

//app.MapDelete("/feedbacks/{id:int}", async (AppDbContext context, int id) =>
//{
//    var feedback = await context.Feedbacks.FindAsync(id);

//    if (feedback == null) return Results.NotFound("Feedback not found");

//    context.Feedbacks.Remove(feedback);
//    await context.SaveChangesAsync();

//    return Results.Ok("Feedback deleted with success!");
//});

app.MapControllers();

app.Run();
