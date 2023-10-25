using Business;
using DataAccess;
using DataAccess.Providers;
using DataAccess.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication().AddJwtBearer();


// Add services to the container.


//DataAccess Layer
builder.Services.AddScoped<IUserDataAccessService, UserDataAccessProvider>();
builder.Services.AddScoped<IMeetingDataAccessService, MeetingDataAccessProvider>();


//Business Layer
builder.Services.AddScoped<IAuthenticationService, AuthenticationManager>();
builder.Services.AddScoped<IMeetingService,IMeetingService>();


//Singleton
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy( policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});




builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DocumentTitle = "MyMeetingHubAPI";
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "MyMeetingHubAPI");
    });
}

app.UseHttpsRedirection();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
